using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repository.IRepository;

namespace WebApplication1.Repository
{
    public class TypeOfNotificationRepository : ITypeOfNotificationRepository
    {
        private readonly ApplicationDbContext _db;
        public TypeOfNotificationRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public ICollection<TypeOfNotifications> GetTypeOfNotifications()
        {
            return _db.TypeOfNotification.OrderBy(c => c.name).ToList();
        }

        public TypeOfNotifications GetTypeOfNotificationsById(int id)
        {
            return _db.TypeOfNotification.FirstOrDefault(c => c.idType == id);
        }
    }
}
