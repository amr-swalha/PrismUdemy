using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using System.Diagnostics;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using PrismCourseApp.Droid;

[assembly:Dependency(typeof(PrismService))]
namespace PrismCourseApp.Droid
{
    public class PrismService : IPrismService
    {
        public void CallDs(string data)
        {
            Debug.WriteLine("DS Value is:" + data);
        }
    }
}