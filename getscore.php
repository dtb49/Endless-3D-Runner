<?php
//connect to the database
  include 'mysqli_connect.php';
  
//get the input
  $username = $_REQUEST['username'];
  $password = $_REQUEST['password'];
  $currentscore = $_REQUEST['highscore'];
  
  $u = mysqli_real_escape_string($dbc, trim($username));
 
 //query the database
  $query = "SELECT * FROM conquest_users WHERE email='$u' AND password=SHA1('$password')";
  
  //echo $query;
  //get the results
  $result = mysqli_query($dbc, $query);
  $row = mysqli_fetch_assoc ($result);
  $highscore = $row['highscore'];
  
  if($currentscore > $highscore)
  {
    $update = "UPDATE conquest_users SET highscore='$currentscore' WHERE email='$u' and password=SHA1('$password')";
    $result_update = mysqli_query($dbc, $update);
    //$update_row = mysqli_fetch_assoc($result_update);
    
    //echo $update_row['highscore'];
    
    $query = "SELECT * FROM conquest_users WHERE email='$u' AND password=SHA1('$password')";
    $result = mysqli_query($dbc, $query);
    $row = mysqli_fetch_assoc ($result);
    
    echo $row['highscore'];
  
  }else{
  
  //test the results
    if(mysqli_num_rows($result) == 1)
    {
        echo $highscore;
        //echo $currentscore;
        
    }else
        echo "wrong";
        }
?>
