using Android.App;
using Android.OS;
using Android.Widget;

namespace AndroidApp1
{
    [Activity(Label = "Profil Użytkownika")]
    public class ProfileActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_profile);

            // Pobranie nazwy użytkownika
            string username = Intent.GetStringExtra("username") ?? "Użytkownik";

            // Wyświetlenie nazwy użytkownika
            TextView profileTextView = FindViewById<TextView>(Resource.Id.profile_text);
            profileTextView.Text = $"Profil użytkownika: {username}";
        }
    }
}