<!-- Début code PHP -->
<?php
//Connexion classique

$bdd = new PDO(
    'mysql:host=localhost;dbname=studonote;charset=utf8',
    'root',
);

//Début de la session
session_start();

// Si l'utilisateur est connecté : OK, sinon redirigez-le vers la page de connexion
if (!isset($_SESSION["identifiant"])) {
    header("Location: login.php");
    exit();
}

$username = $_SESSION["identifiant"];

// Préparation de la requête pour récupérer l'ID de l'utilisateur
$stmt = $bdd->prepare("SELECT idEtudiant FROM etudiant WHERE identifiant ='$username'");

$stmt->execute();

// Récupération de l'ID de l'utilisateur
$id = $stmt->fetch(PDO::FETCH_ASSOC)["idEtudiant"];

?>
<!DOCTYPE html>
<html lang="fr">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Viescolaire - Studonote</title>

    <link rel="icon" type="image/x-icon" href="Images/iconeStudonote.ico">
    <link rel="stylesheet" href="CSS\absences.css">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">

    <!--Bootstrap css-->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">

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

    <div class="container-fluid">
        <div class="row">
            <div class="w-50">
                <div class="card-all mb-4 mt-4 shadow-lg text-center animate__animated animate__fadeInLeft animate__fast" style="backdrop-filter: blur(15px);">
                    <div class="card-body scrollableAbsences">
                        <div class="absence">
                            <h1 class="card-title">ABSENCES</h1>
                            <?php
                            // Connexion à la base de données
                            $servername = "localhost";
                            $username = "root";
                            $password = "";
                            $dbname = "studonote";

                            $conn = new mysqli($servername, $username, $password, $dbname);

                            // Vérification de la connexion
                            if ($conn->connect_error) {
                                die("Connection failed: " . $conn->connect_error);
                            }

                            $sql = "SELECT motif, date FROM absence WHERE idEtudiant ='$id' ORDER BY date";
                            $result = $conn->query($sql);

                            // Affichage des données dans un tableau HTML
                            echo "<table>";
                            echo "<thead><tr><th>Motif</th><th>Date</th></tr></thead>";
                            echo "<tbody>";
                            while ($row = $result->fetch_assoc()) {
                                echo "<tr><td>" . $row["motif"] . "</td><td>" . $row["date"] . "</td></tr>";
                            }
                            echo "</tbody>";
                            echo "</table>";
                            ?>
                        </div>
                    </div>
                </div>
            </div>
            <div class="w-50">
                <div class="card-all mb-4 mt-4 shadow-lg text-center animate__animated animate__fadeInRight animate__fast">
                    <img class="card-img-top" src="Images/imgAbsence.png" style="width: 65%;" alt="Calendar PNG">
                    <div class="card-body absencesTotal">
                        <?php
                        // Préparation de la requête pour récupérer le nombre d'absences
                        $stmt = $bdd->prepare("SELECT COUNT(*) AS total_absences FROM absence WHERE idEtudiant ='$id'");

                        $stmt->execute();

                        // Récupération du nombre d'absences
                        $idAbsence = $stmt->fetch(PDO::FETCH_ASSOC)["total_absences"];
                        ?>
                        <p class="total-absences">Votre nombre total d'absences : <strong><?php echo $idAbsence; ?></strong> </p>
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