using Android.App;
using Android.OS;
using Android.Widget;

namespace AndroidApp1
{
    [Activity(Label = "Dodaj Napój")]
    public class AddDrinkActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_add_drink);

            Button saveButton = FindViewById<Button>(Resource.Id.save_drink_button);
            saveButton.Click += (sender, e) =>
            {
                // nowy napoj
                Toast.MakeText(this, "Napój dodany!", ToastLength.Short).Show();
                Finish(); // zamknij po zapisaniu
            };
        }
    }
}