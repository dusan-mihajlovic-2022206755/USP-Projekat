using MediatR;
using MongoDB.Entities;
using USP.Application.Common.Dto;
using USP.Application.Common.Mappers;

namespace USP.Application.Products.Commands;

public record CreateProductCommand(ProductCreateDto Product) : IRequest<ProductDetailsDto?>;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDetailsDto?>
{
    public async Task<ProductDetailsDto?> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var userEntity = new Domain.Entities.User
        {
            Email = "pbisevac@singidunuma.ac.rs",
            FirstName = "Petar",
            LastName = "Bisevac",
        };

        var userEntity2 = new Domain.Entities.User
        {
            Email = "dusan.mihajlovic.22@singidunum.ac.rs",
            FirstName = "Dusan",
            LastName = "Mihajlovic",
        };

        await userEntity.SaveAsync(cancellation: cancellationToken);
        await userEntity2.SaveAsync(cancellation: cancellationToken);

        var entity = request.Product.ToEntityFromCreateDto(userEntity, new One<Domain.Entities.User>(userEntity));
        await entity.SaveAsync(cancellation: cancellationToken);
        await entity.ReferencedOneToManyUser.AddAsync([userEntity2, userEntity], cancellation: cancellationToken);
        await entity.ReferencedManyToManyUser.AddAsync([userEntity2, userEntity], cancellation: cancellationToken);

        var dto = await entity.ToDtoAsync();

        return dto;
    }
}