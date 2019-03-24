using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.Enums
{
    public enum ResponseStatus
    {
        None = 0,
        InternalException = 1,
        PasswordMismatch = 2,
        IncorrectPassword = 3,
        AlreadyExists = 4
    }
}
