using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TuitionManagementSystemWebApp.DataAccess;
using TuitionManagementSystemWebApp.DataModel;

namespace TuitionManagementSystemWebApp.Pages.Students
{
    public class ListModel : PageModel
    {
        public List<StudentDataModel> Student { get; set; }

        [BindProperty]
        public string SearchText { get; set; }

        public string SuccessMessage { get; set; }

        public string ErrorMessage { get; set; }

        public ListModel()
        {
            SearchText = "";
            SuccessMessage = "";
            ErrorMessage = "";
            Student = new List<StudentDataModel>();


        }
        public void OnGet()
        {
            var trainerData = new StudentDataAccess();
            Student = trainerData.GetAll();

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
            StudentDataAccess studentData = new StudentDataAccess();


            Student = studentData.GetStudentByName(SearchText, SearchText);

            //data check

            if (Student != null && Student.Count > 0)
            {
                SuccessMessage = $"Stuednt  Found ";

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
            var departmentData = new StudentDataAccess();
            Student = departmentData.GetAll();
        }
    }
}
