using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                Application.Current.Shutdown();
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
                    else 
                    {
                        MessageBox.Show("Bye");
                        Application.Current.Shutdown();
                    }
                }
            }
            CreateLevelThree();
        }

        private void CreateLevelThree()
        {
            myGrid.Children.Clear();

            Label labelLvl3 = new Label
            {
                Content = "Level 3",
                FontSize = 20
            };
            labelLvl3.VerticalAlignment = VerticalAlignment.Top;
            labelLvl3.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.Children.Add(labelLvl3);

            Label labelHelp2 = new Label();
            labelHelp2.Content = "Choose the color you see HERE";
            labelHelp2.VerticalAlignment = VerticalAlignment.Top;
            myGrid.Children.Add(labelHelp2);

            ComboBox comboBoxLvl3 = new ComboBox();
            comboBoxLvl3.Margin = new Thickness(10, 60, 10, 300);
            ObservableCollection<string> color = new ObservableCollection<string>();
            color.Add("Green");
            color.Add("Red");
            color.Add("Yellow");
            color.Add("Blue");
            color.Add("Brown");
            color.Add("Black");
            color.Add("Gray");
            color.Add("Pink");
            color.Add("Purple");
            color.Add("White");
            comboBoxLvl3.ItemsSource = color;
            myGrid.Children.Add(comboBoxLvl3);

            Button buttonLvl3 = new Button
            {
                Content = "Enter your answer",
                FontSize = 20
            };
            buttonLvl3.Click += ButtonLvl3_Click;
            buttonLvl3.VerticalAlignment = VerticalAlignment.Bottom;
            myGrid.Children.Add(buttonLvl3);
        }

        private void ButtonLvl3_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in myGrid.Children)
            {
                if (item is ComboBox comboBox)
                {
                    if(comboBox.SelectedItem is "Black")
                    {
                        MessageBox.Show("Good");
                    }
                    else 
                    { 
                        MessageBox.Show("We don't see this color");
                        Application.Current.Shutdown();
                    }
                }
            }
            EndGame();
        }

        private void EndGame()
        {
            myGrid.Children.Clear();
            Label labelEnd = new Label
            {
                Content = "Congratulations, you are the chosen one.",
                FontSize = 30
            };
            labelEnd.VerticalAlignment = VerticalAlignment.Center;
            labelEnd.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.Children.Add(labelEnd);
        }
    }
}
