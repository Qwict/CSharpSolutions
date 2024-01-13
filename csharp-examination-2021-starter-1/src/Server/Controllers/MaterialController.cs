﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shared.Materials;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialService materialService;

        public MaterialController(IMaterialService materialService)
        {
            this.materialService = materialService;
        }

        // TODO: vraag 5 Filter
        [HttpGet]
        public Task<IEnumerable<MaterialDto.Index>> GetIndex(string Search)
        {
            return materialService.GetIndexAsync(Search);
        }
        
        
        [HttpPost]
        public Task<int> CreateAsync([FromBody] MaterialDto.Create material)
        {
            return materialService.CreateAsync(material);
        }
    }
}
