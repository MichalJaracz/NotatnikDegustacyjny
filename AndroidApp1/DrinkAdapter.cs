using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using System.Collections.Generic;

namespace AndroidApp1
{
    public class Drink
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Rating { get; set; }
    }

    public class DrinkAdapter : RecyclerView.Adapter
    {
        private readonly List<Drink> drinks;

        public DrinkAdapter(List<Drink> drinks)
        {
            this.drinks = drinks;
        }

        public override int ItemCount => drinks.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (holder is DrinkViewHolder viewHolder)
            {
                var drink = drinks[position];
                viewHolder.Name.Text = drink.Name;
                viewHolder.Description.Text = drink.Description;
                viewHolder.Rating.Text = $"Ocena: {drink.Rating}/5";
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.drink_item, parent, false);
            return new DrinkViewHolder(itemView);
        }
    }

    public class DrinkViewHolder : RecyclerView.ViewHolder
    {
        public TextView Name { get; private set; }
        public TextView Description { get; private set; }
        public TextView Rating { get; private set; }

        public DrinkViewHolder(View itemView) : base(itemView)
        {
            Name = itemView.FindViewById<TextView>(Resource.Id.drink_name);
            Description = itemView.FindViewById<TextView>(Resource.Id.drink_description);
            Rating = itemView.FindViewById<TextView>(Resource.Id.drink_rating);
        }
    }
}