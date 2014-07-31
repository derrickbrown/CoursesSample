using System;
using System.Drawing;
using CoursesLibrary;
using MonoTouch.CoreFoundation;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace CoursesiOS
{


    [Register("CategoryViewController")]
    public class CategoryViewController : UITableViewController
    {
        private CourseCategoryManager _courseCategoryManager;

        public CategoryViewController()
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
            this.Title = "Categories";

            _courseCategoryManager = new CourseCategoryManager();
            UITableView tableView = this.View as UITableView;
            tableView.Source = new CategoryViewSource(_courseCategoryManager);

        }
    }
}