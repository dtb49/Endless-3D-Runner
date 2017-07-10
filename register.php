<?php
//connect to the database
  include 'mysqli_connect.php';
  
//get the input
if(($_REQUEST['username'] != null) && ($_REQUEST['password'] != null))
{
  $username = $_REQUEST['username'];
  $password = $_REQUEST['password'];
  
  $u = mysqli_real_escape_string($dbc, trim($username));
  $securepass = sha1($password);
  
  $check = "SELECT * FROM conquest_users WHERE email='$u'";
  $check_r = mysqli_query($dbc, $check);
  if(mysqli_num_rows($check_r) == 0)
  {
 //insert into database
  $query = "INSERT INTO conquest_users (email, password, highscore) VALUES ('$u', '$securepass', 0)";
  
  //get the results
  $result = @mysqli_query($dbc, $query) or die('Query failed: '.mysql_error());
  
  echo "registered";
  }else{
    echo "Invalid Email";
  }
  } else {
  
     echo "Invalid access";
  }
?>
