using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using TuitionManagementSystemWebApp.DataAccess;
using TuitionManagementSystemWebApp.DataModel;

namespace TuitionManagementSystemWebApp.Pages.Assignments
{
    public class AddModel : PageModel
    {
       

            [BindProperty]
            [Display(Name = "AssignmentType")]
            public string AssignmentType { get; set; }


             [BindProperty]
             [Display(Name = "AssignmentQuestion")]
             public string AssignmentQuestion { get; set; }

         
            [BindProperty]
            [Display(Name = "StudentId")]

            public int SelectedStudentId { get; set; }

            [BindProperty]
            public List<SelectListItem> StudentList { get; set; }

            [BindProperty]
            [Display(Name = "TrainerId")]
            public int SelectedTrainerId { get; set; }

            [BindProperty]
            public List<SelectListItem> TrainerList { get; set; }

           [BindProperty]
           [Display(Name = "CourseId")]

            public int SelectedCourseId { get; set; }

            [BindProperty]

            public List<SelectListItem> CourseList { get; set; }



          public string SuccessMessage { get; set; }

            public string ErrorMessage { get; set; }





            public AddModel()
            {
                AssignmentType = "";
                AssignmentQuestion = "";
                SuccessMessage = "";
                ErrorMessage = "";
                SelectedStudentId = 0;
                SelectedTrainerId = 0;
                SelectedCourseId = 0;
                //CourseList = GetCourses();
                TrainerList = GetTrainers();
                StudentList = GetStudents();
                CourseList = GetCourses();
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

        private List<SelectListItem> GetCourses()
        {
            var courseDataAccess = new StudentCourseDataAccess();
            var courses = courseDataAccess.GetAll();

            var courseList = new List<SelectListItem>();

            foreach (var t in courses)
            {
                courseList.Add(new SelectListItem
                {
                    Text = t.CourseName,
                    Value = t.CourseId.ToString()
                });

            }

            return courseList;
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
        public void OnGet()
            {
            }

            public void OnPost()
            {

                TrainerList = GetTrainers();
                StudentList = GetStudents();
                CourseList = GetCourses();

                if (!ModelState.IsValid)
                {
                    ErrorMessage = "Invalid Data";
                    return;
                }

                var assignmentDataAccess = new StudentAssignmentDataAccess();
                var assignmentDataModel = new StudentAssignmentDataModel();

                var course = new StudentAssignmentDataModel { AssignmentType = AssignmentType,AssignmentQuestion = AssignmentQuestion, TrainerId = SelectedTrainerId, StudentId = SelectedStudentId ,CourseId = SelectedCourseId};
                var result = assignmentDataAccess.Insert(course);


                if (result != null)
                {
                    SuccessMessage = "Successfully Inserted Assignment";
                    ErrorMessage = "";
                }
                else
                {
                    ErrorMessage = $"Error adding  Assignments - {assignmentDataAccess.ErrorMessage}";
                    SuccessMessage = "";
                }
            }
    }
}
