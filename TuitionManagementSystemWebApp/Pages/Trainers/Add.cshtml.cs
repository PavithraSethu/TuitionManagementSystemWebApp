using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using TuitionManagementSystemWebApp.DataAccess;
using TuitionManagementSystemWebApp.DataModel;

namespace TuitionManagementSystemWebApp.Pages.Trainers
{
    public class AddModel : PageModel
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


        public AddModel()
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
        public void OnGet()
        {
        }

        public void OnPost()
        {
            if(!ModelState.IsValid)
            {
                ErrorMessage = "Inavlid Data";
                return;
            }

            var trainerData = new TrainerDataAccess();

            var newTrainer = new TrainerDataModel {  TrainerName = TrainerName, Gender = Gender ,MobileNumber = MobileNumber,Email = Email };

            var insertTrainer = trainerData.Insert(newTrainer);

            if (insertTrainer != null && insertTrainer.TrainerId > 0)
            {
                SuccessMessage = $"Successfully Inserted Department {insertTrainer.TrainerId}";
                ModelState.Clear();
            }
            else
            {
                ErrorMessage = $" Error ! Add Fail {trainerData.ErrorMessage}.Please try again";
            }
        }
    }
}
