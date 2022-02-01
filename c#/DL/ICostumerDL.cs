using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public interface ICostumerDL
    {
        Task<Costumer> loginByEmailAndPassword(string email, string password);
        Task addCostumer(Costumer c);
        Task updateCostumer(int userId, Costumer userToUpdate);
        Task deleteCostumer(int id);
        Task<bool> checkNumAvailParks(bool typeCar, int id);
        //*******************************
       // Task<List<ParkingHistory>> GetParkingHistory(int id);

    }
}
