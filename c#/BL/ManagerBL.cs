

//using DL;
//using Entities.Models;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;

//namespace BL
//{
//    public class ManagerBL : IManagerBL
//    {
//        IManagerDL _IManagerDL;
//        ICostumerBL costumerBL;
//        public ManagerBL(IManagerDL _IloginDL, ICostumerBL _costumerBL)
//        {
//            _IManagerDL = _IloginDL;
//            costumerBL = _costumerBL;
//        }
//        //********************
//        public async Task<float> checkinOccupancyRates(bool type)
//        {
//            return await _IManagerDL.checkinOccupancyRates(type);
//        }

//        public async Task<string> getCostumerEmailByID(string id)
//        {
//            return await costumerBL.getCostumerEmailByID(id);

//        }

//        public async Task<Task<List<ParkingHistory>>> getCostumersHistoryParking()
//        {
//            return await costumerBL.GetParkingHistory();
//        }

//        public async Task<List<ParkingHistory>> getRecommendationForManager()
//        {
//            return await _IManagerDL.getRecommendationForManager();
//        }

//        public async Task updateManager(int id, ParkingManager managerToUpdate)
//        {
//            await _IManagerDL.updateManager(id, managerToUpdate);
//        }
//    }
//}
