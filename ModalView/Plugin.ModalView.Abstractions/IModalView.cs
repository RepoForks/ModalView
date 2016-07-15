using System;
using Xamarin.Forms;

namespace Plugin.ModalView.Abstractions
{
  /// <summary>
  /// Interface for ModalView
  /// </summary>
  public interface IModalView
  {
		void PushCustomModal(View view);
		void PopCustomModal();
  }
}
