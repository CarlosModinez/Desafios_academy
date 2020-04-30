using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Desafios_academy.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System.Linq;

namespace Desafios_academy.Controllers
{
    public class ExactQueryParamAttribute : Attribute, IActionConstraint
    {
        private readonly string[] keys;

        public ExactQueryParamAttribute(params string[] keys)
        {
            this.keys = keys;
        }

        public int Order => 0;

        public bool Accept(ActionConstraintContext context)
        {
            var query = context.RouteContext.HttpContext.Request.Query;
            return query.Count == keys.Length && keys.All(key => query.ContainsKey(key));
        }
    }


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

        //GET: /reflection/id 
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

        //GET: /refllection?from=20032020&to=24032020
        [HttpGet]
        [ExactQueryParam("from", "to")]
        public ActionResult<IEnumerable<Reflection>> GetReflectionsBetweenDates(string from, string to)
        {

            from = from.Insert(2, "/");
            from = from.Insert(5, "/");

            to = to.Insert(2, "/");
            to = to.Insert(5, "/");

            DateTime toDate = DateTime.ParseExact(to, "dd/MM/yyyy", null);
            DateTime fromDate = DateTime.ParseExact(from, "dd/MM/yyyy", null);
            IQueryable<Reflection> reflectionItems;

            reflectionItems = _context.ReflectionsItems.Where(x => x.CreationTime >= fromDate && x.CreationTime <= toDate.AddDays(1));
            return reflectionItems.ToList();

        }

        [HttpGet]
        [ExactQueryParam("from")]
        public ActionResult<IEnumerable<Reflection>> GetReflectionsFromDate(string from)
        {
            from = from.Insert(2, "/");
            from = from.Insert(5, "/");

            DateTime toDate = DateTime.Now;
            DateTime fromDate = DateTime.ParseExact(from, "dd/MM/yyyy", null);

            IQueryable<Reflection> reflectionItems = _context.ReflectionsItems.Where(x => x.CreationTime >= fromDate);

            return reflectionItems.ToList();
        }


        //Post: /reflection
        [HttpPost]
        public ActionResult<Reflection> PostReflectionItem(Reflection reflection)
        {
            //Se eu receber um Id ou uma data como parametro
            if (reflection.Text == null)
            {    
                return BadRequest();
            }
            
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