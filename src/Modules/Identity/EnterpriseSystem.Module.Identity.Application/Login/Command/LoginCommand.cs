using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseSystem.Module.Identity.Application.Login.Command
{
    public record LoginCommand(string Email, string Password)
        : IRequest<LoginResult>; 
}
