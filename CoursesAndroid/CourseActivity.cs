using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;
using CoursesLibrary;

namespace CoursesAndroid
{
    [Activity(Label = "Courses", MainLauncher = true, Icon="@drawable/icon")]
    public class CourseActivity : FragmentActivity
    {
        private const String DEFAULT_CATEGORY_TITLE = "Android";
        public const string DISPLAY_CATEGORY_TITLE_EXTRA = "DisplayCategoryTitleExtra";
        private CourseCategoryManager _courseCategoryManager;
        private CourseManager _courseManager;
        private CoursePagerAdapter _coursePagerAdapter;
        private ViewPager _viewPager;
        private DrawerLayout _drawerLayout;
        private ListView _categoryDrawerListView;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.CourseActivity);
            _courseCategoryManager = new CourseCategoryManager();
            _courseCategoryManager.MoveFirst();

            string displayCategoryTitle = _courseCategoryManager.Current.Title;

            //string displayCategoryTitle = DEFAULT_CATEGORY_TITLE;
            //Intent startupIntent = this.Intent;
            //if (startupIntent != null)
            //{
            //    String displayCategoryTitleExtra =
            //        startupIntent.GetStringExtra(DISPLAY_CATEGORY_TITLE_EXTRA);

            //    if (!string.IsNullOrEmpty(displayCategoryTitleExtra))
            //        displayCategoryTitle = displayCategoryTitleExtra;
            //}

           


            _courseManager = new CourseManager(displayCategoryTitle);
            _courseManager.MoveFirst();

            _coursePagerAdapter = 
                new CoursePagerAdapter(SupportFragmentManager, _courseManager);

            _viewPager = FindViewById<ViewPager>(Resource.Id.coursePager);
            _viewPager.Adapter = _coursePagerAdapter;

            _drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawerLayout);
            _categoryDrawerListView = FindViewById<ListView>(Resource.Id.categoryDrawerListView);

            _categoryDrawerListView.Adapter = new CourseCategoryManagerAdapter(this, 
                Resource.Layout.CourseCategoryItem, 
                _courseCategoryManager);

            _categoryDrawerListView.SetItemChecked(0, true);
            _categoryDrawerListView.ItemClick += _categoryDrawerListView_ItemClick;
        }

        void _categoryDrawerListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            _drawerLayout.CloseDrawer(_categoryDrawerListView);
            _courseCategoryManager.MoveTo(e.Position);
            _coursePagerAdapter.CourseManager = new CourseManager(_courseCategoryManager.Current.Title);
            _viewPager.CurrentItem = 0;
        }
    }
}