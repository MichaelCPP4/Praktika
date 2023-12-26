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
using System.Windows.Threading;

namespace bred
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Aftorization win2 = new Aftorization();
            if((bool) win2.ShowDialog() || win2.IsSignIn)
            {
                InitializeComponent();

                if (win2.IsUser)
                {
                    slovoTextBox.Text = "Сложно быть пользователем";
                    slovoTextBox.IsReadOnly = true;
                }
            }
            else
            {
                Close();
            }
        
        }
        static Polyline Polyline_Bukvi = new Polyline()
        {
            Stroke = Brushes.Green,
            StrokeThickness = 1.5
        };


        private int currentIndex = 0;
        private DispatcherTimer timer = new DispatcherTimer();
        List<int> numbersArray;
        Point[] points;
        Polyline line = new Polyline()
        {
            Stroke = Brushes.Green,
            StrokeThickness = 1.5
        };
        int cg = 0;

        private void CreateGrafik_Click(object sender, RoutedEventArgs e)
        {
            if (slovoTextBox.Text != "" && slovoTextBox.Text != null)
            {
                canvasPanel.Children.Clear();
                line.Points.Clear();
                cg = 0;
                currentIndex = 0;
                if (numbersArray != null)
                    numbersArray.Clear();

                string word = slovoTextBox.Text;

                numbersArray = RussianAlphabetConverter.ConvertLettersToNumbers(word);
                GenerationPoints(numbersArray.ToArray());

                timer = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 0, 1) }; // 1 секунда
                timer.Tick += Timer_Tick;
                timer.Start();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (currentIndex < numbersArray.Count)
            {
                DrawLine(points[currentIndex]);
                currentIndex++;
            }
            else
            {
                timer.Stop();
            }
        }
        

        private void DrawPoint(int x, int y)
        {
            Ellipse point = new Ellipse();
            point.Width = 5;
            point.Height = 5;
            point.Fill = Brushes.Red; // Цвет точки
            Canvas.SetLeft(point, x); // Измените это значение для расположения точек по оси X
            Canvas.SetBottom(point, y); // Измените это значение для расположения точек по оси Y
            canvasPanel.Children.Add(point); // Замените "YourCanvas" на название вашего Canvas
        }

        private void GenerationPoints(int[] numbersArray)
        {
            int count = numbersArray.Length;
            points = new Point[count];
            for (int i = 0; i < count; i++)
            {
                points[i] = new Point(cg, ((numbersArray[i]+16)*3));
                cg += 30;
            }
        }

        private void DrawLine(Point point1)
        {
            canvasPanel.Children.Remove(line);
            line.Points.Add(point1);
            canvasPanel.Children.Add(line);
        }

        private void ClearGrafik_Click(object sender, RoutedEventArgs e)
        {
            canvasPanel.Children.Clear();
            line.Points.Clear();
            cg = 0;
            currentIndex = 0;
            if (numbersArray != null)
                numbersArray.Clear();
        }

        private void ExitGrafik_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}