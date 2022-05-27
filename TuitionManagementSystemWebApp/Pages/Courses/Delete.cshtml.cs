using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TuitionManagementSystemWebApp.DataAccess;

namespace TuitionManagementSystemWebApp.Pages.Courses
{
    public class DeleteModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int CourseId { get; set; }

        public bool ShowButton { get; set; }

        public string CourseName { get; set; }



        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }

        public DeleteModel()
        {
            CourseName = "";

            SuccessMessage = "";
            ErrorMessage = "";
            ShowButton = true;
        }

        public void OnGet(int courseid)
        {
            CourseId = CourseId;

            if (CourseId <= 0)
            {
                ErrorMessage = "Invalid Id";
                return;
            }

            var courseData = new StudentCourseDataAccess();
            var train = courseData.GetCourseById(courseid);

            if (train != null)
            {
                CourseName = train.CourseName;
            }
            else
            {
                ErrorMessage = "No Record found with that Id";
            }
        }

        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Invalid Data";
                return;
            }

            var courseData = new StudentCourseDataAccess();
            var numOfRows = courseData.Delete(CourseId);
            if (numOfRows > 0)
            {
                SuccessMessage = $"Course {CourseId} deleted successfully!";
                ShowButton = false;
            }
            else
            {
                ErrorMessage = $"Error!{courseData.ErrorMessage} Unable to delete  Course {CourseId}";
            }
        }
    }
}
