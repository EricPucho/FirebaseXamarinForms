using Xamarin.Forms;

namespace FirebaseXamarinForms
{
	public class MainPage : TabbedPage
	{
		public MainPage ()
		{
			Title = "Firebase + Xamarin Forms";

			Children.Add (new SendPage ());
			Children.Add (new ListPage ());
		}
	}
}