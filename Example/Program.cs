using System;
using System.Data;
using System.Linq;


namespace Example
{
    internal class Program
    {
        static void Main(string[] args)
        {

            DataTable employeeTable = new DataTable();

            DataColumn dtColumn = new DataColumn();
            dtColumn.DataType = typeof(int);
            dtColumn.ColumnName = "ID";
            dtColumn.AutoIncrement = true;
            dtColumn.AutoIncrementSeed = 1;
            dtColumn.AutoIncrementStep = 1;
            dtColumn.Caption = "Employee ID";
            dtColumn.ReadOnly = true;
            dtColumn.Unique = true;
            employeeTable.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(string);
            dtColumn.ColumnName = "Name";
            dtColumn.AutoIncrement = false;
            dtColumn.AutoIncrementSeed = 1;
           
            dtColumn.ReadOnly = false;
            employeeTable.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(string);
            dtColumn.ColumnName = "Country";
            dtColumn.AutoIncrement = false;
            
            dtColumn.Caption = "Country Name ";
            dtColumn.ReadOnly = false;
            employeeTable.Columns.Add(dtColumn);


            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(double);
            dtColumn.ColumnName = "Salary";
            dtColumn.AutoIncrement = false;
          
            dtColumn.Caption = "Salary";
            dtColumn.ReadOnly = false;
            employeeTable.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(DateTime);
            dtColumn.ColumnName = "Date";
            dtColumn.AutoIncrement = false;
           
            dtColumn.Caption = "Date";
            dtColumn.ReadOnly = false;
            employeeTable.Columns.Add(dtColumn);

            employeeTable.Rows.Add(null, "Basheer", "Yemen", 5000, DateTime.Now);
            employeeTable.Rows.Add(null, "Ali", "Jordan", 3000, DateTime.Now);
            employeeTable.Rows.Add(null, "Salah", "US", 1000, DateTime.Now);
            employeeTable.Rows.Add(null, "Mohammed", "Jordan", 3000, DateTime.Now);
            employeeTable.Rows.Add(null, "Uday", "US", 1000, DateTime.Now);


            DataColumn[] PrimaryKeyColumn = new DataColumn[1];
            PrimaryKeyColumn[0] = employeeTable.Columns["ID"];
            employeeTable.PrimaryKey = PrimaryKeyColumn;




            Console.WriteLine("\nEmployees List \n");
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



            DataView EmployeeDataView1 = employeeTable.DefaultView;

            Console.WriteLine("\nEmployees List from data view\n");
            for(int i=0;i<EmployeeDataView1.Count;i++)
            {
                Console.WriteLine("{0}, {1},{2} ,{3}", EmployeeDataView1[i][0], EmployeeDataView1[i][1],
                    EmployeeDataView1[i][2], EmployeeDataView1[i][3]);
            }


            //EmployeeDataView1.RowFilter = "Country ='Yemen'";
            //Console.WriteLine("\n Employees List from data view after filtering \" Yemen \":\n");
            //for (int i = 0; i < EmployeeDataView1.Count; i++)
            //{
            //    Console.WriteLine("{0}, {1},{2} ,{3}", EmployeeDataView1[i][0], EmployeeDataView1[i][1],
            //        EmployeeDataView1[i][2], EmployeeDataView1[i][3]);
            //}
            EmployeeDataView1.Sort = "Name DESC";
            Console.WriteLine("\n Employees List from data view after Sorting\n");
            for (int i = 0; i < EmployeeDataView1.Count; i++)
            {
                Console.WriteLine("{0}, {1},{2} ,{3}", EmployeeDataView1[i][0], EmployeeDataView1[i][1],
                    EmployeeDataView1[i][2], EmployeeDataView1[i][3]);
            }
            Console.ReadKey();
        }
    }
}
