using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.Dtos;

namespace WebApplication1.Repository.IRepository
{
    public interface IPostRepository
    {
        List<PostDto> GetAllPostFromFriends(int idUser);
        List<PostDto> GetAllPostByIdFriend(int idUSer);
        ICollection<Post> GetAllProfilePictures(int idUser);
        bool AddPost(PostCreateDto post);
        Post GetPostById(int idPost);
        bool Save();
    }
}
