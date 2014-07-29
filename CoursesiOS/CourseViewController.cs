
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace CoursesiOS
{
	public partial class CourseViewController : UIViewController
	{
		public CourseViewController () : base ("CourseViewController", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
		
            buttonPrev.TouchUpInside += ButtonPrevOnTouchUpInside;
            buttonNext.TouchUpInside += buttonNext_TouchUpInside;

		}

        private void ButtonPrevOnTouchUpInside(object sender, EventArgs eventArgs)
        {
            labelTitle.Text = "Prev Clicked";
        }

        void buttonNext_TouchUpInside(object sender, EventArgs e)
        {
            labelTitle.Text = "Next Clicked";
        }

	}
}

