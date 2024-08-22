using System.Text;

const string PATH = "D:\\Projects\\s\\FileHandleTest\\FileDirectory\\file.txt";
const string PATH_OTHER = "D:\\Projects\\s\\FileHandleTest\\FileDirectory\\file.txt";

using var fileStream = new FileStream(PATH_OTHER, FileMode.Create, FileAccess.Write, FileShare.Read);
//fileStream.SetLength(0);

fileStream.Write(Encoding.UTF8.GetBytes("writer did"));
Console.WriteLine("Write content!");

//var fileInfo = new FileInfo(PATH);
//using var stream = fileInfo.CreateText();
//stream.Write("writer did");