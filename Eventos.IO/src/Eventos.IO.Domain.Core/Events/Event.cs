using System;

namespace Eventos.IO.Domain.Core.Events
{
    public abstract class Event : Message
    {
        public DateTime TimeStamp { get; set; }

        protected Event()
        {
            TimeStamp = DateTime.Now;
        }
    }
}