namespace Common;

public class FileReader
{
    public static string ReadFileContent(string fileName)
    {
        var path = Path.Combine($"{Directory.GetCurrentDirectory()}/Input", fileName);
        return File.ReadAllText(path);
    }
}