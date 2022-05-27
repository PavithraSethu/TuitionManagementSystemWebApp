using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TuitionManagementSystemWebApp.DataAccess;
using TuitionManagementSystemWebApp.DataModel;

namespace TuitionManagementSystemWebApp.Pages.Assignments
{
    public class ListModel : PageModel
    {
        public List<StudentAssignmentDataModel> Assignments { get; set; }

        [BindProperty]
        public string SearchText { get; set; }

        public string SuccessMessage { get; set; }

        public string ErrorMessage { get; set; }

        public ListModel()
        {
            SearchText = "";
            SuccessMessage = "";
            ErrorMessage = "";
            Assignments = new List<StudentAssignmentDataModel>();


        }
        public void OnGet()
        {
            var studentAssignment = new StudentAssignmentDataAccess();
            Assignments = studentAssignment.GetAll();

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
            StudentAssignmentDataAccess studentData = new StudentAssignmentDataAccess();


            Assignments = studentData.GetAssignmentByName(SearchText);

            //data check

            if (Assignments != null && Assignments.Count > 0)
            {
                SuccessMessage = $"Assignment  Found ";

            }
            else
            {
                ErrorMessage = $"Error!.Check Data {studentData.ErrorMessage}";

            }

        }

        public void OnPostClear()
        {
            SearchText = "";
            ModelState.Clear();
            var departmentData = new StudentAssignmentDataAccess();
            Assignments = departmentData.GetAll();
        }
    }
}
