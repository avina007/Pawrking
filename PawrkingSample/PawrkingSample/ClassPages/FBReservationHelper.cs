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
                        TimeLength = item.Object.TimeLength,
                        StartTime = item.Object.StartTime,
                        EndTime = item.Object.EndTime
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

        public static async Task<List<Reservation>> GetExpiredReservation(DateTime refresh)
        {
            try
            {
                var allreservations = await GetAllReservations();
                await firebase
                    .Child("Reservations")
                    .OnceAsync<Reservation>();
                return allreservations.Where(a => a.EndTime <= refresh).ToList();

            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }

        public static async Task<bool> AddReservation(string lotname, string row, int col, string email, decimal timelength, DateTime starttime, DateTime endtime)
        {
            try
            {
                await firebase
                    .Child("Reservations")
                    .PostAsync(new Reservation() { LotName = lotname, Row = row, Col = col, Email = email, TimeLength = timelength, StartTime = starttime, EndTime = endtime});
                return true;

            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

        public static async Task<bool> DeleteRes(string lotname, string row, int col)
        {
            try
            {
                var toDeleteRes = (await firebase
                    .Child("Reservations")
                    .OnceAsync<Reservation>()).Where(a => a.Object.LotName == lotname && a.Object.Row == row && a.Object.Col == col).FirstOrDefault();
                await firebase.Child("Reservations").Child(toDeleteRes.Key).DeleteAsync();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error{e}");
                return false;
            }
        }

        public static async Task<bool> RefreshReservations(DateTime refresh)
        {
            try
            {
                List<Reservation> r = new List<Reservation>();
                r = Task.Run(() => GetExpiredReservation(refresh)).Result;
                for (int i = 0; i < r.Count; i++)
                {
                    await DeleteRes(r[i].LotName, r[i].Row, r[i].Col);
                    await FBParkingHelper.UpdateLotFree(r[i].LotName, r[i].Row, r[i].Col);
                }
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error{e}");
                return false;
            }
        }

        public static async Task<bool> userInUse(string email)
        {
            try
            {
                var checkUser = (await firebase
                    .Child("Reservations")
                    .OnceAsync<Reservation>()).Where(a => a.Object.Email == email).FirstOrDefault();
                if (checkUser == null)
                {
                    return false;
                }
                else
                    return true;
            }
            catch(Exception e)
            {
                Debug.WriteLine($"Error{e}");
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
