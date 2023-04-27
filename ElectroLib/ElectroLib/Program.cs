using ElectroLib.Entities;

namespace ElectroLib
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var db = new Connect.AppContext())
            {
                var user1 = new Users { Name = "Артур", Email="artur@gmail.com"};
                var user2 = new Users { Name = "Саша", Email = "sasha@yahoo.com" };
                var user3 = new Users { Name = "Миша", Email = "mish@gmail.com" };
                var user4 = new Users { Name = "Петя", Email = "pety@yahoo.com" };

               db.Users.Add(user1);
               db.Users.Add(user2);
               db.Users.Add(user3);
               db.Users.Add(user4);

                var book1 = new Books { Name = "Бесы",AuthorName="Достоевский", Style="Роман", YearRelease = 1871 };
                var book2 = new Books { Name = "Идиот", AuthorName = "Достоевский", Style = "Роман", YearRelease = 1867 };
                var book3 = new Books { Name = "Евгений Онегин", AuthorName = "Пушкин", Style = "Роман", YearRelease = 1832 };
                var book4 = new Books { Name = "Дубровский", AuthorName = "Пушкин", Style = "Проза", YearRelease = 1833 };

               db.Books.Add(book1);
               db.Books.Add(book2);
               db.Books.Add(book3);
               db.Books.Add(book4);

                book1.Users = user1;
                book2.Users = user1;
                user1.Book.Add(book3);
                user1.Book.Add(book4);

                db.SaveChanges();
            }
        }
    }
}