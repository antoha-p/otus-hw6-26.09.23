using System.Globalization;
using DelegatesEvents.Extensions;
using DelegatesEvents.Misc;
using DelegatesEvents.Tools;

namespace DelegatesEvents;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Started");

        #region Написать обобщённую функцию расширения

        //Написать обобщённую функцию расширения, находящую и возвращающую максимальный элемент коллекции.
        //Функция должна принимать на вход делегат, преобразующий входной тип в число для возможности поиска максимального значения.
        //public static T GetMax(this IEnumerable collection, Func<T, float> convertToNumber) where T : class;

        var collection1 = new List<ObjectItem<string>>
        {
            new("-10"),
            new("5"),
            new("7.7"),
            new("3.2"),
            new("0")
        };

        var max = collection1.GetMax(x =>
        {
            return float.Parse(x.Value, CultureInfo.InvariantCulture.NumberFormat);
        });

        Console.WriteLine($"floatCollection max.Value = {max?.Value}");

        #endregion

        #region Написать класс, обходящий каталог файлов

        //Написать класс, обходящий каталог файлов и выдающий событие при нахождении каждого файла;
        //Оформить событие и его аргументы с использованием.NET соглашений:
        //public event EventHandler FileFound;
        //FileArgs – будет содержать имя файла и наследоваться от EventArgs
        //Добавить возможность отмены дальнейшего поиска из обработчика;
        //Вывести в консоль сообщения, возникающие при срабатывании событий и результат поиска максимального элемента.

        var baseDirectory = "C:/";
        var filesEnumerator = new FilesEnumerator(baseDirectory);
        filesEnumerator.FileFound1 += OnFileFound;
        filesEnumerator.FileFound2 += OnFileFound;
        filesEnumerator.Enumerate();

        #endregion

        Console.ReadLine();
    }

    public static void OnFileFound(object? sender, FileArgs args)
    {
        var fileName = args.FileName;
        Console.WriteLine($"File found: {fileName}");

        if (fileName.Contains(".sys"))
        {
            args.Stop = true;
        }
    }
}
