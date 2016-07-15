using System;
using Xamarin.Forms;
using Plugin.ModalView;

namespace Demo
{
	public static class NavigationExtension
	{
		public static void PushCustomModal(this INavigation navigation, View view) {
			CrossModalView.Current.PushCustomModal (view);
		}

		public static void PopCustomModal(this INavigation navigation) {
			CrossModalView.Current.PopCustomModal();
		}
	}
}

