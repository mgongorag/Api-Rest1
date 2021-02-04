using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Helpers
{
    public enum ErrorCode
    {
        NotSuccess = 0,
        Success = 1,
        FriendAlreadyExist = 10,
        FriendHasAlreadyBeenRemoved = 11,
        UserDontExist = 12,
        EmailAlreadyExist = 13
    }
}
