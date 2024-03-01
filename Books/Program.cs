using System;
using System.Collections.Generic;
using System.IO;

class Book
{
    public string Name { get; set; }
    public string Author { get; set; }
    public DateTime DatePublished { get; set; }

    public Book(string name, string author, DateTime datePublished)
    {
        Name = name;
        Author = author;
        DatePublished = datePublished;
    }

    public override string ToString()
    {
        return $"Saxeli: {Name}, Avtori: {Author}, Gamocemis Tarigi: {DatePublished.ToShortDateString()}";
    }
}

class BookManager
{
    private List<Book> bookList;

    public BookManager()
    {
        bookList = new List<Book>();
    }

    public void LoadBooksFromFile(string filePath)
    {
        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    string name = parts[0].Trim();
                    string author = parts[1].Trim();
                    DateTime datePublished = DateTime.Parse(parts[2].Trim());
                    Book book = new Book(name, author, datePublished);
                    bookList.Add(book);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("failidan wignebis siis amogeba ver moxerxda: " + ex.Message);
        }
    }

    public void AddBook(Book book)
    {
        bookList.Add(book);
    }

    public void ShowAllBooks()
    {
        foreach (var book in bookList)
        {
            Console.WriteLine(book);
        }
    }

    public void SearchBookByName(string name)
    {
        bool found = false;
        foreach (var book in bookList)
        {
            if (book.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(book);
                found = true;
                break;
            }
        }
        if (!found)
        {
            Console.WriteLine("wigni ver moidzebna");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        BookManager manager = new BookManager();
        string filePath = "C:\\Users\\Lenovo\\Desktop\\books.txt"; 
        // Load books from file
        manager.LoadBooksFromFile(filePath);

        while (true)
        {            
            Console.WriteLine("1. wignis damateba");
            Console.WriteLine("2. wignebis siis naxva");
            Console.WriteLine("3. wignis saxelit modzebna");
            Console.WriteLine("4. dasruleba");
            Console.Write("sheiyvanet sasurveli operaciis nomeri: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("sheiyvanet wignis saxeli: ");
                    string name = Console.ReadLine();
                    Console.Write("sheiyvanet wignis avtori: ");
                    string author = Console.ReadLine();
                    Console.Write("sheiyvanet wignis gamocemis tarigi (MM/DD/YYYY): ");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
                    {
                        Book newBook = new Book(name, author, date);
                        manager.AddBook(newBook);
                        Console.WriteLine("wigni warmatebit daemata");
                    }
                    else
                    {
                        Console.WriteLine("araswori tarigis pormatis gamo wigni ver daemata");
                    }
                    break;
                case "2":
                    Console.WriteLine("wignebis sia:");
                    manager.ShowAllBooks();
                    break;
                case "3":
                    Console.Write("sheiyvanet sadziebo wignis saxeli: ");
                    string searchName = Console.ReadLine();
                    manager.SearchBookByName(searchName);
                    break;
                case "4":
                    Console.WriteLine("tkven gamoxvedit sistemidan");
                    return;
                default:
                    Console.WriteLine("araswori operaciis nomeri, sheiyvanet swori ricxvi");
                    break;
            }
        }
    }
}
