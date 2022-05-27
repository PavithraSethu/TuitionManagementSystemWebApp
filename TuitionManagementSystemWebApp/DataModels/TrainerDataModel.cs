namespace TuitionManagementSystemWebApp.DataModel
{
    public class TrainerDataModel
    {
         public int TrainerId { get; set; }

        public string TrainerName { get; set; }

        public string Gender { get; set; }

        public string MobileNumber { get; set; }

        public string Email { get; set; }


        public TrainerDataModel()
        {
            TrainerName = "";
            Gender = "";
            MobileNumber = "";
            Email = "";

        }




    }
}
