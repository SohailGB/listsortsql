using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace listsortsql
{
    internal class Program
    {
        public static string ListSort(string unsortedNumber)
        {
            List<int> numList = new List<int>();
            numList = unsortedNumber.Select(x => (int)char.GetNumericValue(x)).ToList();
            numList.Sort((a, b) => a.CompareTo(b));
            string sortedNumber = string.Empty;
            foreach (int num in numList)
            {
                sortedNumber += "" + num;
            }
            return sortedNumber;

        }
        static void Main(string[] args)
        {
            //TODO: WRAP ALL OF THIS INTO FUNCTIONS AND TIDY IT UP

            Console.WriteLine("Getting Connection ...");

            var datasource = @"SOHAIL-PC\SQLEXPRESS";//your server
            var database = "NumbersDB"; //your database name
            //your connection string 
            string connString = @"Data Source=SOHAIL-PC\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";



            Console.WriteLine("Write a number");
            
            //This all needs to be a function
            string unsortedNumber = Console.ReadLine();

            Console.WriteLine("Write a direction");
                //TODO: Modify the ListSort function to accept a parameter of ascending/descending


            string sortedNumber = ListSort(unsortedNumber);

            ListSort(unsortedNumber);

            Console.WriteLine(unsortedNumber);
            Console.WriteLine(sortedNumber);



            //create instanace of database connection
            SqlConnection conn = new SqlConnection(connString);


            try
            {
                Console.WriteLine("Opening Connection ...");

                //open connection
                conn.Open();
                Console.WriteLine("Connection successful!");

                SqlCommand cmd = new SqlCommand(@"INSERT INTO NumbersDB.Dbo.NumberTable(Id,UnsortedNumber,SortedNumber,Direction) VALUES('1',@unsortedNumber,@sortedNumber,'4');", conn);
                cmd.Parameters.AddWithValue("@UnsortedNumber", unsortedNumber);
                cmd.Parameters.AddWithValue("@SortedNumber", sortedNumber);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Inserted Data Successfully");
                conn.Close();    

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

 


                Console.Read();

        }



    }
}
