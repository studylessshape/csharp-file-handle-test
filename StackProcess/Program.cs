const string PATH = "D:\\Projects\\s\\FileHandleTest\\FileDirectory\\file.txt";

using var fileStream = new FileStream(PATH, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite);

Console.WriteLine("Start occupy file \'{0}\'", PATH);
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