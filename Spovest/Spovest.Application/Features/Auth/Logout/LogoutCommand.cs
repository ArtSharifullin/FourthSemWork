using MediatR;

namespace Spovest.Application.Features.Auth.Logout
{
    public class LogoutCommand : IRequest<bool>
    {
        // Команда не требует дополнительных параметров
    }
}
