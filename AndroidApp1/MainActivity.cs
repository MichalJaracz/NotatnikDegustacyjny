using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace AndroidApp1
{
    [Activity(Label = "Notatnik Degustacyjny", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            EditText usernameEditText = FindViewById<EditText>(Resource.Id.username);
            EditText passwordEditText = FindViewById<EditText>(Resource.Id.password);
            Button loginButton = FindViewById<Button>(Resource.Id.login_button);

            loginButton.Click += (sender, e) =>
            {
                string username = usernameEditText.Text.Trim();
                string password = passwordEditText.Text.Trim();

                if (RegistrationActivity.Users.ContainsKey(username) &&
                    RegistrationActivity.Users[username] == password)
                {
                    Intent intent = new Intent(this, typeof(UserActivity));
                    intent.PutExtra("username", username);
                    StartActivity(intent);
                }
                else
                {
                    Toast.MakeText(this, "Niepoprawny login lub has³o", ToastLength.Short).Show();
                }
            };

            TextView registerLink = FindViewById<TextView>(Resource.Id.register_link);
            registerLink.Click += (sender, e) =>
            {
                Intent intent = new Intent(this, typeof(RegistrationActivity));
                StartActivity(intent);
            };
        }
    }
}