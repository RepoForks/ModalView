using Plugin.ModalView.Abstractions;
using System;
using UIKit;
using Xamarin.Forms;
using CoreGraphics;

namespace Plugin.ModalView
{
  /// <summary>
  /// Implementation for ModalView
  /// </summary>
  public class ModalViewImplementation : IModalView
  {
		UINavigationController nav;

		public void PushCustomModal(View view)
		{
			if (view.BackgroundColor == Color.Default)
				view.BackgroundColor = Color.White;

			var bounds = UIScreen.MainScreen.Bounds;
			var width = bounds.Width;
			var height = bounds.Height;

			var modal = new ContentView() { BackgroundColor = new Color(0, 0, 0, 0.5) };
			var fullrect = new CGRect(0, 0, width, height);

			var nativeModal = FormsViewToNativeiOS.ConvertFormsToNative(modal, fullrect);

			var rect = new CGRect(15, 35, width - 30, height - 50);
			var nativeConverted = FormsViewToNativeiOS.ConvertFormsToNative(view, rect);

			nav = UIApplication.SharedApplication.KeyWindow.RootViewController.ChildViewControllers[0] as UINavigationController;

			var viewController = new UIViewController();
			viewController.ModalPresentationStyle = UIModalPresentationStyle.Custom;
			viewController.View.BackgroundColor = UIColor.Clear;

			viewController.View.AddSubview(nativeModal);
			viewController.View.AddSubview(nativeConverted);

			nav.PresentModalViewController(viewController, false);
		}

		public void PopCustomModal()
		{
			nav.DismissModalViewController(false);
		}
	}
}