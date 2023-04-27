using MediatR;
using Microsoft.EntityFrameworkCore;
using RobotApocalypse.Data;
using RobotApocalypse.Dtos;
using RobotApocalypse.Exceptions;
using RobotApocalypse.Models;

namespace RobotApocalypse.Handlers
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

            var alreadyReported = await _context.ReportedInfections.FirstOrDefaultAsync(ri => ri.SurvivorId == request.InfectedSurvivorId && ri.ReporterId == request.ReporterId);
            if (alreadyReported != null)
            {
                throw new DuplicateReportException("This reporter has already reported the survivor. Cannot add duplicate report!");
            }

            var report = new ReportedInfection
            {
                ReporterId = request.ReporterId,
                SurvivorId = request.InfectedSurvivorId,
            };
            _context.ReportedInfections.Add(report);
            await _context.SaveChangesAsync();

            var reportedInfectionsCount = await _context.ReportedInfections.Where(ri => ri.SurvivorId == request.InfectedSurvivorId).CountAsync();

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
