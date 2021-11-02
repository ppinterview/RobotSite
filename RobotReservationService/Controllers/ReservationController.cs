using System;
using System.Collections.Generic;
using System.Linq;
using RobotReservationService.Models;
using RobotReservationService.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RobotReservationService.Data;

namespace RobotReservationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private IReservationRepository reservationRepo;
        public ILogger log;

        public ReservationController(ILogger log) {
            this.reservationRepo = new ReservationRepository(new LiteDBProvider());
            this.log = log;
        }

        // GET api/reservation
        [HttpGet]
        public ActionResult<IEnumerable<Reservation>> Get() {
            return reservationRepo.All().ToArray();
        }

        // GET api/reservation/d17eeb84-6d52-49b7-b30c-f4b041016aca
        [HttpGet("{id}")]
        public ActionResult<Reservation> Get(Guid id) {
            return reservationRepo.GetById(id);
        }

        // POST api/reservation
        [HttpPost]
        public bool Post([FromBody] Reservation value) {
            var previousReservations = reservationRepo.All().Where(r => r.Id != value.Id && r.RobotName == value.RobotName && value.Username == value.Username);

            try {
                if (previousReservations.Any(r => DoPeriodsOverlap(r.StartTime, r.EndTime, value.StartTime, value.EndTime))) {
                    return false;
                }
            } catch (Exception e) {
                log.LogError("Couldn't check reservation", e);
            }

            reservationRepo.Update(value);
            return true;
        }

        // PUT api/reservation/d17eeb84-6d52-49b7-b30c-f4b041016aca
        [HttpPut("{id}")]
        public bool Put(Guid id, [FromBody] Reservation value) {
            var previousReservations = reservationRepo.All().Where(r => r.RobotName == value.RobotName && value.Username == value.Username);

            try {
                if (previousReservations.Any(r => DoPeriodsOverlap(r.StartTime, r.EndTime, value.StartTime, value.EndTime))) {
                    return false;
                }
                reservationRepo.Add(value);
            } catch (Exception e) {
                log.LogError("Couldn't check reservation", e);
                return false;
            }
            return true;
        }

        // DELETE api/reservation/d17eeb84-6d52-49b7-b30c-f4b041016aca
        [HttpDelete("{id}")]
        public bool Delete(Guid id) {
            try { 
                return this.reservationRepo.Delete(id);
            } catch { }
            return false;
        }

        public static bool DoPeriodsOverlap(DateTime aStart, DateTime aEnd, DateTime bStart, DateTime bEnd){
            if (aStart > aEnd) {
                throw new ArgumentException("A start can not be after its end.");
            }

            if (bStart > bEnd) {
                throw new ArgumentException("B start can not be after its end.");
            }

            return !((aEnd < bStart && aStart < bStart) ||
                        (bEnd < aStart && bStart < aStart));
        }
    }
}
