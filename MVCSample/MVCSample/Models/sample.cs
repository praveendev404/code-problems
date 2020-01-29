using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCSample.Models
{
    public class sample
    {
        public class BusinessRegisterModel
        {
            [Required(ErrorMessage = "{0} is required field")]
            [DataType(DataType.EmailAddress)]
            [RegularExpression(@"\b[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}\b", ErrorMessage = "Please enter valid  {0}")]
            [Display(Name = "Email address")]
            [StringLength(50, ErrorMessage = "e-mail cannot exceed {1} symbols")]
            public string UserName { get; set; }

            [Required(ErrorMessage = "{0} is required field")]
            [StringLength(20, ErrorMessage = "The {0}'s length must be between {2} and {1} characters", MinimumLength = 4)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Retype password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match")]
            public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = "{0} is required field")]
            [Display(Name = "First Name")]
            [StringLength(32, ErrorMessage = "{0} cannot exceed {1} symbols")]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "{0} is required field")]
            [Display(Name = "Last Name")]
            [StringLength(32, ErrorMessage = "{0} cannot exceed {1} symbols")]
            public string LastName { get; set; }

            [Required(ErrorMessage = "{0} is required field")]
            [Display(Name = "Company Name")]
            [StringLength(100, ErrorMessage = "{0} cannot exceed {1} symbols")]
            public string CompanyName { set; get; }

            [Display(Name = "Business Type")]
            public byte BusinessTypeId { set; get; }

            //modified for website required
            // [Url(ErrorMessage = "Please enter valid url (for example: http://www.quizvia.com or https://www.quizvia.com or www.quizvia.com)")]
            [Required(ErrorMessage = "{0} is required field")]
            [Display(Name = "Website")]
            public string Website { set; get; }

            public byte[] Logo { set; get; }

            [Required(ErrorMessage = "{0} is required field")]
            [Display(Name = "ZIP Code")]
            [RegularExpression(@"\d{5,6}([\-]\d{4})?", ErrorMessage = "Please enter valid {0}.")]
            [StringLength(11, ErrorMessage = "{0} cannot exceed {1} symbols")]
            public string ZipCode { get; set; }

            private bool _approvedTerms = true;
            [Required(ErrorMessage = "{0} is required field")]
            [Display(Name = "I approve the Terms of Use")]
            public bool ApprovedTerms
            {
                get { return _approvedTerms; }
                set { _approvedTerms = value; }
            }

            public bool EmailVerified { get; set; }

            [Required(ErrorMessage = "{0} is required field")]
            [Display(Name = "I want to receive Free Offers and Opportunities")]
            public bool WantReceiveOffersAndOpp { get; set; }

            public bool RegisterOk { get; set; }

            public string PageType { get; set; }

            public string ReturnUrl { get; set; }

            [Required(ErrorMessage = "{0} is required field")]
            [Display(Name = "Address")]
            [StringLength(490)]
            public string Address { get; set; }

            [Required(ErrorMessage = "{0} is required field")]
            [Display(Name = "City")]
            [StringLength(32)]
            public string City { get; set; }

            [Required(ErrorMessage = "{0} is required field")]
            [StringLength(2)]
            [Display(Name = "State")]
            public string StateCode { get; set; }

            [Display(Name = "Country")]
            public string CountryCode { get; set; }



            [Display(Name = "Birth Date")]
            [StringLength(20)]
            [RegularExpression(@"^(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d$", ErrorMessage = "Please enter valid {0}")]
            public string BirthDate { get; set; }

            //modified for website required
            [Required(ErrorMessage = "{0} is required field")]
            [Display(Name = "Mobile Number")]
            [StringLength(32, ErrorMessage = "{0} cannot exceed {1} symbols")]
            [RegularExpression(@"^([0-9\(\)\/\+ \-]*)$", ErrorMessage = "Please enter valid {0}")]
            public string MobilePhoneNumber { get; set; }

            [Display(Name = "Screen Name")]
            [StringLength(32, ErrorMessage = "{0} cannot exceed {1} symbols")]
            public string ScreenName { get; set; }

            [Display(Name = "Gender")]
            public Gender UserGender { get; set; }

            [Display(Name = "Your photo")]
            public string PhotoUrl { get; set; }

            [Required(ErrorMessage = "{0} is required field")]
            [Display(Name = "How did you hear about quizvia?")]
            public byte AdvtTypeId { get; set; }

            //public List<AdvtType> AdvtTypes { set; get; }

            //[Display(Name = "Avatar url")]
            //public string AvatarUrl { get; set; }

            //public string UserId { get; set; }


            //[Display(Name = "Which school we can donate money")]
            //public int? SchoolId { get; set; }

            //public List<School> Schools { set; get; }

            //public List<UserProfileType> UserProfileTypes { set; get; }


            //public List<BusinessType> BusinessTypes { set; get; }

            //public List<SubscriptionType> SubscriptionTypes { set; get; }

            //public byte SubscriptionId { set; get; }

            //public byte UserProfileTypeId { set; get; }

            //public string ReferredBy { set; get; }

            //public List<SecurityQuestion> SecurityQuestions { get; set; }

            //public List<SecurityQuestionsModel> SecurityQuestionsModels { set; get; }
        }
    }
}