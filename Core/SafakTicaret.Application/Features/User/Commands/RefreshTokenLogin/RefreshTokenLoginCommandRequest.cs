using MediatR;

namespace SafakTicaret.Application.Features.User.Commands.RefreshTokenLogin
{
	public class RefreshTokenLoginCommandRequest : IRequest<RefreshTokenLoginCommandResponse>
	{
		public string RefreshToken { get; set; }
	}
}
