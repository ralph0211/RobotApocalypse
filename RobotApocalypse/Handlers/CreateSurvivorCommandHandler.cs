using MediatR;
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
            if (_context.Survivors == null)
            {
                throw new Exception("Entity set 'RobotContext.Survivors' is null.");
            }

            var survivor = new Survivor
            {
                Age = request.Age,
                Name = request.Name,
                Gender = request.Gender,
                LastLocationLatitude = request.LastLocationLatitude,
                LastLocationLongitude = request.LastLocationLongitude,
            };
            _context.Survivors.Add(survivor);
            await _context.SaveChangesAsync(cancellationToken);

            if (request.ResourceIds.Any())
            {
                foreach(var resourceId in request.ResourceIds)
                {
                    _context.SurvivorResources.Add(
                        new SurvivorResource
                            {
                                ResourceId = resourceId,
                                SurvivorId = survivor.Id,
                            });
                }

                await _context.SaveChangesAsync(cancellationToken);
            }

            return survivor.Id;
        }
    }
}
