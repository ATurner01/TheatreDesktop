using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TheatreDesktop.ViewModel;

namespace TheatreDesktop.Views
{
    /// <summary>
    /// Interaction logic for Movies.xaml
    /// </summary>
    public partial class Movies : Page
    {
        public Movies(MovieViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
