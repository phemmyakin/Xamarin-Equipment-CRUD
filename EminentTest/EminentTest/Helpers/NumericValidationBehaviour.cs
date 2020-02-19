using System.Linq;
using Xamarin.Forms;

namespace EminentTest.Helpers
{
    public class NumericValidationBehaviour : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }


        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                bool isValid = e.NewTextValue.ToCharArray().All(x => char.IsDigit(x));
                ((Entry)sender).Text = isValid ? e.NewTextValue : e.NewTextValue.Remove(e.NewTextValue.Length - 1);
            }
        }
    }
}
