using Firebase.Database;
using Firebase.Database.Query;
using PawrkingSample.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawrkingSample.ClassPages
{
    class ReservationHistoryHelper
    {
        public static FirebaseClient firebase = new FirebaseClient("https://pawparking-f1065.firebaseio.com/");

        public static async Task<List<ReservationHistory>> GetAllReservationHistories()
        {
            try
            {
                var HistList = (await firebase
                .Child("ReservationHistory")
                .OnceAsync<ReservationHistory>()).Select(item =>
                new ReservationHistory
                {
                    Email = item.Object.Email,
                    LotName = item.Object.LotName,
                    Row = item.Object.Row,
                    Space = item.Object.Space,
                    Start = item.Object.Start,
                    End = item.Object.End
                }).ToList();
                return HistList;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }

        public static async Task<List<ReservationHistory>> GetMyReservations(string email)
        {
            try
            {
                var HistList = await GetAllReservationHistories();
                await firebase
                    .Child("ReservationHistory")
                    .OnceAsync<ReservationHistory>();
                var myList = HistList.FindAll(a => a.Email == email).ToList();
                return myList;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }

        public static async Task<bool> AddReservationToHistory(string email, string lotname, string row, int space, DateTime start, DateTime end)
        {
            try
            {
                await firebase
                    .Child("ReservationHistory")
                    .PostAsync(new ReservationHistory() { Email = email, LotName = lotname, Row = row, Space = space, Start = start, End = end});
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }
    }
}
