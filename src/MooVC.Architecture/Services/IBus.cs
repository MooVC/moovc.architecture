﻿namespace MooVC.Architecture.Services
{
    public interface IBus
    {
        void Invoke(Message message);
    }
}