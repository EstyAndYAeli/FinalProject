
//using BL;
//using Entities.Models;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace auto_parking.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class managerController : ControllerBase
//    {

//        IManagerBL iManagerBL1;
//        public managerController(IManagerBL _IManagerBL)
//        {
//            iManagerBL1 = _IManagerBL;
//        }

//        // GET: api/<ValuesController>
//        [HttpGet("{id}")]
//        public async Task<string> getCostumerEmailByID(string id)
//        {
//            string email = await iManagerBL1.getCostumerEmailByID(id);
//            if (email == null)
//                return null;
//            return email;

//        }
//        [HttpGet]

//        public async Task<Task<ParkingHistory>> getCostumersHistoryParking()
//        {
//            return await iManagerBL1.getCostumersHistoryParking();


//        }

//        [HttpGet]

//        public async Task<List<ParkingHistory>> getRecommendationForManager()
//        {
//            return await iManagerBL1.getRecommendationForManager();


//        }

//        [HttpPut]
//        public async Task Put(int id, [FromBody] ParkingManager ParkingManagerToUpdate)
//        {
//            await iManagerBL1.updateManager(id, ParkingManagerToUpdate);
//        }

//        [HttpPut]
//        public async Task<float> checkinOccupancyRates(Boolean type)
//        {//2 sending from react at the same time
//            return await iManagerBL1.checkinOccupancyRates(type);

//        }
//    }
//}

