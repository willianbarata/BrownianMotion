using BrownianMotion.MVVM.View;

namespace BrownianMotion
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new InitialPage();
        }
    }
}
