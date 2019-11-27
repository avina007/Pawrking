using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawrkingSample.Classes;
using PawrkingSample.Pages;


namespace PawrkingSample.ClassPages
{
    public class FBParkingHelper
    {
        public static FirebaseClient firebase = new FirebaseClient("https://pawparking-f1065.firebaseio.com/");

        public static async Task<List<ParkingLot>> GetAllParkingLots()
        {
            try
            {
                var lotlist = (await firebase
                .Child("Lots")
                .OnceAsync<ParkingLot>()).Select(item =>
                new ParkingLot
                {
                    LotName = item.Object.LotName,
                    Row = item.Object.Row,
                    Col = item.Object.Col,
                    Open = true
                }).ToList();
                return lotlist;
            }
            catch(Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }

        public static async Task<ParkingLot> GetLot(string lotname)
        {
            try
            {
                var allLots = await GetAllParkingLots();
                await firebase
                    .Child("Lots")
                    .OnceAsync<ParkingLot>();
                return allLots.Where(a => a.LotName == lotname).FirstOrDefault();
            }
            catch(Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }

        public static async Task<bool> AddLot(string lotname, string row, int col)
        {
            try
            {
                await firebase
                    .Child("Lots")
                    .PostAsync(new ParkingLot() { LotName = lotname, Row = row, Col = col, Open = true });
                return true;
            }
            catch(Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

        public static async Task<bool> UpdateLotTaken(string lotname, string row, int col)
        {
            try
            {
                var toUpdateLot = (await firebase
                .Child("Lots")
                .OnceAsync<ParkingLot>()).Where(a => a.Object.LotName == lotname && a.Object.Row == row && a.Object.Col == col).FirstOrDefault();
                await firebase
                .Child("Users")
                .Child(toUpdateLot.Key)
                .PutAsync(new ParkingLot() { LotName = lotname, Row = row, Col = col, Open = false });
                return true;
            }
            catch(Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

        public static async Task<bool> UpdateLotFree(string lotname, string row, int col)
        {
            try
            {
                var toUpdateLot = (await firebase
                .Child("Lots")
                .OnceAsync<ParkingLot>()).Where(a => a.Object.LotName == lotname && a.Object.Row == row && a.Object.Col == col).FirstOrDefault();
                await firebase
                .Child("Users")
                .Child(toUpdateLot.Key)
                .PutAsync(new ParkingLot() { LotName = lotname, Row = row, Col = col, Open = true });
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

        public static async Task<bool> DeleteLot(string lotname, string row, int col)
        {
            try
            {
                var toDeleteLot = (await firebase
                    .Child("Lots")
                    .OnceAsync<ParkingLot>()).Where(a => a.Object.LotName == lotname && a.Object.Row == row && a.Object.Col == col).FirstOrDefault();
                await firebase.Child("Lots").Child(toDeleteLot.Key).DeleteAsync();
                return true;
            }
            catch(Exception e)
            {
                Debug.WriteLine($"Error{e}");
                return false;
            }
        }
        
    }
}
