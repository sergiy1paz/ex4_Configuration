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
            string filePath = builder.GetFileProvider().GetFileInfo(_filePath).PhysicalPath;
            return new FileConfigurationProvider(filePath);
        }
    }
}
