using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TuitionManagementSystemWebApp.DataAccess;

namespace TuitionManagementSystemWebApp.Pages.Assignments
{
    public class deleteModel : PageModel
    {
  
        [BindProperty(SupportsGet = true)]
        public int AssignmentId { get; set; }

        public bool ShowButton { get; set; }

        public string AssignmentType { get; set; }



        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }

        public deleteModel()
        {
            AssignmentId = 0;
            AssignmentType  = "";

            SuccessMessage = "";
            ErrorMessage = "";
            ShowButton = true;
        }

        public void OnGet(int assignmentid)
        {
            AssignmentId = AssignmentId;

            if (AssignmentId <= 0)
            {
                ErrorMessage = "Invalid Id";
                return;
            }

            var deleteData = new StudentAssignmentDataAccess();
            var train = deleteData.GetAssignmentById(assignmentid);

            if (train != null)
            {
               AssignmentType = train.AssignmentType;
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

            var deleteData = new StudentAssignmentDataAccess();
            var numOfRows = deleteData.Delete(AssignmentId);
            if (numOfRows > 0)
            {
                SuccessMessage = $"Course {AssignmentId} deleted successfully!";
                ShowButton = false;
            }
            else
            {
                ErrorMessage = $"Error!{deleteData.ErrorMessage} Unable to delete  Course {AssignmentId}";
            }
        }
    }
}
