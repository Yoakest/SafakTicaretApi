using MediatR;

namespace SafakTicaret.Application.Features.User.Commands.GoogleLoginUser
{
	public class GoogleLoginUserCommandRequest : IRequest<GoogleLoginUserCommandResponse>
	{
		public string IdToken { get; set; }
		public string Name { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Provider { get; set; }

	}
}