namespace TuitionManagementSystemWebApp.DataModel
{
    public class StudentCourseDataModel
    {
        public int CourseId { get; set; }

        public string CourseName { get; set; }

        public int StudentId { get; set; }

        public int TrainerId { get; set; }


        public StudentCourseDataModel()
        {
            CourseName = "";
            StudentId = 0;
            TrainerId = 0;
        }
    }
}
