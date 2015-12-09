<?php
	$con=mysqli_connect("mysql12.000webhost.com","a1841092_data","data1234","a1841092_data");
	if ($con->connect_error)
	{
	    die('Connect Error (' . mysqli_connect_errno() . ') '. mysqli_connect_error());
	}
	
	$name = $_POST["name"];
	$age = $_POST["age"];
	$username = $_POST["username"];
	$password = $_POST["password"];

	$statement = mysqli_prepare($con, "INSERT INTO User (name, age, username, password) VALUES (?, ?, ?, ?) ");
	mysqli_stmt_bind_param($statement, "siss", $name, $age, $username, $password);
	mysqli_stmt_execute($statement);

	mysqli_stmt_close($statement);

	mysqli_close($con);
?>
