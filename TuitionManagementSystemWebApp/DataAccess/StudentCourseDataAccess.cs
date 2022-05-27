using System.Data.SqlClient;
using TuitionManagementSystemWebApp.DataModel;
using TuitionManagementSystemWebApp.Helpers;

namespace TuitionManagementSystemWebApp.DataAccess
{
    public class StudentCourseDataAccess
    {

        public string ErrorMessage { get; private set; }



        //Get All Departmentss


        public List<StudentCourseDataModel> GetAll()
        {
            try

            {
                ErrorMessage = string.Empty;
                ErrorMessage = "";

                List<StudentCourseDataModel> courses = new List<StudentCourseDataModel>();

                using (SqlConnection conn = DataBase.GetConnection())
                {
                    conn.Open();

                    var sqlStmt = $"  Select CourseId ,CourseName, S.StudentId,T.TrainerId From dbo.StudentCourse AS SC" +


                       " INNER JOIN[dbo].Student AS S ON SC.StudentId = S.StudentId " +

                       " INNER JOIN[dbo]. Trainer AS T ON SC.TrainerId = T.TrainerId ";





                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                StudentCourseDataModel course = new StudentCourseDataModel();

                                course.CourseId = reader.GetInt32(0);
                                course.CourseName = reader.GetString(1);
                                course.StudentId = reader.GetInt32(2);
                                course.TrainerId = reader.GetInt32(3);


                                courses.Add(course);
                            }
                        }
                    }

                }
                return courses;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }

        }

        public List<StudentCourseDataModel> GetStudentCourseByName(string coursename)
        {
            try
            {

                ErrorMessage = String.Empty;
                ErrorMessage = "";

                List<StudentCourseDataModel> courses = new List<StudentCourseDataModel>();
                StudentCourseDataModel course = null;

                using (SqlConnection conn = DataBase.GetConnection())

                {
                    conn.Open();
                    string sqlStmt = "Select CourseId,CourseName,StudentId,TrainerId From dbo.StudentCourse";

                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                course = new StudentCourseDataModel();

                                course.CourseId = reader.GetInt32(0);
                                course.CourseName = reader.GetString(1);
                                course.StudentId = reader.GetInt32(2);
                                course.TrainerId = reader.GetInt32(3);


                                courses.Add(course);
                            }
                        }
                    }

                }
                return courses;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }

        }

        public bool Insert(StudentCourseDataModel course)
        {
            try
            {
                ErrorMessage = string.Empty;
                int idInserted = 0;
                using (SqlConnection conn = DataBase.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"INSERT INTO dbo.StudentCourse (CourseName, StudentId,TrainerId) VALUES ('{course.CourseName}', {course.StudentId},{course.TrainerId}); SELECT SCOPE_IDENTITY();";

                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        idInserted = Convert.ToInt32(cmd.ExecuteScalar());
                        if (idInserted > 0)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                this.ErrorMessage = ex.Message;
                return false;
            }


        }

        //update

        public bool Update(StudentCourseDataModel newcourse)
        {
            try
            {
                ErrorMessage = "";
                using (SqlConnection conn = DataBase.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"UPDATE dbo.Trip set CourseName = '{newcourse.CourseName}', StudentId = {newcourse.StudentId},TrainerId = {newcourse.TrainerId}  where CourseId={newcourse.CourseId}";


                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        int numOfRows = cmd.ExecuteNonQuery();
                        if (numOfRows > 0)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            return false;

        }


        //By Id

        public StudentCourseDataModel GetCourseById(int courseid)
        {
            try
            {
                ErrorMessage = string.Empty;




                StudentCourseDataModel course = null;
                using (SqlConnection conn = DataBase.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $" Select CourseId ,CourseName, StudentId,TrainerId   From dbo.StudentCourse where CourseId = {courseid}";


                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read() == true)
                            {


                                course = new StudentCourseDataModel();

                                course.CourseId = reader.GetInt32(0);
                                course.CourseName = reader.GetString(1);
                                course.StudentId = reader.GetInt32(2);
                                course.TrainerId = reader.GetInt32(3);

                            }
                        }
                    }
                }


                return course;
            }

            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }


        }

        public int Delete(int courseid)
        {
            try
            {
                ErrorMessage = String.Empty;
                int numOfRows = 0;
                using (SqlConnection conn = DataBase.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"DELETE FROM dbo.StudentCourse WHERE CourseId ={courseid}";

                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        numOfRows = cmd.ExecuteNonQuery();
                    }

                }
                return numOfRows;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            return 0;


        }
    }

}
