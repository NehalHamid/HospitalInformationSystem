using HospitalInformationSystem.Data.Repository;
using HospitalInformationSystem.Data;
using HospitalInformationSystem.DTO.DTO;
using HospitalInformationSystem.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using HospitalInformationSystem.API.Helpers;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
//using Historydto = HospitalInformationSystem.Models.Models.Historydto;

namespace HospitalInformationSystem.Services
{
    public class ReceptionService
    {
        IRepository<Room> _roomrepository;
        ApplicationDbContext _context;
        IRepository<Patient> _patientrepository;

        public ReceptionService(IRepository<Room> roomrepository, ApplicationDbContext context, IRepository<Patient> patientrepository)
        {
            _roomrepository = roomrepository;
            _context = context;
            _patientrepository = patientrepository;
        }


        public string CreateAccount(Patientdto data)
        {

            var user = new Patient
            {
                Email = data.email,
                FullName = data.fullname,
                BirthDate = data.Bdate,
                Gender = data.gender,
                Phone = data.phone,
                NationalId = data.NID,
                Image = data.img,
            };

            string result =  _patientrepository.Add(user);
            return result;



        }

        public string ReserveOperationRoom(OperationRoom data)
        {
            Patient patient = _context.Patient.FirstOrDefault(x => x.NationalId == data.nationalID);
            int patienId = patient.Id;

            Room room = _context.Room.FirstOrDefault(x => x.Number == data.room_num);
            int roomId= room.Id;
            PatientRoom reservation = new()
            {
                PatientId = patienId,
                RoomId= roomId,
                PatientNationalId = data.nationalID,
                DoctorName = data.name,
                Department = data.department,
                RoomType = "Operation",
                Number = data.room_num,
                EnteringDate=DateTime.Now
            };
            _context.PatientRoom.Add(reservation);
            _context.SaveChanges();

            room.IsReserved = true;
            _context.SaveChanges();


            return "Successfully reserved";


        }
        /*public string ReserveNormalRoom(NormalRoom data)
        {
            Patient patient = _context.Patient.FirstOrDefault(x => x.NationalId == data.nationalID);
            int patienId = patient.Id;

            Room room = _context.Room.FirstOrDefault(x => x.Number == data.room_num);
            int roomId= room.Id;
            PatientRoom reservation = new()
            {
                PatientId = patienId,
                RoomId= roomId,
                PatientNationalId = data.nationalID,
                DoctorName = data.name,
                Department = data.department,
                RoomType = "Operation",
                Number = data.room_num,
                NormalRoomType =data.type,
                EnteringDate=DateTime.Now
            };
            _context.PatientRoom.Add(reservation);
            _context.SaveChanges();

            room.IsReserved = true;
            _context.SaveChanges();


            return "Successfully reserved";


        }*/
        public string ReserveNormalRoom(NormalRoom data)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // Find the patient by National ID
                    Patient patient = _context.Patient.FirstOrDefault(x => x.NationalId == data.nationalID);
                    if (patient == null)
                    {
                        throw new Exception("Patient not found.");
                    }
                    int patientId = patient.Id;

                    // Find the room by room number
                    Room room = _context.Room.FirstOrDefault(x => x.Number == data.room_num);
                    if (room == null)
                    {
                        throw new Exception("Room not found.");
                    }
                    int roomId = room.Id;

                    // Create a new reservation
                    PatientRoom reservation = new PatientRoom
                    {
                        PatientId = patientId,
                        RoomId = roomId,
                        PatientNationalId = data.nationalID,
                        DoctorName = data.name,
                        Department = data.department,
                        RoomType = "Operation",
                        Number = data.room_num,
                        NormalRoomType = data.type,
                        EnteringDate = DateTime.Now
                    };

                    // Add the reservation to the context
                    _context.PatientRoom.Add(reservation);
                    _context.SaveChanges(); // Save the reservation first

                    // Reload the room entity to ensure it's up-to-date
                    _context.Entry(room).Reload();

                    // Update the room's IsReserved property
                    room.IsReserved = true;
                    _context.SaveChanges(); // Save the room's updated state

                    transaction.Commit();

