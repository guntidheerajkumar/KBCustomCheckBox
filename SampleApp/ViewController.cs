using System;
using KBCustomCheckBox;
using UIKit;
using CoreGraphics;

namespace SampleApp
{
	public partial class ViewController : UIViewController
	{
		protected ViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			KBCheckBox checkBox = new KBCheckBox();
			checkBox.Frame = new CGRect(40, 40, 16, 16);
			checkBox.BoxType = KBBoxType.Circle;
			checkBox.Delegate = new CustomDelegate();
			this.View.AddSubview(checkBox);
		}

	}

	public class CustomDelegate : KBCheckBoxDelegate
	{
		public override void DidTapCheckBox(KBCheckBox checkBox)
		{
			
		}
	}
}
