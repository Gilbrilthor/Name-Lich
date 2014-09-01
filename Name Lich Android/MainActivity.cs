using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Markov_List_Backend;

namespace Name_Lich_Android
{
    [Activity(Label = "Name_Lich_Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
        private MarkovChain chain;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            var r = new Random();

            chain = new MarkovChain(r);


            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
        }
    }
}

