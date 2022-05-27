using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TuitionManagementSystemWebApp.DataAccess;

namespace TuitionManagementSystemWebApp.Pages
{
    public class IndexModel : PageModel
    {


        [FromQuery(Name = "action")]
        public string Action { get; set; }


        private readonly ILogger<IndexModel> _logger;

        public int TrainerCount { get; set; }

        public int StudentCount { get; set; }

        //   public int CompleteTrainingStudentCount { get; set; }

        public int DepartmentCount { get; set; }

        public string ErrorMessage { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            TrainerCount = 0;
            StudentCount = 0;
            DepartmentCount = 0;
           
            ErrorMessage = "";
        }

      

        public void OnGet()
        {
            if (!String.IsNullOrEmpty(Action) && Action.ToLower() == "logout")
            {
                Logout();
                return;
            }

            var dashBoardData = new DashBoardDataAccess();
            var dashboard = dashBoardData.GetAll();
            if (dashboard != null)
            {
                TrainerCount = dashboard.TrainerCount;
                StudentCount = dashboard.StudentCount;
                DepartmentCount = dashboard.DepartmentCount;
               
         
            }
            else
            {
                ErrorMessage = $"No Dashboard Data Available - {dashBoardData.ErrorMessage}";
            }
        }
        public void OnPost()
        {
            Logout();
        }
        private void Logout()
        {
            HttpContext.SignOutAsync();
            Response.Redirect("/Index");
        }
       
    }
}