using System.Data.SqlClient;
using TuitionManagementSystemWebApp.DataModel;
using TuitionManagementSystemWebApp.Helpers;

namespace TuitionManagementSystemWebApp.DataAccess
{
    public class StudentAssignmentDataAccess
    {
        public string ErrorMessage { get; private set; }



        //Get All Departmentss


        public List<StudentAssignmentDataModel> GetAll()
        {
            try

            {
                ErrorMessage = string.Empty;
                ErrorMessage = "";

                List<StudentAssignmentDataModel> Assignments = new List<StudentAssignmentDataModel>();

                using (SqlConnection conn = DataBase.GetConnection())
                {
                    conn.Open();

                    var sqlStmt = $"  Select AssignmentId ,AssignmentType,AssignmentQuestion,T.TrainerId, S.StudentId,SC.CourseId From dbo.StudentAssignment AS SA " +


                       " INNER JOIN[dbo]. Trainer AS T ON SA.TrainerId = T.TrainerId " +

                       " INNER JOIN[dbo].Student AS S ON SA.StudentId = S.StudentId " +

                       " INNER JOIN[dbo].StudentCourse AS SC ON SA.CourseId = SC.CourseId ";





                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                StudentAssignmentDataModel Assignment = new StudentAssignmentDataModel();

                                Assignment.AssignmentId = reader.GetInt32(0);
                                Assignment.AssignmentType = reader.GetString(1);

                                Assignment.AssignmentQuestion = reader.GetString(2);
                                Assignment.TrainerId = reader.GetInt32(3);
                                Assignment.StudentId = reader.GetInt32(4);

                                Assignment.CourseId = reader.GetInt32(5);



                                Assignments.Add(Assignment);
                            }
                        }
                    }

                }
                return Assignments;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }

        }

        public List<StudentAssignmentDataModel> GetAssignmentByName(string assignmenttype)
        {
            try
            {

                ErrorMessage = String.Empty;
                ErrorMessage = "";

                List<StudentAssignmentDataModel> Assignments = new List<StudentAssignmentDataModel>();
                StudentAssignmentDataModel Assignment = null;

                using (SqlConnection conn = DataBase.GetConnection())

                {
                    conn.Open();
                    string sqlStmt = "Select  AssignmentId ,AssignmentType,AssignmentQuestion,TrainerId, StudentId,CourseId From dbo.StudentAssignment";

                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                Assignment = new StudentAssignmentDataModel();

                                Assignment.AssignmentId = reader.GetInt32(0);
                                Assignment.AssignmentType = reader.GetString(1);

                                Assignment.AssignmentQuestion = reader.GetString(2);
                                Assignment.TrainerId = reader.GetInt32(3);
                                Assignment.StudentId = reader.GetInt32(4);

                                Assignment.CourseId = reader.GetInt32(5);

                                Assignments.Add(Assignment);


                            }
                        }
                    }

                }
                return Assignments;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }
        }
        // INsert
        public bool Insert(StudentAssignmentDataModel assignment)
        {
            try
            {
                ErrorMessage = string.Empty;
                int idInserted = 0;
                using (SqlConnection conn = DataBase.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"INSERT INTO dbo.StudentAssignment (AssignmentType,AssignmentQuestion,TrainerId, StudentId,CourseId) VALUES ('{assignment.AssignmentType}', '{assignment.AssignmentQuestion}',{assignment.TrainerId},{assignment.StudentId},{assignment.CourseId}); SELECT SCOPE_IDENTITY();";

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

        public bool Update(StudentAssignmentDataModel newassignment)
        {
            try
            {
                ErrorMessage = "";
                using (SqlConnection conn = DataBase.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"UPDATE dbo.StudentAssignment  set   AssignmentType = '{newassignment.AssignmentType}',AssignmentQuestion = '{newassignment.AssignmentQuestion}',TrainerId = {newassignment.TrainerId}, StudentId = {newassignment.StudentId}, CourseId = {newassignment.CourseId} where AssignmentId = {newassignment.AssignmentId}";


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

        public StudentAssignmentDataModel GetAssignmentById(int assignmentid)
        {
            try
            {
                ErrorMessage = string.Empty;




                StudentAssignmentDataModel assignment = null;
                using (SqlConnection conn = DataBase.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $" Select AssignmentId ,AssignmentType,AssignmentQuestion,TrainerId ,StudentId,CourseId  From dbo.StudentAssignment where AssignmentId = {assignmentid}";


                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read() == true)
                            {


                                assignment = new StudentAssignmentDataModel();
                                
                                assignment.AssignmentId = reader.GetInt32(0);
                                assignment.AssignmentType = reader.GetString(1);
                                assignment.AssignmentQuestion = reader.GetString(2);
                                assignment.TrainerId = reader.GetInt32(3);
                                assignment.StudentId = reader.GetInt32(4);
                                assignment.CourseId = reader.GetInt32(5);

                            }
                        }
                    }
                }


                return assignment;
            }

            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }


        }


        public StudentAssignmentDataModel GetAssignById(int assignmentid)
        {
            try
            {
                ErrorMessage = string.Empty;




                StudentAssignmentDataModel assignment = null;
                using (SqlConnection conn = DataBase.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $" Select AssignmentQuestion  From dbo.StudentAssignment where AssignmentId = {assignmentid}";


                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read() == true)
                            {


                                assignment = new StudentAssignmentDataModel();


                                assignment.AssignmentQuestion = reader.GetString(0);


                            }
                        }
                    }
                }


                return assignment;
            }

            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }
        }


            public int Delete(int assignmentid)
            {
            try
            {
                ErrorMessage = String.Empty;
                int numOfRows = 0;
                using (SqlConnection conn = DataBase.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"DELETE FROM dbo.StudentAssignment WHERE AssignmentId ={assignmentid}";

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