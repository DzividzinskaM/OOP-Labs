using System;

namespace Lab6Lib
{
    public class Employee
    {
        public int id { get; }

        public int departmentId { get; }
        public string lastName { get; }
        public string firstName { get; }
        public string address { get; }

        public string phone { get; }

        public string speciality { get; }

        public string diplomNumber { get; }

        public string qualification { get; }

        public string educationalInstitution { get; }

        public Employee(int id, int departmentId, string lastName, string firstName, 
            string address, string phone, string speciality, string diplomNumber, 
            string qualification, string educationalInstitution)
        {
            this.id = id;
            this.departmentId = departmentId;
            this.lastName = lastName;
            this.firstName = firstName;
            this.address = address;
            this.phone = phone;
            this.speciality = speciality;
            this.diplomNumber = diplomNumber;
            this.qualification = qualification;
            this.educationalInstitution = educationalInstitution;
        }


        public Employee(int id, Department department, string lastName, string firstName,
           string address, string phone, string speciality, string diplomNumber,
           string qualification, string educationalInstitution)
        {
            this.id = id;
            this.departmentId = department.id;
            this.lastName = lastName;
            this.firstName = firstName;
            this.address = address;
            this.phone = phone;
            this.speciality = speciality;
            this.diplomNumber = diplomNumber;
            this.qualification = qualification;
            this.educationalInstitution = educationalInstitution;
        }
    }
}
