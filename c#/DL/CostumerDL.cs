//using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Diagnostics;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DL
{
    public class CostumerDL : ICostumerDL
    {
        const int MIN_AVAILABLE = 5;
        private auto_parkingContext _context;
        public CostumerDL(auto_parkingContext context)
        {
            _context = context;
        }

        public async Task addCostumer(Costumer c)
        {

            _context.Costumer.Add(c);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> checkNumAvailParks(bool typeCar, int id)
        {
            //int available = 0;
            //if (typeCar)
            //{ //regular
            //    available = await _context.ParkingLot.Where(s => s.ParkingId == id).Select(d => d.NumOfAvailableRegular).FirstOrDefaultAsync();
            //    if (available > MIN_AVAILABLE)
            //        return true;
            //    return false;
            //}//disable
            //else
            //{
            //    available = await _context.ParkingLot.Where(s => s.ParkingId == id).Select(d => d.NumOfAvailableDisable).FirstOrDefaultAsync();
            //    if (available > MIN_AVAILABLE)
            //        return true;
            return false;
            //}
        }

        public async Task deleteCostumer(int id)
        {
            Costumer cos = await _context.Costumer.FindAsync(id);
            if (cos != null)
            {
                _context.Remove(cos);
                await _context.SaveChangesAsync();
            }
        }
        //*******************************
        //public async Task<List<ParkingHistory>> GetParkingHistory(int id)
        //{
        //    return await _context.ParkingHistory.Where(c => c.CostumerId.Equals(id)).ToListAsync();
        //}

        public async Task<Costumer> loginByEmailAndPassword(string email, string password)
        {
            return await _context.Costumer.Where(c => c.Email.Equals(email) && c.Password.Equals(password)).FirstOrDefaultAsync();
        }

        public async Task updateCostumer(int userId, Costumer updatedCostumer)
        {
            Costumer cos = await _context.Costumer.FindAsync(userId);
            if (cos != null)
            {
                _context.Entry(cos).CurrentValues.SetValues(updatedCostumer);
                await _context.SaveChangesAsync();
            }
        }


    }
}
