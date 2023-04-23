namespace RobotApocalypse.Models
{
    public class SurvivorResource
    {
        public long Id { get; set; }

        public long SurvivorId { get; set;}

        public virtual Survivor Survivor { get; set;}

        public int ResourceId { get; set;}

        public virtual Resource Resource { get; set;}
    }
}
