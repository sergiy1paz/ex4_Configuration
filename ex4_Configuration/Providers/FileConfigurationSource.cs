using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ex4_Configuration.Providers
{
    public class FileConfigurationSource : IConfigurationSource
    {
        private readonly string _filePath;

        public FileConfigurationSource(string filePath)
        {
            _filePath = filePath;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            //string filePath = builder.GetFileProvider().GetFileInfo(_filePath).PhysicalPath;

            /**
             * В цьому місці передаю лише назву файлу в провайдер для того, 
             * щоб можна було зберегти файл в папці проекту 
             * а не в папці з exe - файлом (../bin/Debug/net5.0).
             * 
             * Коли намагаюсь отримати filePath за допомогою builder,
             * то він його шукає в папці з exe - файлом, тому для зручності перевірки роблю наступним чином
             * 
             */
            return new FileConfigurationProvider(_filePath);
        }
    }
}
