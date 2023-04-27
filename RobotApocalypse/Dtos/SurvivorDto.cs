using RobotApocalypse.Models;
using System.ComponentModel.DataAnnotations;

namespace RobotApocalypse.Dtos
{
    public class SurvivorDto
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public bool IsInfected { get; set; } = false;

        public double LastLocationLatitude { get; set; }

        public double LastLocationLongitude { get; set; }

        public virtual IEnumerable<Resource> Resources { get; set; }

        public virtual IEnumerable<ReportedInfection> InfectionReports { get; set; }
    }
}
