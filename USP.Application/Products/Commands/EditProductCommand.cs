using MediatR;
using MongoDB.Entities;
using USP.Application.Common.Dto;
using USP.Application.Common.Mappers;

namespace USP.Application.Products.Commands;

public record EditProductCommand(EditProductDto Product) : IRequest<ProductDetailsDto>;

public class EditProductCommandHandler : IRequestHandler<EditProductCommand, ProductDetailsDto?>
{
    public async Task<ProductDetailsDto?> Handle(EditProductCommand request, CancellationToken cancellationToken)
    {
        
        var entity = request.Product.ToEntityFromEditDto();
        await entity.SaveAsync(cancellation: cancellationToken);
        var dto = await entity.ToDtoAsync();

        return dto;
    }
}