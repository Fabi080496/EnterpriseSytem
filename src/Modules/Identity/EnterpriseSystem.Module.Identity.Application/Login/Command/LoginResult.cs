using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseSystem.Module.Identity.Application.Login.Command
{
    public record LoginResult(
        string Token,
        DateTime ExpiresAt);
}
