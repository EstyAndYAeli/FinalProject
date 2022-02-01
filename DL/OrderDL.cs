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
    public class OrderDL : IOrderDL
    {
        const int MIN_AVAILABLE = 5;
        private auto_parkingContext _context;
        public OrderDL(auto_parkingContext context)
        {
            _context = context;
        }

        public async Task addCostumer(Costumer c)
        {

            _context.Costumer.Add(c);
            await _context.SaveChangesAsync();
        }

        public async Task addOrder_entring(ParkingHistory p)
        {
            _context.ParkingHistory.Add(p);
            await _context.SaveChangesAsync();
        }


        public async Task<bool> putExitParking_cancel(string numberLicensePlate)//add table entrisHIstory
        {
            ParkingHistory p = await _context.ParkingHistory.Where(c => c.NumberLicensePlate.Equals(numberLicensePlate) && c.DateExitParking == null).FirstOrDefaultAsync();//do we need c.DateExitParking == null?
            if (p != null)
            {
                p.DateExitParking = DateTime.Now;
                _context.Entry(p).CurrentValues.SetValues(p);

                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        //**********************************
        //public async Task<bool> checkNumAvailParks(bool typeCar, int id)
        //{
        //    int available = 0;
        //    if (typeCar)
        //    { //regular
        //        available = await _context.ParkingLot.Where(s => s.ParkingId == id).Select(d => d.NumOfAvailableRegular).FirstOrDefaultAsync();
        //        if (available > MIN_AVAILABLE)
        //            return true;
        //        return false;
        //    }//disable
        //    else
        //    {
        //        available = await _context.ParkingLot.Where(s => s.ParkingId == id).Select(d => d.NumOfAvailableDisable).FirstOrDefaultAsync();
        //        if (available > MIN_AVAILABLE)
        //            return true;
        //        return false;
        //    }
        //}

        public async Task deleteCostumer(int id)
        {
            Costumer cos = await _context.Costumer.FindAsync(id);
            if (cos != null)
            {
                _context.Remove(cos);
                await _context.SaveChangesAsync();
            }
        }
        //******************
        //public async Task<List<ParkingHistory>> GetParkingHistory(int id)
        //{
        //    return await _context.ParkingHistory.Where(c => c.costumerId.Equals(id)).ToListAsync();
        //}

        public async Task<bool> isCarExist(string NumLicensePlate)
        {
            ParkingHistory p = await _context.ParkingHistory.Where(c => c.NumberLicensePlate.Equals(NumLicensePlate) && c.DateExitParking == null).FirstOrDefaultAsync();//do we need c.DateExitParking == null?
            if (p != null)
            {
                p.IsEntry = true;//not sure
                _context.Entry(p).CurrentValues.SetValues(p);

                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
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
