using MediatR;
using RobotApocalypse.Models;

namespace RobotApocalypse.Dtos
{
    public class CreateSurvivorCommandDto : IRequest<long>
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public double LastLocationLatitude { get; set; }

        public double LastLocationLongitude { get; set; }

        public IEnumerable<int> Resources { get; set; }
    }
}
