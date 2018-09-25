using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FrameFolderSyncTool
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Usage params: \"Source dir\" \"Target dir\"");
            }

            try
            {
                var sourcePath = args[0];
                var targetPath = args[1];
                var sourceDir = new DirectoryInfo(sourcePath);
                var targetDir = new DirectoryInfo(targetPath);
                if (!sourceDir.Exists)
                    throw new ArgumentException($"Source dir does not exist: {sourcePath}");
                if (!targetDir.Exists)
                    throw new ArgumentException($"Target dir does not exist: {targetPath}");
                if (sourceDir.Name != "Captures")
                    throw new ArgumentException($"Source dir must be named Captures: {sourcePath}");
                if (targetDir.Name != "Captures")
                    throw new ArgumentException($"Target dir must be named Captures: {targetPath}");
                while (true)
                {
                    var doneFileList = sourceDir.GetFiles("done", SearchOption.AllDirectories);
                    var movableDirectories =
                        doneFileList.Select(file => file.Directory).OrderBy(dir => dir.Name).ToArray();
                    foreach (var movableDir in movableDirectories)
                    {
                        var files = movableDir.GetFiles().OrderBy(file => file.Name).ToArray();
                        var moveTargetDir = new DirectoryInfo(Path.Combine(targetDir.FullName, movableDir.Name));
                        if(!moveTargetDir.Exists)
                            moveTargetDir.Create();
                        Console.Write($"Copying folder {moveTargetDir.Name}...");
                        foreach (var file in files)
                        {
                            var targetFile = Path.Combine(moveTargetDir.FullName, file.Name);
                            file.CopyTo(targetFile);
                            file.Delete();
                        }
                        Console.WriteLine(" done.");
                        movableDir.Delete();
                    }
                    await Task.Delay(10000);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error happened, exiting (press enter to exit):");
                Console.WriteLine(exception.ToString());
                Console.ReadLine();
            }
        }
    }
}
