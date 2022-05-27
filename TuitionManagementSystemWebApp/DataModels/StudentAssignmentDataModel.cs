namespace TuitionManagementSystemWebApp.DataModel
{
    public class StudentAssignmentDataModel
    {

        public int AssignmentId { get; set; }

        public string AssignmentType { get; set; }

        public string AssignmentQuestion { get; set; }

        public int TrainerId { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }


        public StudentAssignmentDataModel()
        {
            AssignmentType = "";
            AssignmentQuestion = "";

        }


    }
}
