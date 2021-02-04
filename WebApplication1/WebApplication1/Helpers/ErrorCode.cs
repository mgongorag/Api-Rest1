using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Helpers
{
    public enum ErrorCode
    {
        NotSuccess = 500,
        Success = 200,
        NotFound = 404,
        FriendAlreadyExist = 10,
        FriendHasAlreadyBeenRemoved = 11,
        UserDontExist = 12,
        EmailAlreadyExist = 13,
        USERNAME_IS_ALREADY_IN_USE = 14,
        BAD_REQUEST = 400
        
    }
}
