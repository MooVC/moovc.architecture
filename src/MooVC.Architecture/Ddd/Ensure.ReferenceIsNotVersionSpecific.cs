﻿namespace MooVC.Architecture.Ddd
{
    using System;

    public static partial class Ensure
    {
        public static void ReferenceIsNotVersionSpecific<TAggregate>(
            Reference<TAggregate> reference,
            string argumentName,
            bool allowEmpty = false)
            where TAggregate : AggregateRoot
        {
            ReferenceIsNotVersionSpecific(
                reference,
                argumentName,
                string.Format(Resources.NonVersionSpecificReferenceRequired, typeof(TAggregate).Name),
                allowEmpty: allowEmpty);
        }

        public static void ReferenceIsNotVersionSpecific<TAggregate>(
            Reference<TAggregate> reference,
            string argumentName,
            string message,
            bool allowEmpty = false)
            where TAggregate : AggregateRoot
        {
            if (reference.IsVersionSpecific)
            {
                throw new ArgumentException(message, argumentName);
            }

            if (!allowEmpty)
            {
                ReferenceIsNotEmpty(reference, argumentName, message);
            }
        }
    }
}