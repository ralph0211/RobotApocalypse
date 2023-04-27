using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RobotApocalypse.Models
{
    public class ReportedInfection
    {
        [ForeignKey("Survivor")]
        public long ReporterId { get; set; }

        [Required]
        public virtual Survivor Reporter { get; set; }

        [ForeignKey("Survivor")]
        public long InfectedSurvivorId { get; set; }
    }
}
