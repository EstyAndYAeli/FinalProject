

using DL;
using Entities.Models;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CommentBL : ICommentBL
    {
        ICommentDL commentDL;
        public CommentBL(ICommentDL _ICommentDL)
        {
            commentDL = _ICommentDL;
        }

        public async Task<bool> AddComment(Comment c)
        {
            return await commentDL.AddComment(c);
        }

        public async Task<List<Comment>> getAllRecommendations()
        {
            return await commentDL.getAllRecommendations();
        }

        //public async Task<Costumer> loginByEmailAndPassword(string emeail, string password)
        //{
        //    return await commentDL.loginByEmailAndPassword(emeail, password);
        //}

        //public async Task addCostumer(Costumer c)
        //{
        //    await commentDL.addCostumer(c);

        //}

        //public async Task updateCostumer(int id, Costumer costumerToUpdate)
        //{
        //    await commentDL.updateCostumer(id, costumerToUpdate);
        //}

        //public async Task deleteCostumer(int id)
        //{
        //    await commentDL.deleteCostumer(id);
        //}

        //public async Task<bool> checkNumAvailParks(bool typeCar, int id)
        //{
        //    return await commentDL.checkNumAvailParks(typeCar, id);
        //}

        //public async Task<List<ParkingHistory>> GetParkingHistory(int id)
        //{
        //    return await commentDL.GetParkingHistory(id);
        //}
    }
}
