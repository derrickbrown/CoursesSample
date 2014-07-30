using System;
using System.Drawing;
using System.Linq.Expressions;
using CoursesLibrary;
using MonoTouch.CoreFoundation;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace CoursesiOS
{
  
    [Register("CoursePagerViewController")]
    public class CoursePagerViewController : UIViewController
    {

        private UIPageViewController _pageViewController;
        private CourseManager _courseManager;

        public CoursePagerViewController()
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view
            _pageViewController = new UIPageViewController(UIPageViewControllerTransitionStyle.PageCurl,
                UIPageViewControllerNavigationOrientation.Horizontal,
                UIPageViewControllerSpineLocation.Min);

            _pageViewController.View.Frame = View.Bounds;
            View.AddSubview(_pageViewController.View);

            _courseManager = new CourseManager();
            _courseManager.MoveFirst();

            var dataSource = new CoursePagerViewControllerDataSource(_courseManager);
            _pageViewController.DataSource = dataSource;

            _pageViewController.SetViewControllers(new UIViewController[] {dataSource.GetFirstViewController()},
                UIPageViewControllerNavigationDirection.Forward,
                false, null);

        }
    }
}