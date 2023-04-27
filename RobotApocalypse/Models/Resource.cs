using System.ComponentModel.DataAnnotations;

namespace RobotApocalypse.Models
{
    public class Resource
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
    }
}
