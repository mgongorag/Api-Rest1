using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.Dtos;

namespace WebApplication1.Repository.IRepository
{
    public interface IFriendRepository
    {
        bool addFriend(ListFriend listFriend);
        bool deleteFriend(ListFriendDto listFriend);
        bool existFriend(ListFriendDto listFriend);
        bool Save();

    }
}
