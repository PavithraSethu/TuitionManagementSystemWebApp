using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TuitionManagementSystemWebApp.DataAccess;
using TuitionManagementSystemWebApp.DataModel;

namespace TuitionManagementSystemWebApp.Pages
{
    public class ListModel : PageModel
    {
        public List<TrainerDataModel> Trainer { get; set; }

        [BindProperty]
        public string SearchText { get; set; }

        public string SuccessMessage { get; set; }

        public string ErrorMessage { get; set; }

        public ListModel()
        {
            SearchText = "";
            SuccessMessage = "";
            ErrorMessage = "";
            Trainer = new List<TrainerDataModel>();


        }
        public void OnGet()
        {
            var trainerData = new TrainerDataAccess();
            Trainer = trainerData.GetAll();

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
            TrainerDataAccess  trainerData = new TrainerDataAccess();


            Trainer = trainerData.GetTrainerByName(SearchText, SearchText);

            //data check

            if (Trainer != null && Trainer.Count > 0)
            {
                SuccessMessage = $"Trainer  Found ";

            }
            else
            {
                ErrorMessage = $"Error!.Check Data {trainerData .ErrorMessage}";

            }

        }

        public void OnPostClear()
        {
            SearchText = "";
            ModelState.Clear();
            var departmentData = new TrainerDataAccess ();
            Trainer = departmentData.GetAll();
        }
    }
}

