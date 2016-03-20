
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
            <li><a href="chart1.php">Chart 1</a></li>
            <li><a href="chart2.php">Chart 2</a></li>
            <li><a href="chart3.php">Chart 3</a></li>
            <li class="active"><a href="#">Chart 4</a></li>
            <li><a href="../logout.php">Logout</a></li>
          </ul>
        </div><!--/.nav-collapse -->
      </div>
    </nav>

    <div class="container">

      <div class="starter-template">
        <h1>Score per category</h1>
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

  include("../includes/fusioncharts.php");


  $hostdb = "localhost";  // MySQl host
  $userdb = "root";  // MySQL username
  $passdb = "";  // MySQL password
  $namedb = "bootstrap";  // MySQL database name

  // Establish a connection to the database

  $dbhandle = new mysqli($hostdb, $userdb, $passdb, $namedb);

  /*
    Render an error message, 
    to avoid abrupt failure, 
    if the database connection parameters are incorrect 
  */

  if ($dbhandle->connect_error) {
  exit("There was an error with your connection: ".$dbhandle->connect_error);
  }

  // Form the SQL query that returns the top 10 most populous countries

  $strQuery = "SELECT category, SUM(score) FROM tracking ORDER BY category";

  // Execute the query, or else return the error message.

  $result = $dbhandle->query($strQuery) or exit("Error code ({$dbhandle->errno}): {$dbhandle->error}");

  // If the query returns a valid response, prepare the JSON strin

  if ($result) {
    
  // The `$arrData` array holds the chart attributes and data

  $arrData = array(
    "chart" => array
    (
      "caption" => "Score per category",
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

  // Push the data into the array

  while($row = mysqli_fetch_array($result)) {
  array_push($arrData["data"], array(
    "label" => $row["category"],
    "value" => $row["SUM(score)"]
    )
  );
  }

  /*JSON Encode the data to retrieve the string containing the JSON representation of the data in the array. */

  $jsonEncodedData = json_encode($arrData);

  /*
   Create an object for the column chart using the FusionCharts PHP class constructor. 
   Syntax for the constructor is 
   `FusionCharts("type of chart", "unique chart id", width of the chart, height of the chart, "div id to render the chart", "data format", "data source")`. 
   Because we are using JSON data to render the chart, the data format will be `json`. 
   The variable `$jsonEncodeData` holds all the JSON data for the chart, 
   and will be passed as the value for the data source parameter of the constructor.
  */

  $columnChart = new FusionCharts("column2D", "myFirstChart" , 600, 300, "chart-1", "json", $jsonEncodedData);

  // Render the chart

  $columnChart->render();
  }
  // Close the database connection

  $dbhandle->close();

?>
