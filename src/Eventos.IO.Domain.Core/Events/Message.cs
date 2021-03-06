﻿using System;

namespace Eventos.IO.Domain.Core.Events
{
    public abstract class Message
    {
        public string MessageType { get; protected set; }
        public Guid AggreateId { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}