<!doctype html>

<html>

  <head>
      <meta name="viewport" content="width=964"/>
      <meta charset="utf-8">
      <title>JavaScript Charts for Web, Mobile &amp; Apps - FusionCharts</title>
      <link rel="shortcut icon" href="assets/img/favicon.ico" type="image/x-icon"/>
      <link rel=icon href="assets/img/favicon.ico" type="image/x-icon"/>
      <link href="assets/css/style.css" rel="stylesheet" type="text/css">
      <link href="assets/css/style.css" rel="stylesheet" type="text/css">
      <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" integrity="sha384-1q8mTJOASx8j1Au+a5WDVnPi2lkFfwwEAa8hDDdjZlpLegxhjVME1fgjWPGmkzs7" crossorigin="anonymous">
      <script src="//code.jquery.com/jquery-1.12.0.min.js"></script>
      <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js" integrity="sha384-0mSbJDEHialfmuBBQP6A4Qrprq5OVfW37PRR3j5ELqxss1yVqOtnepnHVP9aJ7xS" crossorigin="anonymous"></script>
      <script src="js/fusioncharts.js"></script>
  
  <style>

    body {
      width: 100%;
      padding: 10px;
      margin: 10px;
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

  </style>

  </head>

  <body>

  <h1> Welcome </h1>
  
  <div id="p1" ><p> Here are the stats from the usage of the tablet application. 
  It is broken down into individual sessions. More statistics are being tracked and will be made available.</p></div>


  <div id=centre >
    <div id="chart-1"><!-- Fusion Charts will render here--></div>
  </div>

  </body>

</html>

<?php

  include("includes/fusioncharts.php");


  $hostdb = "localhost";  // MySQl host
  $userdb = "root";  // MySQL username
  $passdb = "";  // MySQL password
  $namedb = "test";  // MySQL database name

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

  $strQuery = "SELECT level_name, time_played FROM tracking ORDER BY Time_Played";

  // Execute the query, or else return the error message.

  $result = $dbhandle->query($strQuery) or exit("Error code ({$dbhandle->errno}): {$dbhandle->error}");

  // If the query returns a valid response, prepare the JSON strin

  if ($result) {
    
  // The `$arrData` array holds the chart attributes and data

  $arrData = array(
    "chart" => array
    (
      "caption" => "Time Played (seconds)",
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
    "label" => $row["level_name"],
    "value" => $row["time_played"]
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