using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicWPF.Models.View
{
    internal class PatienDataGrid
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string? Note { get; set; }
        public string? Date { get; set; }
        public string? Anamnesis { get; set; }
        public string? Tests { get; set; }
    }
}
