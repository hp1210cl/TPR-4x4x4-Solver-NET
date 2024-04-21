using cs.threephase;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace TPR_4x4x4_Solver_NET
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        StackPanel[][] facelet = new StackPanel[6][];
        Color[] COLORS = { Colors.White, Colors.Red, Colors.Green, Colors.Yellow, Colors.Orange, Colors.Blue };
        int curColor = 0;

        private int maxDepth = 21, maxTime = 5;
        bool useSeparator = true;
        bool showString = false;
        bool inverse = true;
        bool showLength = true;
        Search search = new Search();

        public MainWindow()
        {
            InitializeComponent();
            this.Background = Brushes.AntiqueWhite;

            for (int i = 0; i < 6; i++)
            {
                facelet[i] = new StackPanel[16];
            }
            Grid[] faceletGrids = { gridU, gridR, gridF, gridD, gridL, gridB };
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    facelet[i][j] = new StackPanel();
                    facelet[i][j].Background = new SolidColorBrush(Colors.Gray);
                    facelet[i][j].Margin = new Thickness(1);
                    faceletGrids[i].Children.Add(facelet[i][j]);
                    Grid.SetRow(facelet[i][j], j / 4);
                    Grid.SetColumn(facelet[i][j], j % 4);
                    facelet[i][j].MouseUp += MainWindow_MouseUp;

                }
            }

            checkBoxShowStr.Click += checkBox_Click;

            try
            {
                using (FileStream filestream = new FileStream("twophase.data", FileMode.Open))
                {
                    cs.min2phase.Tools.initFrom(filestream);
                }
            }
            catch (FileNotFoundException e)
            {

            }
            if (!cs.min2phase.Search.isInited())
            {
                cs.min2phase.Search.init();
                try
                {
                    using (FileStream filestream = new FileStream("twophase.data", FileMode.CreateNew))
                    {
                        cs.min2phase.Tools.saveTo(filestream);
                    }
                }
                catch (IOException e)
                {

                }
            }


            Stopwatch timer = Stopwatch.StartNew();
            try
            {
                using (FileStream filestream = new FileStream("threephase.data", FileMode.Open))
                {
                    Tools.initFrom(filestream);

                }
            }
            catch (FileNotFoundException e)
            {

            }
            if (!Search.inited)
            {
                Search.init();
                try
                {
                    using (FileStream filestream = new FileStream("threephase.data", FileMode.CreateNew))
                    {
                        Tools.saveTo(filestream);
                    }
                }
                catch (IOException e)
                {

                }
            }

            //Search.init();
            //MessageBox.Show(timer.ElapsedMilliseconds.ToString());
            Debug.WriteLine($"isInited { timer.ElapsedMilliseconds}ms");
        }


        private void MainWindow_MouseUp(object sender, MouseButtonEventArgs e)
        {
            StackPanel sp = (StackPanel)sender;
            sp.Background = new SolidColorBrush(COLORS[curColor]);
        }


        private void cx_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;

            curColor = Convert.ToInt32(b.Name.Substring(1));
        }


        private void checkBox_Click(object sender, RoutedEventArgs e)
        {
            showString = (bool)checkBoxShowStr.IsChecked;
        }

        private void btnRandom_Click(object sender, RoutedEventArgs e)
        {
            String r = Tools.randomCube();
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    switch (r[16 * i + j])
                    {
                        case 'U':
                            facelet[i][j].Background = new SolidColorBrush(COLORS[0]);
                            break;
                        case 'R':
                            facelet[i][j].Background = new SolidColorBrush(COLORS[1]);
                            break;
                        case 'F':
                            facelet[i][j].Background = new SolidColorBrush(COLORS[2]);
                            break;
                        case 'D':
                            facelet[i][j].Background = new SolidColorBrush(COLORS[3]);
                            break;
                        case 'L':
                            facelet[i][j].Background = new SolidColorBrush(COLORS[4]);
                            break;
                        case 'B':
                            facelet[i][j].Background = new SolidColorBrush(COLORS[5]);
                            break;
                    }
                }
            }
        }

        private void btnSolve_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder s = new StringBuilder(54);

            for (int i = 0; i < 96; i++)
                s.Insert(i, 'B');// default initialization

            for (int i = 0; i < 6; i++)
                // read the 54 facelets
                for (int j = 0; j < 16; j++)
                {
                    if (((SolidColorBrush)facelet[i][j].Background).Color == COLORS[0])
                        s[16 * i + j] = 'U';
                    if (((SolidColorBrush)facelet[i][j].Background).Color == COLORS[1])
                        s[16 * i + j] = 'R';
                    if (((SolidColorBrush)facelet[i][j].Background).Color == COLORS[2])
                        s[16 * i + j] = 'F';
                    if (((SolidColorBrush)facelet[i][j].Background).Color == COLORS[3])
                        s[16 * i + j] = 'D';
                    if (((SolidColorBrush)facelet[i][j].Background).Color == COLORS[4])
                        s[16 * i + j] = 'L';
                    if (((SolidColorBrush)facelet[i][j].Background).Color == COLORS[5])
                        s[16 * i + j] = 'B';
                }

            String cubeString = s.ToString();
            cubeString = "DRURBFDBLBFRRRBLBDLDDDBUBLDRDFDFFFDUFURLRBRUUBURBDLFUUUDFRDLBBFULLFUFFURLLFBDLRRBFDFRLLUBRBULDUL";

            Debug.WriteLine("Cube Definition String: " + cubeString);
            if (showString)
            {
                MessageBox.Show("Cube Definiton String: " + cubeString);
            }
            int mask = 0;
            //mask |= useSeparator ? Search.USE_SEPARATOR : 0;
            //mask |= inverse ? Search.INVERSE_SOLUTION : 0;
            //mask |= showLength ? Search.APPEND_LENGTH : 0;
            Stopwatch timer = Stopwatch.StartNew();
            long t;
            // ++++++++++++++++++++++++ Call Search.solution method from package org.kociemba.twophase ++++++++++++++++++++++++
            String result = search.getsolution(cubeString); 
            timer.Stop();
            t = timer.ElapsedMilliseconds;

            // +++++++++++++++++++ Replace the error messages with more meaningful ones in your language ++++++++++++++++++++++
            if (result.Contains("Error"))
            {
                switch (result[result.Length - 1])
                {
                    case '1':
                        result = "There are not exactly nine facelets of each color!";
                        break;
                    case '2':
                        result = "Not all 12 edges exist exactly once!";
                        break;
                    case '3':
                        result = "Flip error: One edge has to be flipped!";
                        break;
                    case '4':
                        result = "Not all 8 corners exist exactly once!";
                        break;
                    case '5':
                        result = "Twist error: One corner has to be twisted!";
                        break;
                    case '6':
                        result = "Parity error: Two corners or two edges have to be exchanged!";
                        break;
                    case '7':
                        result = "No solution exists for the given maximum move number!";
                        break;
                    case '8':
                        result = "Timeout, no solution found within given maximum time!";
                        break;
                }
            }
            if (showLength)
            {
                int length = 0;
                for (int i = 0; i < result.Length; i++)
                {
                    if ("URFDLBurfdlb".IndexOf(result[i]) != -1)
                    {
                        length++;
                    }
                }
                result += $"({length}f)";
            }

            Debug.WriteLine("Result: " + result);
            MessageBox.Show(result, t.ToString() + " ms");
        }

    }
}
