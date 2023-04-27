using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RobotApocalypse.Models
{
    public class SurvivorResource
    {
        [ForeignKey("Survivor")]
        public long SurvivorId { get; set;}

        [ForeignKey("Resource")]
        public int ResourceId { get; set;}
    }
}
