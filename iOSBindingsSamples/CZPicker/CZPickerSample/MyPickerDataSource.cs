using System;
using CZPickerBinding;

namespace CZPickerSample
{
	public class MyPickerDataSource:CZPickerViewDataSource
	{
		string[] countries = { "México", "Colombia", "Perú", "Ecuador", "Brazil" };


		public override string CzpickerTitleView(CZPickerView pickerView, nint row)
		{
			return countries[row];
		}

		public override nint NumberOfRowsInPickerView(CZPickerView pickerView)
		{
			return countries.Length;
		}
	}
}
