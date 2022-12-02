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
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteHotel([FromRoute] int id)
        {
            var hotel = await contacDbApiContext.Hotels.FindAsync(id);
            if (hotel != null)
            {
                contacDbApiContext.Remove(hotel);
                await contacDbApiContext.SaveChangesAsync();
                return Ok();
            }
            return NotFound();
        }
            [HttpPut]
            [Route("{id:int}")]
            public async Task<IActionResult> UpdateHotel([FromRoute] int id, UpdateHotelRequest updateHotelRequest)

            {
                var hotel = await contacDbApiContext.Hotels.FindAsync(id);
                if (hotel != null)
                {
                    hotel.HotelCode= updateHotelRequest.HotelCode;

                    hotel.HotelName = updateHotelRequest.HotelName;


                    await contacDbApiContext.SaveChangesAsync();
                    return Ok(hotel);

                }
                return NotFound();
            }
        }
    }

