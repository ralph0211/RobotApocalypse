using MediatR;

namespace RobotApocalypse.Dtos
{
    public class FlagSurvivorCommandDto : IRequest<string>
    {
        public long ReporterId { get; set; }

        public long InfectedSurvivorId { get; set; }
    }
}
