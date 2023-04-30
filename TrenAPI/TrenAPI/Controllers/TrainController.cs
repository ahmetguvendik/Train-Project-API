using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrenAPI.Inrerfaces;
using TrenAPI.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrenAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrainController : ControllerBase
    {
        private readonly IRezervasyonService _rezervasyonService;
        public TrainController(IRezervasyonService rezervasyonService)
        {
            _rezervasyonService = rezervasyonService;
        }
        [HttpPost]
        public IActionResult RezervasyonYap(Rezervasyon rezervasyon)
        {
            var yerlesimAyrinti = _rezervasyonService.RezervasyonYap(rezervasyon);

            if (yerlesimAyrinti.Count > 0)
            {
                return Ok(new
                {
                    RezervasyonYapilabilir = true,
                    YerlesimAyrinti = yerlesimAyrinti
                });
            }

            else
            {

                return Ok(new
                {
                
                    RezervasyonYapilabilir = false,
                    YerlesimAyrinti = new List<YerlesimAyrinti>()
                });
            }
        }
    }
}


