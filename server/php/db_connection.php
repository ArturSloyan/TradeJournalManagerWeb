<?php
require_once('server/db_credentials');

try {
  $conn = new PDO('mysql:host='$global_DB_SERVER';dbname='$global_DB_NAME,$global_DB_USER,$global_DB_PASS);
  // set the PDO error mode to exception
  $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
  echo "Connected successfully";
} catch(PDOException $e) {
  echo "Connection failed: " . $e->getMessage();
}
?>