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
        private MarkovChain _chain;
        const string TestText = "Aaliyah\nAaren\nAaron\nAbbey\nAbbi\nAbbie\nAbby\nAbe\nAbegail\nAbel\nAbigail\nAbigayle\nAbner\nAbraham\nAbram\nAcacia\nAce\nAda\nAdair\nAdalyn\nAdalynn\nAdam\nAdamina\nAddie\nAddison\nAddy\nAddyson";

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            var r = new Random();

            _chain = new MarkovChain(r)
            {
                LettersToKeep = 2,
                TerminatorCharacter = '\n'
            };


            _chain.ConsumeText(TestText);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            var button = FindViewById<Button>(Resource.Id.GenerateButton);
            var nameLabel = FindViewById<TextView>(Resource.Id.NameTextView);

            button.Click += delegate { nameLabel.Text = _chain.BuildText(); };
        }
    }
}

