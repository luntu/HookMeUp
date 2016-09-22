﻿using System.Diagnostics;
using Parse;
namespace HookMeUP.iOS
{
	public partial class LoginViewController : ScreenViewController
	{
		

		public override  void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
					
			NavigationController.NavigationBarHidden = true;

			DismissKeyboardOnBackgroundTap();
			RegisterForKeyboardNotifications();

			usernameText.BecomeFirstResponder();
			ShouldReturn(usernameText, passwordText);
			TextFieldKeyboardIteration(usernameText, passwordText);

			forgotPasswordButton.TouchUpInside += (o, e) =>
			{
				ClearFields(usernameText, passwordText);
				//NavigationScreenController(forgotPasswordViewController);
			};

			int i = 0;

			loginButton.TouchUpInside += async (sender, evt) =>
		   	{
				i++;

			   switch (!usernameText.Text.Equals("") && !passwordText.Text.Equals(""))
			   {

				case true:
						   try
						   {
							   loadingOverlay = new LoadingOverlay(bounds);
							   View.Add(loadingOverlay);

							   ParseQuery<ParseObject> query = from userInformation in ParseObject.GetQuery("UserInformation")
															   where userInformation.Get<string>("Username") == TrimInput(usernameText.Text)
															   && userInformation.Get<string>("Password") == TrimInput(passwordText.Text)
														   	select userInformation;

							   ParseObject result = await query.FirstAsync();

							   orderViewController.GetName = result.Get<string>("Name");
							   bool isAdmin = result.Get<bool>("IsAdmin");
							   orderViewController.CurrentUser = result;
							   int vouchers = result.Get<int>("Vouchers");
							   orderViewController.GetVouchers = vouchers;
							   loadingOverlay.Hide();

							   if (isAdmin) NavigationScreenController(adminViewController);
							   else NavigationScreenController(orderViewController);

						   }
						   catch (ParseException ex)
						   {

							   Debug.WriteLine(ex.GetType());
							   loadingOverlay.Hide();
							   AlertPopUp("Login failed", "Username or password incorrect", "OK");

							   if (i == 3)
							   {
								   AlertPopUp("Login failed!!", "You failed to login 3 times we suggest \nyou either Register or retrieve lost password", "OK");
								   BorderButton(registerButton, forgotPasswordButton);
								   loginButton.Enabled = false;
							   }
						   }
						   catch (System.NullReferenceException) 
						   {
							   AlertPopUp("Connection error", "Can't connect", "");				
						   }



					   break;

				   case false:

					   AlertPopUp("Error", "Please fill in details", "OK");

					   break;


			   }



			   ClearFields(usernameText, passwordText);

		   };

			registerButton.TouchUpInside += (o, e) =>
			{


				NavigationScreenController(registerViewController);
				ClearFields(usernameText, passwordText);

			};

		}

	
		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


