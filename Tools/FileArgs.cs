namespace DelegatesEvents.Tools;

public class FileArgs : EventArgs
{
    public readonly string FileName;

    public bool Stop {  get; set; }

    public FileArgs(string fileName)
    {
        FileName = fileName;
    }
}
