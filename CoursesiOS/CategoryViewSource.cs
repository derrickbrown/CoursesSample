using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoursesLibrary;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace CoursesiOS
{
    public class CategoryViewSource : UITableViewSource
    {
        private const string cellId = "CategoryCell";
        private CourseCategoryManager _courseCategoryManager;

        public CategoryViewSource(CourseCategoryManager courseCategoryManager)
        {
            _courseCategoryManager = courseCategoryManager;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(cellId);
            
            if(cell == null)
                cell = new UITableViewCell(UITableViewCellStyle.Default, cellId);
            
            _courseCategoryManager.MoveTo(indexPath.Row);
            cell.TextLabel.Text = _courseCategoryManager.Current.Title;

            return cell;
        }

        public override int RowsInSection(UITableView tableview, int section)
        {
            return _courseCategoryManager.Length;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            _courseCategoryManager.MoveTo(indexPath.Row);
            var coursePageViewController = new CoursePagerViewController(_courseCategoryManager.Current.Title);

            var appDelegate = UIApplication.SharedApplication.Delegate as AppDelegate;
            appDelegate.RootNavigationController.PushViewController(coursePageViewController, true);


        }
    }
}