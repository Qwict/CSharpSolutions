using System;
using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;
using Domain.Common;
using Domain.Subscriptions;

namespace Domain.Members
{
    public class Member : Entity
    {
        public MemberName Name { get; set; } = default!;
        public DateTime DateOfBirth { get; set; }
        public GenderType Gender { get; set; }
        public EmailAddress Email { get; set; } = default!;
        public Phonenumber Phone { get; set; } = default!;

        public IReadOnlyList<Subscription> Subscriptions => _subscriptions.AsReadOnly();
        private readonly List<Subscription> _subscriptions = new();

        /// <summary>
        /// Entity Framework Core Constructor
        /// </summary>
        private Member() { }

        public Member(MemberName name, DateTime dateOfBirth, GenderType gender, EmailAddress email, Phonenumber phone)
        {
            Name = Guard.Against.Null(name, nameof(name));
            DateOfBirth = Guard.Against.Null(dateOfBirth.Date, nameof(dateOfBirth));
            Gender = Guard.Against.Null(gender, nameof(gender));
            Email = Guard.Against.Null(email, nameof(email));
            Phone = Guard.Against.Null(phone, nameof(Phonenumber));
        }

        public void AddSubscription(DateTime startsAt)
        {
            // TODO: vraag 1: Domein (mag geen dubbels hebben)
            var subscription = new Subscription(startsAt);
            if (!HasOverlappingSubscriptions(startsAt)) 
                _subscriptions.Add(subscription);
            else 
                throw new ApplicationException("Overlapping subscription");
        }

        private bool HasOverlappingSubscriptions(DateTime startsAt)
        {
            if (_subscriptions.Any(x => x.IsOverlapping(startsAt)))
                return true;

            return false;
        }
    }
}

