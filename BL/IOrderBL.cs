using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IOrderBL
    {

        Task addOrder_entring(ParkingHistory p);
        Task<bool> isCarExist(string num);
        Task<bool> putExitParking_cancel(string num);

    }
}
