//using BL;
//using Entities.Models;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
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
    public class CommentController : ControllerBase
    {
        ICommentBL iCommentBL1;
        public CommentController(ICommentBL c)
        {
            iCommentBL1 = c;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<List<Comment>> getAllRecommendations()
        {
            return await iCommentBL1.getAllRecommendations();


        }



        // POST api/<ValuesController>
        [HttpPost("{id}")]
        public async Task<bool> AddComment([FromBody] int id, string comment, bool expose, bool forManager)
        {
            Comment c = new Comment();
            c.CostumerId = id;
            c.Recommendation = comment;
            c.ExposeCostumerName = expose;
            c.ForManager = forManager;

            return await iCommentBL1.AddComment(c);
        }

        //            // PUT api/<ValuesController>/5
        //            [HttpPut("{email}")]
        //            public async Task Put(int userId, [FromBody] User userToUpdate)
        //            {
        //                await iloginBL1.Put(userId, userToUpdate);
        //            }

        //            // DELETE api/<ValuesController>/5
        //            [HttpDelete("{id}")]
        //            public void Delete(int id)
        //            {

        //            }
        //        }
    }
}
