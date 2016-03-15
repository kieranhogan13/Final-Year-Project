<?php
	$mysql_hostname = "localhost";
	$mysql_user = "root";
	$mysql_password = "";
	$mysql_database = "bootstrap";

	$bd = mysql_connect($mysql_hostname, $mysql_user, $mysql_password) or die ("Something went wrong!");
	mysql_select_db($mysql_database, $bd) or die("Something went wrong!");
?>