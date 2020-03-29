using System;
using System.Collections.Generic;

namespace FarEastRandhospital
{

    public class Room
    {
        public Room()
        {
            RoomNumber = ++SetRoomNumber;
            PatientList = new List<Patient>();
        }

        public int RoomNumber { get; set; }

        static int SetRoomNumber = 0;

        public List<Patient> PatientList { get; set; }

        public bool IsFull()
        {
            return PatientList.Count >= 3;
        }

        public void AddPatient(Patient patient)
        {
            if (!this.IsFull())
            {
                PatientList.Add(patient);
            }
        }
    }
}
