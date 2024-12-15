using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using System.Collections.Generic;
using Google.Android.Material.FloatingActionButton;

namespace AndroidApp1
{
    [Activity(Label = "User Activity")]
    public class UserActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_user);

            // ustaw nazwe użytkownika
            string username = Intent.GetStringExtra("username") ?? "Użytkownik";
            TextView usernameTextView = FindViewById<TextView>(Resource.Id.username_text);
            usernameTextView.Text = $"Witaj, {username}!";

            // obsługa przycisku profilu
            ImageButton profileButton = FindViewById<ImageButton>(Resource.Id.profile_button);
            profileButton.Click += (sender, e) =>
            {
                Intent intent = new Intent(this, typeof(ProfileActivity));
                intent.PutExtra("username", username);
                StartActivity(intent);
            };

            // przygotowanie listy napojów
            List<Drink> drinks = new List<Drink>
            {
                new Drink { Name = "Kawa Espresso", Description = "Mocne i aromatyczne espresso", Rating = 4.5f },
                new Drink { Name = "Herbata Earl Grey", Description = "Delikatna herbata z nutą bergamotki", Rating = 4.0f },
                new Drink { Name = "Sok Pomarańczowy", Description = "Świeży i orzeźwiający", Rating = 4.8f }
            };

            // Recyclerview
            RecyclerView recyclerView = FindViewById<RecyclerView>(Resource.Id.drinks_recycler_view);
            recyclerView.SetLayoutManager(new LinearLayoutManager(this));
            recyclerView.SetAdapter(new DrinkAdapter(drinks));

            // FloatingActionButton i dodanie kliknięcia
            Button addButton = FindViewById<Button>(Resource.Id.add_drink_button);
            addButton.Click += (sender, e) =>
            {
                // Przejście do ekranu dodawania napoju
                Intent intent = new Intent(this, typeof(AddDrinkActivity));
                StartActivity(intent);
            };
        }
        public override void OnBackPressed()
        {
            // Prevent navigation back to login
            MoveTaskToBack(true);
        }
    }
}