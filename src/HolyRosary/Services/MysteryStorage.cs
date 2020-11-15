using System.Linq;
using System.Text.Json;

using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Hosting;

using HolyRosary.Models;

namespace HolyRosary.Services
{
    public class MysteryStorage 
    {
        private readonly IMemoryCache cache;
        private const string FolderName = "data";

        public MysteryStorage(IMemoryCache cache)
        {
            this.cache = cache;
        }

        public bool LoadFiles(IWebHostEnvironment env) 
        {
            var files = env.WebRootFileProvider.GetDirectoryContents(FolderName).ToArray();

            foreach (var file in files)
            {
                var set = ReadFile(file);
                if(set == null) 
                {
                    continue;
                }

                var days = set.Days;
                foreach(var day in days) 
                {
                    cache.Set<MysterySet>(day.ToLowerInvariant(), set);
                }
            }

            return true;
        }

        private MysterySet ReadFile(IFileInfo file) 
        {
            using var stream = file.CreateReadStream();
            var set = JsonSerializer.DeserializeAsync<MysterySet>(stream).Result;

            return set;
        }
    }
}
