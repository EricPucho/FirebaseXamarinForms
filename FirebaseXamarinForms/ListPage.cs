using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Xamarin.Forms;

namespace FirebaseXamarinForms
{
	public class ListPage : ContentPage
	{
		public ListPage ()
		{
			Title = "Get";

			var mylistview = new ListView ();

			mylistview.ItemTemplate = new DataTemplate (typeof (ViewCellMyList));
			mylistview.SeparatorVisibility = SeparatorVisibility.Default;
			mylistview.SeparatorColor = Color.FromHex ("#ddd");
			mylistview.BackgroundColor = Color.White;
			mylistview.RowHeight = 60;

			mylistview.HasUnevenRows = true;


			var button_get = new Button {
				Text = "Get Data"
			};

			button_get.Clicked += async (object sender, EventArgs e) => {
				try {

					button_get.IsEnabled = false;
					mylistview.ItemsSource = await GetData ();
					button_get.IsEnabled = true;
				} catch (Exception ex) {
					System.Diagnostics.Debug.WriteLine (ex.ToString ());
					button_get.IsEnabled = true;
				}

			};

			Content = new StackLayout {
				Children = {
					button_get, mylistview
				}
			};
		}


		public async Task<List<MyClass>> GetData ()
		{

			IFirebaseConfig config = new FirebaseConfig {
				AuthSecret = "AchfUEuAOVILqYAz3nOw2NB0QLvW3qVbUfrxloot",
				BasePath = "https://fir-xamarinforms.firebaseio.com/"
			};
			IFirebaseClient client = new FirebaseClient (config);

			FirebaseResponse response = await client.GetAsync ("MyClass");

			List<MyClass> myclass_list = response.ResultAs<List<MyClass>> ();

			return myclass_list;

		}
	}
}

