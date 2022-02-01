using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public interface IOrderDL
    {

        Task addOrder_entring(ParkingHistory p);
        Task<bool> putExitParking_cancel(string num);
        Task<bool> isCarExist(string num);
    }
}
