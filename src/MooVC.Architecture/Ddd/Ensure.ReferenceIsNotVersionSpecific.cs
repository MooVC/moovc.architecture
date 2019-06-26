﻿namespace MooVC.Architecture.Ddd
{
    using System;

    public static partial class Ensure
    {
        public static void ReferenceIsNotVersionSpecific<TAggregate>(Reference<TAggregate> reference, string argumentName)
            where TAggregate : AggregateRoot
        {
            if (reference.IsVersionSpecific)
            {
                throw new ArgumentException(string.Format(Resources.NonVersionSpecificReferenceRequired, typeof(TAggregate).Name), argumentName);
            }
        }
    }
}