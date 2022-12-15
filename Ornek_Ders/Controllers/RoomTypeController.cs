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

        public class RoomTypeController : Controller
        {
            private readonly ContacDbApiContext roomtypeContext;

            public RoomTypeController(ContacDbApiContext roomtypeContext)
            {
                this.roomtypeContext = roomtypeContext;

            }
            [HttpGet]
            [Route("RoomTypeGet")]
            public IActionResult GetRoomtype()
            {

                return Ok(roomtypeContext.RoomTypes.ToList());

            }
            [HttpPost]
            [Route("AddRoomType")]
            public async Task<IActionResult> AddRoomType(RoomTypeRequest value)
            {
                var roomtype = new Roomtype()
                {
                    Id = new int(),
                    RoomType = value.RoomType,
                    Remark = value.Remark,



                };
                await roomtypeContext.RoomTypes.AddAsync(roomtype);
                await roomtypeContext.SaveChangesAsync();
                return Ok(roomtype);
            }
        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> DeleteRoomType([FromRoute] int id)
        {
            var roomtype = await roomtypeContext.RoomTypes.FindAsync(id);
            if (roomtype != null)
            {
                roomtypeContext.Remove(roomtype);
                await roomtypeContext.SaveChangesAsync();
                return Ok();
            }
            return NotFound();
        }
        [HttpPut]
        [Route("Update/{id:int}")]
        public async Task<IActionResult> UpdateRoomType([FromBody] Roomtype model)

        {
            Roomtype roomtype = await roomtypeContext.RoomTypes.FirstOrDefaultAsync(h => h.Id == model.Id);
            if (roomtype != null)
            {
                roomtype.RoomType = model.RoomType;

                roomtype.Remark = model.Remark;


                await roomtypeContext.SaveChangesAsync();
                return Ok(roomtype);

            }
            return NotFound();
        }
    }
}
   

