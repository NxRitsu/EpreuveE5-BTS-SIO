<?php
//On se connecte à MySQL
$bdd = new PDO(
    'mysql:host=localhost;dbname=studonote;charset=utf8',
    'root',
);

// Début de la session
session_start();
// Si l'utilisateur est connecté : OK, sinon redirigez-le vers la page de connexion
if (!isset($_SESSION["identifiant"])) {
    header("Location: login.php");
    exit();
}


$username = $_SESSION["identifiant"];
$resultat = $bdd->query("SELECT * FROM etudiant WHERE identifiant='$username'");

?>


<!doctype html>
<html lang="fr">

<head>
    <meta charset="utf-8">
    <title>Accueil - Studonote</title>
    <link rel="icon" type="image/x-icon" href="Images/iconeStudonote.ico">
    <link rel="stylesheet" href="CSS\index.css">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">

    <!--Bootstrap css-->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">

    <!--Icon Bootstrap/Fontawesome-->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.8.2/font/bootstrap-icons.css">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css" rel="stylesheet" />

    <!--Script bootstrap-->
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>

    <!--Script Lax (Scrolling effect TEXTE)-->
    <script src="https://cdn.jsdelivr.net/npm/lax.js"></script>

    <!--Script WOW (Scrolling effect IMAGE par exemple)-->
    <script src="JS/wow.js"></script>
    <script>
        new WOW().init();
    </script>

    <!--CSS Animated-->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/4.1.1/animate.min.css">

</head>

<body>
    <!--Navbar 2.0-->
    <div class="container-fluid p-0 sticky-top">
        <nav class="menu navbar navbar-expand-md">
            <a class="navbar-brand" href="index.php">
                <img src="Images/LogoBlancTransp.png" alt="Logo StudoNote" id="logo" class="d-inline-block">
            </a>
            <button class="menuMob navbar-toggler bg-light" type="button" data-bs-toggle="collapse" data-bs-target="#toggleMobileMenu" aria-controls="toggleMobileMenu" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="toggleMobileMenu">

                <ul class="navbar-nav ms-auto text-center">

                    <li>
                        <a class="nav-link text-white accueil-nav onglet" href="index.php">Accueil</a>
                    </li>

                    <li>
                        <a class="nav-link text-white onglet absences-nav" href="absences.php">Absences</a>
                    </li>
                    <li>
                        <a class="nav-link text-white onglet notes-nav" href="notes.php">Notes</a>
                    </li>
                    <li>
                        <a class="nav-link text-white onglet moncompte-nav" href="moncompte.php">Mon compte</a>
                    </li>
                </ul>
            </div>
        </nav>
    </div>

    <div class="container-fluid pt-3 pb-3">
        <div class="row">
            <!--1ère carte -->
            <div class="col-md-4 col-sm-6">
                <div class="card-all mb-4 mt-4 shadow-lg text-center animate__animated animate__fadeInLeft animate__fast">
                    <img class="card-img-top" src="Images/IndexFix.png" alt="Admin PNG" class="w-100 hover-shadow">
                    <div class="card-body">
                        <p class="card-text text-center textAdmin">En cas de problème, contactez :
                            <a href="mailto:studonote@gmail.com">studonote@gmail.com</a>
                        </p>
                    </div>
                </div>
            </div>
            <!--2ème carte -->
            <div class="col-md-4 col-sm-6">
                <div class="card-all mb-4 mt-4 shadow-lg text-center animate__animated animate__fadeIn">
                    <img class="card-img-top" src="Images/Index.png" alt="Student PNG">
                    <div class="card-body">
                        <?php
                        while ($prenom = $resultat->fetch(PDO::FETCH_OBJ)) {
                        ?>
                            <p class="card-text text-center textWelcome">Bienvenue <?= $prenom->prenom ?> !</p>
                        <?php
                        }
                        ?>

                    </div>
                </div>
            </div>
            <!--3ème carte -->
            <div class="col-md-4 col-sm-6">
                <div class="card-all mb-4 mt-4 shadow-lg text-center animate__animated animate__fadeInRight animate__fast">
                    <img class="card-img-top" src="Images/indexDisconnect.png" alt="Disconnect PNG">
                    <div class="card-body">
                        <a href="logout.php" style="color: white;" class="btn btnDisconnect btn-secondary">Déconnexion</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        window.onload = function() {
            Particles.init({
                selector: '.background',
                connectParticles: false,
                color: '#FFCD39',
                maxParticles: 50,
                sizeVariations: 8,
                speed: 1.5,
            });
        };
    </script>
    <canvas class="background"></canvas>
    <script src="JS/particles.min.js"></script>
</body>

</html>