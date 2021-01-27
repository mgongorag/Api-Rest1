using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repository.IRepository
{
    public interface ITypeOfNotificationRepository
    {
        ICollection<TypeOfNotifications> GetTypeOfNotifications();
        TypeOfNotifications GetTypeOfNotificationsById(int id);
    }
}
