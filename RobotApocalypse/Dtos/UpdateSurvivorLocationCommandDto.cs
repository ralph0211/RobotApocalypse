namespace RobotApocalypse.Dtos
{
    public class UpdateSurvivorLocationCommandDto
    {
        public long SurvivorId { get; set; }

        public long NewLatitude { get; set; }

        public long NewLongitude { get; set; }
    }
}
