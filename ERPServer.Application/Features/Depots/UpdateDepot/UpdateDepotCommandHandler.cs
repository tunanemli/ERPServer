﻿using AutoMapper;
using ERPServer.Domain.Entities;
using ERPServer.Domain.Repository;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Depots.UpdateDepot
{
    internal sealed class UpdateDepotCommandHandler(
        IDepotRepository depotRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper
        ) : IRequestHandler<UpdateDepotCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateDepotCommand request, CancellationToken cancellationToken)
        {
            Depot depot = await depotRepository.GetByExpressionWithTrackingAsync(p => p.Id == request.Id, cancellationToken);

            if (depot is null)
            {
                return Result<string>.Failure("Bu depoya ulaşılamıyor");
            }

            if(depot.Name != request.Name)
            {
                bool isDepotExists = await depotRepository.AnyAsync(p => p.Name == request.Name);
                if(isDepotExists)
                {
                    return Result<string>.Failure("Sistemde bu isimle kayıtlı depo var");
                }
                  
            }

            mapper.Map(request, depot);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Depo bilgileri başarıyla kaydedildi";
        }
    }
}
