using Android.App;
using Android.OS;
using Android.Widget;
using System.Collections.Generic;

namespace AndroidApp1
{
    [Activity(Label = "Rejestracja")]
    public class RegistrationActivity : Activity
    {
        // Statyczna lista użytkowników, która symuluje bazę danych
        public static Dictionary<string, string> Users = new Dictionary<string, string>
        {
            { "kotlet", "123456" },
            { "user1", "1234567" },
            { "user2", "12345678" }
        };

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_registration);

            EditText usernameEditText = FindViewById<EditText>(Resource.Id.username);
            EditText passwordEditText = FindViewById<EditText>(Resource.Id.password);
            Button registerButton = FindViewById<Button>(Resource.Id.register_button);

            registerButton.Click += (sender, e) =>
            {
                string username = usernameEditText.Text.Trim();
                string password = passwordEditText.Text.Trim();

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    Toast.MakeText(this, "Nazwa użytkownika i hasło nie mogą być puste!", ToastLength.Short).Show();
                    return;
                }

                if (Users.ContainsKey(username))
                {
                    Toast.MakeText(this, "Użytkownik o podanej nazwie już istnieje!", ToastLength.Short).Show();
                }
                else
                {
                    Users.Add(username, password);
                    Toast.MakeText(this, "Rejestracja zakończona sukcesem!", ToastLength.Short).Show();

                    // Powrót do ekranu logowania
                    Finish();
                }
            };
        }
    }
}