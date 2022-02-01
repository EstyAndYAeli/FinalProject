using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace DL
{
    public class ManagerDL : IManagerDL
    {
        const int MIN_AVAILABLE = 5;
        private auto_parkingContext _context;
        public ManagerDL(auto_parkingContext context)
        {
            _context = context;
        }

        //***********************************
        //public async Task<float> checkinOccupancyRates(bool type)
        //{
        //    int numOfRegular = await _context.ParkingLot.Select(d => d.NumOfRegular).FirstOrDefaultAsync();
        //    int NumOfDisabled = await _context.ParkingLot.Select(d => d.NumOfDisabled).FirstOrDefaultAsync();

        //    if (type)
        //        return await _context.ParkingLot.Select(d => d.NumOfAvailableRegular).FirstOrDefaultAsync() / numOfRegular;
        //    return await _context.ParkingLot.Select(d => d.NumOfAvailableDisable).FirstOrDefaultAsync() / NumOfDisabled;

        //}

        public async Task<string> getCostumerEmailByID(string id)
        {
            Costumer c = await _context.Costumer.Where(c => c.CostumerId.Equals(id)).FirstOrDefaultAsync();
            return c.Email;
        }

        //public async Task<Task<ParkingHistory>> getCostumersHistoryParking()//how to return whole table or query
        //{
        //    //Query q= "select * 
        //    //    from ParkingHistory";
        //    //return await _context.ParkingHistory.Select(p=>p).ToListAsync();
        //    List<ParkingHistory> parkingHistory = await _context.ParkingHistory.ToListAsync();
        //    return parkingHistory;
        //}

        //public async Task<List<ParkingHistory>> getRecommendationForManager()
        //{
        //    return await _context.Comment.Where(c => c.ForManager == true).ToListAsync();
        //}

        public async Task updateManager(int userId, ParkingManager managerToUpdate)
        {
            ParkingManager p = await _context.ParkingManager.FindAsync(userId);
            if (p != null)
            {
                _context.Entry(p).CurrentValues.SetValues(managerToUpdate);
                await _context.SaveChangesAsync();
            }
        }
    }
}
