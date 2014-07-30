
using System;
using System.Drawing;
using CoursesLibrary;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace CoursesiOS
{
	public partial class CourseViewController : UIViewController
	{

	    //private CourseManager courseManager;

        public Course Course { get; set; }
        public int CoursePosition { get; set; }

		public CourseViewController () : base ("CourseViewController", null)
		{
            //courseManager = new CourseManager();
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

		    buttonNext.Hidden = true;
		    buttonPrev.Hidden = true;
            //buttonPrev.TouchUpInside += ButtonPrevOnTouchUpInside;
            //buttonNext.TouchUpInside += buttonNext_TouchUpInside;

            //courseManager.MoveFirst();
            UpdateUI();
		}

        //private void ButtonPrevOnTouchUpInside(object sender, EventArgs eventArgs)
        //{
        //    courseManager.MovePrev();
        //    UpdateUI();
        //}

        //void buttonNext_TouchUpInside(object sender, EventArgs e)
        //{
        //    courseManager.MoveNext();
        //    UpdateUI();
        //}

	    private void UpdateUI()
	    {
            labelTitle.Text = Course.Title;
            textDescription.Text = Course.Description;
            imageCourse.Image = UIImage.FromBundle(Course.Image);
	    }
	}
}

