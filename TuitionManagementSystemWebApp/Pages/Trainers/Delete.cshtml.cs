using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TuitionManagementSystemWebApp.DataAccess;

namespace TuitionManagementSystemWebApp.Pages.Trainers
{
    public class DeleteModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int TrainerId { get; set; }

        public bool ShowButton { get; set; }

        public string TrainerName { get; set; }



        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }

        public DeleteModel()
        {
            TrainerName = "";

            SuccessMessage = "";
            ErrorMessage = "";
            ShowButton = true;
        }

        public void OnGet(int trainerid)
        {
            TrainerId = trainerid;

            if (TrainerId < 0)
            {
                ErrorMessage = "Invalid Id";
                return;
            }

            var trainerData = new TrainerDataAccess();
            var train = trainerData.GetTrainerById(trainerid);

            if (train != null)
            {
                TrainerName = train.TrainerName;
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

            var trainerData = new TrainerDataAccess();
            var numOfRows = trainerData.Delete(TrainerId);
            if (numOfRows > 0)
            {
                SuccessMessage = $"Trainer {TrainerId} deleted successfully!";
                ShowButton = false;
            }
            else
            {
                ErrorMessage = $"Error!{trainerData.ErrorMessage} Unable to delete  Trainer{TrainerId}";
            }
        }
    }
}
