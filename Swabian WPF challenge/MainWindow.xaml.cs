﻿using CsvHelper;
using Microsoft.Win32;
using Newtonsoft.Json;
using OxyPlot;
using Swabian_WPF_challenge.Classes;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Swabian_WPF_challenge
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<PointFile> pointFile;
        public MainWindow()
        {
            InitializeComponent();
            pointFile = DatabaseConnection.ReadDatabase();
            pointFilesListView.Items.Clear();
            pointFilesListView.ItemsSource = pointFile;
        }

        private void LoadFileButton_Click(object sender, RoutedEventArgs e)
        {
            List<DataPoint> points = LoadFile();
            pointFile = DatabaseConnection.ReadDatabase();
            if (pointFile != null)
            {
                pointFilesListView.ItemsSource = pointFile;
            }
            if (points.Count != 0)
            {
                GraphWindow graphWindow = new GraphWindow(points);
                graphWindow.ShowDialog();
            } else
            {
                MessageBox.Show("No points found on file", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private List<DataPoint> LoadFile()
        {
            List<DataPoint> points = new List<DataPoint>();
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Json files (*.json, *.csv)|*.json; *.csv|All files (*.*)|*.*";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (dialog.ShowDialog() == true)
            {
                string fileName = dialog.FileName;
                if (fileName.EndsWith(".csv"))
                {
                    string csv = File.ReadAllText(fileName);
                    string[] csvPoints = csv.Split(
                        new[] { Environment.NewLine },
                        StringSplitOptions.None
                    );
                    foreach (string val in csvPoints)
                    {
                        string[] point = val.Split(';');
                        int[] int_arr = Array.ConvertAll(point, Int32.Parse);
                        points.Add(new DataPoint(int_arr[0], int_arr[1]));
                    }
                }
                if (fileName.EndsWith(".json"))
                {
                    string json = File.ReadAllText(fileName);
                    points = JsonConvert.DeserializeObject<List<DataPoint>>(json);
                }
                DatabaseConnection.insertIntoDatabase(dialog.FileName, points);
            }
            return points;
        }
    }
}
