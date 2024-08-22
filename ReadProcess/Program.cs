using System.Text;

const string PATH = "D:\\Projects\\s\\FileHandleTest\\FileDirectory\\file.txt";

using var fileStream = new FileStream(PATH, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

var bytes = new byte[1024].AsSpan();
fileStream.Read(bytes);

var content = Encoding.UTF8.GetString(bytes).Trim('\0');

Console.WriteLine(content);