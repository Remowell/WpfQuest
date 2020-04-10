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

namespace WpfQuest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int time = 11;
        int counter = 0;
        private DispatcherTimer Timer;

        public MainWindow()
        {
            InitializeComponent();
            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Tick += Timer_Tick;
            Timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (time > 0)
            {
                time--;
                label.Content = string.Format("00:0{0}:0{1}", time / 60, time % 60);
            }
            else
            {
                Timer.Stop();
                MessageBox.Show("Next time");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            counter++;
            if(counter == 15)
            {
                Timer.Stop();
                MessageBox.Show("Next level");
                CreateLevelTwo();
            }
        }

        private void CreateLevelTwo()
        {
            myGrid.Children.Clear();

            Label labelLvl2 = new Label
            {
                Content = "Level 2",
                FontSize = 20,
            };
            labelLvl2.VerticalAlignment = VerticalAlignment.Top;
            labelLvl2.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.Children.Add(labelLvl2);

            TextBox textBoxLvl2 = new TextBox
            {
                Margin = new Thickness(10, 34, 10, 50),
                FontSize = 20
            };
            myGrid.Children.Add(textBoxLvl2);

            Button buttonLvl2 = new Button
            {
                Content = "Enter your answer",
                FontSize = 20
            };
            buttonLvl2.Click += ButtonLvl2_Click;
            buttonLvl2.VerticalAlignment = VerticalAlignment.Bottom;
            myGrid.Children.Add(buttonLvl2);

            Label labelHelp = new Label();
            labelHelp.Content = "You should go { level3 }";
            labelHelp.VerticalAlignment = VerticalAlignment.Top;
            myGrid.Children.Add(labelHelp);
        }

        private void ButtonLvl2_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in myGrid.Children)
            {
                if (item is TextBox textBox)
                {
                    if (textBox.Text == "level3")
                    {
                        MessageBox.Show("Next level");
                    }
                    else { MessageBox.Show("We need answer"); }
                    break;
                }
                break;
            }
            CreateLevelThree();
        }

        private void CreateLevelThree()
        {
            myGrid.Children.Clear();
        }
    }
}
