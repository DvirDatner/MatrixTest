using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MatrixTest;
using NLog;

namespace MatrixTest
{
    public class TrainersController : ApiController
    {
        private DataContext db = new DataContext();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        // GET: api/Trainers
        public IQueryable<Trainer> GetTrainers()
        {
            return db.Trainers;
        }

        // GET: api/Trainers/5
        [ResponseType(typeof(Trainer))]
        public IHttpActionResult GetTrainer(int id)
        {
            Trainer trainer = db.Trainers.Find(id);
            if (trainer == null)
            {
                return NotFound();
            }

            return Ok(trainer);
        }

        // PUT: api/Trainers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTrainer(int id, Trainer trainer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbTrainer = db.Trainers.Find(id);
            if (id != trainer.Id || dbTrainer == null || trainer.GuidId != dbTrainer.GuidId)
            {
                return BadRequest();
            }

            db.Entry(trainer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                logger.Error(e, DateTime.Now.ToString());
                if (!TrainerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(trainer);
        }

        // POST: api/Trainers
        [ResponseType(typeof(Trainer))]
        public IHttpActionResult PostTrainer(Trainer trainer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Trainers.Add(trainer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = trainer.Id }, trainer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrainerExists(int id)
        {
            return db.Trainers.Count(e => e.Id == id) > 0;
        }
    }
}