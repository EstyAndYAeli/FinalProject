

using DL;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CostumerBL : ICostumerBL
    {
        ICostumerDL _ICostumerDL;
        public CostumerBL(ICostumerDL _IloginDL)
        {
            _ICostumerDL = _IloginDL;
        }

        public async Task<Costumer> loginByEmailAndPassword(string emeail, string password)
        {
            return await _ICostumerDL.loginByEmailAndPassword(emeail, password);
        }

        public async Task addCostumer(Costumer c)
        {
            await _ICostumerDL.addCostumer(c);

        }

        public async Task updateCostumer(int id, Costumer costumerToUpdate)
        {
            await _ICostumerDL.updateCostumer(id, costumerToUpdate);
        }

        public async Task deleteCostumer(int id)
        {
            await _ICostumerDL.deleteCostumer(id);
        }

        public async Task<bool> checkNumAvailParks(bool typeCar, int id)
        {
            return await _ICostumerDL.checkNumAvailParks(typeCar, id);
        }

        //**************************
        public async Task<List<ParkingHistory>> GetParkingHistory(int id)
        {
            return  new List<ParkingHistory>();
            //return await _ICostumerDL.GetParkingHistory(id);
        }
    }
}
