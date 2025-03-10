using ERPServer.Domain.Entities;
using ERPServer.Domain.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace ERPServer.Application.Features.Recipes.GetByIdRecipeWithDetailsQuery
{
    internal sealed class GetByIdRecipeWithDetailsQueryHandler(IRecipeRepository recipeRepository) : IRequestHandler<GetByIdRecipeWithDetailsQuery, Result<Recipe>>
    {
        public async Task<Result<Recipe>> Handle(GetByIdRecipeWithDetailsQuery request, CancellationToken cancellationToken)
        {
            Recipe? recipe = await recipeRepository.Where(p => p.Id == request.Id)
                .Include(p=>p.Product)
                .Include(p => p.RecipeDetails!)
                .ThenInclude(p => p.Product)
                .FirstOrDefaultAsync(cancellationToken);

            if (recipe is null)
            {
                return Result<Recipe>.Failure("Ürüne ait reçete bulunamadı");
            }

            return recipe;
        }
    }
}
