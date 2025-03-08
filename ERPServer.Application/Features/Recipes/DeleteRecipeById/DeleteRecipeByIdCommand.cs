using ERPServer.Domain.Entities;
using ERPServer.Domain.Repository;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Recipes.DeleteRecipeById
{
    public sealed record DeleteRecipeByIdCommand(
        Guid Id
        ) : IRequest<Result<string>>;

    internal sealed class DeleteRecipeByIdHandler(
        IRecipeRepository recipeRepository,
        IUnitOfWork unitOfWork
        ) : IRequestHandler<DeleteRecipeByIdCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteRecipeByIdCommand request, CancellationToken cancellationToken)
        {
            Recipe recipe = await recipeRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);

            if( recipe is null )
            {
                return Result<string>.Failure("Bu reçeteye ulaşılamıyor");
            }

            recipeRepository.Delete(recipe);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Reçete başarıyla silindi";
        }
    }
}
