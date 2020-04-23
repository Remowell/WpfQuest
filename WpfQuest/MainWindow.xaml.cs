using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Media;
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
        public int endurance;
        public int endurChar;

        public MainWindow()
        {
            MessageBox.Show("You have only one attempt to answer at ANY level. Good luck");
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
                MessageBox.Show("Next time.");
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
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Center
            };
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
                FontSize = 20,
                VerticalAlignment = VerticalAlignment.Bottom
            };
            buttonLvl2.Click += ButtonLvl2_Click;
            myGrid.Children.Add(buttonLvl2);

            Label labelHelp = new Label()
            {
                Content = "You should go { level3 }",
                VerticalAlignment = VerticalAlignment.Top
            };
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
                        MessageBox.Show("Bye.");
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
                FontSize = 20,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            myGrid.Children.Add(labelLvl3);

            Label labelHelp2 = new Label()
            {
                Content = "Choose the color you see HERE",
                VerticalAlignment = VerticalAlignment.Top
            };
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
                FontSize = 20,
                VerticalAlignment = VerticalAlignment.Bottom
            };
            buttonLvl3.Click += ButtonLvl3_Click;
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
                        MessageBox.Show("We don't see this color.");
                        Application.Current.Shutdown();
                    }
                }
            }
            CreateLevelFour();
        }

        private void CreateLevelFour()
        {
            myGrid.Children.Clear();

            Label labelLvl4 = new Label
            {
                FontSize = 20,
                HorizontalAlignment = HorizontalAlignment.Center,
                Content = "Level 4"
            };
            myGrid.Children.Add(labelLvl4);

            GroupBoxChar();
            GroupBoxItems();

            Button buttonDung = new Button
            {
                Content = "Dungeon is waiting",
                FontSize = 20,
                Margin = new Thickness(0, 200, 0, 0)
            };
            buttonDung.Click += ButtonDung_Click;
            myGrid.Children.Add(buttonDung);
        }

        private void GroupBoxChar()
        {
            GroupBox groupBoxChar = new GroupBox
            {
                Margin = new Thickness(0, 50, 0, 0)
            };
            groupBoxChar.Header = "Character";
            StackPanel stackPanelChar = new StackPanel();

            RadioButton radioButtonWarrior = new RadioButton
            {
                Content = "Warrior",
                FontSize = 15,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            stackPanelChar.Children.Add(radioButtonWarrior);

            RadioButton radioButtonMag = new RadioButton
            {
                Content = "Mage",
                FontSize = 15,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            stackPanelChar.Children.Add(radioButtonMag);

            groupBoxChar.Content = stackPanelChar;
            myGrid.Children.Add(groupBoxChar);
        }

        private void GroupBoxItems()
        {
            GroupBox groupBoxItems = new GroupBox
            {
                Margin = new Thickness(0, 110, 0, 0)
            };
            groupBoxItems.Header = "Items";

            StackPanel stackPanelItems = new StackPanel();

            CheckBox keyBox = new CheckBox
            {
                Content = "Old key",
                FontSize = 15,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            stackPanelItems.Children.Add(keyBox);

            CheckBox boneBox = new CheckBox
            {
                Content = "Dragon bones",
                FontSize = 15,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            stackPanelItems.Children.Add(boneBox);

            CheckBox mapBox = new CheckBox
            {
                Content = "Strange map",
                FontSize = 15,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            stackPanelItems.Children.Add(mapBox);

            CheckBox run = new CheckBox
            {
                Content = "Magic rune",
                FontSize = 15,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            stackPanelItems.Children.Add(run);
           
            groupBoxItems.Content = stackPanelItems;
            myGrid.Children.Add(groupBoxItems);
        }

        private void ButtonDung_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in myGrid.Children)
            {
                if (item is GroupBox box)
                {
                    FindStackPan(box);
                }
            }
            if (endurChar > endurance) 
            {
                MessageBox.Show("You are very slow .. Therefore you are dead");
                Application.Current.Shutdown(); 
            }
            else 
            { 
                MessageBox.Show("You defeated the ghost, found a way out of the dungeon and opened it. Next level");
                EndGame();
            }
        }

        private void FindStackPan(GroupBox groupBox)
        {
            if (groupBox.Content is StackPanel stackPanel)
            {
                WhatInStackPan(stackPanel);
            }
        }

        private void WhatInStackPan(StackPanel stackPanel)
        {
            foreach (var element in stackPanel.Children)
            {
                if (element is RadioButton radioButton)
                {
                    MagOrWar(radioButton);
                }
                else if (element is CheckBox checkBox)
                {
                    WhatItem(checkBox);
                }
            }
        }

        private void MagOrWar(RadioButton radioButton)
        {
            if (radioButton.Content is "Mage")
            {
                if (radioButton.IsChecked is true)
                {
                    endurance = 50;
                    MessageBox.Show("Powerful spells, but remember it's not a pack horse.");
                }
            }
            else if (radioButton.Content is "Warrior")
            {
                if (radioButton.IsChecked is true)
                {
                    endurance = 75;
                    MessageBox.Show("Strong body and battle ax. It is unlikely to be saved from magic ...");
                }
            }
            else { MessageBox.Show("We need a hero"); }
        }

        private void WhatItem(CheckBox checkBox)
        {
            if (checkBox.Content is "Old key")
            {
                if (checkBox.IsChecked is true)
                {
                    endurChar += 25;
                }
                else
                {
                    MessageBox.Show("You didn't get a key. You couldn't get out of the dungeon. Now this is your tomb.");
                    Application.Current.Shutdown();
                }
            }
            else if (checkBox.Content is "Dragon bones")
            {
                if (checkBox.IsChecked is true)
                {
                    endurChar += 25;
                }
            }
            else if (checkBox.Content is "Strange map")
            {
                if (checkBox.IsChecked is true)
                {
                    endurChar += 25;
                }
                else
                {
                    MessageBox.Show("Where is this damn way out?");
                    Application.Current.Shutdown();
                }
            }
            else
            {
                if (endurance == 75)
                {
                    if (checkBox.IsChecked is true) { endurChar += 25; }
                    else 
                    { 
                        MessageBox.Show("An ancient ghost has smashed you to pieces ... A drop of magic wouldn't hurt");
                        Application.Current.Shutdown();
                    }
                }
                else
                {
                    if (checkBox.IsChecked is true) { endurChar += 25; }
                }
            }
        }

        private void EndGame()
        {
            myGrid.Children.Clear();

            SoundPlayer sp = new SoundPlayer();
            sp.Stream = Properties.Resources.Golden_Wind___Torture_Song_Theme;
            sp.Play();

            Label labelEnd = new Label
            {
                Content = "Congratulations, you are the chosen one.",
                FontSize = 30,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            myGrid.Children.Add(labelEnd);
        }
    }
}
