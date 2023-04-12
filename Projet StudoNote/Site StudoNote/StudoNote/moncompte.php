<!--Début code PHP-->
<?php
//Connexion classique
$bdd = new PDO(
    'mysql:host=localhost;dbname=studonote;charset=utf8',
    'root',
);

//Connexion spécial pour utiliser la commande du bouton "Mise à jour" 
$BDD = array();
$BDD['host'] = "localhost";
$BDD['user'] = "root";
$BDD['pass'] = "";
$BDD['db'] = "studonote";
$mysqli = mysqli_connect($BDD['host'], $BDD['user'], $BDD['pass'], $BDD['db']);
if (!$mysqli) {
    echo "connexion non établie";
    exit;
}

// Début de la session
session_start();
// Si l'utilisateur est connecté : OK, sinon redirigez-le vers la page de connexion
if (!isset($_SESSION["identifiant"])) {
    header("Location: login.php");
    exit();
}

$username = $_SESSION["identifiant"];

//Variables permettant de pré-remplir les input
$prenomSql = $bdd->query("SELECT * FROM etudiant WHERE identifiant='$username'");
$nomSql = $bdd->query("SELECT * FROM etudiant WHERE identifiant='$username'");
$emailSql = $bdd->query("SELECT * FROM etudiant WHERE identifiant='$username'");
$usernameSql = $bdd->query("SELECT * FROM etudiant WHERE identifiant='$username'");

//Permet d'afficher le nom et le prenom de l'étudiant sur la page des paramètres du compte
$nomPrenom1 = $bdd->query("SELECT * FROM etudiant WHERE identifiant='$username'");
$nomPrenom2 = $bdd->query("SELECT * FROM etudiant WHERE identifiant='$username'");
?>
<!--Fin code PHP-->

