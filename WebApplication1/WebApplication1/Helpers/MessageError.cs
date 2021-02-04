using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Helpers
{
    public static class MessageError
    {
        public const string
        NotSuccess = "Han error has been ocurred",
        Success = "Operation executed successfully ",
        FriendAlreadyExist = "Friend Already Exist",
        FriendHasAlreadyBeenRemoved = "Friend has already been bemoved",
        UserDontExist = "User don't exist",
        EmailExist = "Email already exist",
        UsernameExist = "This username is already in use ",
        NOT_FOUND = "The requested record does not exist",
        BAD_REQUEST = "Bad request, check the documentation";
    }
}
