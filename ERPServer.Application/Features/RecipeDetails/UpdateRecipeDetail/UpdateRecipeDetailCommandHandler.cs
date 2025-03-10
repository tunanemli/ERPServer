using AutoMapper;
using ERPServer.Domain.Entities;
using ERPServer.Domain.Repository;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace ERPServer.Application.Features.RecipeDetails.UpdateRecipeDetail
{
    internal sealed class UpdateRecipeDetailCommandHandler(
        IRecipeDetailRepository recipeDetailRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork
        ) : IRequestHandler<UpdateRecipeDetailCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateRecipeDetailCommand request, CancellationToken cancellationToken)
        {
            RecipeDetail recipeDetail = await recipeDetailRepository
                .GetByExpressionWithTrackingAsync(p => p.Id ==request.Id, cancellationToken);

            if (recipeDetail is null)
            {
                return Result<string>.Failure("Reçetedeki ürünlere erişilemiyor");
            }

            RecipeDetail? oldProductExistsInThisRecipeDetail = await recipeDetailRepository.Where(p=> p.Id != request.Id
            && p.ProductId == request.ProductId && p.RecipeId == recipeDetail.RecipeId).FirstOrDefaultAsync(cancellationToken);
            if (oldProductExistsInThisRecipeDetail is not null)
            {
                recipeDetailRepository.Delete(recipeDetail);
                oldProductExistsInThisRecipeDetail.Quantity += request.Quantity;
                recipeDetailRepository.Update(oldProductExistsInThisRecipeDetail);
            }

            else
            {
                mapper.Map(request,recipeDetail);
            }
            
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Reçetedeki ürün başarıyla güncellendi.";
        }
    }
}
