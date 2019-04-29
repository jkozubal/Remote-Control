using System;
using System.Windows;
using System.Windows.Controls;
using RemoteInvitesControl;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                RemoteControlConfigModel savedModel = Serialize.ReadXML();
                RemoteCheckBox.IsChecked = savedModel.RemoteControlEnabled;
                NumberofTimeBox.SelectedValue = savedModel.TimeOfInvitation;
                TimeBox.SelectedValue = savedModel.UnitOfTime;
                VistaCheckBox.IsChecked = savedModel.OnlyVistaOrNewerEnabled;
                InviteGroupBox.IsEnabled = savedModel.RemoteControlEnabled;
            }
            catch //exception (file not found, unreadable file, etc.)
            {
                TimeBox.SelectedIndex = 1;
                TimeBox_SelectionChanged(null, null);
                InviteGroupBox.IsEnabled = false;
            }
        }

        private void TimeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NumberofTimeBox.Items.Clear();
            NumberofTimeBox.IsEnabled = true;
            int currentItem = TimeBox.SelectedIndex;

            if (currentItem == 0) //godz.
            {
                for (int i = 1; i <= 5; i++)
                {
                    NumberofTimeBox.Items.Add(i);
                }
            }
            if (currentItem == 1)//min
            {
                for (int i = 5; i < 60; i += 10)
                {
                    NumberofTimeBox.Items.Add(i);
                }
            }

            if (NumberofTimeBox.SelectedIndex < 0)
            {
                NumberofTimeBox.SelectedIndex = 0;
            }
        }

        public void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            bool isRemoteChecked = RemoteCheckBox.IsChecked.GetValueOrDefault();
            int whatTime = Convert.ToInt32(NumberofTimeBox.SelectedValue);
            string stringValue = TimeBox.SelectedValue.ToString();
            bool isVistaChecked = VistaCheckBox.IsChecked.GetValueOrDefault();

            RemoteControlConfigModel model = new RemoteControlConfigModel(isRemoteChecked, whatTime, stringValue, isVistaChecked);

            Serialize.WriteXML(model);

            this.Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RemoteCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            InviteGroupBox.IsEnabled = false;
        }

        private void RemoteCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            InviteGroupBox.IsEnabled = true;
        }
    }
}
