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

namespace Xand0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Game _game;
        private Button[,] _buttons = new Button[0, 0];
  
        public MainWindow()
        {
            InitializeComponent();
            _game = new Game();
            CreateGridElements();
        }

        public void CreateGridElements()
        {

            for (int i = 0; i < _game.GameGrid.Rows; i++)
            {
                this.visualGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            }

            for (int j = 0; j < _game.GameGrid.Cols; j++)
            {
                this.visualGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }


            _buttons = new Button[_game.GameGrid.Rows, _game.GameGrid.Cols];

            for (int i = 0; i < _game.GameGrid.Rows; i++)
            {
                for (int j = 0; j < _game.GameGrid.Cols; j++)
                {
                    var button = new Button();

                    button.SetValue(Grid.RowProperty, i);
                    button.SetValue(Grid.ColumnProperty, j);
                    button.BorderBrush = Brushes.LightGray;
                    this.visualGrid.Children.Add(button);
                  
                    _buttons[i,j] = button;
                    _buttons[i, j].Click += ButtonClick;

                    

                }
            }
        }


        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            int row = 0, col = 0;
            if (_game.Player == 0)
            {
                if (_game.IsGameOver()==true)
                {
                    labelGameOver.Content = "GAME OVER";
                }
                else
                {
                    for (int i = 0; i < _game.GameGrid.Rows; i++)
                    {
                        for (int j = 0; j < _game.GameGrid.Cols; j++)

                        { if (_buttons[i, j] == sender)
                            
                            {
                                if (_buttons[i, j].Content == "" || _buttons[i, j].Content == null)
                                {
                                    _buttons[i, j].Content = "0";
                                    _buttons[i, j].Background = Brushes.LightGreen;

                                    Position poz = new Position(i, j);
                                    _game.Move(poz, _game.Player);
                                    if (_game.IsGameOver() == true)
                                    {
                                        labelGameOver.Content = "GAME OVER";
                                        return; 
                                    }

                                    Random r = new Random();

                                    do
                                    {
                                        row = r.Next(0, 3);
                                        col = r.Next(0, 3);

                                    } while (_buttons[row, col].Content != "" && _buttons[row, col].Content != null);

                                 
                                     _buttons[row, col].Content = "X";
                                    _buttons[row, col].Background = Brushes.LightCoral;
                                    Position poz_x = new Position(row, col);
                                    _game.Move(poz_x, _game.Player);
                                    if (_game.IsGameOver() == true)
                                    {
                                        labelGameOver.Content = "GAME OVER";
                                        return;
                                    }

                                }


                            }

                        }
                    }
                }
            }
            //else
            //    if (_game.Player == 1)
            //{
            //if (_game.IsGameOver() == true)
            //{
            //    labelGameOver.Content = "GAME OVER";
            //}
            //else
            //{
            //    for (int i = 0; i < _game.GameGrid.Rows; i++)
            //    {
            //        for (int j = 0; j < _game.GameGrid.Cols; j++)

            //        {
            //            if (_buttons[i, j] == sender)

            //            {
            //                if (_buttons[i, j].Content == "" || _buttons[i, j].Content == null)
            //                {
            //                      _buttons[row, col].Content = "X";
            //                    _buttons[row, col].Background = Brushes.LightCoral;

            //                    Position poz = new Position(i, j);
            //                    _game.Move(poz, _game.Player);
            //                    if (_game.IsGameOver() == true)
            //                    {
            //                        labelGameOver.Content = "GAME OVER";
            //                        return;
            //                    }
            //                  }
            //               }

            //        }
            //    }
            //}
            //}
            //}

        }

        public void Refresh()
        {
            
            for (int i = 0; i < _game.GameGrid.Rows; i++)
                for (int j = 0; j < _game.GameGrid.Cols; j++)
                {
                    _buttons[i, j].BorderBrush = Brushes.DarkGray;
                    _buttons[i, j].Background = Brushes.LightGray;
                    _buttons[i, j].Content ="";
                    _game.Reset();
                    labelGameOver.Content = "";
                    
                }
        }
        private void RefreshClick(object sender, RoutedEventArgs e)
        {
            if(_game.IsGameOver()==true)
                 Refresh();
        }

    }
}
