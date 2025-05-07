using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui.Storage;
using Microcharts.Maui;
using SkiaSharp;

namespace Playza.Services
{
    public class UsageTracker
    {
        private DateTime _sessionStart;

        public void AppStarted()
        {
            _sessionStart = DateTime.Now;
        }

        public void AppClosed()
        {
            var sessionEnd = DateTime.Now;
            var duration = sessionEnd - _sessionStart;

            SaveUsage(duration);
        }

        private void SaveUsage(TimeSpan duration)
        {
            var today = DateTime.Today.ToString("yyyy-MM-dd");
            var key = $"usage_{today}";
            var previous = Preferences.Get(key, 0.0);
            var updated = previous + duration.TotalMinutes;

            Preferences.Set(key, updated);
        }

        public async Task<Dictionary<string, double>> GetUsageData()
        {
            var usage = new Dictionary<string, double>();

            // Usando Task.Run para fazer isso de forma assíncrona
            await Task.Run(() =>
            {
                for (int i = 0; i < 7; i++)
                {
                    var date = DateTime.Today.AddDays(-i).ToString("yyyy-MM-dd");
                    var minutes = Preferences.Get($"usage_{date}", 0.0);
                    usage[date] = minutes;
                }
            });

            return usage;
        }
    }
}
