using GestionnairePassword.Models;
using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using SQLite;
using System.Collections.ObjectModel;
using GestionnairePassword.Data;

namespace GestionnairePassword.Views;

public partial class Générateur : ContentPage
{
    string[] minuscules = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
    string[] majuscules = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
    string[] caractères = new string[] { "@", "[", "]", "^", "_", "!", "#", "$", "%", "&", "(", ")", "*", "+", "/", "<", ">", "{", "}", "?", "=" };
    string[] chiffres = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

    public static string GeneratedPassword;

    public Générateur()
    {
        InitializeComponent();

        NavigationPage.SetHasBackButton(this, false);
    }

    private async void Liste_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AppShell());
    }

    private void GenPwd_Clicked(object sender, EventArgs e)
	{
        Random rnd = new Random();
        int count = 0;

        //minuscules
        if(MajusculesCheckbox.IsChecked == false && CaractèresCheckbox.IsChecked == false && ChiffresCheckbox.IsChecked == false)
        {
            string password = "";
            while (count < PwdLength.Value)
            {
                password = password + minuscules[rnd.Next(25)];
                count++;
            }
            Password.Text = password;
        }

        //minuscules et majuscules
        if(MajusculesCheckbox.IsChecked == true && CaractèresCheckbox.IsChecked == false && ChiffresCheckbox.IsChecked == false)
        {
            string password = "";
            while (count < PwdLength.Value)
            {
                if(rnd.Next(2) == 0)
                {
                    password = password + minuscules[rnd.Next(25)];
                    count++;
                }else if (rnd.Next(2) == 1)
                {
                    password = password + majuscules[rnd.Next(25)];
                    count++;
                }
            }
            Password.Text = password;
        }

        //Juste les minuscules et caractères
        if(MajusculesCheckbox.IsChecked == false && CaractèresCheckbox.IsChecked == true && ChiffresCheckbox.IsChecked == false)
        {
            string password = "";
            while (count < PwdLength.Value)
            {
                if (rnd.Next(2) == 0)
                {
                    password = password + minuscules[rnd.Next(25)];
                    count++;
                }
                else if (rnd.Next(2) == 1)
                {
                    password = password + caractères[rnd.Next(20)];
                    count++;
                }
            }
            Password.Text = password;
        }

        //minuscules et les chiffres
        if (MajusculesCheckbox.IsChecked == false && CaractèresCheckbox.IsChecked == false && ChiffresCheckbox.IsChecked == true)
        {
            string password = "";
            while (count < PwdLength.Value)
            {
                if (rnd.Next(2) == 0)
                {
                    password = password + minuscules[rnd.Next(25)];
                    count++;
                }
                else if (rnd.Next(2) == 1)
                {
                    password = password + chiffres[rnd.Next(9)];
                    count++;
                }
            }
            Password.Text = password;
        }

        //minuscules, majuscules, et caractères
        if (MajusculesCheckbox.IsChecked == true && CaractèresCheckbox.IsChecked == true && ChiffresCheckbox.IsChecked == false)
        {
            string password = "";
            while (count < PwdLength.Value)
            {
                if (rnd.Next(3) == 0)
                {
                    password = password + minuscules[rnd.Next(25)];
                    count++;
                }
                else if (rnd.Next(3) == 1)
                {
                    password = password + majuscules[rnd.Next(25)];
                    count++;
                }
                else if (rnd.Next(3) == 2)
                {
                    password = password + caractères[rnd.Next(20)];
                    count++;
                }
            }
            Password.Text = password;
        }

        //minuscules, majuscules, et chiffres
        if (MajusculesCheckbox.IsChecked == true && CaractèresCheckbox.IsChecked == false && ChiffresCheckbox.IsChecked == true)
        {
            string password = "";
            while (count < PwdLength.Value)
            {
                if (rnd.Next(3) == 0)
                {
                    password = password + minuscules[rnd.Next(25)];
                    count++;
                }
                else if (rnd.Next(3) == 1)
                {
                    password = password + majuscules[rnd.Next(25)];
                    count++;
                }
                else if (rnd.Next(3) == 2)
                {
                    password = password + chiffres[rnd.Next(9)];
                    count++;
                }
            }
            Password.Text = password;
        }

        //minuscules, caractères, et chiffres
        if (MajusculesCheckbox.IsChecked == false && CaractèresCheckbox.IsChecked == true && ChiffresCheckbox.IsChecked == true)
        {
            string password = "";
            while (count < PwdLength.Value)
            {
                if (rnd.Next(3) == 0)
                {
                    password = password + minuscules[rnd.Next(25)];
                    count++;
                }
                else if (rnd.Next(3) == 1)
                {
                    password = password + caractères[rnd.Next(20)];
                    count++;
                }
                else if (rnd.Next(3) == 2)
                {
                    password = password + chiffres[rnd.Next(9)];
                    count++;
                }
            }
            Password.Text = password;
        }

        //minuscules, caractères, majuscules, et chiffres
        if (MajusculesCheckbox.IsChecked == true && CaractèresCheckbox.IsChecked == true && ChiffresCheckbox.IsChecked == true)
        {
            string password = "";
            while (count < PwdLength.Value)
            {
                if (rnd.Next(4) == 0)
                {
                    password = password + minuscules[rnd.Next(25)];
                    count++;
                }
                else if (rnd.Next(4) == 1)
                {
                    password = password + majuscules[rnd.Next(25)];
                    count++;
                }
                else if (rnd.Next(4) == 2)
                {
                    password = password + caractères[rnd.Next(20)];
                    count++;
                }
                else if (rnd.Next(4) == 3)
                {
                    password = password + chiffres[rnd.Next(9)];
                    count++;
                }
            }
            Password.Text = password;
        }
        GeneratedPassword = Password.Text;
    }

    private void PwdLength_ValueChanging(object sender, ValueChangedEventArgs e)
    {
        TextLength.Text = $"Longueur du mot de passe : {PwdLength.Value}";
    }

}