using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using TuitionManagementSystemWebApp.DataAccess;
using TuitionManagementSystemWebApp.DataModel;

namespace TuitionManagementSystemWebApp.Pages.Trainers
{
    public class EditModel : PageModel
    {
        [BindProperty]
        [Display(Name = "TrainerId")]

        public int TrainerId { get; set; }


        [BindProperty]
        [Display(Name = "TrainerName")]
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string TrainerName { get; set; }

        [BindProperty]
        [Display(Name = "Gender")]
        [Required]


        public string Gender { get; set; }


        [BindProperty]
        public List<SelectListItem> Genders { get; set; }

        [BindProperty]
        [Display(Name = "MobileNumber")]
        [Required]


        public string MobileNumber { get; set; }

        [BindProperty]
        [Display(Name = "Email")]
        [Required]


        public string Email { get; set; }



        public string SuccessMessage { get; set; }

        public string ErrorMessage { get; set; }


        public EditModel()
        {

            TrainerName = "";
            Gender = "";
            MobileNumber = "";
            Email = "";
            SuccessMessage = "";
            ErrorMessage = "";
            Genders = GetGenders();

        }


        private List<SelectListItem> GetGenders()
        {
            var SelectItems = new List<SelectListItem>();

            SelectItems.Add(new SelectListItem { Text = "Male", Value = "M" });
            SelectItems.Add(new SelectListItem { Text = "Female", Value = "F" });
            SelectItems.Add(new SelectListItem { Text = "Unspecified", Value = "U" });

            return SelectItems;
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
            var dept = trainerData.GetTrainerById(trainerid);


            if (dept != null)
            {
                TrainerName = dept.TrainerName;
                Gender = dept.Gender;
                MobileNumber = dept.MobileNumber;
                Email = dept.Email;

            }
            else
            {
                ErrorMessage = "No record found with that id";
            }
        }

        public void OnPost()
        {
            //validation
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Invalid Data . Please Correct and Try  Again.";
                return;
            }


            

            //Data operation
            var trainerData = new TrainerDataAccess();
            var trainerToUpdata = new TrainerDataModel { TrainerId = TrainerId ,TrainerName = TrainerName, Gender = Gender, MobileNumber = MobileNumber, Email = Email};
            var updateTrainer = trainerData.Update(trainerToUpdata);

            //Check Result
            if (updateTrainer != null)
            {
                SuccessMessage = $"Employee {updateTrainer.TrainerId} updated successfully.";
            }
            else
            {
                ErrorMessage = $"Error ! Updating Department";
            }
        }


     
    }
}
