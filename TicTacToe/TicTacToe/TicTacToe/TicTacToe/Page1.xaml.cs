using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TicTacToe
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        Button[] buttons;
        int[,] tab;
        int counter;
        bool O_PlayerTurn = true;
        

        public Page1()
        {
            InitializeComponent();

            labInfo.Text = MainPage.pl1 + "-O starts. Lets go!";
            buttons = new Button[9];
            tab = new int[3, 3];
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i] = (Button)FindByName("btn" + (i + 1).ToString());
               
                buttons[i].Clicked += btn_Clicked;
            }
        }

            private void clearButtons()
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].Text = "";
                }
            }

            private void disableButtons()
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    if (buttons[i].IsEnabled)
                    {
                        buttons[i].IsEnabled = false;
                    }
                }
            }

            private void enableButtons()
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].IsEnabled = true;
                }
            }

            private void resetTable()
            {
                for (int i = 0; i < tab.GetLength(0); i++)
                {
                    for (int j = 0; j < tab.GetLength(1); j++)
                    {
                        tab[i, j] = 0;
                    }
                }
            }

            private void btnNewGame_Clicked(object sender, EventArgs e)
            {
                clearButtons();
                enableButtons();
                resetTable();
                counter = 0;
                O_PlayerTurn = true;
                labInfo.Text =MainPage.pl1+"-O starts. Lets go!";
            }

            private int checkResult()
            {
                int sum;
                for (int i = 0; i < tab.GetLength(0); i++)
                {
                    sum = 0;
                    for (int j = 0; j < tab.GetLength(1); j++)
                        sum += tab[i, j];

                    if ((sum == 3) || (sum == -3))
                        return sum;


                }
                for (int j = 0; j < tab.GetLength(1); j++)
                {
                    sum = 0;
                    for (int i = 0; i < tab.GetLength(0); i++)

                        sum += tab[i, j];
                    if ((sum == 3) || (sum == -3))

                        return sum;



                }
                sum = tab[0, 0] + tab[1, 1] + tab[2, 2];
                if ((sum == 3) || (sum == -3))

                    return sum;


                sum = tab[2, 0] + tab[1, 1] + tab[0, 2];
                if ((sum == 3) || (sum == -3))

                    return sum;

                return 0;
            }

            private void btn_Clicked(object sender, EventArgs e)
            {
                if (counter < 9)
                {
                    int j, k;
                    for (int i = 0; i < buttons.Length; i++)
                    {
                        if (sender.Equals(buttons[i]))
                        {
                            if (i < 3)
                            {
                                j = 0; k = i;
                            }
                            else if (i < 6)
                            {
                                j = 1;
                                k = i - 3;
                            }
                            else
                            {
                                j = 2; k = i - 6;
                            }

                            if (O_PlayerTurn)
                            {
                                buttons[i].Text = "O";
                                O_PlayerTurn = false;
                                tab[j, k] = -1;


                            labInfo.Text = MainPage.pl2 + "-X your turn";
                        }
                            else
                            {
                                buttons[i].Text = "X";
                                O_PlayerTurn = true;
                                tab[j, k] = 1;

                            labInfo.Text = MainPage.pl1 + "-O your turn";
                        }
                            counter++;
                            buttons[i].IsEnabled = false;

                            int result = checkResult();
                            if (result == 3)
                            {
                                labInfo.Text = MainPage.pl2 + " you has won!";
                                disableButtons();
                                return;
                            }

                            else if (result == -3)
                            {
                                labInfo.Text = MainPage.pl1 + " you has won!";
                                disableButtons();
                                return;
                            }
                        if (counter == 9)

                            
                                labInfo.Text = "game over-no winners";
                            return;

                        }
                    }
                }
            }

        }
    }