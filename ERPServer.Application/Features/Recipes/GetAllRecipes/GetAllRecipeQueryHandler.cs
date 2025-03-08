﻿using ERPServer.Domain.Entities;
using ERPServer.Domain.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace ERPServer.Application.Features.Recipes.GetAllRecipes
{
    internal sealed class GetAllRecipeQueryHandler(IRecipeRepository recipeRepository) : IRequestHandler<GetAllRecipesQuery, Result<List<Recipe>>>
    {
        public async Task<Result<List<Recipe>>> Handle(GetAllRecipesQuery request, CancellationToken cancellationToken)
        {
            List<Recipe> result = await recipeRepository.GetAll()
                .Include(p => p.Product)
                .OrderBy(p => p.Product!.Name)
                .ToListAsync(cancellationToken);

            return result;
        }
    }
}
