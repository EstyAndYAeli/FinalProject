using BL;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace auto_parking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class costumerController : ControllerBase
    {

        ICostumerBL iCostumerBL1;
        public costumerController(ICostumerBL _ICostumerBL)
        {

            iCostumerBL1 = _ICostumerBL;
        }

        // GET: api/<ValuesController>
        [HttpGet("{email}/{password}")]
        public async Task<ActionResult<Costumer>> loginByEmailAndPassword(string email, string password)
        {
            //loginBL loginbl = new loginBL();
            Costumer costumer = await iCostumerBL1.loginByEmailAndPassword(email, password);
            if (costumer == null)
                return NoContent();
            return Ok(costumer);

        }

        [HttpGet]
        public async Task<bool> checkNumAvailParks(bool typeCar, int id)
        {
            return await iCostumerBL1.checkNumAvailParks(typeCar, id);
        }



        [HttpGet]
        public async Task<ActionResult<List<ParkingHistory>>> GetParkingHistory(int id)
        {
            return await iCostumerBL1.GetParkingHistory(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task addCostumer([FromBody] Costumer costumer)
        {
            await iCostumerBL1.addCostumer(costumer);
        }



        //PUT api/<ValuesController>/5
        [HttpPut]
        public async Task Put(int id, [FromBody] Costumer costumerToUpdate)
        {
            await iCostumerBL1.updateCostumer(id, costumerToUpdate);
        }

        //DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task deleteCostumer(int id)
        {
            await iCostumerBL1.deleteCostumer(id);
        }

    }
}

