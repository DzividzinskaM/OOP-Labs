using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Lab6Lib;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee1 = new Employee(1, 1, "Ivanov", "Ivan", "Kyiv", "12345",
                "manager", "2222", "1", "KPI");
            Employee employee2 = new Employee(3, 2, "Petrov", "Petro", "Kyiv", "12346",
                "worker", "123", "high", "KNU");
            Employee employee3 = new Employee(4, 2, "Pavlo", "Pavlo", "Chetnitsi", "225553",
               "worker", "124", "2", "ChNU");

            Department department1 = new Department(1, "First", employee1);
            Department department2 = new Department(2, "Second", employee2);


            Instrument instrument = new Instrument(1, "i1", department1);
            Instrument instrument2 = new Instrument(2, "i2", department1);
            Instrument instrument3 = new Instrument(3, "i3", department2);
            Instrument instrument4 = new Instrument(4, "i4", department2);

            DBHelpler dBHelpler = new DBHelpler();

            //dBHelpler.addDepartment(department1);
            //dBHelpler.addDepartment(department2);

            //dBHelpler.addEmployee(employee2);
            //dBHelpler.addEmployee(employee1);
            //dBHelpler.addEmployee(employee3);

            //dBHelpler.addInstrument(instrument);
            //dBHelpler.addInstrument(instrument2);
            //dBHelpler.addInstrument(instrument3);
            //dBHelpler.addInstrument(instrument4);


            dBHelpler.changeDepartment(instrument, department2);
            dBHelpler.addCheckingInstrunent(instrument, employee1, Convert.ToDateTime("2020-05-20"));
            dBHelpler.addCheckingInstrunent(instrument, employee1, DateTime.Now);


            Console.WriteLine("List of departments");
            showDepartments(dBHelpler.getDepartment());
            Console.WriteLine();


            Console.WriteLine("Full info about employees");
            showEmployees(dBHelpler.getFullInfoAboutEmployee());
            Console.WriteLine();

            Console.WriteLine("department 1 has next instruments");
            showInstruments(dBHelpler.getDepartmentInstruments(department1));
            Console.WriteLine();

            Console.WriteLine("get departments' manager");
            showManagers(dBHelpler.getManager());
            Console.WriteLine();

            Console.WriteLine("Count of employees in every department");
            showNumberEmployees(dBHelpler.getNumberDepartmentsEmployees());
            Console.WriteLine();

            Console.WriteLine("select date of last checking instrument 1");
            Console.WriteLine(dBHelpler.getLastChecking());
            Console.WriteLine();

            Console.WriteLine("Full sorting info about employees");
            showEmployees(dBHelpler.getFullInfoSortAboutEmployee());
            Console.WriteLine();

            Console.Write("select department with min count of instruments ");
            Console.WriteLine(dBHelpler.getMinDepartmentsInstruments());
            Console.WriteLine();

            Console.WriteLine("Departments");
            showDS(dBHelpler.getDepartmentsDS());




        }

        private static void showDS(DataSet departments)
        {
            foreach (DataTable table in departments.Tables)
            {
                Console.WriteLine(table.TableName);             
                foreach (DataColumn column in table.Columns)
                    Console.Write("\t{0}", column.ColumnName);
                Console.WriteLine();
                foreach (DataRow row in table.Rows)
                {
                    var arr = row.ItemArray;
                    foreach (var value in arr)
                        Console.Write("\t\t{0}", value);
                    Console.WriteLine();
                }
            }
        }

        private static void showNumberEmployees(Dictionary<int, int> departmentEmployee)
        {
            foreach(var value in departmentEmployee)
            {
                Console.WriteLine($"department {value.Key}: {value.Value}");
            }
        }

        private static void showManagers(List<Managers> managers)
        {
            foreach (var value in managers)
            {
                Console.WriteLine($"{value.firstName} { value.lastName }: {value.departmentName}");
            }
        }

        private static void showInstruments(List<Instrument> instruments)
        {
            foreach(var value in instruments)
            {
                Console.WriteLine($"{value.id}. {value.name} - department id: {value.departmentId}");

            }
        }

        private static void showEmployees(List<Employee> employees)
        {
            foreach(var value in employees)
            {
                Console.WriteLine($"{value.id}, department - {value.departmentId}, name - {value.firstName} {value.lastName}" +
                    $"phone - {value.phone}, address - {value.address}, specialization - {value.speciality}, qualification -" +
                    $"{value.qualification}");
               
            }
        }

        private static void showDepartments(List<Department> departments)
        {
           foreach(var value in departments)
           {
                Console.WriteLine("department id - " + value.id);
                Console.WriteLine("department name -" + value.name);
                Console.WriteLine("department manager - "+ value.managerId);

           }
        }

       
    }
}
