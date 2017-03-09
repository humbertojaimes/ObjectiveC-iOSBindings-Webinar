using System;

using UIKit;

namespace PayPal.iOS.Test
{
	public partial class ViewController : UIViewController
	{
		async void BtnOpenCam_TouchUpInside(object sender, EventArgs e)
		{
			var scanViewController = new CardIOPaymentViewController(new CustomCardIOPaymentViewControllerDelegate(this));

			await this.PresentViewControllerAsync(scanViewController, true);
		}

		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			_lblVersion.Text = PayPalMobile.LibraryVersion;
			_btnOpenCam.TouchUpInside += BtnOpenCam_TouchUpInside;
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		#region ProvideCreditCard

		public void UserDidCancelPaymentViewController(CardIOPaymentViewController paymentViewController)
		{
			paymentViewController.DismissViewController(true, null);
		}

		public async void UserDidProvideCreditCardInfo(CardIOCreditCardInfo cardInfo, CardIOPaymentViewController paymentViewController)
		{
			await paymentViewController.DismissViewControllerAsync(true);
			UIAlertController alert = UIAlertController.Create("PayPal", 
			                                                   $"Card:{cardInfo.CardNumber}, Cvv:{cardInfo.Cvv}, Exp. Date:{cardInfo.ExpiryMonth}/{cardInfo.ExpiryYear}",
			                                                   UIAlertControllerStyle.Alert);

			UIAlertAction okButton = UIAlertAction.Create("Ok", UIAlertActionStyle.Default, async (obj) => {
				await alert.DismissViewControllerAsync(true);
			});
			alert.AddAction(okButton);
			await this.PresentViewControllerAsync(alert, true);
		}

		#endregion
	}

	public class CustomCardIOPaymentViewControllerDelegate : CardIOPaymentViewControllerDelegate
	{
		ViewController _controller;

		public CustomCardIOPaymentViewControllerDelegate(ViewController manager)
		{
			_controller = manager;
		}

		public override void UserDidCancelPaymentViewController(CardIOPaymentViewController paymentViewController)
		{
			_controller.UserDidCancelPaymentViewController(paymentViewController);
		}

		public override void UserDidProvideCreditCardInfo(CardIOCreditCardInfo cardInfo, CardIOPaymentViewController paymentViewController)
		{
			_controller.UserDidProvideCreditCardInfo(cardInfo, paymentViewController);
		}
	}
}
