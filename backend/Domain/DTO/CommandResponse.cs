using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class CommandResponse
    {
        public bool Sucess { get; set; }
        public object Data { get; set; }
        public IEnumerable<Notification> Notifications { get; set; }

        public CommandResponse(object data, INotifiable notifications)
        {
            Sucess = true;
            Data = notifications.IsValid() ? data : null;
            Notifications = notifications.Notifications;
        }

        public CommandResponse(INotifiable notifications)
        {
            Sucess = false;
            Data = null;
            Notifications = notifications.Notifications;
        }
    }
}