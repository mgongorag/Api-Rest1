using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class PostRepository : IPostRepository
    {

        private readonly ApplicationDbContext _db;
        public PostRepository (ApplicationDbContext db)
        {
            _db = db;
        }

        public bool AddPost(PostCreateDto post)
        {
            using var transaction = _db.Database.BeginTransaction();
            bool success = false;

            Post postDb = new Post();
            postDb.description = post.description;
            postDb.idUser = post.idUser;
            postDb.idTypePost = post.idTypePost;

            try
            {
                _db.Post.Add(postDb);
                success = Save();

                if(post.images != null)
                {
                    foreach (var image in post.images)
                    {
                        var imageDB = new ImagePost();
                        imageDB.idPost = postDb.idPost;
                        imageDB.path = image.path;
                        _db.Add(imageDB);
                        success = Save();
                    }
                }

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                success = false;
            }
            return success;
        }


        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public List<PostDto> GetAllPostByIdFriend(int idUSer)
        {
            List<PostDto> PostOfFriend = new List<PostDto>();
             
            using(var db = _db)
            {
                PostOfFriend = (from d in db.Post
                                where d.idUser == idUSer
                                orderby d.date descending
                                select new PostDto
                                {
                                    idPost = d.idPost,
                                    description = d.description,
                                    images = (
                                        from i in db.ImagePost
                                        where i.idPost == d.idPost
                                        && i.state == true
                                        orderby i.idImage
                                        select new ImagePostDto
                                        {
                                            idImage = i.idImage,
                                            path = i.path,
                                            idPost = i.idPost
                                        }
                                    ).ToList(),
                                    user = (
                                                from u in db.User
                                                where u.idUSer == d.idUser
                                                select new PostUserDto
                                                {
                                                    idUSer = u.idUSer,
                                                    firstName = u.firstName,
                                                    lastName = u.lastName,
                                                    username = u.username
                                                }
                                            ).FirstOrDefault(),
                                    typeOfPost = (
                                                    from t in db.TypeOfPost
                                                    where t.idTypeOfPost == d.idTypePost
                                                    select new TypeOfPost
                                                    {
                                                        idTypeOfPost = t.idTypeOfPost,
                                                        typePost = t.typePost
                                                    }
                                                 ).FirstOrDefault(),
                                }).ToList();
                                   
            }
            return PostOfFriend;
        }

        public List<PostDto> GetAllPostFromFriends(int idUser)
        {
            List<PostDto> PostOfFriend = new List<PostDto>();

            using (var db = _db)
            {
                PostOfFriend = (from u in db.User
                                join lf in db.ListFriend on u.idUSer equals lf.idUser
                                join friend in db.User on lf.idFriend equals friend.idUSer
                                join post in db.Post on lf.idFriend equals post.idUser
                                //join img in db.ImagePost on post.idPost equals img.idPost
                                where u.idUSer == idUser
                                select new PostDto
                                {
                                    idPost = post.idPost,
                                    description = post.description,
                                    images = (
                                            from img in db.ImagePost
                                            where img.idPost == post.idPost
                                            select new ImagePostDto
                                            {
                                                idImage = img.idImage,
                                                path = img.path,
                                                idPost = img.idPost
                                            }).ToList(),
                                    typeOfPost = (
                                                    from t in db.TypeOfPost
                                                    where t.idTypeOfPost == post.idTypePost
                                                    select new TypeOfPost
                                                    {
                                                        idTypeOfPost = t.idTypeOfPost,
                                                        typePost = t.typePost
                                                    }
                                                 ).FirstOrDefault(),
                                    user = (
                                                from u in db.User
                                                where u.idUSer == friend.idUSer
                                                select new PostUserDto
                                                {
                                                    idUSer = u.idUSer,
                                                    firstName = u.firstName,
                                                    lastName = u.lastName,
                                                    username = u.username
                                                }
                                            ).FirstOrDefault()
                                }).ToList();
            }
            return PostOfFriend;
        }

        public ICollection<Post> GetAllProfilePictures(int idUser)
        {
            throw new NotImplementedException();
        }

        public Post GetPostById(int idPost)
        {
            return _db.Post.FirstOrDefault(p => p.idPost == idPost);
        }
    }
}
