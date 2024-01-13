using Domain.Common;
using Domain.Members;
using Ardalis.GuardClauses;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Domain.Groups
{
    public class Group : Entity
    {
        private readonly List<Member> _members = new();

        public string Name { get; set; }
        public IReadOnlyList<Member> Members => _members.AsReadOnly();

        private Group() { }

        public Group(string name)
        {
            // TODO: Antwoord vraag 2
            Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
        }

        public void AddMember(Member member)
        {
            // TODO: Antwoord vraag 1c
            Guard.Against.Null(member, nameof(member));
            
            // TODO: Antwoord vraag 1b
            Guard.Against.DuplicateMember(_members, member);
            
            // TODO: Antwoord vraag 1a
            _members.Add(member);
        }
    }
    
    public static class GuardExtensions
    {
        public static void DuplicateMember(this IGuardClause guardClause, IEnumerable<Member> members, Member member)
        {
            if (members.Contains(member))
                throw new ArgumentException("Member already exists in group");
        }
    }
}
