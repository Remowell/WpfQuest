using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
    /// 

    public enum Levels
    {
        Level1,
        Level2,
        Level3,
        Level4,
        Level5,
        Level6
    }

    public partial class MainWindow : Window
    {
        public class Images
        {
            public string ImagePath { get; set; }
            public string Letter { get; set; }
        }

        public int levelNow;
        public int time;
        public int counter = 0;
        public DispatcherTimer Timer;
        public int endurance;
        public int endurChar;
        public int indentation;
        public int score = 0;

        SoundPlayer sp = new SoundPlayer();

        public MainWindow()
        {
            MessageBox.Show("You have only one attempt to answer at ANY level. Good luck");
            InitializeComponent();
            CreateLevelOne();
        }

        private void CreateLevelOne()
        {
            myGrid.Children.Clear();

            levelNow = 1;
            Skip();
            Label labelLvl1 = new Label
            {
                Content = "Level 1",
                FontSize = 20,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            myGrid.Children.Add(labelLvl1);

            Button buttonLvl1 = new Button
            {
                Content = "(?__?)",
                FontSize = 30,
                Margin = new Thickness(196, 157, 196, 157)
            };
            buttonLvl1.Click += ButtonLvl1_Click;
            myGrid.Children.Add(buttonLvl1);

            ForTimer();
        }

        private void ForTimer()
        {
            time = 11;
            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Tick += Timer_TickLvl1;
            Timer.Start();

            Label labelTime = new Label
            {
                Name = "labelTime",
                FontSize = 30,
                VerticalAlignment = VerticalAlignment.Bottom
            };
            myGrid.Children.Add(labelTime);
        }

        private void Timer_TickLvl1(object sender, EventArgs e)
        {
            foreach (var item in myGrid.Children)
            {
                if (item is Label label)
                {
                    if (label.Name is "labelTime")
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
                }
            }
        }

        private void ButtonLvl1_Click(object sender, RoutedEventArgs e)
        {
            counter++;
            if(counter == 15)
            {
                counter = 0;
                Timer.Stop();
                MessageBox.Show("Next level");
                CreateLevelTwo();
            }
        }

        private void CreateLevelTwo()
        {
            myGrid.Children.Clear();

            levelNow = 2;
            Skip();
            Back();
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
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left
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

            levelNow = 3;
            Skip();
            Back();
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
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            myGrid.Children.Add(labelHelp2);

            CreateComboBox();

            Button buttonLvl3 = new Button
            {
                Content = "Enter your answer",
                FontSize = 20,
                VerticalAlignment = VerticalAlignment.Bottom
            };
            buttonLvl3.Click += ButtonLvl3_Click;
            myGrid.Children.Add(buttonLvl3);
        }

        private void CreateComboBox()
        {
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

            levelNow = 4;
            Skip();
            Back();
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
                Margin = new Thickness(0, 220, 0, 0)
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
                HorizontalAlignment = HorizontalAlignment.Left
            };
            stackPanelChar.Children.Add(radioButtonWarrior);

            RadioButton radioButtonMag = new RadioButton
            {
                Content = "Mage",
                FontSize = 15,
                HorizontalAlignment = HorizontalAlignment.Left
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
                HorizontalAlignment = HorizontalAlignment.Left
            };
            stackPanelItems.Children.Add(keyBox);

            CheckBox boneBox = new CheckBox
            {
                Content = "Dragon bones",
                FontSize = 15,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            stackPanelItems.Children.Add(boneBox);

            CheckBox mapBox = new CheckBox
            {
                Content = "Strange map",
                FontSize = 15,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            stackPanelItems.Children.Add(mapBox);

            CheckBox run = new CheckBox
            {
                Content = "Magic rune",
                FontSize = 15,
                HorizontalAlignment = HorizontalAlignment.Left
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
                endurChar = 0;
                MessageBox.Show("You defeated the ghost, found a way out of the dungeon and opened it. Next level");
                CreateLevelFive();
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

        private void CreateLevelFive()
        {
            myGrid.Children.Clear();

            levelNow = 5;
            Skip();
            Back();
            Label labelLvl5 = new Label
            {
                Content = "Level 5",
                FontSize = 20,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            myGrid.Children.Add(labelLvl5);

            CreateListBox();
            CreateListView();
            StopMusic();

            Button choseAnsButt = new Button
            {
                Content = "Choose answer",
                FontSize = 20,
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Right
            };
            choseAnsButt.Click += ChoseAnsButt_Click;
            myGrid.Children.Add(choseAnsButt);
        }

        private void CreateListBox()
        {
            int numOfButton = 1;
            string flag = "Bers";
            ListBox listBox = new ListBox
            {
                Width = 400,
                Margin = new Thickness(0, 60, 0, 40),
                HorizontalAlignment = HorizontalAlignment.Left
            };
            myGrid.Children.Add(listBox);

            CreatePlayButton(listBox, numOfButton, flag);

            numOfButton++;
            flag = "Clint";
            CreatePlayButton(listBox, numOfButton, flag);

            numOfButton++;
            flag = "Knight";
            CreatePlayButton(listBox, numOfButton, flag);
        }

        private void CreatePlayButton(ListBox listBox, int num, string flag)
        {
            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;

            Label labelClB = new Label
            {
                Content = num,
                FontSize = 20
            };
            stackPanel.Children.Add(labelClB);

            Button play = new Button
            {
                Height = 50,
                Width = 50,
                Content = "Play"
            };
            stackPanel.Children.Add(play);
            listBox.Items.Add(stackPanel);

            switch (flag)
            {
                case "Bers":
                    play.Click += PlayBers_Click;
                    break;
                case "Clint":
                    play.Click += PlayClint_Click;
                    break;
                case "Knight":
                    play.Click += PlayKnight_Click;
                    break;
                default:
                    break;
            }
        }

        private void PlayClint_Click(object sender, RoutedEventArgs e)
        {
            sp.Stop();
            sp.Stream = Properties.Resources.Ennio_Morricone___A_Fistful_Of_Dollars;
            sp.Play();
        }

        private void PlayBers_Click(object sender, RoutedEventArgs e)
        {
            sp.Stop();
            sp.Stream = Properties.Resources.Susumu_Hirasawa___Forces;
            sp.Play();
        }

        private void PlayKnight_Click(object sender, RoutedEventArgs e)
        {
            sp.Stop();
            sp.Stream = Properties.Resources.KOTOR___The_Sith;
            sp.Play();
        }

        private void CreateListView()
        {
            var factory = new FrameworkElementFactory(typeof(Image));
            factory.SetValue(Image.SourceProperty, new Binding(nameof(Images.ImagePath)));
            factory.SetValue(Image.WidthProperty, 250.0);
            factory.SetValue(Image.HeightProperty, 100.0);
            var dataTemplate = new DataTemplate { VisualTree = factory };

            ListView listView = new ListView
            {
                Width = 400,
                Margin = new Thickness(0, 60, 0, 40),
                HorizontalAlignment = HorizontalAlignment.Right
            };
            myGrid.Children.Add(listView);

            GridView gridView = new GridView();
            listView.View = gridView;

            gridView.Columns.Add(new GridViewColumn { Header = "Image", CellTemplate = dataTemplate });
            gridView.Columns.Add(new GridViewColumn { Header = "Letter", DisplayMemberBinding = new Binding(nameof(Images.Letter)), Width = 150 });

            var ImageList = new List<Images>
            {
                new Images { ImagePath = "A Fistful Of Dollars.jpeg", Letter = "A" },
                new Images { ImagePath = "OLd Republic.png", Letter = "B"},
                new Images { ImagePath = "Berserk.jpg", Letter = "C" }
            };
            listView.ItemsSource = ImageList;
        }

        private void StopMusic()
        {
            Button stopMus = new Button
            {
                Content = "Stop music",
                FontSize = 20,
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            stopMus.Click += StopMus_Click;
            myGrid.Children.Add(stopMus);
        }

        private void StopMus_Click(object sender, RoutedEventArgs e)
        {
            sp.Stop();
        }

        private void ChoseAnsButt_Click(object sender, RoutedEventArgs e)
        {
            sp.Stop();
            CreateNextStepLvl5();
        }

        private void CreateNextStepLvl5()
        {
            myGrid.Children.Clear();

            GroupBox groupBoxAns = new GroupBox
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Header = "Answers"
            };
            myGrid.Children.Add(groupBoxAns);

            Button buttonCheck = new Button
            {
                Content = "Check",
                FontSize = 20,
                VerticalAlignment = VerticalAlignment.Bottom
            };
            buttonCheck.Click += ButtonCheck_Click;
            myGrid.Children.Add(buttonCheck);

            CreateRadButAns(groupBoxAns);
        }

        private void CreateRadButAns(GroupBox groupBoxAns)
        {
            StackPanel panelAns = new StackPanel();

            RadioButton radButTrue = new RadioButton
            {
                Content = "1C 2A 3B",
                FontSize = 20
            };
            panelAns.Children.Add(radButTrue);

            RadioButton radButNotTrue = new RadioButton
            {
                Content = "1B 2C 3A",
                FontSize = 20
            };
            panelAns.Children.Add(radButNotTrue);

            RadioButton radButFalse = new RadioButton
            {
                Content = "1A 2C 3B",
                FontSize = 20
            };
            panelAns.Children.Add(radButFalse);

            groupBoxAns.Content = panelAns;
        }

        private void ButtonCheck_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in myGrid.Children)
            {
                if (item is GroupBox box)
                {
                    StackWithAnswers(box);
                }
            }
            CreateLevelSix();
        }

        private void StackWithAnswers(GroupBox box)
        {
            if (box.Content is StackPanel panel)
            {
                foreach (var element in panel.Children)
                {
                    if (element is RadioButton button)
                    {
                        IfItIsTrue(button);
                    }
                }
            }
        }

        private void IfItIsTrue(RadioButton trueButton)
        {
            if (trueButton.Content is "1C 2A 3B")
            {
                switch (trueButton.IsChecked)
                {
                    case true:
                        MessageBox.Show("Well, you know enough to join the fraternity. Continue");
                        break;
                    case false:
                        MessageBox.Show("This is a classic. You need to know this");
                        Application.Current.Shutdown();
                        break;
                    default:
                        break;
                }
            }
        }

        private void CreateLevelSix()
        {
            myGrid.Children.Clear();

            levelNow = 6;
            Skip();
            Back();
            Label labelLvl6 = new Label
            {
                Content = "Level 6",
                FontSize = 20,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            myGrid.Children.Add(labelLvl6);

            CreateContextmenu();
        }

        private void CreateContextmenu()
        {
            ContextMenu contextMenu = new ContextMenu();
            Label labelLvl6 = new Label
            {
                Margin = new Thickness(0, 70, 0, 0),
                Content = "Use your mouse \nand select the movie \nthat help you.",
                FontSize = 50,
                HorizontalContentAlignment = HorizontalAlignment.Center
            };
            labelLvl6.ContextMenu = contextMenu;

            ContextItem(contextMenu);

            myGrid.Children.Add(labelLvl6);
        }

        private void ContextItem(ContextMenu contextMenu)
        {
            MenuItem groundhogItem = new MenuItem
            {
                Name = "Groundhog",
                Header = "Groundhog Day"
            };
            groundhogItem.Click += Groundhog_Click;
            contextMenu.Items.Add(groundhogItem);

            MenuItem legendItem = new MenuItem
            {
                Name = "Legend",
                Header = "I Am Legend"
            };
            legendItem.Click += Legend_Click;
            contextMenu.Items.Add(legendItem);

            MenuItem galaxyItem = new MenuItem
            {
                Name = "Galaxy",
                Header = "The Hitchhiker's Guide to the Galaxy"
            };
            galaxyItem.Click += Galaxy_Click;
            contextMenu.Items.Add(galaxyItem);
        }

        private void Groundhog_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Time travel is a good thing");
            Levels lvl = (Levels)(new Random().Next(0, 5));
            switch (lvl)
            {
                case Levels.Level1: CreateLevelOne();
                    break;
                case Levels.Level2: CreateLevelTwo();
                    break;
                case Levels.Level3: CreateLevelThree();
                    break;
                case Levels.Level4: CreateLevelFour();
                    break;
                case Levels.Level5: CreateLevelFive();
                    break;
                case Levels.Level6: CreateLevelSix();
                    break;
                default:
                    break;
            }
        }

        private void Galaxy_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("On the first try. Very well.");
            CreateLevelSeven();
        }

        private void Legend_Click(object sender, RoutedEventArgs e)
        {
            myGrid.Children.Clear();
            CreateMiniGame();
        }

        private void CreateMiniGame()
        {
            TextBlock blockScore = new TextBlock
            {
                Text = "Your score: " + score.ToString(),
                FontSize = 20,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top
            };
            myGrid.Children.Add(blockScore);

            Label labelTimeTwo = new Label
            {
                Name = "labelTimeTwo",
                FontSize = 30,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Bottom
            };
            myGrid.Children.Add(labelTimeTwo);

            CreateButtons();
            ForClock();
        }

        private void CreateButtons()
        {
            for (int i = 0; i < 10; i++)
            {
                Button buttonSurv = new Button
                {
                    Height = 5,
                    Width = 5,
                    Margin = new Thickness(5, 5, indentation, 5),
                    ClickMode = ClickMode.Press
                };
                indentation += 10;
                buttonSurv.Click += ButtonSurv_Click;

                myGrid.Children.Add(buttonSurv);
            }
        }

        private void ButtonSurv_Click(object sender, RoutedEventArgs e)
        {
            score += 100;
            foreach (var item in myGrid.Children)
            {
                if (item is TextBlock textBlock)
                {
                    textBlock.Text = "Your score: " + score;
                }
                else if (item is Button button)
                {
                    if (button.IsPressed == true)
                    {
                        myGrid.Children.Remove(button);
                        break;
                    }
                }
            }

            if (score == 1000)
            {
                score = 0;
                indentation = 0;
                Timer.Stop();
                MessageBox.Show("You quickly assessed the situation and quickly made a decision. You survived.");
                CreateLevelSeven();
            }
        }

        private void ForClock()
        {
            time = 11;
            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Tick += DoomsdayClock;
            Timer.Start();
        }

        private void DoomsdayClock(object sender, EventArgs e)
        {
            foreach (var item in myGrid.Children)
            {
                if (item is Label label)
                {
                    if (label.Name is "labelTimeTwo")
                    {
                        if (time > 0)
                        {
                            time--;
                            label.Content = string.Format("00:0{0}:0{1}", time / 60, time % 60);
                        }
                        else
                        {
                            Timer.Stop();
                            MessageBox.Show("It's unlikely that you'll survive after the end.");
                            Application.Current.Shutdown();
                        }
                    }
                }
            }

        }

        private void CreateLevelSeven()
        {
            myGrid.Children.Clear();
            Skip();
            Back();
            levelNow = 7;
            Label labelLvl7 = new Label
            {
                Content = "Level 7",
                FontSize = 20,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            myGrid.Children.Add(labelLvl7);

            Label labelHelpLvl7 = new Label
            {
                Content = "The good do nothing, the bad destroy, \nthe neutrals gloat, and the old friend \nwill help get out",
                FontSize = 15,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            myGrid.Children.Add(labelHelpLvl7);

            TreeView trw = new TreeView
            { 
                Margin = new Thickness(0, 70, 0, 0)
            };
            myGrid.Children.Add(trw);

            TreeViewItem trwGood = new TreeViewItem
            {
                Header = "(.❛ ᴗ ❛.)",
                FontSize = 20
            };
            trw.Items.Add(trwGood);

            CreateFirstBranch(trwGood);
            CreateSecondBranch(trwGood);
            CreateThirdBranch(trwGood);
        }

        private void CreateFirstBranch(TreeViewItem treeView)
        {
            Button buttonAngry = new Button
            {
                Content = "୧((#Φ益Φ#))୨",
                FontSize = 20
            };
            buttonAngry.Click += Angry_Click;
            treeView.Items.Add(buttonAngry);

            Button buttonNet = new Button
            {
                Content = "┐(‘～` )┌",
                FontSize = 20
            };
            buttonNet.Click += Groundhog_Click;
            treeView.Items.Add(buttonNet);

            TreeViewItem trwGood = new TreeViewItem
            {
                Header = "(◕‿ ◕)",
                FontSize = 20
            };
            treeView.Items.Add(trwGood);

            CreateSecondBranch(trwGood);
        }

        private void CreateSecondBranch(TreeViewItem treeView)
        {
            TreeViewItem trwGood = new TreeViewItem
            {
                Header = "(´｡• ᵕ •｡`)",
                FontSize = 20
            };
            treeView.Items.Add(trwGood);

            Button buttonAngry = new Button
            {
                Content = "	٩(ఠ益ఠ)۶",
                FontSize = 20
            };
            buttonAngry.Click += Angry_Click;
            treeView.Items.Add(buttonAngry);

            Button buttonAngry2 = new Button
            {
                Content = "(ఠఠ益ఠఠ)",
                FontSize = 20
            };
            buttonAngry.Click += Angry_Click;
            treeView.Items.Add(buttonAngry2);

            Button buttonNet = new Button
            {
                Content = "┐(￣～￣)┌",
                FontSize = 20
            };
            buttonNet.Click += Groundhog_Click;
            treeView.Items.Add(buttonNet);

            CreateThirdBranch(trwGood);
        }

        private void CreateThirdBranch(TreeViewItem treeView)
        {
            Button buttonAngry = new Button
            {
                Content = "↑_(ΦwΦ)Ψ",
                FontSize = 20
            };
            buttonAngry.Click += Angry_Click;
            treeView.Items.Add(buttonAngry);

            Button buttonWho = new Button
            {
                Content = "(?__?)",
                FontSize = 20
            };
            buttonWho.Click += ButtonWho_Click; 
            treeView.Items.Add(buttonWho);

            TreeViewItem trwGood = new TreeViewItem
            {
                Header = "	°˖✧◝(⁰▿⁰)◜✧˖°",
                FontSize = 20
            };
            treeView.Items.Add(trwGood);
        }

        private void ButtonWho_Click(object sender, RoutedEventArgs e)
        {
            CreateLevelEight();
        }

        private void Angry_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Oh this guy looks ang..");
            Application.Current.Shutdown();
        }

        private void CreateLevelEight()
        {
            myGrid.Children.Clear();
            Skip();
            Back();
            levelNow = 8;
            Label labelLvl8 = new Label
            {
                Content = "Level 8",
                FontSize = 20,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            myGrid.Children.Add(labelLvl8);
        }

        private void Skip()
        {
            Button skip = new Button
            {
                Content = "Skip level",
                FontSize = 15,
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Top
            };
            skip.Click += Skip_Click;
            myGrid.Children.Add(skip);
        }

        private void Skip_Click(object sender, RoutedEventArgs e)
        {
            switch (levelNow)
            {
                case 1: CreateLevelTwo();
                    break;
                case 2: CreateLevelThree();
                    break;
                case 3: CreateLevelFour();
                    break;
                case 4: CreateLevelFive();
                    break;
                case 5: CreateLevelSix();
                    break;
                case 6: CreateLevelSeven();
                    break;
                case 7: CreateLevelEight();
                    break;
                case 8: EndGame();
                    break;
                default:
                    break;
            }
        }

        private void Back()
        {
            Button back = new Button
            {
                Content = "Back",
                FontSize = 15,
                Margin = new Thickness(0, 0, 0, 30),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Right
            };
            back.Click += Back_Click;
            myGrid.Children.Add(back);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            switch (levelNow)
            {
                case 2: CreateLevelOne();
                    break;
                case 3: CreateLevelTwo();
                    break;
                case 4: CreateLevelThree();
                    break;
                case 5: CreateLevelFour();
                    break;
                case 6: CreateLevelFive();
                    break;
                case 7: CreateLevelSix();
                    break;
                case 8: CreateLevelSeven();
                    break;
                default:
                    break;
            }
        }

        private void EndGame()
        {
            myGrid.Children.Clear();

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
