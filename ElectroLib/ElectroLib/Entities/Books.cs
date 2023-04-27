namespace ElectroLib.Entities
{
    public class Books
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? YearRelease { get; set; }
        public string? AuthorName { get; set; }
        public string? Style { get; set; }


        // Внешний ключ
        public int UsersId { get; set; }
        // Навигационное свойство
        public Users? Users { get; set; }
    }
}
