using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text.RegularExpressions;
using Ardalis.GuardClauses;
using Domain.Common;

namespace Domain.Members
{
    public class EmailAddress : ValueObject
    {
        private static Regex simpleMailRegex = new Regex("^(\\S+)@(\\S+)$", RegexOptions.Compiled);
        public string Value { get; } = default!;

        /// <summary>
        /// Entity Framework Core Constructor
        /// </summary>
        private EmailAddress() { }

        public EmailAddress(string value)
        {
            if (simpleMailRegex.IsMatch(value))
                Value = value.Trim();
            else
                throw new ArgumentException($"Email Address '{value}' is not valid.");

        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value.ToLowerInvariant();
        }
    }
}

