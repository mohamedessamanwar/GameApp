
namespace Game_APP.Models.Data
{
    public class Game : BaseEntity
    {

        [MaxLength(length: 2500)]

        public string Description { get; set; } = string.Empty;

        [MaxLength(length: 500)]

        public string Cover { get; set; } = string.Empty;

        public int CategoryId { get; set; }


        public Category Category { get; set; } = default!;


        public IEnumerable<GameDevice> GameDevice { get; set; } = new List <GameDevice>();




    }
}
