using System;
using System.Collections.Generic;
using System.Linq;
using RobotReservationService.Models;
using RobotReservationService.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace RobotReservationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RobotController : ControllerBase
    {
        private IRobotRepository roboRepo;

        public RobotController(IRobotRepository roboRepo)
        {
            this.roboRepo = roboRepo;
        }

        // GET api/robot
        [HttpGet]
        public ActionResult<IEnumerable<Robot>> Get()
        {
            return roboRepo.All().ToArray();
        }

        // GET api/robot/d17eeb84-6d52-49b7-b30c-f4b041016aca
        [HttpGet("{id}")]
        public ActionResult<Robot> Get(Guid id)
        {
            return this.roboRepo.GetById(id);
        }

        // POST api/robot
        [HttpPost]
        public bool Post([FromBody] Robot value)
        {
            return this.roboRepo.Update(value);
        }

        // PUT api/robot/d17eeb84-6d52-49b7-b30c-f4b041016aca
        [HttpPut("{id}")]
        public bool Put(Guid id, [FromBody] Robot value)
        {
            value.Id = id;
            var robot = this.roboRepo.GetById(id);
            if (robot == null)
            {
                return this.roboRepo.Add(value);
            } else
            {
                return this.roboRepo.Update(value);
            }
        }

        // DELETE api/robot/d17eeb84-6d52-49b7-b30c-f4b041016aca
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            return this.roboRepo.Delete(id);
        }
    }
}
