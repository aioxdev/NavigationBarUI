using Avalonia.Controls;

namespace NavigationUI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.PointerPressed += (sender, e) =>
            {
                this.BeginMoveDrag(e);
            };
        }
    }
}