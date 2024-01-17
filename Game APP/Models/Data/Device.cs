
namespace Game_APP.Models.Data
{
    public class Device : BaseEntity
    {

        [MaxLength(length:50)]
        public string Icon { get; set; } = string.Empty;


        public  IEnumerable<GameDevice> GameDevices { get; set; } = new List<GameDevice>();


    }
}
