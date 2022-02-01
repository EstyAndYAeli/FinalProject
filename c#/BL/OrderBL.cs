

using DL;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class OrderBL : IOrderBL
    {
        IOrderDL IOrderDL1;
        public OrderBL(IOrderDL _IOrderDL)
        {
            IOrderDL1 = _IOrderDL;
        }

        //public async Task<Costumer> loginByEmailAndPassword(string emeail, string password)
        //{
        //    return await _ICostumerDL.loginByEmailAndPassword(emeail, password);
        //}

        //public async Task addCostumer(Costumer c)
        //{
        //    await _ICostumerDL.addCostumer(c);

        //}

        //public async Task updateCostumer(int id, Costumer costumerToUpdate)
        //{
        //    await _ICostumerDL.updateCostumer(id, costumerToUpdate);
        //}

        //public async Task deleteCostumer(int id)
        //{
        //    await _ICostumerDL.deleteCostumer(id);
        //}

        //public async Task<bool> checkNumAvailParks(bool typeCar, int id)
        //{
        //    return await _ICostumerDL.checkNumAvailParks(typeCar, id);
        //}

        //public async Task<List<ParkingHistory>> GetParkingHistory(int id)
        //{
        //    return await _ICostumerDL.GetParkingHistory(id);
        //}

        public async Task addOrder_entring(ParkingHistory p)
        {
            await IOrderDL1.addOrder_entring(p);
        }

        public async Task<bool> putExitParking_cancel(string num)
        {
            return await IOrderDL1.putExitParking_cancel(num);
        }
        public async Task<bool> isCarExist(string numberLicensePlate)
        {
            return await IOrderDL1.isCarExist(numberLicensePlate);
        }
    }
}
