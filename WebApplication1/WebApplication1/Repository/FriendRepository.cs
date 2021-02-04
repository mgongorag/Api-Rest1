using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.Dtos;
using WebApplication1.Repository.IRepository;

namespace WebApplication1.Repository
{
    public class FriendRepository : IFriendRepository
    {
        private readonly ApplicationDbContext _db;
        public FriendRepository ( ApplicationDbContext db)
        {
            _db = db;
        }

        public bool addFriend(ListFriend listFriendU)
        {
            using var transaction = _db.Database.BeginTransaction();
            bool success = false;

            try
            {
                _db.ListFriend.Add(listFriendU);
                success = Save();

                ListFriend listFriendF = new ListFriend();
                listFriendF.idUser = listFriendU.idFriend;
                listFriendF.idFriend = listFriendU.idUser;
                _db.ListFriend.Add(listFriendF);
                success = Save();
                transaction.Commit();
            }
            catch (Exception)
            {
                success = false;
                transaction.Rollback();
            }

            return success;
        }

        public bool deleteFriend(ListFriendDto listFriend)
        {
            throw new NotImplementedException();
        }

        public bool existFriend(ListFriendDto listFriend)
        {
            return _db.ListFriend.Any(lf => lf.idUser == listFriend.idUser && lf.idFriend == listFriend.idFriend);
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }
    }
}
