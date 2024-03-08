using CommandLine;

namespace TempLog
{
    class SaveOptions
    {
        [Option('n', "name", Required = false, Default = "123", HelpText = "Local dir for save")]
        public string OutDir { get; set; }
    }
}
