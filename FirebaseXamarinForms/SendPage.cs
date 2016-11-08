using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using Xamarin.Forms;

namespace FirebaseXamarinForms
{
	public class SendPage : ContentPage
	{

		public SendPage ()
		{
			Title = "Send";

			var entry_name = new Entry {
				Placeholder = "Enter your name",
				Keyboard = Keyboard.Text
			};

			var entry_age = new Entry {
				Placeholder = "Enter your age",
				Keyboard = Keyboard.Numeric
			};


			var button_send = new Button {
				Text = "Send"
			};



			button_send.Clicked += async (object sender, EventArgs e) => {
				try {

					button_send.IsEnabled = false;
					await SendData (entry_name.Text, entry_age.Text);
					button_send.IsEnabled = true;
					await DisplayAlert ("", "Data uploaded successfully on Firebase", "OK");

				} catch (Exception ex) {
					System.Diagnostics.Debug.WriteLine (ex.ToString ());
					await DisplayAlert ("", "Something wrong :/", "Ouf");
					button_send.IsEnabled = true;
				}
			};

			Content = new StackLayout {
				Children = {
					entry_name,
					entry_age,
					button_send
				}
			};
		}

		public async Task SendData (string name_, string age_)
		{

			IFirebaseConfig config = new FirebaseConfig {
				AuthSecret = "AchfUEuAOVILqYAz3nOw2NB0QLvW3qVbUfrxloot",
				BasePath = "https://fir-xamarinforms.firebaseio.com/"
			};
			IFirebaseClient client = new FirebaseClient (config);

			List<MyClass> myclass_list = new List<MyClass> ();

			myclass_list.Add (new MyClass () {
				age = int.Parse (age_),
				name = name_
			});

			await client.SetAsync ("MyClass", myclass_list);


		}
	}

}