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
    public class HeroesController : ApiController
    {
        private DataContext db = new DataContext();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        // GET: api/Heroes?guidId={guidId}
        public IQueryable<Hero> GetHeroes(int guidId)
        {
            return db.Heroes.Where(hero => hero.GuidId == guidId);
        }

        // GET: api/Heroes/5
        [ResponseType(typeof(Hero))]
        public IHttpActionResult GetHero(int id)
        {
            Hero hero = db.Heroes.Find(id);
            if (hero == null)
            {
                return NotFound();
            }

            return Ok(hero);
        }

        // PUT: api/Heroes/Training/5
        [HttpPut]
        [Route("api/Heroes/Training")]
        [ResponseType(typeof(void))]
        public IHttpActionResult TrainingHero(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Hero hero = db.Heroes.Find(id);
            if (hero == null)
            {
                return NotFound();
            }

            if (!HeroesTraining.Train(hero))
            {
                return StatusCode(HttpStatusCode.Forbidden);
            }

            db.Entry(hero).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                logger.Error(e, DateTime.Now.ToString());

                if (!HeroExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(hero);
        }

        // POST: api/Heroes
        [ResponseType(typeof(Hero))]
        public IHttpActionResult PostHero(Hero hero)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Heroes.Add(hero);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hero.Id }, hero);
        }

        // DELETE: api/Heroes/5
        [ResponseType(typeof(Hero))]
        public IHttpActionResult DeleteHero(int id)
        {
            Hero hero = db.Heroes.Find(id);
            if (hero == null)
            {
                return NotFound();
            }

            db.Heroes.Remove(hero);
            db.SaveChanges();

            return Ok(hero);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HeroExists(int id)
        {
            return db.Heroes.Count(e => e.Id == id) > 0;
        }
    }
}