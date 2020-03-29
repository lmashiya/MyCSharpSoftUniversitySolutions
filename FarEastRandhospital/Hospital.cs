using System.Collections.Generic;
using System;
using System.Linq;

namespace FarEastRandhospital
{
    public class Hospital
    {
        public List<Department> DepartmentsList { get; set; }
        public List<Doctor> DoctorsList { get; set; }

        private string _name;

        public Hospital()
        {
            DoctorsList = new List<Doctor>();
            DepartmentsList = new List<Department>();
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length > 1 && value.Length < 100)
                {
                    _name = value;
                }
                else
                {
                    throw new ArgumentException("Please ensure Hospital name is more than 1 letter and less than 100 letters");
                }
            }
        }

        public void AddDepartment(string departmentName)
        {
            if (!ContainsDepartment(departmentName))
            {
                var department = new Department(departmentName);
                DepartmentsList.Add(department);
            }
        }

        public void AddDoctor(string name,string surname)
        {
            if (!ContainsDoctor(name))
            {
                var doctor = new Doctor(name,surname);
                DoctorsList.Add(doctor);
            }
        }

        public void AddPatient(string name,string surname ,string patientName,string departmentName)
        {
            var fullname = name + " " + surname;
            var doctor = GetDoctorInList(fullname);
            var department = GetDepartmentInList(departmentName);

            if(doctor != null)
                doctor.AddPatient(new Patient(patientName));
            if (doctor != null)
                department.AddPatientInRoom(new Patient(patientName));
        }

        public bool ContainsDepartment(string departmentName)
        {
            return DepartmentsList.Any(x => x.Name == departmentName);
        }

        public bool ContainsDoctor(string doctorName)
        {
            return DoctorsList.Any(x => x.Name == doctorName);
        }

        public Department GetDepartmentInList(string departmentName)
        {
            return DepartmentsList.FirstOrDefault(x => x.Name == departmentName);
        }

        public Doctor GetDoctorInList(string doctorName)
        {
            return DoctorsList.FirstOrDefault(x => x.Fullname == doctorName);
        }

    }

}
