using System;
using System.Collections.Generic;
using Ardalis.GuardClauses;
using Domain.Common;

namespace Domain.Materials
{
	public class Material : Entity
	{
        private readonly List<Event> history = new();

        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool InStock { get; private set; } = true;

        public bool OutOfStock => !InStock;
        public IReadOnlyList<Event> History => history.AsReadOnly();

        private Material() { }

        public Material(string name, string description)
        {
            Name = Guard.Against.NullOrWhiteSpace(name,nameof(name));
            Description = description;
        }

        public void Borrow(string student)
        {
            // TODO: vraag 2: Guard clause, mighe not be usefull because student Event already protected
            var events = new Event(Guard.Against.NullOrWhiteSpace(student, nameof(student)), Event.ActionType.Borrow);
            if (OutOfStock)
            {
                throw new ApplicationException("Already borrowed");
            }
            InStock = false;
            
            // TODO: vraag 1b
            history.Add(events);
        }
    }
}

