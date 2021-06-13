using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salka.Data.Equipments.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController
    {
        public string Hello()
        {
            return "elo, jestem dostepny equipment";
        }
    }
}
