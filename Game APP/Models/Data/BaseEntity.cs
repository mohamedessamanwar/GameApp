using System.ComponentModel.DataAnnotations;

namespace Game_APP.Models.Data
{
    public class BaseEntity
    {
        public int Id { get; set; }


        [MaxLength(length: 250)]
        public string Name { get; set; } = string.Empty;
    }
}
