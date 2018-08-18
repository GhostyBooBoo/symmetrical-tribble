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
        public MainWindow()
        {
            InitializeComponent();
            this.model = new MainWindowModel();
            this.model.Stitches.Add(new Stitch()
            {
                Comments = "default",
                Date = DateTime.Today,
                Duration = TimeSpan.FromHours(2.5)
            });

            stitchList.ItemsSource = model.Stitches;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var stitch = new Stitch()
            {
                Comments = comments.Text,
                Date = DateTime.Today,
                Duration = TimeSpan.FromHours(2.5)
            };

            this.model.Stitches.Add(stitch);
            stitchList.Items.Refresh();
        }
    }
}
