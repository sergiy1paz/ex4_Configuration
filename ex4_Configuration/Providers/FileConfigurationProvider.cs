using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ex4_Configuration.Providers
{
    public class FileConfigurationProvider : ConfigurationProvider
    {
        public static List<string> FileNames { get; private set; }

        private readonly string _filePath;

        public FileConfigurationProvider(string filePath)
        {
            _filePath = filePath;
        }

        public override void Load()
        {
            CreateConfig();
        }

        private void CreateConfig()
        {
            var data = new Dictionary<string, string>();
            FileNames = new List<string>();
            using (FileStream stream = new FileStream(_filePath, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var pair = line.Trim().Split("=");
                        data.Add(pair[0], pair[1].ToLower());
                        FileNames.Add(pair[0]);
                    }
                }
            }
            Data = data;
        }
    }
}
