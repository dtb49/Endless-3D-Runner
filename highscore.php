<?php
//connect to the database
  include 'mysqli_connect.php';
  
  $query = "SELECT `email`, `highscore` FROM `conquest_users` ORDER BY highscore DESC LIMIT 5";
  
  $result = mysqli_query($dbc, $query);
  
  while($row = mysqli_fetch_array($result, MYSQLI_ASSOC))
  {
  echo $row['email']."-".$row['highscore']."-";
  }
?>
