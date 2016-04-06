<?php
    $servername = "localhost";
    $username = "root";
    $password = "Language2016";
    $dbName = "fyp";

    //Make connection

    $conn = new mysqli($servername, $username, $password, $dbName);

    //Check Connection
    if(!$conn)
    {
        die("Connection failed.". mysqli_connect_error());
    }
    else echo("    Connection success");

    // now we store our sent information from Unity in php variables, we can work with
    $level = $_POST['newLevel'];
    $category = $_POST['newCategory'];
    $time = $_POST['newTime'];
    $score = $_POST['newScore'];
    
    echo "$level" . " | " . "$category" . " | " . "$time" . " | " . "$score";

    // Now we simply add/insert our values into our "highscores" table
    // we first choose the columns and then add our values
    // we don't need to fill in any value into the ID part, as it automatically gets a new value depending on the entries
    $sql = "INSERT INTO tracking (levelname, category, timeplayed, score) VALUES ('$level', '$category', '$time', '$score');";
    
    if ($conn->query($sql) === TRUE) 
    {
        echo "New record created successfully";
    } 
    else {
        echo "Error: " . $sql . "<br>" . $conn->error;
    }

    // we're done now, so we can close the connection
    $conn->close();

?>