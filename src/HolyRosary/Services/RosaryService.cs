using System;
using System.Collections.Generic;

using HolyRosary.Models;
using Microsoft.Extensions.Caching.Memory;

namespace HolyRosary.Services
{
    public class RosaryService
    {
        private readonly DateService dateService;
        private readonly IMemoryCache memoryCache;

        public RosaryService(DateService dateService, IMemoryCache memoryCache)
        {
            this.dateService = dateService;
            this.memoryCache = memoryCache;
        }

        public RosaryViewModel GetRosaryForDay(DateTime? date) 
        {
            if(date == null)
            {
                return null;
            }

            var today = date.GetValueOrDefault();

            var dayOfWeek = dateService.GetDayOfWeek(today);
            var set = FindMystery(dayOfWeek);
            if(set == null) 
            {
                return null;
            }

            var tomorrow = today.AddDays(1);
            var yesterday = today.AddDays(-1);

            var viewModel = new RosaryViewModel 
            {
                Today = today,
                Tomorrow = tomorrow,
                Yesterday = yesterday,
                Day = dayOfWeek,
                
                Title = set.Name
            };

            var mysteryList = new List<MysteryViewModel>();
            foreach(var mystery in set.Mysteries) 
            {
                var mysteryViewModel = new MysteryViewModel 
                {
                    Name = mystery.Name,
                    Event = mystery.Event,
                    Lesson = mystery.Lesson
                };

                mysteryList.Add(mysteryViewModel);
            }

            viewModel.Mysteries = mysteryList.ToArray();

            return viewModel;
        }

        private MysterySet FindMystery(string dayOfWeek) 
        {
            var key = dayOfWeek.ToLowerInvariant();
            var set = memoryCache.Get<MysterySet>(key);

            return set;
        }
    }
}
