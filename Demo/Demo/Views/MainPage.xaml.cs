using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Plugin.ModalView;

namespace Demo
{
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();

			Title = "Modal View";
		}

		public void OnShow (object sender, EventArgs e)
		{
			CrossModalView.Current.PushCustomModal (new MyModalView());
		}
	}
}

