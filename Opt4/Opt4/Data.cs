using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Opt4
{
    internal class Data
    {
        public string Post { get; set; }
        public string B1 { get; set; }
        public string B2 { get; set; }
        public string B3 { get; set; }
        public string B4 { get; set; }
        public string Ost { get; set; }
        private string Pot { get; set; }

        public string GetPot()
        {
            return Pot;
        }
    }
}