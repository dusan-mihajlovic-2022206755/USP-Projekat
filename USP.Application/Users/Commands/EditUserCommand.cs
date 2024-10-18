using MediatR;
using MongoDB.Entities;
using USP.Application.Common.Dto;
using USP.Application.Common.Mappers;

namespace USP.Application.Users.Commands;

public record EditUserCommand(EditUserDto User) : IRequest;

public class EditUserCommandHandler : IRequestHandler<EditUserCommand>
{
    public async Task Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = request.User.ToEntity();
            await entity.SaveAsync(cancellation: cancellationToken);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}