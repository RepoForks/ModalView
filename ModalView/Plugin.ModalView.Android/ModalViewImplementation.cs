using Plugin.ModalView.Abstractions;
using System;
using Android.Support.V7.App;
using Xamarin.Forms;

namespace Plugin.ModalView
{
  /// <summary>
  /// Implementation for Feature
  /// </summary>
  public class ModalViewImplementation : IModalView
  {
		AlertDialog _dialog;

		// TODO: handle screen rotation

		public void PushCustomModal(View view)
		{
			if (view.BackgroundColor == Color.Default)
				view.BackgroundColor = Color.White;

			var metrics = Forms.Context.Resources.DisplayMetrics;
			var widthInDp = ConvertPixelsToDp(metrics.WidthPixels);
			var heightInDp = ConvertPixelsToDp(metrics.HeightPixels);

			var nativeConverted = FormsToNativeDroid.ConvertFormsToNative(view, new Rectangle(0, 0, widthInDp - 30, heightInDp - 55));

			var builder = new AlertDialog.Builder(Forms.Context);

			builder.SetView(nativeConverted);

			_dialog = builder.Create();

			_dialog.Show();
		}

		public void PopCustomModal()
		{
			_dialog.Dismiss();
			_dialog.Dispose();
		}

		private int ConvertPixelsToDp(float pixelValue)
		{
			var dp = (int)((pixelValue) / Forms.Context.Resources.DisplayMetrics.Density);
			return dp;
		}
  }
}