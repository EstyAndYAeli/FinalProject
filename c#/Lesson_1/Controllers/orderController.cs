using BL;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using RGiesecke.DllExport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace auto_parking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        IOrderBL IOrderBL1;
        public OrderController(IOrderBL _IOrderBL)
        {
            IOrderBL1 = _IOrderBL;
        }


        //[DllExport("addOrder_entring", CallingConvention = CallingConvention.Cdecl)]
        // POST api/<ValuesController>
        [HttpPost]
        public async Task<bool> addOrder_entring(string NumberLicensePlate, bool isEntry)
        {
            ParkingHistory p = new ParkingHistory();
            if (isEntry)//want to enter-open the gate now!
            {
                if (!await IOrderBL1.isCarExist(NumberLicensePlate))// the user exist
                {
                    p.IsEntry = isEntry;
                    p.NumberLicensePlate = NumberLicensePlate;
                    p.DateEntryParking = DateTime.Now;
                    await IOrderBL1.addOrder_entring(p);

                }
                return true;
            }
            p.IsEntry = isEntry;
            p.NumberLicensePlate = NumberLicensePlate;
            p.DateEntryParking = DateTime.Now;
            await IOrderBL1.addOrder_entring(p);
            return false;
        }


        //// GET: api/<ValuesController>
        //[HttpGet("{login}/{password}")]
        //public async Task<ActionResult<User>> login(string login, string password)
        //{
        //    //loginBL loginbl = new loginBL();
        //    User user = await iloginBL1.getUser(login, password);
        //    if (user == null)
        //        return NoContent();
        //    return Ok(user);

        //}


        //// POST api/<ValuesController>
        //[HttpPost]
        //public async Task Post([FromBody] User user)
        //{
        //    //user.Mail = "fffff";
        //    await iloginBL1.Post(user);
        //}

        public async Task<bool> putExitParking_cancel(string NumberLicensePlate)//return false means cannot get out but it might get stuck
        {
            return await IOrderBL1.putExitParking_cancel(NumberLicensePlate);
        }


        //// DELETE api/<ValuesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{

        //}
    }
}

