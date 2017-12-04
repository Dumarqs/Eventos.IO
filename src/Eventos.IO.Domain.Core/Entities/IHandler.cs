using Eventos.IO.Domain.Core.Events;

namespace Eventos.IO.Domain.Core.Entities
{
    public interface IHandler<in T> where T: Message
    {
        void Handle(T message);
    }
}