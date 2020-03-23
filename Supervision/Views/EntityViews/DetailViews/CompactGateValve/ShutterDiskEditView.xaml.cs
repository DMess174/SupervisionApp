using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Supervision.Views.EntityViews.DetailViews.CompactGateValve
{
    public partial class ShutterDiskEditView : Window
    {
        public ShutterDiskEditView()
        {
            InitializeComponent();
        }

        private void PreviewKeyDown_EventHandler(object sender, System.Windows.Input.KeyEventArgs e)
        {
            // The following is in order to avoid them nasty exceptions if the 
            // user hits "up" or "down" with no date selected:

            if (sender == null                               // Ignore if no sender
               || ((DatePicker)sender).SelectedDate == null) // Ignore if no date
                return;

            if (e.Key == Key.F6)
            {
                ((DatePicker)sender).SelectedDate = DateTime.Now;
            }
            // Do this on user clicking the up button
            if (e.Key == Key.Up)
            {
                ((DatePicker)sender).SelectedDate =
                   ((DatePicker)sender).SelectedDate.GetValueOrDefault().AddDays(1);
            }

            // And this when he clicks the down
            if (e.Key == Key.Down)
            {
                ((DatePicker)sender).SelectedDate =
                   ((DatePicker)sender).SelectedDate.GetValueOrDefault().AddDays(-1);
            }
        }
    }
}
