using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using TuitionManagementSystemWebApp.DataAccess;
using TuitionManagementSystemWebApp.DataModel;

namespace TuitionManagementSystemWebApp.Pages.Students
{
    public class AddModel : PageModel
    {

        [BindProperty]
        [Display(Name = "FirstName")]

        public string FirstName { get; set; }

        [BindProperty]
        [Display(Name = "LastName")]

        public string LastName { get; set; }

        [BindProperty]
        [DataType(DataType.Date)]

        public DateTime DOB { get; set; }

        [BindProperty]
        [Display(Name = "Age")]

        public string Age { get; set; }

        [BindProperty]
        [Display(Name = "Address")]

        public string Address { get; set; }


        [BindProperty]
        [Display(Name = "Gender")]

        public string Gender { get; set; }
        [BindProperty]
        [Display(Name = "Email")]

        public string Email { get; set; }

        [BindProperty]
        [Display(Name = "MobileNumber")]

        public string MobileNumber { get; set; }

        [BindProperty]
        [Display(Name = "Mark")]

        public string Mark { get; set; }

        [BindProperty]
        [Display(Name = "TotalMark")]

        public string TotalMark { get; set; }

      //  [BindProperty]
       // [Display(Name = "Status")]

       // public string  SelectedStatus { get; set; }

        [BindProperty]
        public string Status{ get; set; }
        

        [BindProperty]
        public List<SelectListItem> StatusList { get; set; }

       // [BindProperty]
        //[Display(Name = "TrainerId")]



        //public int SelectedTrainerId { get; set; }

        [BindProperty]
       
       public int TrainerId { get; set; }


 
      



        public string SuccessMessage { get; set; }

        public string ErrorMessage { get; set; }

        public AddModel()
        {
            FirstName = "";
            LastName = "";
            DOB = DateTime.Now;
            Age = "";
            Address = "";
            Gender = "";
            Email = "";
            MobileNumber = "";
            Mark = "";
            TotalMark = "";
        //    SelectedStatus = "";
            StatusList = GetStatus();
            Status = "";
          //  SelectedTrainerId = 0;
            
            
            SuccessMessage = "";
            ErrorMessage = "";
        }

       

        private List<SelectListItem> GetStatus()
        {
            var selectItems = new List<SelectListItem>();
            selectItems.Add(new SelectListItem { Text = "Active" ,Value = "Active"});
            selectItems.Add(new SelectListItem { Text = "Deactive", Value = "Deactive"});

            return selectItems;
        }
        //private List<SelectListItem> GetStatus()
        //{
          //  StudentDataAccess studentData = new StudentDataAccess();
           ///var status = studentData.GetAll();
            //var statusList = new List<SelectListItem>();

           // foreach (var course in status)
           // {
             //   statusList.Add(new SelectListItem
               // {
                 //   Text = course.Status,
                   // Value = course.Status.ToString()
           //     });
            //}
           // return statusList;
        //}
        public void OnGet()
        {
        }

        public void OnPost()
        {

         //   Status = GetStatus();
          

            if (!ModelState.IsValid)
            {
                ErrorMessage = "Invalid Data";
                return;
            }



            var studentDataAccess = new StudentDataAccess();
            var trainer = new StudentDataModel { FirstName = FirstName, LastName = LastName, DOB = DOB, Age = Age, Address = Address, Gender = Gender, MobileNumber = MobileNumber,Email = Email, Mark = Mark, TotalMark = TotalMark, Status = Status, TrainerId = TrainerId };

            var result = studentDataAccess.Insert(trainer);

            if (result!=null)
            {
                SuccessMessage = $"Successfully Inserted ";
                ErrorMessage = "";
            }
            else
            {
                ErrorMessage = $" Error ! {studentDataAccess.ErrorMessage} Add Fail .Please try again";
                SuccessMessage = "";
            }
        }

    }
}
