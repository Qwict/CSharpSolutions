using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Materials;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Shared.Materials;

namespace Services.Materials
{
	public class MaterialService : IMaterialService
    {
        private readonly ApplicationDbContext dbContext;

        public MaterialService(ApplicationDbContext dbContext)
		{
            this.dbContext = dbContext;
        }

        public async Task<int> CreateAsync(MaterialDto.Create model)
        {
            var m = new Material(model.Name, model.Description);
            dbContext.Materials.Add(m);
            await dbContext.SaveChangesAsync();
            return m.Id;
        }

        public async Task<IEnumerable<MaterialDto.Index>> GetIndexAsync(string searchTerm)
        {
            // TODO: Antwoord 5: Filter
            var materials = new List<MaterialDto.Index>();
            if (string.IsNullOrEmpty(searchTerm))
            {
                materials =  await dbContext.Materials.Select(x => new MaterialDto.Index
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    InStock = x.InStock
                }).ToListAsync();
            }
            else
            {
                materials =  await dbContext.Materials.Select(x => new MaterialDto.Index
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    InStock = x.InStock
                    // TODO: vraag 5 Filter to name die START met searchTerm of description die containse
                }).Where(x => x.Name.StartsWith(searchTerm) || x.Description.Contains(searchTerm)).OrderBy(x => x.Name).ToListAsync();
            }

            return materials;
            
        }
    }
}

