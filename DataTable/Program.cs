using System;
using System.Data;
using System.Linq;

namespace DataTableDemo
{
    internal class Program
    {

        static DataTable CreateEmployeeTable()
        {

            DataTable Datatable = new DataTable();
            Datatable.Columns.Add("ID",typeof(int));
            Datatable.Columns.Add("Name",typeof(string));
            Datatable.Columns.Add("Country", typeof(string));
            Datatable.Columns.Add("Salary", typeof(double));
            Datatable.Columns.Add("Date", typeof(DateTime));

            return Datatable;

        }

        static void AddEmployee(DataTable table,int id, string name,string country, double salary, DateTime date)
        {
            table.Rows.Add(id, name, country, salary, date);
        }
        static void ShowEmployees(string filter)
        {
            DataTable employeeTable = CreateEmployeeTable();

            AddEmployee(employeeTable, 1, "Basheer", "Yemen", 5000, DateTime.Now);
            AddEmployee(employeeTable, 2, "Ali", "Jordan", 3000, DateTime.Now);
            AddEmployee(employeeTable, 3, "Salah", "US", 1000, DateTime.Now);
            AddEmployee(employeeTable, 5, "Mohammed", "Jordan", 3000, DateTime.Now);
            AddEmployee(employeeTable, 4, "Uday", "US", 1000, DateTime.Now);


            int employeeCount;
            double totalSalary;
            double averageSalary;
            double minSalary;
            double maxSalary;

            if (!string.IsNullOrWhiteSpace(filter))
            {
                Console.WriteLine($"Filter: {filter}\n");

                DataRow[] resultRows = employeeTable.Select(filter);

                foreach (DataRow row in resultRows)
                {
                    Console.WriteLine(
                        "ID: {0}\tName: {1}\tCountry: {2}\tSalary: {3}\tDate: {4}",
                        row["ID"],
                        row["Name"],
                        row["Country"],
                        row["Salary"],
                        row["Date"]);
                }

                employeeCount = resultRows.Length;
                totalSalary = Convert.ToDouble(employeeTable.Compute("SUM(Salary)", filter));
                averageSalary = Convert.ToDouble(employeeTable.Compute("AVG(Salary)", filter));
                minSalary = Convert.ToDouble(employeeTable.Compute("Min(Salary)", filter));
                maxSalary = Convert.ToDouble(employeeTable.Compute("Max(Salary)", filter));

            }
            else
            {
                Console.WriteLine("All Employees\n");

                foreach (DataRow row in employeeTable.Rows)
                {
                    Console.WriteLine(
                        "ID: {0}\tName: {1}\tCountry: {2}\tSalary: {3}\tDate: {4}",
                        row["ID"],
                        row["Name"],
                        row["Country"],
                        row["Salary"],
                        row["Date"]);
                }

                employeeCount = employeeTable.Rows.Count;

                totalSalary = Convert.ToDouble(employeeTable.Compute("SUM(Salary)", string.Empty));
                averageSalary = Convert.ToDouble(employeeTable.Compute("AVG(Salary)", string.Empty));
                minSalary = Convert.ToDouble(employeeTable.Compute("MIN(Salary)", string.Empty));
                maxSalary = Convert.ToDouble(employeeTable.Compute("MAX(Salary)", string.Empty));
            }

            //employeeTable.DefaultView.Sort = "ID DESC";
            //employeeTable = employeeTable.DefaultView.ToTable();
            //Console.WriteLine("\nSorted by ID DESC\n");
            //foreach (DataRow row in employeeTable.Rows)
            //{
            //    Console.WriteLine(
            //                "ID: {0}\tName: {1}\tCountry: {2}\tSalary: {3}\tDate: {4}",
            //                row["ID"],
            //                row["Name"],
            //                row["Country"],
            //                row["Salary"],
            //                row["Date"]);

            //}

            //employeeTable.DefaultView.Sort = "Name ASC";
            //employeeTable = employeeTable.DefaultView.ToTable();
            //Console.WriteLine("\nSorted by Name ASC\n");
            //foreach (DataRow row in employeeTable.Rows)
            //{
            //    Console.WriteLine(
            //                "ID: {0}\tName: {1}\tCountry: {2}\tSalary: {3}\tDate: {4}",
            //                row["ID"],
            //                row["Name"],
            //                row["Country"],
            //                row["Salary"],
            //                row["Date"]);

            //}


            //DataRow[] Results = employeeTable.Select("ID=5");
            //foreach(var row in Results)
            //{
            //    row.Delete();
            //}
            //Console.WriteLine("\n Delete ID =5 \n");
            //foreach (DataRow row in employeeTable.Rows)
            //{
            //    Console.WriteLine(
            //                "ID: {0}\tName: {1}\tCountry: {2}\tSalary: {3}\tDate: {4}",
            //                row["ID"],
            //                row["Name"],
            //                row["Country"],
            //                row["Salary"],
            //                row["Date"]);

            //}

            //Console.WriteLine("\n Update ID =5 \n");
            //DataRow[] Results = employeeTable.Select("ID=5");
            //foreach (var row in Results)
            //{
            //    row["Name"] = "Mohammed";
            //    row["Salary"] = "9000";
            //}
            //foreach (DataRow row in employeeTable.Rows)
            //{
            //    Console.WriteLine(
            //                "ID: {0}\tName: {1}\tCountry: {2}\tSalary: {3}\tDate: {4}",
            //                row["ID"],
            //                row["Name"],
            //                row["Country"],
            //                row["Salary"],
            //                row["Date"]);
            //}
        }


        static void Main(string[] args)
        {

            ShowEmployees("");
        }
    }
}
