using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempLog
{
    public class AddConfigOptions
    {
        [Option('o',"outDir",Required = false, Default = "123", HelpText = "Local dir for save")]
        public string OutDir { get; set; }

        [Option('i',"inDir", Required = false, Default = "123", HelpText = "Saved dir on Google Space")]
        public string InDir { get; set; }

        [Option('e',"extentions", Required = false, Default = null, HelpText = "Extentions saved extensions.")]
        public IEnumerable<string>? FilesExtensions { get; set; }

        [Option('s', "save", Required = false, Default = false, HelpText = "Added extensions.")]
        public bool Save { get; set; }
    }
}
