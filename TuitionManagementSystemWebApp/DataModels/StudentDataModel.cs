namespace TuitionManagementSystemWebApp.DataModel
{
    public class StudentDataModel
    {

        public int StudentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DOB { get; set; }

        public string Age { get; set; }

        public string Address { get; set; }

        public string Gender { get; set; }

        public string Email { get; set; }

        public string MobileNumber { get; set; }

        public string Mark { get; set; }

        public string TotalMark { get; set; }

        public string Status { get; set; }

        public int TrainerId { get; set; }

        public StudentDataModel()
        {
            FirstName = "";
            LastName = "";
            DOB = DateTime.Now;
            Age = "";
            Address = "";
            Gender = "";
            Email = "";
            MobileNumber = "";
            Mark = "";
            TotalMark = "";
            Status = "";
            TrainerId = 0;
           

        }

        public bool IsValid()
        {
            if(FirstName == null || FirstName.Trim() == null || FirstName.Trim().Length < 3)
            {
                return false;
            }

            if (LastName == null || LastName.Trim() == null || LastName.Trim().Length < 0)
            {
                return false;

            }
            if (DOB == null)
            {
                return false;

            }

            if (Age == null || Age.Trim() == null || Age.Trim().Length < 0)
            {
                return false;

            }

            if (Address == null || Address.Trim() == null || Address.Trim().Length < 5)
            {
                return false;

            }

            if (Email == null || Email.Trim() == null || Email.Trim().Length < 2)
            {
                return false;

            } 
            if (MobileNumber == null ||  LastName.Trim().Length < 10)
            {
                return false;

            }

            if (Status == null || Status.Trim() == null || Status.Trim().Length < 0)
            {
                return false;

            }

            return true;
        }

    }
}
