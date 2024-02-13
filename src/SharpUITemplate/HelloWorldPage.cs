
namespace SharpUITemplate
{
    using Sharp.UI;

    public partial class HelloWorldPage : ContentPage
    {
        int count = 0;

        public HelloWorldPage()
        {
            Content =

            new VStack(e => e
                .Spacing(25)
                .Padding(new Thickness(30, 0))
                .CenterVertically())
            {
                new Image("dotnet_bot.png", out var image)
                    .HeightRequest(150)
                    .CenterHorizontally(),

                new Label("Welcome to the Sharp.UI for MAUI")
                    .FontSize(e => e.OnPhone(16).Default(20))
                    .CenterHorizontally(),

                new Button("Click me")
                    .FontSize(20)
                    .CenterHorizontally()
                    .OnClicked(button =>
                    {
                        count++;
                        button.Text = $"Clicked {count} ";
                        button.Text += count == 1 ? "time" : "times";
                    })
            };
        }
    }
}
