using System;
using InfColorPicker;
using UIKit;

namespace InfColorPickerSample
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
			InfColorPickerController picker = InfColorPickerController.ColorPickerViewController;
			//picker.WeakDelegate = this;
			picker.ColorPickerControllerDidFinish += Picker_ColorPickerControllerDidFinish;
			picker.SourceColor = this.View.BackgroundColor;
			picker.PresentModallyOverViewController(this);
		}

		void Picker_ColorPickerControllerDidFinish(object sender, EventArgs e)
		{
			View.BackgroundColor = ((InfColorPickerController)sender).ResultColor;
			DismissViewController(false, null);
		}

	}
}