<!--Début HTML-->
<!DOCTYPE html>
<html lang="fr">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Mon compte - Studonote</title>

    <link rel="icon" type="image/x-icon" href="Images/iconeStudonote.ico">
    <link rel="stylesheet" href="CSS\moncompte.css">

    <!--Bootstrap css-->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">
    <link rel="stylesheet" href="CSS\bootstrap.min.css">

    <!--Icon Bootstrap/Fontawesome-->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.8.2/font/bootstrap-icons.css">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css" rel="stylesheet" />

    <!--Script bootstrap-->
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>

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

    <section class="py-5 my-5 section">
        <div class="container">
            <h1 class="mb-5 animate__animated animate__fadeInRight titre">Paramètre du compte</h1>
            <div class="bg-transparent shadow rounded-lg d-block d-sm-flex animate__animated animate__zoomIn animate__fast box-transparent">
                <div class="profile-tab-nav border-right-red">
                    <div class="p-4">
                        <div class="img-circle text-center mb-3">
                            <img src="Images/studentlogo.png" alt="Image" class="shadow">
                        </div>
                        <h4 class="text-center" style="color: white;">
                            <?php while ($nom = $nomPrenom1->fetch(PDO::FETCH_OBJ)) { ?>
                                <?= $nom->nom ?>
                            <?php }
                            while ($prenom = $nomPrenom2->fetch(PDO::FETCH_OBJ)) { ?>
                                <?= $prenom->prenom ?>
                            <?php } ?>
                        </h4>
                    </div>
                    <div class="nav flex-column nav-pills" id="v-pills-tab" role="tablist" aria-orientation="vertical">
                        <a class="nav-link active" id="account-tab" data-toggle="pill" href="#account" role="tab" aria-controls="account" aria-selected="true">
                            <i class="fa fa-home text-center mr-1"></i>
                            Compte
                        </a>
                        <a class="nav-link" id="password-tab" data-toggle="pill" href="#password" role="tab" aria-controls="password" aria-selected="false">
                            <i class="fa fa-key text-center mr-1"></i>
                            Mot de passe
                        </a>
                        <a class="nav-link" id="username-tab" data-toggle="pill" href="#username" role="tab" aria-controls="username" aria-selected="false">
                            <i class="fa fa-user text-center mr-1"></i>
                            Identifiant
                        </a>
                    </div>
                </div>
                <div class="tab-content p-4 p-md-5" id="v-pills-tabContent">
                    <div class="tab-pane fade show active" id="account" role="tabpanel" aria-labelledby="account-tab">
                        <form action="./moncompte.php" method="post">
                            <h2 class="mb-4 titleInBox">Paramètre du compte</h2>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Prénom</label>
                                        <input type="text" class="form-control" value="<?php while ($prenom = $prenomSql->fetch(PDO::FETCH_OBJ)) { ?><?= $prenom->prenom ?> <?php } ?>" disabled="disabled" name="prenom">
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Nom</label>
                                        <input type="text" class="form-control" value="<?php while ($nom = $nomSql->fetch(PDO::FETCH_OBJ)) { ?><?= $nom->nom ?> <?php } ?>" disabled="disabled" name="nom">
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Email</label>
                                        <input type="email" class="form-control" value="<?php while ($email = $emailSql->fetch(PDO::FETCH_OBJ)) { ?><?= $email->email ?><?php } ?>" name="email" required>
                                    </div>
                                </div>
                            </div>
                            <div>
                                <input type="submit" class="btn btn-secondary" name="majCompte" value="Mettre à jour">
                                <button class="btn btn-light">Annuler</button>
                                <?php
                                //Commande pour actualiser l'email
                                if (isset($_POST['majCompte'])) {
                                    if (!mysqli_query($mysqli, "UPDATE etudiant SET email = '" . $_POST['email'] . "' WHERE identifiant = '$username'")) {
                                        echo "Une erreur s'est produite";
                                    } else {
                                        echo "Mise à jour effectuée";
                                    }
                                }


                                ?>
                            </div>
                        </form>
                    </div>
                    <div class="tab-pane fade" id="password" role="tabpanel" aria-labelledby="password-tab">
                        <form action="./moncompte.php" method="post">
                            <h2 class="mb-4 titleInBox">Paramètre mot de passe</h2>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Ancien mot de passe</label>
                                        <input type="password" name="oldPwd" class="form-control">
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Nouveau mot de passe</label>
                                        <input type="password" name="newPwd" class="form-control">
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Confirmer le nouveau mot de passe</label>
                                        <input type="password" name="confPwd" class="form-control">
                                    </div>
                                </div>
                            </div>
                            <div>
                                <input type="submit" class="btn btn-secondary" name="majPassword" value="Mettre à jour">
                                <button class="btn btn-light">Annuler</button>
                                <?php
                                //Commande pour actualiser le mot de passe
                                if (isset($_POST['majPassword'])) {
                                    $oldPwd = hash('sha1', $_POST['oldPwd']);
                                    $newPwd = $_POST['newPwd'];
                                    $confPwd = $_POST['confPwd'];

                                    if (!mysqli_query($mysqli, "SELECT password FROM etudiant WHERE identifiant = '$username'") == $_POST['oldPwd']) {
                                        echo "L'ancien mot de passe n'est pas le bon";
                                    } else {
                                        if ($_POST['newPwd'] == $_POST['confPwd']) {
                                            if (!mysqli_query($mysqli, "UPDATE etudiant SET password = '" . hash('sha1', $_POST['newPwd']) . "' WHERE identifiant = '$username'")) {
                                                echo "Les mots de passes ne correspondent pas";
                                            } else {
                                                echo "Mise à jour effectuée";
                                            }
                                        }
                                    }
                                }

                                ?>
                            </div>
                        </form>
                    </div>
                    <div class="tab-pane fade" id="username" role="tabpanel" aria-labelledby="username-tab">
                        <form action="./moncompte.php" method="post">
                            <h2 class="mb-4 titleInBox">Paramètre d'identifiant</h2>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Nouvel identifiant</label>
                                        <input type="text" name="newUsername" class="form-control">
                                    </div>
                                </div>
                            </div>
                            <div>
                                <input type="submit" class="btn btn-secondary" name="majUsername" value="Mettre à jour">
                                <button class="btn btn-light">Annuler</button>
                                <?php
                                //Commande pour actualiser le mot de passe
                                if (isset($_POST['majUsername'])) {
                                    if (!mysqli_query($mysqli, "UPDATE etudiant SET identifiant = '" . $_POST['newUsername'] . "' WHERE identifiant = '$username'")) {
                                        echo "Une erreur est survenue";
                                    } else {
                                        echo "Mise à jour effectuée";
                                    }
                                }

                                ?>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
        </div>
    </section>
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
<!--Fin code HTML-->