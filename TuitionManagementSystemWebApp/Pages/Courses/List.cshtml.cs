using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TuitionManagementSystemWebApp.DataAccess;
using TuitionManagementSystemWebApp.DataModel;

namespace TuitionManagementSystemWebApp.Pages.Courses
{
    public class ListModel : PageModel
    {
        public List<StudentCourseDataModel> StudentCourse { get; set; }

        [BindProperty]
        public string SearchText { get; set; }

        public string SuccessMessage { get; set; }

        public string ErrorMessage { get; set; }

        public ListModel()
        {
            SearchText = "";
            SuccessMessage = "";
            ErrorMessage = "";
            StudentCourse = new List<StudentCourseDataModel>();


        }
        public void OnGet()
        {
            var studentcourse = new StudentCourseDataAccess();
            StudentCourse = studentcourse.GetAll();

        }

        public void OnPostSearch()
        {
            //validation
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Invalid Data ";
                return;

            }

            if (string.IsNullOrEmpty(SearchText) || (SearchText.Length < 3))
            {
                ErrorMessage = "Please Input More than 3 character";
                return;
            }

            //Data Access
            StudentCourseDataAccess studentData = new StudentCourseDataAccess();


            StudentCourse = studentData.GetStudentCourseByName(SearchText);

            //data check

            if (StudentCourse != null && StudentCourse.Count > 0)
            {
                SuccessMessage = $"Course  Found ";

            }
            else
            {
                ErrorMessage = $"Error!.Check Data ";

            }

        }

        public void OnPostClear()
        {
            SearchText = "";
            ModelState.Clear();
            var departmentData = new StudentCourseDataAccess();
            StudentCourse = departmentData.GetAll();
        }
    }
}
