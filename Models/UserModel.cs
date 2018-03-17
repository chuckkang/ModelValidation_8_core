using System.ComponentModel.DataAnnotations;

namespace registration_8.Models
{
	public class UserModel : BaseEntity
	{
		/// THIS IS A CHANGE ON teh BRANCH
		[Required, MinLength(2, ErrorMessage="First Name must be longer than 1 character"), MaxLength(100)]
		[DataType(DataType.Text, ErrorMessage="Do not include any special characters or numbers.")]
		[Display(Name = "First Name")]
		public string FirstName { get; set; }

		[Display(Name = "Last Name")]
		[Required, MinLength(2, ErrorMessage = "Last Name must be longer than 1 character"), MaxLength(100)]
		// [Required(ErrorMessage = "Please enter something")]
		[DataType(DataType.Text, ErrorMessage = "Do not include any special characters or numbers.")]
		
		public string LastName { get; set; }

		[Display(Name = "Email")]
		[Required(ErrorMessage = "Pleaes Enter A Valid Email Address"), EmailAddress(ErrorMessage="Email must be in correct format")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Please enter a password more than 3 characters long.")]
		[MinLengthAttribute(3, ErrorMessage = "Please enter more than 3 characters."), MaxLengthAttribute(7, ErrorMessage="Password must NOT be more than 7 characters long.")]
		public string Password { get; set; }

		[Display(Name = "Re-Enter Password")]
		[Required(ErrorMessage = "Please enter a your password again")]
		[Compare("Password", ErrorMessage = "Your password and confirmation password do not match")]
		public string ConfirmPassword { get; set; }

		public UserModel(string _first, string _last, string _email, string _pass, string _confirm)
		{
			FirstName = _first;
			LastName = _last;
			Email = _email;
			Password = _pass;
			ConfirmPassword = _confirm;
		}

		public string ReturnUserModel()
		{
			return $"{FirstName}-{this.LastName}-{this.Email}-{this.Password}-{this.ConfirmPassword}>>>>>";
		}

	}
}