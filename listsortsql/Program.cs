using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
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
                    Console.WriteLine("Do you want sort by Ascending or Descending?");
                    Console.WriteLine("1 for Ascending, 2 for Descending. By default, the sort will descend");
                    
                    string direction = Console.ReadLine();
                    bool boolDir = false;
                    if (direction == "1")
                    {
                        watch.Start();
                        Number.ListSort(unsortedNumber, direction, boolDir);
                        boolDir = true;
                    }
                    else if (direction == "2")
                    {
                        watch.Start();
                        Number.ListSort(unsortedNumber, direction, boolDir);
                        boolDir = false;
                    }
                    else
                    {
                        watch.Start();
                        Number.ListSort(unsortedNumber, direction, boolDir);
                        boolDir = false;
                    }
                    string sortedNumber = Number.ListSort(unsortedNumber,direction,boolDir);
                  
                    TimeSpan ts = watch.Elapsed;
                    watch.Stop();


                    
                    Console.WriteLine("Your unsorted number " + unsortedNumber);
                    Console.WriteLine("Your sorted number " + sortedNumber);


                    string elapsedTime = String.Format("{0:00}.{1:00:00}", ts.Seconds, ts.Milliseconds);
                    Console.WriteLine("Runtime " + elapsedTime);


                    //create instanace of database connection
                    SqlConnection conn = new SqlConnection(connString);


                    try
                    {
                        Console.WriteLine("Opening database connection");

                        //open connection
                        conn.Open();

                        Console.WriteLine("Connection successful");
                        //Insert Data
                        SqlCommand cmd = new SqlCommand(@"INSERT INTO NumbersDB.Dbo.NumberTable(UnsortedNumber,SortedNumber,Direction,ElapsedTime) VALUES(@unsortedNumber,@sortedNumber,@Direction,@ElapsedTime);", conn);
                        
                        
                        cmd.Parameters.AddWithValue("@UnsortedNumber", unsortedNumber);
                        cmd.Parameters.AddWithValue("@SortedNumber", sortedNumber);
                        cmd.Parameters.AddWithValue("@ElapsedTime", elapsedTime);
                        cmd.Parameters.AddWithValue("@Direction", boolDir);
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Inserted Data Successfully");


                        //Select Data
                        Console.WriteLine("Do you want to view all previously entered database entries? Type 1 for yes or anything else for no");
                        string ViewEntryCheck = Console.ReadLine();
                        if (ViewEntryCheck == "1")
                        {
                            SqlCommand cmdSelect = new SqlCommand(@"SELECT Id, SortedNumber, Direction, ElapsedTime FROM NumbersDB.dbo.NumberTable", conn);


                            using (SqlDataReader reader = cmdSelect.ExecuteReader())
                            {
                           
                                while (reader.Read())
                                {

                                    Console.WriteLine("Id " + reader[0] + " Sorted Number " + reader[1] + " Direction " + direction + " Elapsed Time " + reader[3]);
                                }
                            }
                        }
                        
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
    




