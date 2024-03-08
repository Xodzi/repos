using CommandLine;
using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Xml.Linq;
using TempLog;


Parser.Default.ParseArguments<AddConfigOptions>(args).MapResult((opts) =>
AddConfig(opts), //in case parser sucess
errs => HandleParseError(errs)); //in  case parser fail

Task AddConfig(AddConfigOptions opts)
{
    if (!opts.Save)
    {
        Console.WriteLine("false");
        return Task.CompletedTask;
    }
    if (!Directory.Exists(opts.OutDir))
    {
        Console.WriteLine("Dir doesn't exist");
        return Task.CompletedTask;
    }


    string jsonstr = File.ReadAllText("settings.json");
    List<Settings> settings = JsonSerializer.Deserialize<List<Settings>>(jsonstr);
    var set = new Settings { Extensions = opts.FilesExtensions.ToList(), InDir = opts.InDir, OutDir = opts.OutDir };
    settings.Add(set);


    string json = JsonSerializer.Serialize(settings);
    File.WriteAllText("settings.json", json);
    return Task.CompletedTask;
}
object HandleParseError(IEnumerable<Error> errs)
{
    Console.WriteLine(errs);
    return errs;
}