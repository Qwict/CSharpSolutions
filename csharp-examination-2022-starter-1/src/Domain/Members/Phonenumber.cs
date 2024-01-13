using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Ardalis.GuardClauses;
using Domain.Common;

namespace Domain.Members
{
    public class Phonenumber : ValueObject
    {
        public string Value { get; } = default!;

        /// <summary>
        /// Entity Framework Core Constructor
        /// </summary>
        private Phonenumber() { }

        public Phonenumber(string value)
        {
            // TODO: vraag 2b Guard against null or whitespace 
            Value = Guard.Against.NullOrWhiteSpace(value.Replace(" ", ""));
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value.ToLowerInvariant();
        }
    }
}

