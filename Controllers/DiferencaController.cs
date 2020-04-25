using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Desafios_academy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiferencaController : ControllerBase
    {
        public IDictionary<string, int> Get(string date)
        {
    
            IDictionary<string, int> dict = new Dictionary<string, int>();
     
            //Ajusta a string date
            date = date.Insert(2, "/");
            date = date.Insert(5, "/");
            
            DateTime today = DateTime.Today;
            TimeSpan days = DateTime.ParseExact(date, "dd/MM/yyyy", null) - today;
            string daysS = Convert.ToString(days);
            string daysAmount = daysS.Substring(0, daysS.IndexOf("."));

            dict.Add("dias entre as datas", Convert.ToInt32(daysAmount));
            return dict;
        }
    }
}
