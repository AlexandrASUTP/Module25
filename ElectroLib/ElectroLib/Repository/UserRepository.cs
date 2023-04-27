using ElectroLib.Entities;

namespace ElectroLib.Repository
{
    public class UserRepository
    {
        Connect.AppContext db = new Connect.AppContext();

        public Users FindOfId (int i)
        {
            Users user = db.Users.FirstOrDefault(p => p.Id == i);
            if (user != null)
            Console.WriteLine(user.Name);
            return user;
        }
        public void FindAll()
        {
            var user = db.Users.ToList();
            if (user != null)
            foreach (var users in user)
            Console.WriteLine($"{users.Id}, {users.Name}, {users.Email}");
        }
        public void AddUser (string name, string email)
        {
            var user1 = new Users { Name = name, Email = email };
            db.Users.Add(user1);
        }
        public void DeliteUser(string name)
        {
            var user1 = new Users { Name = name};
            db.Users.Remove(user1);
        }
        public void UpdateUserName(int id, string name)
        {
            Users user = FindOfId(id);
            user.Name = name;
            db.SaveChanges();
        }

        /// <summary>
        /// Получать булевый флаг о том, есть ли определенная книга на руках у пользователя.
        /// </summary>
        /// <returns></returns>
        public bool BookIntoUser(string userName)
        {
            var userQuery = db.Users.Where(u => u.Name == userName);
            var userQuery1 = userQuery.ToList();
            var bookQuery = db.Books;
            var bookQuery1 = bookQuery.ToList();
            bool j = false;
            foreach (var i in bookQuery1)
            {
                foreach (var w in userQuery1)
                {
                    if (i.UsersId == w.Id) { j=true; };

                }
            }
            return j;
        }
        /// <summary>
        /// Получать количество книг на руках у пользователя.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public int NumberOfBookIntoUser(string userName)
        {
            var userQuery = db.Users.Where(u=>u.Name == userName);
            var userQuery1 = userQuery.ToList();
            var bookQuery = db.Books;
            var bookQuery1 = bookQuery.ToList();
            int j = 0;
            foreach (var i in bookQuery1)
            {
                foreach (var w in userQuery1)
                {
                    if (i.UsersId == w.Id) { j++; };
                    
                }
            }
            return j;
        }
       
    }
}
