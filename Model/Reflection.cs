using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desafios_academy.Model
{
    public class Reflection
    {
        public Reflection()
        {
            this.CreationTime = DateTime.Now;

            Guid guid = Guid.NewGuid();
            this.Id = guid.ToString();
        }

        public string Id { get; set; }
        public string Text { get; set; }
        public DateTime CreationTime { get; set; }
       
    }
}
