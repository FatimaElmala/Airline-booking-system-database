using System;
using System.Data.SqlClient;

namespace DatabaseProject
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection("data source=.; database=AirlineBookingSystem; integrated security=SSPI");
                connection.Open();
                Console.WriteLine("Connection is Established");


                string sql_command0 = "delete from PassengerProfile;";
                SqlCommand cmd_3 = new SqlCommand(sql_command0, connection);
                cmd_3.ExecuteNonQuery();

                //------- inserting records 
                string sql_command = "insert into PassengerProfile values (1,'very','Ahemd','Ahmed','Ahmed','cairo','0114547574','testing1@mail.com')";
                string sql_command1 = "insert into PassengerProfile values (2,'secret','Tasneem','Mohamed','Ali','tanta','0114507555','testing2@mail.com')";
                string sql_command2 = "insert into PassengerProfile values (3,'amazing','Essam','Omar','Anas','cairo','0116547574','testing3@mail.com')";
                string sql_command3 = "insert into PassengerProfile values (4,'password','Asmaa','Tasneem','Ebrahim','Alexanderia','0118947513','testing4@mail.com')";

                SqlCommand cmd = new SqlCommand(sql_command, connection);          
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand(sql_command1, connection);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand(sql_command2, connection);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand(sql_command3, connection);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Data inserted successfully ");
                //-----------Retrieving data
                sql_command = "SELECT * FROM PassengerProfile";
                cmd = new SqlCommand(sql_command, connection);

                SqlDataReader Query = cmd.ExecuteReader();

                while (Query.Read())
                {
                    string PassengerProfileID = Query["PassengerProfileID"].ToString();
                    string FirstName = Query["FirstName"].ToString();
                    string LastName = Query["LastName"].ToString();
                    string MobileNum = Query["MobileNum"].ToString();
                   
                    Console.WriteLine("Passenger ID : " + PassengerProfileID + " " + "First Name : " + FirstName + " " + "LastName :" + LastName + " Mobile Number :" + MobileNum);

                }
                Query.Close();

                //------------Deleting the first record in the table 
                string sql_command_del = "delete from PassengerProfile where PassengerProfileID=1;";
                SqlCommand cmd_del = new SqlCommand(sql_command_del, connection);
                cmd_del.ExecuteNonQuery();
                Console.WriteLine("First record deleted successfully.");

                //------------Updating (MobileNum) attribute in the second record
                string str_update = "Update PassengerProfile set MobileNum='01096543245' where PassengerProfileID=2";
                SqlCommand cmd_update = new SqlCommand(str_update, connection);
                cmd_update.ExecuteNonQuery();
                Console.WriteLine("mobile number of the passenger with ID=2 is updated to 01096543245");



                //-------------Re-Retrieving the data
                sql_command = "SELECT * FROM PassengerProfile";
                cmd = new SqlCommand(sql_command, connection);

               Query = cmd.ExecuteReader();

                while (Query.Read())
                {
                    string PassengerProfileID = Query["PassengerProfileID"].ToString();
                    string FirstName = Query["FirstName"].ToString();
                    string LastName = Query["LastName"].ToString();
                    string MobileNum = Query["MobileNum"].ToString();

                    Console.WriteLine("Passenger ID : " + PassengerProfileID + " " + "First Name : " + FirstName + " " + "LastName :" + LastName + " Mobile Number :" + MobileNum);

                }
                Query.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong." + e);
            }
            // Closing the connection  
            finally
            {
                connection.Close();
            }





        }
    }
}
