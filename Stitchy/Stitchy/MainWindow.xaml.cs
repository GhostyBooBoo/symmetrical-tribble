using Stitchy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
        }

        private void StitchListItemDelete_Click(object sender, RoutedEventArgs e)
        {
            if (stitchList.SelectedIndex == -1) { return; }

            this.model.Stitches.RemoveAt(stitchList.SelectedIndex);
            stitchList.Items.Refresh();
        }

        private void MenuItemSave_Click(object sender, RoutedEventArgs e)
        {
            this.persistenceProcessor.Save(this.model.Stitches);
        }

        private void MenuItemOpen_Click(object sender, RoutedEventArgs e)
        {
            var data = this.persistenceProcessor.Open();
            this.model.Stitches.Clear();
            this.model.Stitches.AddRange(data);
            stitchList.Items.Refresh();
        }
    }
}
