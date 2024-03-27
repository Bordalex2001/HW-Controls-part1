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

namespace HW_Controls__part_1_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView
    {
        private readonly Presenter _presenter;
        public MainWindow()
        {
            InitializeComponent();
            _presenter = new Presenter(this);
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _presenter.Initialize();
        }

        public void AddPhotoTab(string imageName, Image image)
        {
            TabItem tabItem = new TabItem();
            tabItem.Header = imageName;
            tabItem.Content = image;
            imageTabControl.Items.Add(tabItem);
        }
        
        public event EventHandler<EventArgs> Next;
        public event EventHandler<EventArgs> Previous;
        public event EventHandler<EventArgs> Add;
        public event EventHandler<EventArgs> Delete;

        private void nextTabBtn_Click(object sender, RoutedEventArgs e)
        {
            Next?.Invoke(this, e);
        }

        private void previousTabBtn_Click(object sender, RoutedEventArgs e)
        {
            Previous?.Invoke(this, e);
        }

        private void imageTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _presenter.TabChanged(imageTabControl.SelectedIndex);
        }

        private void deletePhoto_Click(object sender, RoutedEventArgs e)
        {
            Delete?.Invoke(this, e);
        }
    }
}