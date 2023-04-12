<?php
require('config.php');
session_start();

$email = $_POST['email'];

$conn = new mysqli('localhost', 'root', '', 'studonote');

$stmt = $conn->prepare("UPDATE etudiant SET email = '$email' WHERE identifiant = '$_SESSION[identifiant]'");
$stmt->execute();
echo "mise à jour effectuée";
$stmt->close();
$conn->close();
?>