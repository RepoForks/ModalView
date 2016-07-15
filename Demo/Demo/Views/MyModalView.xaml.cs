using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Plugin.ModalView;

namespace Demo
{
	public partial class MyModalView : ContentView
	{
		public MyModalView ()
		{
			InitializeComponent ();
		}

		public void OnClose (object sender, EventArgs e)
		{
			CrossModalView.Current.PopCustomModal ();
		}
	}
}

