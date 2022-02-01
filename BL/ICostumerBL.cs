using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface ICostumerBL
    {
        Task<Costumer> loginByEmailAndPassword(string email, string password);
        Task addCostumer(Costumer costumer);
        Task updateCostumer(int id, Costumer costumerToUpdate);
        Task deleteCostumer(int id);
        Task<bool> checkNumAvailParks(bool typeCar, int id);
        //*****************
        Task<List<ParkingHistory>> GetParkingHistory(int id);
    }
}
