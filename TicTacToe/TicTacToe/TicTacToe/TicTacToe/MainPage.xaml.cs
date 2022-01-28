using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TicTacToe
{
    public partial class MainPage : ContentPage
    {
      static public string pl1, pl2;

    public MainPage()
        {
            InitializeComponent();
           
                NextPage.Clicked += NextPage_Clicked;
            player1.Text = "";
            player2.Text = "";



        }

        private void NextPage_Clicked(object sender, EventArgs e)
        {
            if (player1.Text == "" || player2.Text == "")
            {

                InfoL.Text = "you forgot to enter the names of the players below :)";
            }
            else
            {
                 pl1 = player1.Text;
                 pl2 = player2.Text;
                Navigation.PushAsync(new Page1());
            }
            
            
            }
    }
}
