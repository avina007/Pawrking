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
    public class FBReservationHelper
    {
        string email2;
        public FBParkingHelper(string email3)
        {
            email2 = email3;
        }
        public static FirebaseClient firebase = new FirebaseClient("https://pawparking-f1065.firebaseio.com/");

        public static async Task<List<Reservation>> GetAllReservations()
        {
            try
            {
                var reservationlist = (await firebase
                    .Child("Reservations")
                    .OnceAsync<Reservation>()).Select(item =>
                    new Reservation
                    {
                        Lot = item.Object.Lot,
                        Email = item.Object.Email,
                        Timer = item.Object.Timer

                    }).ToList();
                return reservationlist;
            }
            catch(Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }

        public static async Task<Reservation> GetReservation()
        {
            try
            {
                var allreservations = await GetAllReservations();
                await firebase
                    .Child("Reservations")
                    .OnceAsync<Reservation>();
                return allreservations.Where(a => a.Email == email).FirstOrDefault();

            }
            catch(Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }

        public static async Task<bool> AddReservation(string lotname, string row, int col, int time)
    }
}
