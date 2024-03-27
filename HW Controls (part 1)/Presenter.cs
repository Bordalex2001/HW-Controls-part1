using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace HW_Controls__part_1_
{
    internal class Presenter
    {
        private readonly MainWindow _view;
        private readonly IModel _model;
        private int _index = 0;
        public Presenter(MainWindow view)
        {
            _view = view;
            _view.Next += NavigateForward;
            _view.Previous += NavigateBackward;
            _view.Delete += DeletePhoto;
            _model = new Model();
            _index = 0;
        }
        public void Initialize()
        {
            LoadPhotosToTabs();
        }
        private void LoadPhotosToTabs()
        {
            foreach (Photo photo in _model.Photos) 
            {
                Image image = new Image();
                image.Source = new BitmapImage(new Uri(photo.Name, UriKind.Relative));
                _view.AddPhotoTab(photo.Name, image);
            }
        }
        private void NavigateForward(object sender, EventArgs e)
        {
            _index = (_index + 1) % _model.Photos.Count;
            _view.imageTabControl.SelectedIndex = _index;
        }
        private void NavigateBackward(object sender, EventArgs e)
        {
            _index = (_index - 1 + _model.Photos.Count) % _model.Photos.Count;
            _view.imageTabControl.SelectedIndex = _index;
        }
        private void AddNewPhoto(object sender, EventArgs e)
        {
            /*String pathToImage = "";
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "JPG files(*.jpg)|*.jpg| PNG files(*.png)|*.png|";
            if (fileDialog.ShowDialog() == System.Windows.)*/
        }
        private void DeletePhoto(object sender, EventArgs e)
        {
            if (_model.Photos.Count > 0)
            {
                _model.Photos.RemoveAt(_index);
                _view.imageTabControl.Items.RemoveAt(_index);
                if (_index > 0)
                {
                    _index--;
                }
                _view.imageTabControl.SelectedIndex = _index;
            }
        }
        public void TabChanged(int index)
        {
            _index = index;
        }
    }
}