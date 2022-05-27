using System.Data.SqlClient;
using TuitionManagementSystemWebApp.DataModels;
using TuitionManagementSystemWebApp.Helpers;

namespace TuitionManagementSystemWebApp.DataAccess
{
    public class DashBoardDataAccess
    {
        public string ErrorMessage { get; private set; }



        public DashBoardDataModel GetAll()
        {
            try
            {
                ErrorMessage = String.Empty;
                ErrorMessage = "";
                DashBoardDataModel d = new DashBoardDataModel();
                using (SqlConnection conn = DataBase.GetConnection())
                {
                    conn.Open();

                    var sqlstmt = $" SELECT COUNT(*) AS TrainerCount FROM Trainer";

                    using (SqlCommand cmd = new SqlCommand(sqlstmt, conn))
                    {
                        d.TrainerCount = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    sqlstmt = $"SELECT COUNT(*) As StudentCount FROM Student";
                    using (SqlCommand cmd = new SqlCommand(sqlstmt, conn))
                    {
                        d.StudentCount = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    sqlstmt = $"SELECT COUNT(*) AS DepartmentCount FROM StudentCourse";
                    using (SqlCommand cmd = new SqlCommand(sqlstmt, conn))
                    {
                        d.DepartmentCount = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                 //   sqlstmt = $"SELECT COUNT(*) AS CompleteTrainingCount FROM EmployeeCourse";
                   // using (SqlCommand cmd = new SqlCommand(sqlstmt, conn))
                    //{
                      //  d.CompleteTrainingCount = Convert.ToInt32(cmd.ExecuteScalar());
                    //}
                //
                }

                return d;
            }


            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            return null;
        }
    }
}
