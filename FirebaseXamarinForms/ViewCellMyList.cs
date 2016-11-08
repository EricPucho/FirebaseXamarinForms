using System;

using Xamarin.Forms;

namespace FirebaseXamarinForms
{
	public class ViewCellMyList : ViewCell
	{


		public ViewCellMyList ()
		{

			var name = new Label () {
				FontAttributes = FontAttributes.Bold,
				FontSize = 12,
				TextColor = Color.Black
			};
			name.SetBinding (Label.TextProperty, new Binding ("name"));

			var age = new Label () {
				FontAttributes = FontAttributes.Bold,
				FontSize = 12,
				TextColor = Color.Black
			};
			age.SetBinding (Label.TextProperty, new Binding ("age"));

			#region grid
			var rowdefdef = new RowDefinition {
				Height = GridLength.Auto,

			};
			var columndef = new ColumnDefinition {
				Width = GridLength.Auto
			};

			var grid = new Grid {
				HorizontalOptions = LayoutOptions.Fill,
				Padding = new Thickness (16, 6, 16, 6),
				//HeightRequest = 50
			};

			grid.RowDefinitions.Add (rowdefdef);
			grid.ColumnDefinitions.Add (columndef);

			name.SetValue (Grid.ColumnProperty, 0);
			name.SetValue (Grid.RowProperty, 0);
			grid.Children.Add (name);

			age.SetValue (Grid.ColumnProperty, 0);
			age.SetValue (Grid.RowProperty, 1);
			grid.Children.Add (age);


			#endregion

			View = grid;

		}
	}
}
