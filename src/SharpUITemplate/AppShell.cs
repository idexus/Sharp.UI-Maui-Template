
namespace SharpUITemplate
{
    using Sharp.UI;

    public class AppShell : Shell
    {
        public AppShell()
        {
            this.Resources.MergedDictionaries.Add(AppResources.Default);

            var tab = new Tab("Main")
            {
                new ShellContent<HelloWorldPage>(),   
            };

            this.Add(tab);
        }
    }
}
