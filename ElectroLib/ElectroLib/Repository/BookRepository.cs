using ElectroLib.Entities;

namespace ElectroLib.Repository
{
    public class BookRepository
    {
        Connect.AppContext db = new Connect.AppContext();

        public Books FindOfId(int i)
        {
            Books? book = db.Books.FirstOrDefault(p => p.Id == i);
            if (book != null)
                Console.WriteLine(book.Name);
            return book;
        }
        public void FindAll()
        {
            var book = db.Books.ToList();
            if (book != null)
                foreach (var books in book)
                    Console.WriteLine($"{books.Id}, {books.Name}, {books.YearRelease}");
        }
        public void AddBook(string name, int yearRelease)
        {
            var book1 = new Books { Name = name, YearRelease = yearRelease };
            db.Books.Add(book1);
        }
        public void DeliteBook(string name)
        {
            var book1 = new Books { Name = name };
            db.Books.Remove(book1);
        }
        public void UpdateYearReleaseBook(int id, int yearRelease)
        {
            Books book = FindOfId(id);
            book.YearRelease = yearRelease;
            db.SaveChanges();
        }
        /// <summary>
        /// Получать список книг определенного жанра и вышедших между определенными годами.
        /// </summary>
        /// <param name="yearRelease_low"></param>
        /// <param name="yearRelease_high"></param>
        /// <param name="style"></param>
        /// <returns></returns>
        public List<Books> BookSelectStileAndRangeYearRelease(int yearRelease_low, int yearRelease_high, string style)
        {
            var bookQuery = db.Books.Where(u => ((u.Style == style) && (u.YearRelease >= yearRelease_low) && (u.YearRelease <= yearRelease_high)));
            var books = bookQuery.ToList();
            return books;
        }

        /// <summary>
        /// Получать количество книг определенного автора в библиотеке.
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        public int NumberOfBookWithSelectAuthor(string author)
        {
            var bookQuery = db.Books.Where(u => ((u.AuthorName == author)));
            var books = bookQuery.ToList();
            int i = 0;
            foreach (var book in books)
            {
                i++;
            }
            return i;
        }
        /// <summary>
        /// Получать количество книг определенного жанра в библиотеке.
        /// </summary>
        /// <param name="style"></param>
        /// <returns></returns>
        public int NumberOfBookWithSelectStyle(string style)
        {
            var bookQuery = db.Books.Where(u => ((u.Style == style)));
            var books = bookQuery.ToList();
            int i = 0;
            foreach (var book in books)
            {
                i++;
            }
            return i;
        }
        /// <summary>
        /// Получать булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке.
        /// </summary>
        /// <param name="author"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool BookWithSelectAuthorAndName(string author, string name)
        {
            var bookQuery = db.Books.Any(u => ((u.AuthorName == author)&& (u.Name == name)));
            return bookQuery;
        }
        /// <summary>
        /// Получение последней вышедшей книги.
        /// </summary>
        /// <returns></returns>
        public List<Books> LastYearReleaseBook()
        {
            var book1 = db.Books.Max(u => u.YearRelease);
            var book2 = db.Books.Where(u => u.YearRelease == book1);
            var book = book2.ToList();
            return book;
        }
        /// <summary>
        /// Получение списка всех книг, отсортированного в алфавитном порядке по названию.
        /// </summary>
        /// <returns></returns>
        public List<Books> ListBooksOrderByDescending()
        {
            var book1 = db.Books.OrderByDescending(n => n.Name);
            var book = book1.ToList();
            return book;
        }
        /// <summary>
        /// Получение списка всех книг, отсортированного в порядке убывания года их выхода.
        /// </summary>
        /// <returns></returns>
        public List<Books> ListBooksOrderBy()
        {
            var book1 = db.Books.OrderBy(n => n.Name);
            var book = book1.ToList();
            return book;
        }
    }
}
