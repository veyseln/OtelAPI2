using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ornek_Ders.Controllers.Models;
using Ornek_Ders.Data;
using Ornek_Ders.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Ornek_Ders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : Controller
    {
        private readonly ContacDbApiContext contacDbApiContext;

        public HotelsController(ContacDbApiContext contacDbApiContext)
        {
            this.contacDbApiContext = contacDbApiContext;
         
        }
        [HttpGet]
        [Route("Hotelget")]
        public IActionResult GetHotels()
        {

            return Ok(contacDbApiContext.Hotels.ToList());

        }
        [HttpPost]
        [Route("AddHotel")]
        public async Task<IActionResult> AddHotel(AddHotelRequest value)
        {
            var hotel = new Hotel()
            {
                Id = new int(),
                HotelCode = value.HotelCode,
                HotelName = value.HotelName,



            };
            await contacDbApiContext.Hotels.AddAsync(hotel);
            await contacDbApiContext.SaveChangesAsync();
            return Ok(hotel);
        }
    }
}