                    return "Successfully reserved";
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    var innerExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : "No inner exception";
                    throw new Exception($"Error reserving room: {ex.Message}. Inner exception: {innerExceptionMessage}");
                }
            }
        }




        /* public payment ReturnPrices(string id)
         {
             List<Requests> requests = _context.Requests.Where(x => x.NationalId == id && x.DateTime.Date == DateTime.Today).ToList();
             Console.WriteLine(requests);

             Patient patient = _context.Patient.FirstOrDefault(x => x.NationalId == id);
             string patientName = patient.FullName;

             List<string> rays = [];
             List<string> tests = [];
             foreach (Requests request in requests)
             {
                 if (request.Name == "XRay")
                 {
                     rays.Add(request.Type);
                 }
                 else
                 {
                     tests.Add(request.Type);
                 }
             }

             List<Servs> services = [];
             foreach (var item in rays)
             {
                 XRays xray = _context.Xrays.FirstOrDefault(x => x.Name == item);
                 if ((xray!=null))
                 {
                     decimal price = xray.Price;
                     string name = xray.Name;
                     Servs serv = new()
                     {
                         NameOfService = name + " XRay",
                         Price = price,
                     };
                     services.Add(serv);
                 }               

             };

             foreach (var item in tests)
             {
                 Tests test = _context.Tests.FirstOrDefault(x => x.Name == item);
                 if (test !=null)
                 {
                     decimal price = test.Price;
                     string name = test.Name;
                     Servs serv = new()
                     {
                         NameOfService = name + " Test",
                         Price = price,
                     };
                     services.Add(serv);
                 }

             }


             List<PatientRoom> rooms = _context.PatientRoom.Where(x => x.PatientNationalId == id&& x.EnteringDate.Date == DateTime.Today).ToList();
             foreach (var room in rooms)
             {
                 Room room1 = _context.Room.FirstOrDefault(x=>x.Number== room.Number);
                 if (room1 != null)
                 {
                     decimal price = room1.NightPrice;
                     string name = room1.Type;
                     Servs serv = new()
                     {
                         NameOfService = name + " Room",
                         Price = price,
                     };
                     services.Add(serv);
                 }


             }

             payment result = new()
             {
                 Name = patientName,
                 Services = services,
             };

             return result;


         }*/

        public payment ReturnPrices(string id)
        {
            List<Requests> requests = _context.Requests.Where(x => x.NationalId == id && x.DateTime.Date == DateTime.Today).ToList();
            Console.WriteLine("Requests: " + requests.Count);

            Patient patient = _context.Patient.FirstOrDefault(x => x.NationalId == id);
            if (patient == null)
            {
                Console.WriteLine("Patient not found");
                return null;
            }

            string patientName = patient.FullName;

            List<string> rays = new List<string>();
            List<string> tests = new List<string>();
            foreach (Requests request in requests)
            {
                if (request.Name == "XRay")
                {
                    rays.Add(request.Type);
                }
                else
                {
                    tests.Add(request.Type);
                }
            }

            List<Servs> services = new List<Servs>();
            foreach (var item in rays)
            {
                XRays xray = _context.Xrays.FirstOrDefault(x => x.Name == item);
                if (xray != null)
                {
                    decimal price = xray.Price;
                    string name = xray.Name;
                    Servs serv = new()
                    {
                        NameOfService = name + " XRay",
                        Price = price,
                    };
                    services.Add(serv);
                }
            }

            foreach (var item in tests)
            {
                Tests test = _context.Tests.FirstOrDefault(x => x.Name == item);
                if (test != null)
                {
                    decimal price = test.Price;
                    string name = test.Name;
                    Servs serv = new()
                    {
                        NameOfService = name + " Test",
                        Price = price,
                    };
                    services.Add(serv);
                }
            }

            List<PatientRoom> rooms = _context.PatientRoom.Where(x => x.PatientNationalId == id && x.EnteringDate.Date == DateTime.Today).ToList();
            foreach (var room in rooms)
            {
                Room room1 = _context.Room.FirstOrDefault(x => x.Number == room.Number);
                if (room1 != null)
                {
                    decimal price = room1.NightPrice;
                    string name = room1.Type;
                    Servs serv = new()
                    {
                        NameOfService = name + " Room",
                        Price = price,
                    };
                    services.Add(serv);
                }
            }

            payment result = new()
            {
                Name = patientName,
                Services = services,
            };

            Console.WriteLine("Services count: " + services.Count);
            return result;
        }


    }
}
 