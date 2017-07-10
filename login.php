<?php
//connect to the database
  include 'mysqli_connect.php';
  
//get the input
  $username = $_REQUEST['username'];
  $password = $_REQUEST['password'];
  
  $u = mysqli_real_escape_string($dbc, trim($username));
 
 //query the database
  $query = "SELECT * FROM conquest_users WHERE email='$u' AND password=SHA1('$password')";
  
  //echo $query;
  //get the results
  $result = mysqli_query($dbc, $query);
  
  //test the results
    if(mysqli_num_rows($result) == 1)
        echo "right";
    else
        echo "wrong";
?>
