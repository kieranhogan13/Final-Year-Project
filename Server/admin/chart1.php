
<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <meta name="description" content="">
    <meta name="author" content="">

    <title>Home</title>
    <link rel="shortcut icon" href="../assets/img/favicon.ico" type="image/x-icon"/>
    <link rel=icon href="../assets/img/favicon.ico" type="image/x-icon"/>
    <link href="../css/bootstrap.min.css" rel="stylesheet">

  <style>

    body {
      width: 100%;
      padding: 10px;
      margin: 10px;
      padding-top: 50px;
  }
    h1 {
      text-align: center;
      font-size: 50px;
    }
    #centre {
      text-align: center;
    }
    #p1 {
      padding-left: 50px;
      padding-right: 50px;
    }
    .starter-template {
  padding: 40px 15px;
  text-align: center;
}

  </style>

  </head>

  <body>

    <nav class="navbar navbar-inverse navbar-fixed-top">
      <div class="container">
        <div class="navbar-header">
          <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
            <span class="sr-only">Toggle navigation</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
          </button>
          <a class="navbar-brand" href="index.php">Dashboard/Home</a>
        </div>
        <div id="navbar" class="collapse navbar-collapse">
          <ul class="nav navbar-nav">
            <li class="active"><a href="#">Chart 1</a></li>
            <li><a href="chart2.php">Chart 2</a></li>
            <li><a href="chart3.php">Chart 3</a></li>
            <li><a href="chart4.php">Chart 4</a></li>
            <li><a href="../logout.php">Logout</a></li>
          </ul>
        </div><!--/.nav-collapse -->
      </div>
    </nav>

    <div class="container">

      <div class="starter-template">
        <h1>Time spent playing game levels</h1>
        <div id="p1" >
        	<p class="lead">Here are the current statistics:</p>	   </div>

        <div id=centre >
    		<div id="chart-1"><!-- Fusion Charts will render here--></div>
  		</div>

    </div><!-- /.container -->

    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/fusioncharts.js"></script>

  </body>
</html>


<?php

session_start();
if(empty($_SESSION['login_admin']))
{
    header('Location: http://' . $_SERVER['HTTP_HOST'] . '/login.php');
    exit;
}

  include("../includes/fusioncharts.php");


  $hostdb = "localhost";  // MySQl host
  $userdb = "root";  // MySQL username
  $passdb = "Language2016";  // MySQL password
  $namedb = "fyp";  // MySQL database name

  $dbhandle = new mysqli($hostdb, $userdb, $passdb, $namedb);

  if ($dbhandle->connect_error) {
  exit("There was an error with your connection: ".$dbhandle->connect_error);
  }

  
  
  $strQuery = "SELECT timeplayed, category, levelname FROM tracking WHERE category LIKE '%Game%'";

  $result = $dbhandle->query($strQuery) or exit("Error code ({$dbhandle->errno}): {$dbhandle->error}");

  if ($result) {

  $arrData = array(
    "chart" => array
    (
      "caption" => "Time spent playing game levels (seconds)",
      "paletteColors" => "#e60000",
      "bgColor" => "#ffffff",
      "borderAlpha"=> "20",
      "canvasBorderAlpha"=> "0",
      "usePlotGradientColor"=> "1",
      "plotBorderAlpha"=> "10",
      "showXAxisLine"=> "1",
      "xAxisLineColor" => "#999999",
      "showValues" => "1",
      "divlineColor" => "#999999",
      "divLineIsDashed" => "0",
      "showAlternateHGridColor" => "1"
    )
  );

  $arrData["data"] = array();

  while($row = mysqli_fetch_array($result)) {
  array_push($arrData["data"], array(
    "label" => $row["levelname"],
    "value" => $row["timeplayed"]
    )
  );
  }

  $jsonEncodedData = json_encode($arrData);

  $columnChart = new FusionCharts("column2D", "myFirstChart" , 600, 300, "chart-1", "json", $jsonEncodedData);

  $columnChart->render();

  $conn->close();

?>
