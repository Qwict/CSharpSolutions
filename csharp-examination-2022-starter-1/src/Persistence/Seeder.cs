using Ardalis.GuardClauses;
using Bogus;
using Domain.Members;
using System;
using System.Linq;

namespace Persistence
{
    public class Seeder
    {
        private readonly ApplicationDbContext dbContext;

        public Seeder(ApplicationDbContext dbContext)
        {
            this.dbContext = Guard.Against.Null(dbContext,nameof(dbContext));
        }

        public void Seed()
        {
            Randomizer.Seed = new Random(1337);
            if (dbContext.Members.Any())
                return;

            GenerateMembers();
        }

        private void GenerateMembers()
        {
            var members = new MemberFaker(false).Generate(20);

            dbContext.AddRange(members);
            dbContext.SaveChanges();
        }
    }
}
