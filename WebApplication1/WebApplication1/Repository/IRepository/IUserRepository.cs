using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.Dtos;

namespace WebApplication1.Repository.IRepository
{
    public interface IUserRepository
    {

        bool registerUser(User user);
        bool existEmail(string email);
        bool existUsername(string username);
        User getUser(int idUSer);
        User LoginAuth(string user, string password);
        int numerOfFriends(int idUSer);
        bool save();
    }
}
