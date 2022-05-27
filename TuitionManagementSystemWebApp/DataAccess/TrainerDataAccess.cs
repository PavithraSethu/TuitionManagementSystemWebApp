using System.Data.SqlClient;
using TuitionManagementSystemWebApp.DataModel;
using TuitionManagementSystemWebApp.Helpers;

namespace TuitionManagementSystemWebApp.DataAccess
{
    public class TrainerDataAccess
    {

        public string ErrorMessage { get; private set; }



        //Get All Departmentss


        public List<TrainerDataModel> GetAll()
        {
            try

            {
                ErrorMessage = string.Empty;
                ErrorMessage = "";

                List<TrainerDataModel> trainers = new List<TrainerDataModel>();

                using (SqlConnection conn = DataBase.GetConnection())
                {
                    conn.Open();

                    var sqlStmt = $"Select TrainerId,TrainerName,Gender,MobileNumber,Email From dbo.Trainer";

                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TrainerDataModel trainer = new TrainerDataModel();

                                trainer.TrainerId = reader.GetInt32(0);
                                trainer.TrainerName = reader.GetString(1);
                                trainer.Gender = reader.GetString(2);
                                trainer.MobileNumber = reader.GetString(3);
                                trainer.Email = reader.GetString(4);

                                trainers.Add(trainer);
                            }
                        }
                    }

                }
                return trainers;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }

        }
        //Get by Id

        public TrainerDataModel GetTrainerById(int trainerid)
        {
            try
            {
                ErrorMessage = string.Empty;




               TrainerDataModel trainer = null;
                using (SqlConnection conn = DataBase.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"Select TrainerId,TrainerName,Gender,MobileNumber,Email From Trainer where TrainerId = {trainerid}";

                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read() == true)
                            {
                                trainer = new TrainerDataModel();


                                trainer.TrainerId = reader.GetInt32(0);
                                trainer.TrainerName = reader.GetString(1);
                                trainer.Gender = reader.GetString(2);
                                trainer.MobileNumber = reader.GetString(3);
                                trainer.Email = reader.GetString(4);

                              

                            }
                        }
                    }
                }


                return trainer;
            }

            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }


        }

        //Get by Name

        public List<TrainerDataModel> GetTrainerByName(string trainername,string mobilenumber)
        {
            try
            {
                ErrorMessage = String.Empty;

                List<TrainerDataModel> trainers = new List<TrainerDataModel>();

                using (SqlConnection conn = DataBase.GetConnection())

                {
                    conn.Open();
                    var sqlStmt = $"Select TrainerId,TrainerName,Gender,MobileNumber,Email From dbo.Trainer where TrainerName like '%{trainername}%' OR MobileNumber like '%{mobilenumber}%'";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                TrainerDataModel trainer = new TrainerDataModel();
                                trainer.TrainerId = reader.GetInt32(0);
                                trainer.TrainerName = reader.GetString(1);
                                trainer.Gender = reader.GetString(2);
                                trainer.MobileNumber = reader.GetString(3);
                                trainer.Email = reader.GetString(4);

                                trainers.Add(trainer);
                            }
                        }

                    }

                }
                return trainers;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }

        }


        //insert

        public TrainerDataModel Insert(TrainerDataModel newTrainer)
        {
            try
            {
                ErrorMessage = String.Empty;

                using (SqlConnection conn = DataBase.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"INSERT INTO dbo.Trainer(TrainerName,Gender,MobileNumber,Email) VALUES('{newTrainer.TrainerName}','{newTrainer.Gender}','{newTrainer.MobileNumber}','{newTrainer.Email}'); select scope_identity()";
                    ; using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        int numOfRows = Convert.ToInt32(cmd.ExecuteScalar());
                        if (numOfRows > 0)
                        {
                            newTrainer.TrainerId = numOfRows;
                            return newTrainer;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }

            return null;
        }

        // update

        public TrainerDataModel Update(TrainerDataModel updateTrainer)
        {
            try
            {
                ErrorMessage = String.Empty;

                using (SqlConnection conn = DataBase.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"UPDATE dbo.Trainer SET TrainerName='{updateTrainer.TrainerName}',Gender='{updateTrainer.Gender}',MobileNumber ='{updateTrainer.MobileNumber}',Email='{updateTrainer.Email}'" +
                        $" WHERE TrainerId = {updateTrainer.TrainerId}";

                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        int numOfRows = cmd.ExecuteNonQuery();
                        if (numOfRows > 0)
                        {
                            return updateTrainer;
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

        //Delete

        public int Delete(int trainerid)
        {
            try
            {
                ErrorMessage = String.Empty;
                int numOfRows = 0;
                using (SqlConnection conn = DataBase.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"DELETE FROM dbo.Trainer WHERE TrainerId ={trainerid}";

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
