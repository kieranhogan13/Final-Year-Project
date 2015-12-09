<?php
	$con=mysqli_connect("mysql12.000webhost.com","a1841092_data","data1234","a1841092_data");
	if ($con->connect_error)
	{
	    die('Connect Error (' . mysqli_connect_errno() . ') '. mysqli_connect_error());
	}
	
	$username = $_POST["username"];
	$password = $_POST["password"];

	$statement = mysqli_prepare($con, "SELECT * FROM user WHERE username = ?, AND password = ?");
	mysqli_stmt_bind_param($statement, "ss", $username, $password);
	mysqli_stmt_execute($statement);

	mysqli_stmt_store_result($statement);
	mysqli_stmt_bind_result($statement, $userID, $name, $age, $username, $password);

	$user = array();

	while(mysqli_stmt_fetch($statemet))
	{
		$user[name] = $name;
		$user[age] = $age;
		$user[username] = $username;
		$user[password] = $password;
	}

	echo json_encode($user);

	mysqli_stmt_close($statement);

	mysqli_close($con);
?>
