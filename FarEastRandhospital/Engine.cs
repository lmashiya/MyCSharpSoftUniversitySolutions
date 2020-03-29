using System;
using System.Linq;

namespace FarEastRandhospital
{
    partial class Program
    {
        public class Engine
        {
            public Hospital Hospital { get; set; }
            public Engine()
            {
                Hospital = new Hospital();

            }

            public void Run()
            {
                string[] inputArgs = GetInput();

                while (inputArgs[0] != "Output")
                {
                    PopulateHospital(inputArgs);
                    inputArgs = GetInput();
                }

                inputArgs = GetInput();
                while (inputArgs[0] != "End")
                {
                    if (inputArgs.Length == 1 && Hospital.ContainsDepartment(inputArgs[0]))
                    {
                        string departmentName = inputArgs[0];
                        Department department = Hospital.DepartmentsList.FirstOrDefault(x => x.Name == departmentName);
                        Console.WriteLine(department);
                    }

                    else if (inputArgs.Length == 2)
                    {
                        var doctorFullname = inputArgs[0] + " " + inputArgs[1];
                        if (Hospital.ContainsDoctor(doctorFullname))
                        {
                            Doctor doctor = Hospital.GetDoctorInList(doctorFullname);
                            Console.WriteLine(doctor);
                        }
                        else if (Hospital.ContainsDepartment(inputArgs[0]) && int.TryParse(inputArgs[1],out int roomNumber) )
                        {
                            Department department = Hospital.GetDepartmentInList(inputArgs[0]);
                            Console.WriteLine(department);
                        }
                    }
                }
            }

            public string[] GetInput()
            {
                return Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            }

            public void PopulateHospital(string[] inputArgs)
            {
                string departmentName = inputArgs[0];
                string doctorName = inputArgs[1];
                string doctorSurname = inputArgs[2];
                string patientName = inputArgs[3];

                Hospital.AddDepartment(departmentName);
                Hospital.AddDoctor(doctorName, doctorSurname);
                Hospital.AddPatient(doctorName, doctorSurname, patientName, departmentName);

            }
        }
    }
}
