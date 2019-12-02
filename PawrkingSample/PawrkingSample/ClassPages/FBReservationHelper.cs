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
         public string email2;
        public FBReservationHelper(string email3)
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
                        LotName = item.Object.LotName,
                        Row = item.Object.Row,
                        Col = item.Object.Col,
                        
                        Email = item.Object.Email,
                        LengthOfReservation = item.Object.LengthOfReservation,
                        StartTime = item.Object.StartTime
                    }).ToList();
                return reservationlist;
            }
            catch(Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }

        public static async Task<Reservation> GetReservation(string email)
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

        public static async Task<bool> AddReservation(string lotname, string row, int col, string email, int timelength, DateTime starttime)
        {
            try
            {
                await firebase
                    .Child("Reservations")
                    .PostAsync(new Reservation() { LotName = lotname, Row = row, Col = col, Email = email, LengthOfReservation = timelength, StartTime = starttime});
                return true;

            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

        /*
        public static async Task<bool> UpdateReservation(string lotname, string row, int col, int time, string email)
        {
            try
            {


                var toUpdateUser = (await firebase
                .Child("Users")
                .OnceAsync<Users>()).Where(a => a.Object.Email == email && a.Object).FirstOrDefault();
                await firebase
                .Child("Users")
                .Child(toUpdateUser.Key)
                .PutAsync(new Users() { Email = email,  });
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }*/


    }
}
