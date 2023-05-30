<!DOCTYPE html>
<html>

<head>
  <meta charset="utf-8">
  <title>Connexion - Studonote</title>
  <link rel="icon" type="image/x-icon" href="Images/iconeStudonote.ico">
  <link rel="stylesheet" href="CSS\login.css" />

  <!--Bootstrap css-->
  <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">

  <!--Script bootstrap-->
  <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
  <script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
  <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>

  <!--Script Lax (Scrolling effect TEXTE)-->
  <script src="https://cdn.jsdelivr.net/npm/lax.js"></script>

  <!--CSS Animated-->
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/4.1.1/animate.min.css">

</head>
<body>
  <?php
  require('config.php'); /*On va cherche le fichier config.php pour se connecter à la base de donnée*/
  session_start();
  if (isset($_POST['identifiant'])) {
    $identifiant = stripslashes($_REQUEST['identifiant']);
    $identifiant = mysqli_real_escape_string($conn, $identifiant);
    $password = stripslashes($_REQUEST['password']);
    $password = mysqli_real_escape_string($conn, $password);
    $query = "SELECT * FROM `etudiant` WHERE identifiant='$identifiant' and password='" . hash('sha1', $password) . "'";
    $result = mysqli_query($conn, $query) or die(mysql_error());
    $rows = mysqli_num_rows($result);

    if ($rows == 1) {
      $_SESSION['identifiant'] = $identifiant;
      header("Location: index.php");
    } else {
      $message = "Le nom d'utilisateur ou le mot de passe est incorrect.";
    }
  }
  ?>
  <section>
    <div class="form-box animate__animated animate__zoomIn animate__fast">
      <div class="form-value">
        <form action="" method="post" name="login">
          <h2>CONNEXION</h2>
          <div class="inputbox">
            <ion-icon name="mail-outline"></ion-icon>
            <input type="text" class="box-input" name="identifiant" required>
            <label for="">Identifiant</label>
          </div>
          <div class="inputbox">
            <ion-icon name="lock-closed-outline"></ion-icon>
            <input type="password" class="box-input" name="password" required>
            <label for="">Password</label>
          </div>
          <input type="submit" value="Se connecter" name="submit" class="buttonText">
        </form>
      </div>
    </div>
  </section>
  <script type="module" src="https://unpkg.com/ionicons@5.5.2/dist/ionicons/ionicons.esm.js"></script>
  <script nomodule src="https://unpkg.com/ionicons@5.5.2/dist/ionicons/ionicons.js"></script>

  <?php if (!empty($message)) { ?>
    <div>
      <?php echo '<script>alert("' . $message . '");</script>'; ?>
    </div>
  <?php } ?>
  </form>
  <script>window.onload = function() {
  Particles.init({
    selector: '.background',
    connectParticles: false,
    color: '#FFCD39',
    maxParticles: 100,
    sizeVariations: 8,
    speed: 1.5,
  });
}; </script>
  <canvas class="background"></canvas>
  <script src="JS/particles.min.js"></script>
</body>

</html>