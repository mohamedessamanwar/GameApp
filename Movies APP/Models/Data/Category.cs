namespace Game_APP.Models.Data
{
    public class Category : BaseEntity
    {

      
        public IEnumerable<Game> Games { get; set; } = new List<Game>(); // 1 Category has many Games
    }
}
