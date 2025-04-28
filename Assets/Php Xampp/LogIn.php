<?php

    //SET UP connection to db
    $servername = "localhost"; // server link if online
    $username = "root"; //privilages option in PHPMyAdmin
    $password = ""; // no password on root
    $dbname = "ttwbackend";


    // provided by user
    $loginUser = $_POST["loginUser"];
    $loginPass = $_POST["loginPass"];

    // try connnection
    $conn = new mysqli($servername, $username, $password, $dbname); 
    
    //error catching in connection
    if ($conn->connect_error) {
        // die = return or break [stop code running]
        die("Connection Failed" . $conn->connect_error);
    }
    echo"Connected to db.<br>";

    // SERVER COMMANDS to use
    $sql = "SELECT password FROM users WHERE username = '" . $loginUser ."'" ;

    // makes a query/request from line 10 $conn using commmands from $sql on line 20
    $result = $conn->query($sql);

    if ($result->num_rows > 0) {
        echo"USERS<br>";
        while ($row = $result->fetch_assoc()) {

            // check if password from server and device match
            if($row["password"] == $loginPass){
                
                
                echo "Login Successfully";

                // gets user data
                    // player info

                    // player password

                    // player coins

            }
            // found user - wrong password
            else{
                echo "Wrong credentials. - Incorreect Username or Password";
            }
        }
    }
    // if found no users
    else {
        echo "0 results";
    }

    //close connection - stop
    $conn->close();


?>