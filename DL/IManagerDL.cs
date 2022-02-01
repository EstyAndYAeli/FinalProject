using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public interface IManagerDL
    {

        Task updateManager(int userId, ParkingManager userToUpdate);
        //***********************************
        //Task<float> checkinOccupancyRates(bool type);
        //Task<string> getCostumerEmailByID(string id);
        //Task<Task<ParkingHistory>> getCostumersHistoryParking();
        //Task<List<ParkingHistory>> getRecommendationForManager();
    }
}
