using System;
using Ardalis.GuardClauses;
using Domain.Common;
using Domain.Members;

namespace Domain.Subscriptions
{
    public class Subscription : Entity
    {
        private const int validAmountOfDays = 30;

        public DateTime StartsAt { get; set; }
        public DateTime EndsAt => StartsAt.AddDays(validAmountOfDays);
        public bool IsValid => EndsAt.Date >= DateTime.Today.Date;

        /// <summary>
        /// Entity Framework Core Constructor
        /// </summary>
        private Subscription() { }

        internal Subscription(DateTime startsAt)
        {
            StartsAt = Guard.Against.Null(startsAt.Date, nameof(startsAt));
        }

        public bool IsOverlapping(DateTime dateToCheck)
        {
            return dateToCheck.Date >= StartsAt.Date && dateToCheck.Date < EndsAt.Date;
        }
    }
}

