<?php

    //SET UP connection to db
    $servername = "localhost"; // server link if online
    $username = "root"; //privilages option in PHPMyAdmin
    $password = ""; // no password on root
    $dbname = "ttwbackend";


    // provided by user
    $loginUser = $_POST["loginUser"];
    $loginPass = $_POST["loginPass"];
    $loginCoins = $_POST["loginCoins"];

    // try connnection
    $conn = new mysqli($servername, $username, $password, $dbname); 
    
    //error catching in connection
    if ($conn->connect_error) {
        // die = return or break [stop code running]
        die("Connection Failed" . $conn->connect_error);
    }
    echo"Connected to db.<br>";

    // SERVER COMMANDS to use
    $sql = "SELECT username FROM users WHERE username = '" . $loginUser ."'" ;
    //$sql = "UPDATE users SET `username`='[value-2]',`password`='[value-3]',`coins`='[value-4]' WHERE 1"
    //$sql = "INSERT INTO users() VALUES()";

    // makes a query/request from line 10 $conn using commmands from $sql on line 20
    $result = $conn->query($sql);

    if ($result->num_rows > 0) {
            // found user - wrong password
        echo "Username already exist";
    }
    // if found no users
    else {
        echo "0 results : Registering User";
        
        // NEW SQL command
        $sql = "INSERT INTO users (username, password, coins) VALUES ('" . $loginUser ."', '" . $loginUser ."','" . $loginCoins ."')";

        // CHECK IF SUCCESSFULL on Query
        if($conn->query($sql)==TRUE){
            echo "Created an Account";
        } else {
            echo "Error". $sql ."<br>". $conn->error;
        }
    }
    //close connection - stop
    $conn->close();


?>