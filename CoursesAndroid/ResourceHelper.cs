using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace CoursesAndroid
{
    public static class ResourceHelper
    {

        private static Dictionary<string, int> _cache = new Dictionary<string, int>(); 

        public static int TranslateDrawable(string drawableName)
        {
            int resourceValue = -1;

            if (_cache.ContainsKey(drawableName))
            {
                return _cache[drawableName];
            }
          

            Type drawableType = typeof (Resource.Drawable);

            FieldInfo resourceFieldInfo = drawableType.GetField(drawableName);
            resourceValue = (int)resourceFieldInfo.GetValue(null);

            _cache.Add(drawableName, resourceValue);
            return resourceValue;
        }
    }
}