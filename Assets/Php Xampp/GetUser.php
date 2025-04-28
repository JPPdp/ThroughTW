<?php

    //SET UP connection to db
    $servername = "localhost"; // server link if online
    $username = "root"; //privilages option in PHPMyAdmin
    $password = ""; // no password on root

    // which database to access
    $dbname = "ttwbackend"; // the DATABASE NAME

    // try connnection once per initiation
    $conn = new mysqli($servername, $username, $password, $dbname); 
    
    //error catching in connection
    if ($conn->connect_error) {
        // die = return or break [stop code running]
        die("Connection Failed" . $conn->connect_error);
    }

    // if connected successfully to db
    echo"Connected to db.";


    // =============================================================================//
    // IF THERES NO SERVER ERROR - then Functionality below is the prob
    // =============================================================================//
    // select items [username, password, & coins] from users table

    // what to request
    $sql = "SELECT username, password, coins FROM users";

    // makes a query/request from line 12 $conn using commmands from $sql on line 30
    $result = $conn->query($sql);
    // make Result = connection to db using this query(sql commands[Select username password and coins from users table])
    if ($result->num_rows > 0) {
        echo"USERS<br>";
        while ($row = $result->fetch_assoc()) {
            // show username** password** and coins** & new line
            echo "username:" . $row["username"] ." - password: ". $row["password"] . " - coins:". $row["coins"] ."<br>";
        }
    }
    // if found no users
    else {
        echo "0 results";
    }
    //close connection
    $conn->close();
?>