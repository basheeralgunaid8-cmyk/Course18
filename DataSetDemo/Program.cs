
using System;
using System.Data;
using System.Linq;
namespace DataSetDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataTable EmployeeDatatable = new DataTable("EmployeeDatatable");
            EmployeeDatatable.Columns.Add("ID", typeof(int));
            EmployeeDatatable.Columns.Add("Name", typeof(string));
            EmployeeDatatable.Columns.Add("Country", typeof(string));
            EmployeeDatatable.Columns.Add("Salary", typeof(double));
            EmployeeDatatable.Columns.Add("Date", typeof(DateTime));

            EmployeeDatatable.Rows.Add(1, "Basheer", "Yemen", 5000, DateTime.Now);
            EmployeeDatatable.Rows.Add(2, "Ali", "Jordan", 3000, DateTime.Now);
            EmployeeDatatable.Rows.Add(3, "Salah", "US", 1000, DateTime.Now);
            EmployeeDatatable.Rows.Add(4, "Mohammed", "Jordan", 3000, DateTime.Now);
            EmployeeDatatable.Rows.Add(5, "Uday", "US", 1000, DateTime.Now);
            Console.WriteLine("\n Employees List \n");
            foreach (DataRow row in EmployeeDatatable.Rows)
            {
                Console.WriteLine(
                            "ID: {0}\tName: {1}\tCountry: {2}\tSalary: {3}\tDate: {4}",
                            row["ID"],
                            row["Name"],
                            row["Country"],
                            row["Salary"],
                            row["Date"]);
            }

            DataTable DepartmentDataTable = new DataTable("DepartmentDataTable");
            DepartmentDataTable.Columns.Add("DepartmentID", typeof(int));
            DepartmentDataTable.Columns.Add("Name", typeof(string));

            DepartmentDataTable.Rows.Add(1, "IT");
            DepartmentDataTable.Rows.Add(2, "CS");
            DepartmentDataTable.Rows.Add(3, "Marketing");

            Console.WriteLine("\n Department List \n");
            foreach (DataRow row in DepartmentDataTable.Rows)
            {
                Console.WriteLine(
                           "DepartmentID: {0}\t Name: {1}",
                           row["DepartmentID"],
                           row["Name"]);
            }

            DataSet dataset1 = new DataSet();
            dataset1.Tables.Add(EmployeeDatatable);
            dataset1.Tables.Add(DepartmentDataTable);
            Console.WriteLine("\n Department List From Data set \n");
            foreach (DataRow row in dataset1.Tables["DepartmentDataTable"].Rows)
            {
                Console.WriteLine(
                            "DepartmentID: {0}\t Name: {1}",
                            row["DepartmentID"],
                            row["Name"]);
            }

        }
    }
}

