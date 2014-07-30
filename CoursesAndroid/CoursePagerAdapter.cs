using Android.Support.V4.App;
using CoursesLibrary;
using Java.Lang;

namespace CoursesAndroid
{
    public class CoursePagerAdapter : FragmentStatePagerAdapter
    {
        private CourseManager _courseManager;

        public CoursePagerAdapter(FragmentManager fm, CourseManager courseManager)
            : base(fm)
        {
            this._courseManager = courseManager;
        }

        public override Fragment GetItem(int position)
        {
            _courseManager.MoveTo(position);

            var courseFragment = new CourseFragment();
            courseFragment.Course = _courseManager.Current;

            return courseFragment;
        }

        public override int Count
        {
            get { return _courseManager.Length; }
        }

        public CourseManager CourseManager
        {
            set
            {
                _courseManager = value;
                NotifyDataSetChanged();
            }
        }

        public override int GetItemPosition(Object @object)
        {
            return PositionNone;
        }
    }
}