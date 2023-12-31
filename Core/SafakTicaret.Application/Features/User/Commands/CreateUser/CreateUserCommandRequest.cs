﻿using MediatR;

namespace SafakTicaret.Application.Features.User.Commands.CreateUser
{
	public class CreateUserCommandRequest : IRequest<CreateUserCommandResponse>
	{
		public string UserName { get; set; }
		public string NameSurname { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string RePassword { get; set; }

	}
}