using Microsoft.Maui.Controls.Shapes;

namespace SharpUITemplate
{
    using Sharp.UI;

    public partial class HelloWorldPage : ContentPage
    {
        int count = 0;

        public HelloWorldPage()
        {
            Content = new VStack(out var vStack, e => e.CenterVertically())
            {
                new Label("Sharp.UI", out var label)
                    .TextColor(Colors.LightGrey)
                    .FontSize(70)
                    .CenterHorizontally(),

                new Label("Hot Reload Test :)")
                    .FontSize(30)
                    .TextColor(Colors.Red)
                    .CenterHorizontally(),

                new Slider(out var slider)
                    .Minimum(1).Maximum(100)
                    .Margin(20),

                new Border
                {
                    new Grid(e => e.RowDefinitions(e => e.Star(1).Star(3).Star(count: 2)).Spacing(10))
                    {
                        new Label()
                            .Text(e => e.Path("Value").Source(slider).StringFormat("Value : {0:F1}"))
                            .FontSize(30)
                            .CenterHorizontally()
                            .Padding(10),

                        new Image("dotnet_bot.png").Row(1),

                        new Label("Hello World!!!").Row(2)
                            .CenterHorizontally()
                            .FontSize(25)
                            .TextColor(Colors.DarkGray),

                        new Switch(out var myswitch).Row(3)
                            .CenterHorizontally()
                    }
                }
                .SizeRequest(250,400)
                .BackgroundColor(AppColors.Gray950)
                .StrokeShape(new RoundRectangle().CornerRadius(30))
                .VisualStateGroups(new VisualStateGroupList
                {
                    new VisualState<Border> {
                        async border => {
                            await border.AnimateBackgroundColorTo(Colors.Red, 500);
                            await label.RotateXTo(360, 400);
                        },
                        new StateTrigger().IsActive(e => e.Path("IsToggled").Source(myswitch))
                    },

                    new VisualState<Border> {
                        async border => {
                            await border.AnimateBackgroundColorTo(AppColors.Gray950, 500);
                            await label.RotateXTo(0, 400);
                        },
                        new StateTrigger().IsActive(e => e.Path("IsToggled").Source(myswitch).Negate())
                    }
                }),

                new Button("Click me")
                    .WidthRequest(250)
                    .Margin(30)
                    .OnClicked(async button =>
                    {
                        count++;
                        button.Text = $"Clicked {count} ";
                        button.Text += count == 1 ? "time" : "times";

                        await vStack.RotateYTo(((count % 4) switch {0 => 0, 1 => 20, 2 => 0, _ => -20}));
                        await label.RotateTo(360 * (count % 2), 300);            
                    })

            };
        }
    }
}
