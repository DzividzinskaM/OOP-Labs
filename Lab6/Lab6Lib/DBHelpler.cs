using System;
using System.Collections.Generic;
using System.Text;

using System.Data.SqlClient;
using System.Data;
using LinqToDB;

namespace Lab6Lib
{
    public class Managers
    {
        public string firstName { get; }
        public string lastName { get; }
        public string departmentName { get; }

        public Managers(string firstName, string lastName, string department)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.departmentName = department;
        }
    }
    public class DBHelpler
    {
        private string DataSource = @"DESKTOP-NK89RBK\SQLEXPRESS";

        private string InitialCatalog = "MetrologicalCompany";

        private bool IntegretedSecurity = true;

        private bool Pooling = true;

        public readonly string connectionString;


        public readonly string employeeIDParamName = "EmployeeID";
        public readonly string lastNameParamName = "lastName";
        public readonly string firstNameParamName ="firstName";
        public readonly string phoneParamName = "phone";
        public readonly string addressParamName = "adress";
        public readonly string departmentIdParamName = "DepartmentID";
        public readonly string specialityParamName = "speciality";
        public readonly string diplomNumberParamName = "diplomNumber";
        public readonly string qualificationParamName = "qualification";
        public readonly string educationInstutionParamName = "educationInstution";
        public readonly string departmentNameParamName = "departmentName";
        public readonly string departmentManagerIDParamName = "departmentManagerID";
        private string instrumentIdParamName = "InstrumentID";
        private string instrumentNameParamName = "instrumentName";


        private string employeeTableName = "Employee";
        private string employeeDetailsTableName = "EmployeeDetails";
        private string departmentTableName = "Department";
        private string instrumentsTableName = "MeasuringInstruments";

        public DBHelpler()
        {
            SqlConnectionStringBuilder connectBuilder = new SqlConnectionStringBuilder();
            connectBuilder.DataSource = DataSource;
            connectBuilder.InitialCatalog = InitialCatalog;
            connectBuilder.IntegratedSecurity = IntegretedSecurity;
            connectBuilder.Pooling = Pooling;
            connectionString = connectBuilder.ConnectionString;
        }

       
 
       
        public void addEmployee(Employee employee)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                string insertCommandStr = "insert into " + employeeTableName + $"({employeeIDParamName}," +
                    $"{lastNameParamName}, {firstNameParamName}, {phoneParamName}, {addressParamName}," +
                    $"{departmentIdParamName}) values (@{employeeIDParamName}," +
                    $"@{lastNameParamName}, @{firstNameParamName}, @{phoneParamName}, @{addressParamName}," +
                    $"@{departmentIdParamName})";
                SqlCommand insertCmd = new SqlCommand(insertCommandStr, cn);
                insertCmd.Parameters.AddWithValue($"@{employeeIDParamName}", employee.id);
                insertCmd.Parameters.AddWithValue($"@{lastNameParamName}", employee.lastName);
                insertCmd.Parameters.AddWithValue($"@{firstNameParamName}", employee.firstName);
                insertCmd.Parameters.AddWithValue($"@{phoneParamName}", employee.phone);
                insertCmd.Parameters.AddWithValue($"@{addressParamName}", employee.address);
                insertCmd.Parameters.AddWithValue($"@{departmentIdParamName}", employee.departmentId);
                try
                {
                    insertCmd.ExecuteNonQuery() ;
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                insertCommandStr = "insert into " + employeeDetailsTableName + $"({employeeIDParamName}, {specialityParamName}," +
                    $"{diplomNumberParamName}, {qualificationParamName}, {educationInstutionParamName})" +
                    $" values (@{employeeIDParamName}, @{specialityParamName}," +
                    $"@{diplomNumberParamName}, @{qualificationParamName}, @{educationInstutionParamName})";
                insertCmd = new SqlCommand(insertCommandStr, cn);
                insertCmd.Parameters.AddWithValue($"@{employeeIDParamName}", employee.id);
                insertCmd.Parameters.AddWithValue($"@{specialityParamName}", employee.speciality);
                insertCmd.Parameters.AddWithValue($"@{diplomNumberParamName}", employee.diplomNumber);
                insertCmd.Parameters.AddWithValue($"@{qualificationParamName}", employee.qualification);
                insertCmd.Parameters.AddWithValue($"@{educationInstutionParamName}", employee.educationalInstitution);
                try
                {
                    insertCmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public void addDepartment(Department department)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();

                string insertCmdStr = $"insert into "+ departmentTableName + $" ({departmentIdParamName}," +
                    $"{departmentNameParamName}, {departmentManagerIDParamName}) " +
                    $"Values(@{departmentIdParamName}," +
                    $" @{departmentNameParamName}, @{departmentManagerIDParamName})";
                SqlCommand cmd = new SqlCommand(insertCmdStr, cn);
                cmd.Parameters.AddWithValue($"@{departmentIdParamName}", department.id);
                cmd.Parameters.AddWithValue($"@{departmentNameParamName}", department.name);
                cmd.Parameters.AddWithValue($"@{departmentManagerIDParamName}", department.managerId);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
        }
        

        public void addInstrument(Instrument instrument)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();

                string insertCmdStr = "insert into " + instrumentsTableName + $"({instrumentIdParamName}," +
                    $" {instrumentNameParamName}, {departmentIdParamName}) values(@{instrumentIdParamName}, " +
                    $"@{instrumentNameParamName}, @{departmentIdParamName})";
                SqlCommand cmd = new SqlCommand(insertCmdStr, cn);
                cmd.Parameters.AddWithValue($"@{instrumentIdParamName}", instrument.id);
                cmd.Parameters.AddWithValue($"@{instrumentNameParamName}", instrument.name);
                cmd.Parameters.AddWithValue($"@{departmentIdParamName}", instrument.departmentId);
                Console.WriteLine(cmd.CommandText);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
        }

        private string CheckingInstrumentsTableName = "CheckingInstruments";
        private string checkingDateParamName = "checkingDate";
        public void addCheckingInstrunent(Instrument instrument, Employee employee, DateTime date)
        {
            using(SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                string insertCmdStr = "insert into " + CheckingInstrumentsTableName + $" ({instrumentIdParamName}, " +
                    $"{employeeIDParamName}, {checkingDateParamName}) values(@{instrumentIdParamName}, @{employeeIDParamName}, " +
                    $"@{checkingDateParamName})";
                SqlCommand cmd = new SqlCommand(insertCmdStr, cn);

                cmd.Parameters.AddWithValue($"@{instrumentIdParamName}", instrument.id);
                cmd.Parameters.AddWithValue($"@{employeeIDParamName}", employee.id);
                cmd.Parameters.AddWithValue($"@{checkingDateParamName}", date);
                Console.WriteLine(cmd.CommandText);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }


        public void deleteEmployee(Employee employee)
        {
            using(SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();

                string deleteCmdStr = "delete " + employeeDetailsTableName + $" where {employeeIDParamName} = {employee.id}";
                SqlCommand delete = new SqlCommand(deleteCmdStr, cn);
                try
                {
                    delete.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                deleteCmdStr = "delete " + employeeTableName + $" where {employeeIDParamName} = {employee.id}";
                delete = new SqlCommand(deleteCmdStr, cn);
                try
                {
                    delete.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public void changeDepartment(Instrument instrument, Department department)
        {
            using(SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();

                string updateCmdStr = "Update " + instrumentsTableName + $" set {departmentIdParamName} = {department.id} " +
                    $"where {instrumentIdParamName} = {instrument.id}";
                SqlCommand cmd = new SqlCommand(updateCmdStr, cn);
                Console.WriteLine(cmd.CommandText);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

 

        public List<Department> getDepartment()
        {
            List<Department> departments = new List<Department>();
            string cmdStr = $"select * from {departmentTableName}";
          

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(cmdStr, cn);
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    departments.Add(new Department((int)rd[departmentIdParamName], rd[departmentNameParamName].ToString(),
                        (int)rd[departmentManagerIDParamName]));
                }
                return departments;

            }
        }


        public List<Employee> getFullInfoAboutEmployee()
        {
            List<Employee> employees = new List<Employee>();
            string cmdStr = $"select * from {employeeTableName} inner join {employeeDetailsTableName} " +
                $"on {employeeTableName}.{employeeIDParamName} = {employeeDetailsTableName}.{employeeIDParamName}";

            using(SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(cmdStr, cn);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    employees.Add(new Employee((int)rd[employeeIDParamName], (int)rd[departmentIdParamName], rd[lastNameParamName].ToString(),
                        rd[firstNameParamName].ToString(), rd[addressParamName].ToString(), rd[phoneParamName].ToString(), 
                        rd[specialityParamName].ToString(), rd[diplomNumberParamName].ToString(),
                        rd[qualificationParamName].ToString(), rd[educationInstutionParamName].ToString()));
                }
                return employees;
                
            }
        }

        public List<Instrument> getDepartmentInstruments(Department department)
        {
            List<Instrument> instruments = new List<Instrument>();

            string cmdStr = $"select * from {instrumentsTableName} where {departmentIdParamName} = {department.id}";

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(cmdStr, cn);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    instruments.Add(new Instrument((int)rd[instrumentIdParamName], rd[instrumentNameParamName].ToString(),
                        (int)rd[departmentIdParamName]));
                }
                return instruments;
            }
        }

        public List<Managers> getManager()
        {
            List<Managers> managers = new List<Managers>();

            string cmdStr = $"select distinct {departmentTableName}.{departmentNameParamName}, {employeeTableName}.{firstNameParamName}, " +
                $"{employeeTableName}.{lastNameParamName} from {departmentTableName} " +
                $"inner join {employeeTableName} on {departmentTableName}.{departmentIdParamName} " +
                $"= {employeeTableName}.{departmentIdParamName}";
            using(SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(cmdStr, cn);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    managers.Add(new Managers(rd[firstNameParamName].ToString(), rd[lastNameParamName].ToString(),
                        rd[departmentNameParamName].ToString()));
                }
                return managers;
            }
        }

        public Dictionary<int, int> getNumberDepartmentsEmployees()
        {
            Dictionary<int, int> DepartmentEmployees = new Dictionary<int, int>();
            string tplCountEmployee = "employeeNumber";
            string cmdStr = $"select {departmentIdParamName}, count(*) as {tplCountEmployee} from {employeeTableName} group by {departmentIdParamName}";
            using(SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(cmdStr, cn);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    DepartmentEmployees.Add((int)rd[departmentIdParamName], (int)rd[tplCountEmployee]);
                }
                return DepartmentEmployees;
            }
        }

        public DateTime getLastChecking()
        {
            int result;
            string cmdStr = $"select max({checkingDateParamName}) from {CheckingInstrumentsTableName}";
            using(SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(cmdStr, cn);
                return Convert.ToDateTime(cmd.ExecuteScalar());
            }
        }

        public List<Employee> getFullInfoSortAboutEmployee()
        {
            List<Employee> employees = new List<Employee>();
            string cmdStr = $"select * from {employeeTableName} inner join {employeeDetailsTableName} " +
                $"on {employeeTableName}.{employeeIDParamName} = {employeeDetailsTableName}.{employeeIDParamName}" +
                $" order by {firstNameParamName}, {lastNameParamName}";

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(cmdStr, cn);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    employees.Add(new Employee((int)rd[employeeIDParamName], (int)rd[departmentIdParamName], rd[lastNameParamName].ToString(),
                        rd[firstNameParamName].ToString(), rd[addressParamName].ToString(), rd[phoneParamName].ToString(),
                        rd[specialityParamName].ToString(), rd[diplomNumberParamName].ToString(),
                        rd[qualificationParamName].ToString(), rd[educationInstutionParamName].ToString()));
                }
                return employees;

            }
        }

        public int getMinDepartmentsInstruments()
        {

            string cmdStr = $"select count({instrumentIdParamName}) from {instrumentsTableName} group by {departmentIdParamName}";
            using(SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(cmdStr, cn);
                return (int)cmd.ExecuteScalar();
            }

        }

        public DataSet getDepartmentsDS()
        {
            string cmdStr = $"select * from {departmentTableName}";
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmdStr, cn);

                DataSet departments = new DataSet();

                adapter.Fill(departments);

                return departments;
            }
        }

    }
}
