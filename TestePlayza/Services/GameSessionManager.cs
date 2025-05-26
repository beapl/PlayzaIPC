using System;
using System.Collections.Generic;
using System.Linq;
using Playza.Models;

namespace Playza.Services
{
    public class GameSessionManager
    {
        private static GameSessionManager _instance;
        public static GameSessionManager Instance => _instance ??= new GameSessionManager();

        public GameReport CurrentReport { get; private set; }

        private GameSessionManager()
        {
            CurrentReport = new GameReport();
        }

        public void AddMiniGameReport(MiniGameReport report)
        {
            CurrentReport.MiniGameReports.Add(report);
        }

        public void Reset()
        {
            CurrentReport = new GameReport();
        }
    }
}
