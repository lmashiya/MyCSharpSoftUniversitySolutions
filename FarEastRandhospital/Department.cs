using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FarEastRandhospital
{
    public class Department
    {
        public Department(string name)
        {
            Name = name;
            RoomsList = new List<Room>();
            CreateRooms();
        }

        public string Name { get; set; }
        public List<Room> RoomsList { get; set; }

        public void CreateRooms()
        {
            for (int i = 0; i < 20; i++)
            {
                RoomsList.Add(new Room());
            }
        }

        public void AddPatientInRoom(Patient patient)
        {
            var currentRoom = RoomsList.FirstOrDefault(x => !x.IsFull());
            currentRoom.AddPatient(patient);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            var occupiedRooms = RoomsList.Where(x => x.PatientList.Count > 1).ToList();
            if (occupiedRooms.Count >= 1)
            {
                occupiedRooms.ForEach(x => x.PatientList.ForEach(y => sb.AppendLine(y.Name)));
            }
            return sb.ToString();
        }
    }

}
