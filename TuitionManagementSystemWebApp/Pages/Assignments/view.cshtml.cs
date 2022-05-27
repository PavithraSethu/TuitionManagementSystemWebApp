using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TuitionManagementSystemWebApp.DataAccess;
using TuitionManagementSystemWebApp.DataModel;

namespace TuitionManagementSystemWebApp.Pages.Assignments
{
    public class viewModel : PageModel
    {

        public int AssignmentId { get; set; }

        public string Name { get; set; }

        public string SuccessMessage { get; set; }

        public string ErrorMessage { get; set; }
        public void OnGet(int assignmentid)
        {

            AssignmentId = assignmentid;
            var assignid = new StudentAssignmentDataAccess();

            var assign = assignid.GetAssignById(assignmentid);

            if(assign != null)
            {
                Name = assign.AssignmentQuestion;
            }
        }

          
          public void OnPost()
        {

        }
           
    }
}
