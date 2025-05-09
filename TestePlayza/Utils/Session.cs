using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Utils/Session.cs
using Playza.Models;

namespace Playza.Utils
{
    public static class Session
    {
        public static User CurrentUser { get; set; }
    }
}
