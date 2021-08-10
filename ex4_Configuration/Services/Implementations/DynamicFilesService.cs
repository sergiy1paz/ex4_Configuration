using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ex4_Configuration.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System.IO;
using ex4_Configuration.Models;

namespace ex4_Configuration.Services.Implementations
{
    public class DynamicFilesService : IDynamicFilesService
    {
        private const string PATH = @"DynamicFiles/";
        private readonly IConfiguration _configuration;

        public DynamicFilesService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task CreateAndWrite()
        {
            foreach (var fileName in Providers.FileConfigurationProvider.FileNames)
            {
                using (FileStream stream = new FileStream($"{PATH}{fileName}.{_configuration[fileName]}", FileMode.Create))
                {
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        var children = _configuration.GetSection(GetGroup(fileName)).GetChildren();

                        if (children is not null)
                        {
                            foreach (var child in children)
                            {
                                var user = child.Get<User>();
                                await writer.WriteLineAsync(user?.ToString());
                            }
                        }
                        
                    }
                }
            }
        }

        public Task Remove()
        {
            return Task.Run(() =>
            {
                var directory = Directory.GetCurrentDirectory();
                var folderPath = directory + @"/DynamicFiles/";
                foreach (var file in Directory.GetFiles(folderPath))
                {
                    if (file.Contains("README.txt"))
                    {
                        continue;
                    }
                    File.Delete(file);
                }
            });
            
        }

        private string GetGroup(string fileName)
        {
            var fN = fileName.ToLower();
            if (fN.Contains("employees")) return "employees";
            if (fN.Contains("customers")) return "customers";
            else return fileName;
        }
        
    }
}
