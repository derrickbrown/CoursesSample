using System;
using Android.Content;
using Android.Views;
using Android.Widget;
using CoursesLibrary;

namespace CoursesAndroid
{
    public class CourseCategoryManagerAdapter : BaseAdapter<CourseCategory>
    {
        private Context _context;
        private int _layoutResourceId;
        private CourseCategoryManager _courseCategoryManager;


        public CourseCategoryManagerAdapter(Context context, int layoutResourceId,
            CourseCategoryManager courseCategoryManager)
        {
            _context = context;
            _layoutResourceId = layoutResourceId;
            _courseCategoryManager = courseCategoryManager;
        }


        public override CourseCategory this[int position]
        {
            get
            {
                _courseCategoryManager.MoveTo(position);
                return _courseCategoryManager.Current;
            }
        }

        public override int Count
        {
            get {return _courseCategoryManager.Length; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;

            if (view == null)
            {
                var infalter = _context.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;
                view = infalter.Inflate(_layoutResourceId, null);

            }

            var textView = view.FindViewById<TextView>(Android.Resource.Id.Text1);
            textView.Text = this[position].Title;

            return view;

        }
    }
}