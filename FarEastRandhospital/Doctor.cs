using System.Collections.Generic;
using System.Text;

namespace FarEastRandhospital
{

    public class Doctor
    {
        public Doctor(string name, string surname)
        {
            Name = name;
            Surname = surname;
            Fullname = Name + " " + Surname;
            PatientsList = new List<Patient>();
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Fullname { get; set; }

        public List<Patient> PatientsList { get; set; }

        public void AddPatient(Patient patient)
        {
            PatientsList.Add(patient);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            PatientsList.ForEach(x => sb.AppendLine(x.Name));
            return sb.ToString();
        }
    }

}
