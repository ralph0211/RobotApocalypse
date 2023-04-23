using MediatR;
using Microsoft.EntityFrameworkCore;
using RobotApocalypse.Data;
using RobotApocalypse.Exceptions;
using RobotApocalypse.Models;

namespace RobotApocalypse.Dtos
{
    public class FlagSurvivorCommandHandler : IRequestHandler<FlagSurvivorCommandDto, string>
    {
        private readonly RobotContext _context;

        public FlagSurvivorCommandHandler(RobotContext context)
        {
            _context = context;
        }
        public async Task<string> Handle(FlagSurvivorCommandDto request, CancellationToken cancellationToken)
        {
            //pass reporter id and infected id. 
            //if 3 reports, survivor is marked as infected
            var reporter = await _context.Survivors.FindAsync(request.ReporterId);
            if (reporter == null)
            {
                throw new EntityNotFoundException("The reporting survivor has not been found");
            }

            var infectedSurvivor = await _context.Survivors.FindAsync(request.InfectedSurvivorId);
            if (infectedSurvivor == null)
            {
                throw new EntityNotFoundException("The reported survivor has not been found");
            }

            var report = new ReportedInfection
            {
                ReporterId = request.ReporterId,
                InfectedSurvivorId = request.InfectedSurvivorId,
            };
            _context.ReportedInfections.Add(report);
            await _context.SaveChangesAsync();

            var reportedInfectionsCount = await _context.ReportedInfections.Where(ri => ri.InfectedSurvivorId == request.InfectedSurvivorId).CountAsync();

            if (reportedInfectionsCount > 2)
            {
                infectedSurvivor.IsInfected = true;
                await _context.SaveChangesAsync();

                return "Survivor reported as infected. Report count now 3 or more so survivor has been flagged!";
            }

            return $"Survivor reported as infected. Report count now {reportedInfectionsCount}";
        }
    }
}
