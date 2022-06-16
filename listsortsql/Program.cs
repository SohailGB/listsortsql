using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace listsortsql
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Number number = new Number();
            Stopwatch watch = new Stopwatch();
            Regex regex = new Regex("^[0-9]*$"); //Regex numbers only
            string unsortedNumber = String.Empty;
            bool inputCheck = false;

            //your connection string 
            string connString = @"Data Source=SOHAIL-PC\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


            while (!inputCheck)
            {
                Console.WriteLine("Write a number. Only numbers are valid");
                unsortedNumber = Console.ReadLine();
                if (((regex.IsMatch(unsortedNumber))))
                {
                    inputCheck = true;
                    Console.WriteLine("REGEX PASSED");
                    watch.Start();

                    string sortedNumber = Number.ListSort(unsortedNumber);

                    Number.ListSort(unsortedNumber);
                    TimeSpan ts = watch.Elapsed;


                    //TODO: Implement directions
                    Console.WriteLine("Your unsorted number " + unsortedNumber);
                    Console.WriteLine("Your sorted number " + sortedNumber);

                    string elapsedTime = String.Format("{0:00}.{1:00:00}", ts.Seconds, ts.Milliseconds);
                    Console.WriteLine("Runtime " + elapsedTime);

                    watch.Stop();

                    //create instanace of database connection
                    SqlConnection conn = new SqlConnection(connString);


                    try
                    {
                        Console.WriteLine("Opening Database Connection");

                        //open connection
                        conn.Open();
                        Console.WriteLine("Connection successful");

                        SqlCommand cmd = new SqlCommand(@"INSERT INTO NumbersDB.Dbo.NumberTable(UnsortedNumber,SortedNumber,Direction) VALUES(@unsortedNumber,@sortedNumber,'4');", conn);
                        cmd.Parameters.AddWithValue("@UnsortedNumber", unsortedNumber);
                        cmd.Parameters.AddWithValue("@SortedNumber", sortedNumber);
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Inserted Data Successfully");
                        conn.Close();

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error: " + e.Message);
                        Console.ReadLine();


                    }
                }
            }

          
            Console.ReadLine();
        }

    }
}
    




