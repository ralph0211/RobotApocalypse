using Microsoft.EntityFrameworkCore;

namespace RobotApocalypse.Models
{
    public class Survivor
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public bool IsInfected { get; set; } = false;

        public double LastLocationLatitude { get; set; }

        public double LastLocationLongitude { get; set; }

        public IEnumerable<Resource> Resources { get; set; }

        public virtual IEnumerable<ReportedInfection> InfectionReports { get; set; }

        //public int InfectionReportCount { get; set; }
    }
}
