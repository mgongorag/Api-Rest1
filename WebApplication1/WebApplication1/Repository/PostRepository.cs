using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repository.IRepository;

namespace WebApplication1.Repository
{
    public class PostRepository : IPostRepository
    {

        private readonly ApplicationDbContext _db;
        public PostRepository (ApplicationDbContext db)
        {
            _db = db;
        }

        public ICollection<Post> GetAllPostByIdFriend(int idUSer)
        {
            return _db.Post.Where(p => p.idUser == idUSer).OrderByDescending(p => p.date).ToList();
        }

        public ICollection<Post> GetAllPostFromFriends(int idUser)
        {
            throw new NotImplementedException();
        }

        public ICollection<Post> GetAllProfilePictures(int idUser)
        {
            throw new NotImplementedException();
        }
    }
}
