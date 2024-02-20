namespace DelegatesEvents.Tools;

public class FilesEnumerator
{
    public delegate void OnFileFoundDelegate(object? sender, FileArgs args);

    public readonly string BaseDirectory;
    
    /// <summary>
    /// Пример с библиотечным делегатом
    /// </summary>
    public event EventHandler<FileArgs> FileFound1 = delegate { };

    /// <summary>
    /// Пример со своим делегатом
    /// </summary>
    public event OnFileFoundDelegate FileFound2;

    public FilesEnumerator(string baseDirectory)
    {
        BaseDirectory = baseDirectory;
    }

    public void Enumerate()
    {
        foreach (var file in Directory.EnumerateFiles(BaseDirectory))
        {
            var args = new FileArgs(file);
            FileFound1(this, args);
            FileFound2(this, args);

            if (args.Stop)
                break;
        }
    }
}
