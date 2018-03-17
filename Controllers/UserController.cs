using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using registration_8.Models;
using Microsoft.AspNetCore.Http;
// using System.
namespace registration_8
{
	public class UserController : Controller{
		public readonly DbConnector _db;

		public UserController(DbConnector connect)
		{
			_db = connect;
		}

		[HttpGet, HttpPost]
		[Route("user"), Route("user/registration")]
		public IActionResult Registration(string FirstName, string LastName, string Email, string Password, string ConfirmPassword)
		{
			//lets make sure we can connect
			List<Dictionary<string, object>> results =_db.Query("Select * from users");
			ViewBag.Results = results;
			UserModel newUser = new UserModel( FirstName, LastName, Email, Password, ConfirmPassword);
			Console.WriteLine(newUser.ReturnUserModel() + "------------------------------");
			TryValidateModel(newUser);
			Console.WriteLine();
			if (ModelState.IsValid)
			{
				return RedirectToAction("add");
			} 
			else{
				ViewBag.Errors = ModelState.Values;
				return View();
			}
		}

		[Route("user/add")]
		[HttpGet]
		public IActionResult Add()
		{

			return View();
		}
	}
	

	

}