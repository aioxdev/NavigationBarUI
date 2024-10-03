using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml;

namespace NavigationUI.Components;

public partial class NavBar : UserControl
{
    public static readonly StyledProperty<int> SelectedIndexProperty =
        AvaloniaProperty.Register<NavBar, int>(nameof(SelectedIndex));

    public int SelectedIndex
    {
        get => this.GetValue(SelectedIndexProperty);
        set => SetValue(SelectedIndexProperty, value);
    }

    public NavBar()
    {
        InitializeComponent();
        this.Loaded += NavBar_Loaded;
    }

    private void NavBar_Loaded(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        ToggleButton homeBtn = (ToggleButton)navList.Children[0];
        double pointerPos = homeBtn.Bounds.Left + (homeBtn.Bounds.Width / 2) - 3;
        navPointer.Margin = new Thickness(pointerPos, 0, 0, 0);
    }

    private void ToggleButton_Checked(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        foreach (ToggleButton btn in navList.Children)
        {
            if (btn == sender)
            {
                SelectedIndex=navList.Children.IndexOf(btn);    
            }
            else
            {
                btn.IsEnabled = true;
                btn.IsChecked = false;
            }
        }

        ToggleButton checkedBtn=(ToggleButton)sender;

        double pointerPos=checkedBtn.Bounds.Left+(checkedBtn.Bounds.Width/2)-3;
        navPointer.Margin=new Thickness(pointerPos,0,0,0);
    }
}