using GestionnairePassword.Data;
using GestionnairePassword.Models;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Maui.Controls;
using Microsoft.Maui;
using GestionnairePassword.Views;
using System.Security.Cryptography;

namespace GestionnairePassword
{
    class Login
    {
        public string motDePasseEnregistre;

        public string ChargerMotDePasse()
        {
            // Charger le mot de passe enregistré depuis le stockage sécurisé
            string motDePasseHash = null;

            // Utiliser SecureStorage pour charger le mot de passe depuis le stockage sécurisé
            try
            {
                motDePasseHash = SecureStorage.GetAsync("MotDePasseHash").Result;
            }
            catch (Exception ex)
            {
                // Gérer les exceptions éventuelles lors de l'accès au stockage sécurisé
                Console.WriteLine($"Erreur lors du chargement du mot de passe : {ex.Message}");
            }

            return motDePasseHash;
        }

        public void EnregistrerMotDePasse(string motDePasse)
        {
            // Hacher le mot de passe
            string motDePasseHash = HashMotDePasse(motDePasse);

            // Enregistrer le mot de passe haché dans le stockage sécurisé
            SecureStorage.SetAsync("MotDePasseHash", motDePasseHash);
        }

        public string HashMotDePasse(string motDePasse)
        {
            // Hacher le mot de passe en utilisant un algorithme de hachage sécurisé, comme SHA256
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(motDePasse);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        public void Inscription(string motDePasseSaisi)
        {
            // Récupérer le mot de passe saisi par l'utilisateur
            string motDePasse = motDePasseSaisi;

            // Enregistrer le mot de passe haché dans le stockage sécurisé
            EnregistrerMotDePasse(motDePasse);

            // Afficher un message de succès
            //DisplayAlert("Succès", "Mot de passe enregistré avec succès", "OK");
        }

        public bool Connexion(string motDePasseSaisi)
        {
            // On récupère le mot de passe saisi par l'utilisateur
            string motDePasse = motDePasseSaisi;

            // On charge le mot de passe enregistré depuis le stockage sécurisé
            string motDePasseEnregistre = ChargerMotDePasse();

            // On hash le mot de passe saisi pour le comparer avec celui enregistré
            string motDePasseHash = HashMotDePasse(motDePasse);
            // Vérifier si les mots de passe hachés correspondent

            if (motDePasseEnregistre == motDePasseHash)
            {
                // Afficher un message de connexion réussie
                /*await DisplayAlert("Succès", "Connexion réussie", "OK");
                Form.IsVisible = false;
                Liste.IsVisible = true;
                AddButton.IsVisible = true;
                Logo.IsVisible = false;
                Shell.SetTabBarIsVisible(this, true);*/ // Affiche la TabBar dans la page Générateur
                return true;
            }
            else
            {
                // Afficher un message d'échec de connexion
                //await DisplayAlert("Erreur", "Mot de passe incorrect", "OK");
                return false;
            }
        }

        public void SupprimerMotDePasse()
        {
            // Utiliser SecureStorage pour supprimer la clé du mot de passe depuis le stockage sécurisé
            SecureStorage.Remove("MotDePasseHash");
        }
    }
}
