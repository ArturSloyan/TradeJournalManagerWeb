<?php
// At the beginning of your pages where you want to check if a user is logged in
session_start();

if (!isset($_SESSION["username"])) {
    // Redirect to login page or show a login form
    header("Location: PHP/signin.php");
    exit();
}
?>