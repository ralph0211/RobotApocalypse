using MediatR;
using Microsoft.EntityFrameworkCore;
using RobotApocalypse.Data;
using RobotApocalypse.Dtos;
using RobotApocalypse.Models;

namespace RobotApocalypse.Handlers
{
    public class CreateSurvivorCommandHandler : IRequestHandler<CreateSurvivorCommandDto, long>
    {
        private readonly RobotContext _context;

        public CreateSurvivorCommandHandler(RobotContext context) { 
            _context = context;
        }
        public async Task<long> Handle(CreateSurvivorCommandDto request, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();
            if (_context.Survivors == null)
            {
                throw new Exception("Entity set 'RobotContext.Survivors' is null.");
            }

            var survivor = new Survivor
            {
                Age = request.Age,
                Name = request.Name,
                Gender = request.Gender,
                //IsInfected = request.IsInfected,
                LastLocationLatitude = request.LastLocationLatitude,
                LastLocationLongitude = request.LastLocationLongitude,
                Resources = request.Resources,
            };
            _context.Survivors.Add(survivor);
            await _context.SaveChangesAsync(cancellationToken);

            return survivor.Id;
        }
    }
}
