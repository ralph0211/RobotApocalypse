using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace RobotApocalypse.Models
{
    public class Survivor
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [MaxLength(10)]
        public string Gender { get; set; }

        public bool IsInfected { get; set; } = false;

        public double LastLocationLatitude { get; set; }

        public double LastLocationLongitude { get; set; }

        public virtual IEnumerable<Resource> Resources { get; set; }

        public virtual IEnumerable<ReportedInfection> InfectionReports { get; set; }
    }
}
