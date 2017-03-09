using System;

using UIKit;

namespace CZPickerSample
{
	public partial class ViewController : UIViewController
	{
		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		partial void UIButton3_TouchUpInside(UIButton sender)
		{
			CZPickerBinding.CZPickerView myPicker = new CZPickerBinding.CZPickerView("País", "Aceptar", "Cancelar");
			myPicker.DataSource = new MyPickerDataSource();
			myPicker.AllowMultipleSelection = true;
			myPicker.Show();
		}
	}
}
