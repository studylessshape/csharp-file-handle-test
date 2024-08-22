using System.Text;

const string DIRECTORY = "D:\\Projects\\s\\FileHandleTest\\FileDirectory";
const string PATH = "D:\\Projects\\s\\FileHandleTest\\FileDirectory\\file.txt";

var fileWatcher = new FileSystemWatcher(DIRECTORY, "file.txt");
fileWatcher.Changed += FileWatcher_Changed;
fileWatcher.Deleted += FileWatcher_Deleted;

void FileWatcher_Deleted(object sender, FileSystemEventArgs e)
{
    using var fileStream = new FileStream(PATH, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);

    fileStream.Write(Encoding.UTF8.GetBytes("recover did"));

    Console.WriteLine("Recover file");
}

static void FileWatcher_Changed(object sender, FileSystemEventArgs e)
{
    using var fileStream = new FileStream(PATH, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite);

    var bytes = new byte[1024].AsSpan();
    fileStream.Read(bytes);

    var content = Encoding.UTF8.GetString(bytes).Trim('\0');

    Console.WriteLine(content);
}


fileWatcher.EnableRaisingEvents = true;

Console.WriteLine("Start watch file \'{0}\'", PATH);
Console.WriteLine("Press \'ESC\' to exit");


while (true)
{
    if (Console.KeyAvailable)
    {
        var readKey = Console.ReadKey(true);
        if (readKey.Key == ConsoleKey.Escape)
        {
            break;
        }
    }
}