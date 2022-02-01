using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IManagerBL
    {

        Task updateManager(int id, ParkingManager costumerToUpdate);
       Task<float> checkinOccupancyRates(bool type);
        Task<string> getCostumerEmailByID(string id);
        Task<Task<ParkingHistory>> getCostumersHistoryParking();
        Task<List<ParkingHistory>> getRecommendationForManager();
    }
}
