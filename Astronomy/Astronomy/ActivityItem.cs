using Android.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Astronomy
{
    // Container used to hold an intent with its title
    public class ActivityItem
    {
        public string Title { get; set; }
        public Intent Intent { get; set; }
        public override string ToString()
        {
            return Title;
        }
    }
}