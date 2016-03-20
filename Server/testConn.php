<?php

$servername = "localhost";
$username = "root";
$password = "Language2016";
$dbName = "bootstrap";

//Make connection

$conn = new mysqli($servername, $username, $password, $dbName);

//Check Connection
if(!$conn)
{
	die("Connection failed.". mysqli_connect_errpr());
}
else echo("Connection success");

echo "<br>";

$sql = "SELECT timeplayed, category FROM tracking ORDER BY category";
$result = mysqli_query($conn, $sql);

if (mysqli_num_rows($result) > 0)
{
	while($row = mysqli_fetch_assoc($result))
	{
		echo " Time Played: " .$row['timeplayed'] . " in Category: " .$row['category'] . " ;<br>";
	}
}

?>