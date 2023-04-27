namespace ElectroLib.Entities
{
    public class Users
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        // Навигационное свойство
        public List<Books> Book { get; set; } = new List<Books>();
    }
}
