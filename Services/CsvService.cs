using CsvHelper;
using Library.Entities;
using System.Globalization;

namespace Library.Services;

public class CsvService
{
    private const string FilePath = "books.csv";

    public static void EnsureFileExistsAndHasHeader()
    {
        if (!File.Exists(FilePath))
        {
            using (var writer = new StreamWriter(FilePath, false))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                // Escreve o cabeçalho usando a classe Book
                csv.WriteHeader<Book>();
                csv.NextRecord();
            }
        }
    }

    public static List<Book> ReadFromCsv(bool includeDeleted = false)
    {
        EnsureFileExistsAndHasHeader();

        using (var reader = new StreamReader(FilePath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csv.GetRecords<Book>().ToList();

            if (includeDeleted)
            {
                return records;
            }

            return records.Where(b => b.QuantityInStock > 0).ToList();
        }
    }

    public static void AddBookToCsv(Book book)
    {
        // Certifica-se de que o arquivo e o cabeçalho existem antes de adicionar
        EnsureFileExistsAndHasHeader();

        using (var writer = new StreamWriter(FilePath, append: true))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteRecord(book);
            csv.NextRecord();
        }
    }

    public static void OverwriteBooksToCSV(List<Book> books)
    {
        using (var writer = new StreamWriter(FilePath))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteRecords(books);
        }
    }

    public static int NextId() 
    {
        List<Book> books = ReadFromCsv(true);

        return books.Any() ? books.Max(b => b.Id) + 1 : 1;
    }
}
