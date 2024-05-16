using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Verwaltung
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void BtnMinMaxResOnClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button senderBtn)
            {
                if (senderBtn == null) return;

                if (senderBtn.Name == nameof(BtnWindowMinimize))
                {
                    this.WindowState = WindowState.Minimized;
                }

                if (senderBtn.Name == nameof(BtnWindowClose))
                {
                    var dialogSettings = new MetroDialogSettings
                    {
                        AffirmativeButtonText = "JA",
                        NegativeButtonText = "NEIN",
                        AnimateShow = true,
                        AnimateHide = true
                    };

                    var result = await this.ShowMessageAsync("ACHTUNG", "Wollen Sie wirklich die Anwendung beenden?",
                        MessageDialogStyle.AffirmativeAndNegative, dialogSettings);

                    if (result == MessageDialogResult.Affirmative)
                    {
                        Application.Current.Shutdown();
                    }
                }
            }
            else if (sender is ToggleButton senderTglBtn)
            {
                if (senderTglBtn == null) return;

                if (senderTglBtn.IsChecked == true)
                {
                    this.WindowState = WindowState.Maximized;
                }
                else
                {
                    this.WindowState = WindowState.Normal;
                }
            }
        }

        private void Grid_PreviewMouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            try
            {
                if(e.LeftButton == MouseButtonState.Pressed)
                {
                    DragMove();
                }

            }
            catch (Exception)
            {
                //
            } 


        }
    }
}
