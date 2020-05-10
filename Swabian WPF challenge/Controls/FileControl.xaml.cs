using Swabian_WPF_challenge.Classes;
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

namespace Swabian_WPF_challenge.Controls
{
    /// <summary>
    /// Interaction logic for FileControl.xaml
    /// </summary>
    public partial class FileControl : UserControl
    {


        //public PointFile PointFile
        //{
        //    get { return (PointFile)GetValue(PointFileProperty); }
        //    set { SetValue(PointFileProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for PointFile.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty PointFileProperty =
        //    DependencyProperty.Register("PointFile", typeof(PointFile), typeof(FileControl), new PropertyMetadata(0));


        public PointFile PointFile
        {
            get { return (PointFile)GetValue(PointFileProperty); }
            set { SetValue(PointFileProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Contact.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PointFileProperty =
            DependencyProperty.Register("PointFile", typeof(PointFile), typeof(FileControl), new PropertyMetadata(new PointFile(), SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FileControl control = d as FileControl;

            if (control != null)
            {
                control.nameTextBlock.Text = (e.NewValue as PointFile).Name;
                control.dateTextBlock.Text = (e.NewValue as PointFile).Date.ToString();
                control.pathTextBlock.Text = (e.NewValue as PointFile).Path;
                control.pointsTextBlock.Text = (e.NewValue as PointFile).Points.Count.ToString();
            }
        }
        public FileControl()
        {
            InitializeComponent();
        }
    }
}
