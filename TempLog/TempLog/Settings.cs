using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempLog
{
    public class Settings
    {
        public string OutDir { get; set; }
        public string InDir { get; set; }
        public List<string>? Extensions { get; set; }
    }
}
