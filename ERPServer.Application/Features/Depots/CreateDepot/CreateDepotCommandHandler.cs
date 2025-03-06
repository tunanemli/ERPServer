using AutoMapper;
using ERPServer.Domain.Entities;
using ERPServer.Domain.Repository;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Depots.CreateDepot
{
    internal sealed class CreateDepotCommandHandler(
        IDepotRepository depotRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper
        
        ) : IRequestHandler<CreateDepotCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateDepotCommand request, CancellationToken cancellationToken)
        {
            bool depotNameExists = await depotRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);

            if ( depotNameExists)
            {
                return Result<string>.Failure("Bu isimli başka bir depo bulunuyor.");
            }

            Depot depot = mapper.Map<Depot>(request);

            await depotRepository.AddAsync(depot);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Depo Kaydı Başarıyla Tamamlandı";
        }
    }
}
