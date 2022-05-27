using System.Data.SqlClient;
using TuitionManagementSystemWebApp.DataModel;
using TuitionManagementSystemWebApp.Helpers;

namespace TuitionManagementSystemWebApp.DataAccess
{
    public class StudentDataAccess
    {
        public string ErrorMessage { get; private set; }



        //Get All Departmentss


        public List<StudentDataModel> GetAll()
        {
            try

            {
                ErrorMessage = string.Empty;
                ErrorMessage = "";

                List<StudentDataModel> students = new List<StudentDataModel>();

                using (SqlConnection conn = DataBase.GetConnection())
                {
                    conn.Open();

                    var sqlStmt = $" Select S.StudentId ,S.FirstName ,S.LastName ,S.DOB ,S.Age ,S.Address ,S.Gender ,S.Email ,S.MobileNumber ,S.Mark ,S.TotalMark ,S.Status ,S.TrainerId  From dbo.Student AS S "
                        +
                        " INNER JOIN[dbo].Trainer AS T ON S.TrainerId = T.TrainerId ";

                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                StudentDataModel student = new StudentDataModel();

                                student.StudentId = reader.GetInt32(0);
                                student.FirstName = reader.GetString(1);
                                student.LastName = reader.GetString(2);
                                student.DOB = reader.GetDateTime(3); 
                                student.Age = reader.GetString(4);
                                student.Address = reader.GetString(5);

                                student.Gender = reader.GetString(6);
                                student.Email = reader.GetString(7);
                                student.MobileNumber = reader.GetString(8);
                                student.Mark = reader.GetString(9);
                                student.TotalMark = reader.GetString(10);
                                student.Status = reader.GetString(11);
                                student.TrainerId = reader.GetInt32(12);


                                students.Add(student);
                            }
                        }
                    }

                }
                return students;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }
        }


        public StudentDataModel GetStudentById(int studentid)
        {
            try
            {
                ErrorMessage = string.Empty;




                StudentDataModel student = null;
                using (SqlConnection conn = DataBase.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $" Select StudentId ,FirstName ,LastName ,DOB ,Age ,Address ,Gender ,Email ,MobileNumber ,Mark ,TotalMark ,Status ,TrainerId  From dbo.Student where StudentId = {studentid}"; 
                        

                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read() == true)
                            {
                               
                                
                                 student = new StudentDataModel();

                                student.StudentId = reader.GetInt32(0);
                                student.FirstName = reader.GetString(1);
                                student.LastName = reader.GetString(2);
                                student.DOB = reader.GetDateTime(3);
                                student.Age = reader.GetString(4);
                                student.Address = reader.GetString(5);

                                student.Gender = reader.GetString(6);
                                student.Email = reader.GetString(7);
                                student.MobileNumber = reader.GetString(8);
                                student.Mark = reader.GetString(9);
                                student.TotalMark = reader.GetString(10);
                                student.Status = reader.GetString(11);
                                student.TrainerId = reader.GetInt32(12);

                            }
                        }
                    }
                }


                return student;
            }

            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }


        }

        public List<StudentDataModel> GetStudentByName(string firstname, string Address)
        {
            try
            {

                ErrorMessage = String.Empty;
                ErrorMessage = "";

                List<StudentDataModel> students = new List<StudentDataModel>();
                StudentDataModel department = null;

                using (SqlConnection conn = DataBase.GetConnection())

                {
                    conn.Open();
                    string sqlStmt = "Select StudentId,FirstName,LastName,DOB,Age,Address,Gender,Email,MobileNumber,Mark,TotalMark,Status,TrainerId From dbo.Student";

                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                StudentDataModel student = new StudentDataModel();

                                student.StudentId = reader.GetInt32(0);
                                student.FirstName = reader.GetString(1);
                                student.LastName = reader.GetString(2);
                                student.DOB = reader.GetDateTime(3);
                                student.Age = reader.GetString(4);
                                student.Address = reader.GetString(5);

                                student.Gender = reader.GetString(6);
                                student.Email = reader.GetString(7);
                                student.MobileNumber = reader.GetString(8);
                                student.Mark = reader.GetString(9);
                                student.TotalMark = reader.GetString(10);
                                student.Status = reader.GetString(11);
                                student.TrainerId = reader.GetInt32(12);


                                students.Add(student);
                            }
                        }
                    }

                }
                return students;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }

        }


        public bool Insert(StudentDataModel trainer)
        {
            try
            {
                ErrorMessage = string.Empty;

                using (SqlConnection conn = DataBase.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"INSERT INTO dbo.Student (FirstName,LastName,DOB,Age,Address,Gender,Email,MobileNumber,Mark,TotalMark,Status,TrainerId) VALUES ('{trainer.FirstName}','{trainer.LastName}', '{trainer.DOB.ToString("yyyy-MM-dd")}','{trainer.Age}','{trainer.Address}','{trainer.Gender}','{trainer.Email}','{trainer.MobileNumber}','{trainer.Mark}','{trainer.TotalMark}','{trainer.Status}',{trainer.TrainerId}); SELECT SCOPE_IDENTITY();";

                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        int idInserted = Convert.ToInt32(cmd.ExecuteScalar());
                        if (idInserted > 0)
                        {
                            trainer.StudentId = idInserted;

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

        public StudentDataModel Update(StudentDataModel updatestudent)
        {
            try
            {
                ErrorMessage = String.Empty;

                using (SqlConnection conn = DataBase.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"UPDATE dbo.Student SET FirstName = '{updatestudent.FirstName}',LastName='{updatestudent.LastName}', DOB='{updatestudent.DOB.ToString("yyyy-MM-dd")}',Age ='{updatestudent.Age}',Address = '{updatestudent.Address}',Gender = '{updatestudent.Gender}',Email = '{updatestudent.Email}',MobileNumber ='{updatestudent.MobileNumber}',Mark='{updatestudent.Mark}',TotalMark ='{updatestudent.TotalMark}',Status = '{updatestudent.Status}',TrainerId = '{updatestudent.TrainerId}'  " +
                        $" WHERE StudentId = {updatestudent.StudentId}";

                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        int numOfRows = cmd.ExecuteNonQuery();
                        if (numOfRows > 0)
                        {
                            return updatestudent;
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;

            }
            return null;

        }

    }

}
