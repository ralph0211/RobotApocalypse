using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RobotApocalypse.Models
{
    public class ReportedInfection
    {
        [ForeignKey("Survivor")]
        public long ReporterId { get; set; }

        [ForeignKey("Survivor")]
        public long SurvivorId { get; set; }
    }
}
