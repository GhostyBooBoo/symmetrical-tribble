using Stitchy.Models;
using System;
using System.Windows;

namespace Stitchy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowModel model;
        private PersistenceProcessor persistenceProcessor;

        public MainWindow()
        {
            InitializeComponent();
            this.model = new MainWindowModel();
            this.persistenceProcessor = new PersistenceProcessor();

            stitchList.ItemsSource = model.Stitches;

            this.LoadData();
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            var stitch = new Stitch()
            {
                Comments = comments.Text,
                StartDate = startTime.Value ?? DateTime.Now,
                EndDate = endTime.Value ?? DateTime.Now
            };

            this.model.Stitches.Add(stitch);
            stitchList.Items.Refresh();
            this.UpdateTotal();
            this.SaveData();
        }

        private void StitchListItemDelete_Click(object sender, RoutedEventArgs e)
        {
            if (stitchList.SelectedIndex == -1) { return; }

            this.model.Stitches.RemoveAt(stitchList.SelectedIndex);
            stitchList.Items.Refresh();
            this.UpdateTotal();
            this.SaveData();
        }

        private void MenuItemSave_Click(object sender, RoutedEventArgs e)
        {
            this.SaveData();
        }

        private void MenuItemOpen_Click(object sender, RoutedEventArgs e)
        {
            this.LoadData();
        }

        private void LoadData()
        {
            var data = this.persistenceProcessor.Open();
            this.model.Stitches.Clear();
            this.model.Stitches.AddRange(data);
            stitchList.Items.Refresh();
            this.UpdateTotal();
        }

        private void SaveData()
        {
            this.persistenceProcessor.Save(this.model.Stitches);
        }

        private void UpdateTotal()
        {
            var totalDuration = new TimeSpan(0);

            foreach (var stitch in this.model.Stitches)
            {
                totalDuration += stitch.Duration;
            }

            totalDisplay.Text = $"Total time: {totalDuration}";
        }
    }
}
