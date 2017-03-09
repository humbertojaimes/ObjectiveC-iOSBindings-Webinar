using System;
using ObjCRuntime;

[Native]
public enum PayPalShippingAddressOption : nint
{
	None = 0,
	Provided = 1,
	PayPal = 2,
	Both = 3
}

[Native]
public enum PayPalPaymentIntent : nint
{
	Sale = 0,
	Authorize = 1,
	Order = 2
}

[Native]
public enum PayPalPaymentViewControllerState : nint
{
	Unsent = 0,
	InProgress = 1
}
