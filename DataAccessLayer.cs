using System;
using System.Data.SqlClient;

public class DataAccessLayer
{
    public void GoToMain()
    {

        DataAccessLayer obj = new DataAccessLayer();
        Console.WriteLine("******************************************************************************");
        Console.WriteLine("WELCOME TO STUDENT REGISTRATION, PLEASE CHOOSE AN OPTION");
        Console.WriteLine("******************************************************************************");
        Console.WriteLine("1. View Registered Student");
        Console.WriteLine("2. View The Registered Courses");
        Console.WriteLine("3. Add New Student");
        Console.WriteLine("4. Add New Courses");
        Console.WriteLine("5. update to Student");
        Console.WriteLine("6. update to Courses");
        Console.WriteLine("7. Delete from Student");
        Console.WriteLine("8. Delete from Courses");
        var input = Convert.ToInt32(Console.ReadLine());
        Console.Clear();

        if (input == 1)
        {
            obj.GetStudent();
        }
        else if (input == 2)
        {
            obj.GetCourses();
        }
        else if (input == 3)
        {
            obj.insertvalueTOStudent();
        }
        else if (input == 4)
        {
            obj.insertvalueTOCourses();
        }
        else if (input == 5)
        {
            obj.updatestudent();
        }
        else if (input == 6)
        {
            obj.updateCourses();
        }
        else if (input == 7)
        {
            obj.Deletestudent();
        }
        else if (input == 8)
        {
            obj.Deletecourse();
        }
        else
        {
            Console.WriteLine("invalid option!! ");
        }

    }
    public void GetCourses()
    {
        try
        {
            SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-RJVLR4L\SQLEXPRESS; Initial Catalog=CBUDB; Integrated Security=SSPI");

            connect.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Courses", connect);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"CourseID: {reader.GetValue(0)}\nCourseName: {reader.GetValue(1)}\nCredits: {reader.GetValue(2)}");

                //Console.WriteLine("Enter 9 to go back to Main");
                //var option1 = Convert.ToInt32(Console.ReadLine());
                //if (option1 == 9)
                //{
                //    Console.Clear();
                //    GoToMain();
                //}
            }

            connect.Close();
        }
        catch (Exception)
        {
            Console.WriteLine("something went wrong in course");
        }
    }

    public void GetStudent() // get student data from database
    {
        try
        {
            SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-RJVLR4L\SQLEXPRESS; Initial Catalog=CBUDB; Integrated Security=SSPI");

            connect.Open(); //we open the the connection to our database
            SqlCommand cmd = new SqlCommand("SELECT * FROM Students", connect);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
              Console.WriteLine($"studentID: {reader.GetValue(0)}");
              Console.WriteLine($"firstName: {reader.GetValue(1)}");
            Console.WriteLine($"lastName: {reader.GetValue(2)}");
            Console.WriteLine($"Email: {reader.GetValue(3)}");
            Console.WriteLine($"DateOfbirth: {reader.GetValue(4)}");
            Console.WriteLine("");

                //Console.WriteLine("Enter 9 to go back to Main");
                //var option1 = Convert.ToInt32(Console.ReadLine());
                //if (option1 == 9)
                //{
                //    Console.Clear();
                //    GoToMain();
                //}

            }
            connect.Close();
        }
        catch (Exception)
        {
            Console.WriteLine("something went wrong");
        }
    }

    public void insertvalueTOStudent() // Adding new students to the database
    {
        try
        {
            SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-RJVLR4L\SQLEXPRESS; Initial Catalog=CBUDB; Integrated Security=SSPI");

            Console.WriteLine("Enter studentID:");
            var studentIDInput = Console.ReadLine();
            int _StudentID;

            if (!string.IsNullOrWhiteSpace(studentIDInput) && int.TryParse(studentIDInput, out _StudentID))
            {
                Console.WriteLine("Enter firstname:");
                var _FirstName = Console.ReadLine();
                Console.WriteLine("Enter lastname:");
                var _LastName = Console.ReadLine();
                Console.WriteLine("Enter Email:");
                var _Email = Console.ReadLine();
                Console.WriteLine("Enter Date of birth (YYYY-MM-DD):");
                var _DateOfBirth = Console.ReadLine();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandText = "INSERT INTO Students (StudentID, FirstName, LastName, Email, DateOfBirth) VALUES (@StudentID, @FirstName, @LastName, @Email, @DateOfBirth)";
                cmd.Parameters.AddWithValue("@StudentID", _StudentID);
                cmd.Parameters.AddWithValue("@FirstName", _FirstName);
                cmd.Parameters.AddWithValue("@LastName", _LastName);
                cmd.Parameters.AddWithValue("@Email", _Email);
                cmd.Parameters.AddWithValue("@DateOfBirth", _DateOfBirth);

                connect.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                connect.Close();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Student was added successfully!");
                    Console.WriteLine("Enter 9 to go back to Main");
                    var option1 = Convert.ToInt32(Console.ReadLine());
                    if (option1 == 9)
                    {
                        Console.Clear();
                        GoToMain();
                    }
                }
                else
                {
                    Console.WriteLine("Failed to add student!");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for StudentID. Please enter a valid integer value.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }


    public void insertvalueTOCourses()
    {
        try
        {
            SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-RJVLR4L\SQLEXPRESS; Initial Catalog=CBUDB; Integrated Security=SSPI");

            Console.WriteLine("Enter courseID:");
            var _CourseID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter coursename:");
            var _CourseName = Console.ReadLine();
            Console.WriteLine("Enter credit:");
            var _Credit = int.Parse(Console.ReadLine());

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "INSERT INTO Courses(CourseID, CourseName, Credits) VALUES (@CourseID, @CourseName, @Credits)";
            cmd.Parameters.AddWithValue("@CourseID", _CourseID);
            cmd.Parameters.AddWithValue("@CourseName", _CourseName);
            cmd.Parameters.AddWithValue("@Credits", _Credit);

            connect.Open();
            int _rows = cmd.ExecuteNonQuery();
            connect.Close();

            if (_rows > 0)
            {
                Console.WriteLine("Course Was Added successfully!");
                Console.WriteLine("Enter 9 to go back to Main");
                var option1 = Convert.ToInt32(Console.ReadLine());
                if (option1 == 9)
                {
                    Console.Clear();
                    GoToMain();
                }
            }
            else
            {
                Console.WriteLine("Failed to Add Course, Please try Again!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }




    public void updatestudent() //We update Student Details here... 
    {
        try
        {
            SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-RJVLR4L\SQLEXPRESS; Initial Catalog=CBUDB; Integrated Security=SSPI");

            Console.WriteLine("Enter new studentID:");
            var _StudentID = int.Parse(Console.ReadLine());
            Console.WriteLine("Please Enter new firstname:");
            var _FirstName = (Console.ReadLine());
            Console.WriteLine("Please Enter new lastname:");
            var _LastName = (Console.ReadLine());
            Console.WriteLine("Please Enter new Email:");
            var _Email = (Console.ReadLine());
            Console.WriteLine("Please Enter new Date of birth:");
            var _DateOfBirth = (Console.ReadLine());

            SqlCommand cmd = new SqlCommand(); 
            cmd.Connection = connect;
            cmd.CommandText = "update Students set FirstName=@FirstName,LastName=@LastName,Email=@Email,DateOfBirth=@DateOfBirth where StudentID=@StudentID";
            cmd.Parameters.AddWithValue("@StudentID", _StudentID);
            cmd.Parameters.AddWithValue("@FirstName", _FirstName);
            cmd.Parameters.AddWithValue("@LastName", _LastName);
            cmd.Parameters.AddWithValue("@Email", _Email);
            cmd.Parameters.AddWithValue("@DateOfBirth", _DateOfBirth);

            connect.Open();
            int _rows = cmd.ExecuteNonQuery();
            connect.Close();

            if (_rows > 0)
            {
                Console.WriteLine($"{_rows} update successfully!");
                
            }
            else
            {
                Console.WriteLine("update Failed!");
            }
        }
        catch (Exception)
        {
            Console.WriteLine("something went wrong!");
        }
    }

    public void updateCourses()// we update the course Details...
    {
        try
        {
            SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-RJVLR4L\SQLEXPRESS; Initial Catalog=CBUDB; Integrated Security=SSPI");

            Console.WriteLine("Enter new courseID:");
            var _CourseID = (Console.ReadLine());
            Console.WriteLine("Enter new coursename:");
            var _CourseName = (Console.ReadLine());
            Console.WriteLine("Enter new credit:");
            var _Credit = (Console.ReadLine());

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "update Courses set CourseName=@CourseName,Credit=@Credit where CourseID=@CourseID ";
            cmd.Parameters.AddWithValue("@CourseID", _CourseID);
            cmd.Parameters.AddWithValue("@CourseName", _CourseName);
            cmd.Parameters.AddWithValue("@Credit", _Credit);

            connect.Open();
            int _rows = cmd.ExecuteNonQuery();
            connect.Close();

            if (_rows > 0)
            {
                Console.WriteLine($"{_rows} updated successfull!");
            }
            else
            {
                Console.WriteLine("Failed to update!");
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Something Went Wrong!!");
        }
    }

    public void Deletestudent() //we remove the existing student gere...
    {
        try
        {
            SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-RJVLR4L\SQLEXPRESS; Initial Catalog=CBUDB; Integrated Security=SSPI");

            Console.WriteLine("Enter StudentID:");
            var _StudentID = int.Parse(Console.ReadLine());

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "delete from Students where StudentID=@StudentID";
            cmd.Parameters.AddWithValue("@StudentID", _StudentID);

            connect.Open();
            int _rows = cmd.ExecuteNonQuery();
            connect.Close();

            if (_rows > 0)
            {
                Console.WriteLine($"{_rows} Row(s) Deleted successfully!");
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Fail to Delete! or invalid StudentID Number in studentDB");
        }
    }

    public void Deletecourse() //remove Existing Course
    {
        try
        {
            SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-RJVLR4L\SQLEXPRESS; Initial Catalog=CBUDB; Integrated Security=SSPI");

            Console.WriteLine("Enter new courseID:");
            var _CourseID = (Console.ReadLine());

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "delete from Courses where CourseID=@CourseID ";
            cmd.Parameters.AddWithValue("@CourseID", _CourseID);

            connect.Open();
            int _rows = cmd.ExecuteNonQuery();
            connect.Close();

            if (_rows > 0)
            {
                Console.WriteLine($"{_rows} Course was Deleted successfully!");
                Console.WriteLine("Enter 0 to go bacj to Main");
                Console.Clear();
                var opt = Convert.ToInt32(Console.ReadLine());
                if (opt == 0)
                {
                    GoToMain();
                }
            }
            else
            {
                Console.WriteLine("Fail to Delete! or invalid ID Entered");
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Failded to Delete! or invalid StudentID Number");
        }
    }
}
