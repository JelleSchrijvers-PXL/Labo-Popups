
namespace Popups
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private Random rnd = new Random(); 
        private Color GetRandomColor()
        {
            return Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
        }

        private async void PromptAlert(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Toevoegen", "Naam");

            if (result != null)
            {
                var button = new Button();
                {
                    button.Text = result;
                    button.FontSize = 20;
                    button.Padding = 20;
                    button.CornerRadius = 10;
                    button.BackgroundColor = GetRandomColor();
                }

                button.Clicked += async (sender, e) =>
                {
                    bool answer = await DisplayAlertAsync("Verwijderen", $"Bent u zeker dat u {result} wilt verwijderen", "Ja", "Nee");

                    if (answer)
                    {
                        await Task.WhenAll(
                            button.FadeToAsync(0, 2000),
                            button.ScaleToAsync(0, 2000));
                        MyFlexLayout.Children.Remove(button);
                    }
                };

                MyFlexLayout.Children.Add(button);
            }
            else
            {
                await DisplayAlertAsync("You canceled", "You have canceled this will lead to no actions", "OK");
            }
        }
    }

}
