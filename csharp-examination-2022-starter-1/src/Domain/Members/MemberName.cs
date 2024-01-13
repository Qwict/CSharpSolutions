using System;
using System.Collections.Generic;
using Ardalis.GuardClauses;
using Domain.Common;

namespace Domain.Members
{
    public class MemberName : ValueObject
    {
        public string Firstname { get; } = default!;
        public string Lastname { get; } = default!;
        public string Fullname => this.ToString();

        /// <summary>
        /// Entity Framework Core Constructor
        /// </summary>
        private MemberName() { }

        public MemberName(string firstname, string lastname)
        {
            Firstname = Guard.Against.NullOrWhiteSpace(firstname.Trim(), nameof(Firstname));
            Lastname  = Guard.Against.NullOrWhiteSpace(lastname.Trim(), nameof(Lastname));
        }

        public override string ToString()
        {
            return $"{Firstname} {Lastname}";
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Lastname.ToLowerInvariant();
            yield return Firstname.ToLowerInvariant();
        }
    }
}

