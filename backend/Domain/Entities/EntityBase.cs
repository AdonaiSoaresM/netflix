using prmToolkit.NotificationPattern;

namespace Domain.Entities
{
    public class EntityBase : Notifiable
    {
        public Guid Id { get; private set; }
    }
}