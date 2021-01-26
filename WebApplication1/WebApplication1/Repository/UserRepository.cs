﻿using Microsoft.EntityFrameworkCore;
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
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool existEmail(string email)
        {
            bool exist = _db.User.Any(c => c.email.ToLower().Trim() == email.ToLower().Trim());
            return exist;
        }

        public bool existUsername(string username)
        {
            bool exist = _db.User.Any(c => c.username.ToLower().Trim() == username.ToLower().Trim());
            return exist;
        }


        public bool registerUser(User user)
        {
            _db.User.Add(user);
            return save();
        }

        public bool save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public User getUser(int idUSer)
        {
            return _db.User.FirstOrDefault(c => c.idUSer == idUSer);
            //return _db.User.Include(u => u.gender).Where(u => u.idGender ==)
        }

    }
}
