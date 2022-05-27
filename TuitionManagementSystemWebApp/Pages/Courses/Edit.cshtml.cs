using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using TuitionManagementSystemWebApp.DataAccess;
using TuitionManagementSystemWebApp.DataModel;

namespace TuitionManagementSystemWebApp.Pages.Courses
{
    public class EditModel : PageModel
    {

        [BindProperty(SupportsGet = true)]

        public int CourseId { get; set; }

        [BindProperty]
        [Display(Name = "CourseName")]
        public string CourseName { get; set; }

        [BindProperty]

        public List<SelectListItem> CourseList { get; set; }

        [BindProperty]
        [Display(Name = "StudentId")]

        public int StudentId { get; set; }

        [BindProperty]
        [Display(Name = "StudentId")]

        public int SelectedStudentId { get; set; }

        [BindProperty]
        public List<SelectListItem> StudentList { get; set; }

        [BindProperty]
        [Display(Name = "TrainerId")]
        public int TrainerId { get; set; }


        [BindProperty]
        [Display(Name = "TrainerId")]
        public int SelectedTrainerId { get; set; }

        [BindProperty]
        public List<SelectListItem> TrainerList { get; set; }


        public string SuccessMessage { get; set; }

        public string ErrorMessage { get; set; }





        public EditModel()
        {
            CourseName = "";
            SuccessMessage = "";
            ErrorMessage = "";
            SelectedStudentId = 0;
            SelectedTrainerId = 0;


            //CourseList = GetCourses();
            TrainerList = GetTrainers();
            StudentList = GetStudents();
        }

        private List<SelectListItem> GetStudents()
        {
            var studentDataAccess = new StudentDataAccess();
            var studentid = studentDataAccess.GetAll();

            var studentList = new List<SelectListItem>();

            foreach (var id in studentid)
            {
                studentList.Add(new SelectListItem
                {
                    Text = id.FirstName,
                    Value = id.StudentId.ToString()
                });
            }
            return studentList;
        }

       
        private List<SelectListItem> GetTrainers()
        {
            var trainerDataAccess = new TrainerDataAccess();
            var trainers = trainerDataAccess.GetAll();

            var trainersList = new List<SelectListItem>();

            foreach (var t in trainers)
            {
                trainersList.Add(new SelectListItem
                {
                    Text = t.TrainerName,
                    Value = t.TrainerId.ToString()
                });

            }

            return trainersList;
        }

        //  private List<SelectListItem> GetCourses()
        //{
        //  var courseDataAccess = new StudentCourseDataAccess();
        //var course = courseDataAccess.GetAll();

        //var courseList = new List<SelectListItem>();

        // foreach(var c in course)
        // {
        //   courseList.Add(new SelectListItem
        // {
        //   Text = c.CourseName,
        // Value = c.CourseId.ToString()
        //});

        // }
        // return CourseList;
        // }
        public void OnGet(int courseid)
        {

            CourseId = courseid;
            if (CourseId < 0)
            {
                ErrorMessage = "Invalid Id";
                return;
            }

            TrainerList = GetTrainers();
            StudentList = GetStudents();

            var courseDataAccess = new StudentCourseDataAccess();
            var cust = courseDataAccess.GetCourseById(courseid);
            if (cust != null)
            {
                CourseId = cust.CourseId;
                CourseName = cust.CourseName;
                StudentId= cust.StudentId;
                TrainerId = cust.TrainerId;
              

            }
            else
            {
                ErrorMessage = "No record found with this id";
            }
        }

        public void OnPost()
        {

            TrainerList = GetTrainers();
            StudentList = GetStudents();

            if (!ModelState.IsValid)
            {
                ErrorMessage = "Invalid Data";
                return;
            }

            var courseDataAccess = new StudentCourseDataAccess();
            var courseDataModel = new StudentCourseDataModel();

            var course = new StudentCourseDataModel { CourseId = CourseId ,CourseName = CourseName, StudentId = SelectedStudentId, TrainerId = SelectedTrainerId };
            var result = courseDataAccess.Insert(course);


            if (result != null)
            {
                SuccessMessage = "Successfully Edited!!";
                ErrorMessage = "";
            }
            else
            {
                ErrorMessage = $"Error adding  Course - {courseDataAccess.ErrorMessage}";
                SuccessMessage = "";
            }
        }

    }
}
