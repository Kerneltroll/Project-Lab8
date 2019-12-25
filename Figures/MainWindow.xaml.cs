using FigureLibrary;
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


namespace Figures
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PolygonArray polygonArray = new PolygonArray();
        public MainWindow()
        {
            InitializeComponent();
        }



        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            StreamReader file = new StreamReader(@"C:\Users\Hames\Desktop\Lab8\Figures\list.txt");
            while (file.Peek() != -1)
            {
                string[] line = file.ReadLine().Split(' ');
                if (line.Length == 5)
                {
                    int[] coordArray = new int[4];
                    for (int i = 0; i < 4; i++)
                    {
                        coordArray[i] = Int32.Parse(line[i]);
                    }
                    polygonArray.AddPolygon("Rectangle", line[4], coordArray);
                }
                if (line.Length == 7)
                {
                    int[] coordArray = new int[6];
                    for (int i = 0; i < 6; i++)
                    {
                        coordArray[i] = Int32.Parse(line[i]);
                    }
                    polygonArray.AddPolygon("Triangle", line[6], coordArray);
                }
            }
            file.Close();

            TextBox textBox = new TextBox();
            textBox.TextWrapping = TextWrapping.Wrap;
            textBox.Width = ListView.Width - 15;
            textBox.FontSize = 14;
            textBox.Text = "---> Information loaded --->";
            ListView.Items.Add(textBox);
        }

        private void ShawAllPoly_Click(object sender, RoutedEventArgs e)
        {
            ListView.Items.Clear();

            string[] colors;
            string[] figures = polygonArray.ShowAllPolygones(out colors);
            for (int i = 0; i < figures.Length; i++)
            {
                TextBox textBox = new TextBox();
                textBox.TextWrapping = TextWrapping.Wrap;
                textBox.Width = ListView.Width - 15;
                textBox.FontSize = 14;
                System.Drawing.Color color = System.Drawing.Color.FromName(colors[i]);
                textBox.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, color.R, color.G, color.B));
                textBox.Text = figures[i];
                ListView.Items.Add(textBox);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextBox textBox = new TextBox();
            textBox.TextWrapping = TextWrapping.Wrap;
            textBox.Width = ListView.Width - 15;
            textBox.FontSize = 14;
            textBox.Text = "---> Added " + polygonArray.Counter + " items " + "--->";
            ListView.Items.Add(textBox);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TextBox textBox = new TextBox();
            textBox.TextWrapping = TextWrapping.Wrap;
            textBox.Width = ListView.Width - 15;
            textBox.FontSize = 14;
            //textBox.Text = "---> Added " +  + " items " + "--->";
            ListView.Items.Add(textBox);
        }

        private void ShowSortedButton_Click(object sender, RoutedEventArgs e)
        {
            polygonArray.SortPolygons();

            ListView.Items.Clear();
            
            string[] colors;
            string[] figures = polygonArray.ShowAllPolygones(out colors);
            for (int i = 0; i < figures.Length; i++)
            {
                TextBox textBox = new TextBox();
                textBox.TextWrapping = TextWrapping.Wrap;
                textBox.Width = ListView.Width - 15;
                textBox.FontSize = 14;
                System.Drawing.Color color = System.Drawing.Color.FromName(colors[i]);
                textBox.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, color.R, color.G, color.B));
                textBox.Text = figures[i];
                ListView.Items.Add(textBox);
            }
        }
    }
}
