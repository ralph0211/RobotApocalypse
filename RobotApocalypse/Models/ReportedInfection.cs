namespace RobotApocalypse.Models
{
    public class ReportedInfection
    {
        public long ReporterId { get; set; }

        public virtual Survivor Reporter { get; set; }

        public long InfectedSurvivorId { get; set; }

        public virtual Survivor InfectedSurvivor { get; set; }
    }
}
