using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playza.Models
{
    public class GameReport
    {
        public List<MiniGameReport> MiniGameReports { get; set; } = new();
        public TimeSpan TotalTime => MiniGameReports.Aggregate(TimeSpan.Zero, (sum, next) => sum + next.TimeTaken);
    }

    public class MiniGameReport
    {
        public string GameName { get; set; }
        public TimeSpan TimeTaken { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }

}
