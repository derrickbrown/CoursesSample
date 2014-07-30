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

            var firstCourseViewController = CreateCoursesViewController();

            _pageViewController.SetViewControllers(new UIViewController[] {firstCourseViewController}, 
                UIPageViewControllerNavigationDirection.Forward,
                false, null);

            _pageViewController.GetNextViewController = GetNextViewController;
            _pageViewController.GetPreviousViewController = GetPreviousViewController;
        }

        public CourseViewController CreateCoursesViewController()
        {
            var courseViewController = new CourseViewController();
            courseViewController.Course = _courseManager.Current;
            courseViewController.CoursePosition = _courseManager.CurrentPosition;

            return courseViewController;
        }

        public UIViewController GetNextViewController(UIPageViewController pageViewController,
            UIViewController referenceViewController)
        {
            CourseViewController returnCourseViewController = null;

            var referenceCourseViewController 
                = referenceViewController as CourseViewController;

            if (referenceCourseViewController != null)
            {
                _courseManager.MoveTo(referenceCourseViewController.CoursePosition);
                if (_courseManager.CanMoveNext)
                {
                    _courseManager.MoveNext();
                    returnCourseViewController = CreateCoursesViewController();
                }
            }

            return returnCourseViewController;
        }

        public UIViewController GetPreviousViewController(UIPageViewController pageViewController,
            UIViewController referenceViewController)
        {
            CourseViewController returnCourseViewController = null;

            var referenceCourseViewController
                = referenceViewController as CourseViewController;

            if (referenceCourseViewController != null)
            {
                _courseManager.MoveTo(referenceCourseViewController.CoursePosition);
                if (_courseManager.CanMovePrev)
                {
                    _courseManager.MovePrev();
                    returnCourseViewController = CreateCoursesViewController();
                }
            }

            return returnCourseViewController;
        }

    }
}