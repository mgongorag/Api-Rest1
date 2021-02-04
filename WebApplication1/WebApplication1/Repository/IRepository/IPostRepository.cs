﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repository.IRepository
{
    public interface IPostRepository
    {
        ICollection<Post> GetAllPostFromFriends(int idUser);
        ICollection<Post> GetAllPostByIdFriend(int idUSer);
        ICollection<Post> GetAllProfilePictures(int idUser);
        Post GetPostById(int idPost);
    }
}
