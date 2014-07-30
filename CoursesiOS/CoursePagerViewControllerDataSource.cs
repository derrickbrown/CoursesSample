using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoursesLibrary;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace CoursesiOS
{
    public class CoursePagerViewControllerDataSource : UIPageViewControllerDataSource
    {
        private CourseManager _courseManager;

        public CoursePagerViewControllerDataSource(CourseManager courseManager)
        {
            _courseManager = courseManager;
        }

        public override UIViewController GetNextViewController(UIPageViewController pageViewController, UIViewController referenceViewController)
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

        public override UIViewController GetPreviousViewController(UIPageViewController pageViewController, UIViewController referenceViewController)
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

        public CourseViewController CreateCoursesViewController()
        {
            var courseViewController = new CourseViewController();
            courseViewController.Course = _courseManager.Current;
            courseViewController.CoursePosition = _courseManager.CurrentPosition;

            return courseViewController;
        }

        public CourseViewController GetFirstViewController()
        {
            _courseManager.MoveFirst();
            return CreateCoursesViewController();
        }
    }
}