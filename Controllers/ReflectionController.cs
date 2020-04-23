using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Desafios_academy.Model;
using Microsoft.EntityFrameworkCore;


namespace Desafios_academy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReflectionController : ControllerBase
    {

        private readonly ReflectionContext _context;

        public ReflectionController(ReflectionContext context) => _context = context;


        //GET: /reflection
        [HttpGet]
        public ActionResult<IEnumerable<Reflection>> GetReflections()
        {
            return _context.ReflectionsItems;
        }

        //GET: /reflection/n
        [HttpGet("{id}")]
        public ActionResult<Reflection> GetReflectionItem(string id)
        {
            Reflection reflectionItem = _context.ReflectionsItems.Find(id);

            //If dont found
            if (reflectionItem == null)
            {
                return NotFound();
            }

            return reflectionItem;
        }

        //Post: /reflection
        [HttpPost]
        public ActionResult<Reflection> PostReflectionItem(Reflection reflection)
        {
            _context.ReflectionsItems.Add(reflection);
            _context.SaveChanges();

            //Poderia nao retornar nada tambem.
            return CreatedAtAction("GetReflectionItem", new Reflection { Id = reflection.Id }, reflection);
        }

        //Put: /reflection
        [HttpPut("{id}")]
        public ActionResult PutReflectionItem(string id, Reflection reflection)
        {
            //Nao posso dar permissao para o ID ser modificado
            if (id != reflection.Id)
            {
                return BadRequest();
            }

            _context.Entry(reflection).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        //DELETE: /reflection
        [HttpDelete("{id}")]
        public ActionResult<Reflection> DeleteReflectionItem(string id)
        {
            var ReflectionItem = _context.ReflectionsItems.Find(id);

            if (ReflectionItem == null)
            {
                return NotFound();
            }

            _context.ReflectionsItems.Remove(ReflectionItem);
            _context.SaveChanges();

            return ReflectionItem;


        }
    }
}
