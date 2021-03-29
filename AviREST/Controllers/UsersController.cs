﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AviBL;
using AviModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AviREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IAviBL _aviBL;

        public UsersController(IAviBL aviBL)
        {
            _aviBL = aviBL;
        }
        
        // GET: api/<UsersController>/
        [HttpGet]
        [Route("/api/User/email/{userEmail}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetUserByEmail(string userEmail)
        {
            var user = await _aviBL.GetUserByEmail(userEmail);
            if (user == null) return NotFound();
            return Ok(user); 
        }

        [HttpPost]
        [Route("/api/User/{userId}/{pilotId}")]
        [Produces("application/json")]
        public async Task<IActionResult> EditUser(int userId, int pilotId)
        {
            var user = await _aviBL.GetUserById(userId);
            var pilot = _aviBL.GetPilotByID(pilotId);
            Contributor contributer = null;
            if (user != null && pilot != null)
            {
                var result = _aviBL.GetContributorById(userId, pilotId);
                if (result == null)
                {
                    contributer = new Contributor();
                    contributer.UserID = userId;
                    contributer.PilotID = pilotId;
                    _aviBL.AddContributor(contributer);
                }
            }
            else
            {
                return NotFound();
            }
            return Ok(contributer);
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
