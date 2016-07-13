﻿using System;

using UIKit;

namespace HookMeUP.iOS
{
	public partial class ForgotPasswordViewController : ScreenViewController
	{


		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			int i = 0;
			getPasswordButton.TouchUpInside += (obj, evt) => {
				i++;
				switch (!usernameTextForgot.Text.Equals("") && !employeeNoForgot.Text.Equals("")) {

					case true:
						string[] info = registerViewController.GetValues().Split('#');

						try
						{
							string username = info[2];
							string employeeNo = info[4];
							string password = info[3];

							if (username.Equals(usernameTextForgot.Text) && employeeNo.Equals(employeeNoForgot.Text))
							{
								getPasswordText.Text = password;

							}else{

								AlertPopUp("Error","Username and employee number do not match","OK");
								getPasswordButton.Enabled = false;
							}


						}
						catch (IndexOutOfRangeException){
							//Do nothing this is an empty value returned. The user did not register

						}
						break;

					case false:
						AlertPopUp("Error","Please fill in details","Ok");
						break;
				}
			
			}; 

		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

