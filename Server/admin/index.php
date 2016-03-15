
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
          <a class="navbar-brand" href="#">Dashboard/Home</a>
        </div>
        <div id="navbar" class="collapse navbar-collapse">
          <ul class="nav navbar-nav">
            <li><a href="chart1.php">Chart 1</a></li>
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
        <h1>Welcome</h1>
        <div id="p1" >
        	<p class="lead"> Here are the stats from the usage of the tablet application. 
  It is broken down into individual sessions. These should help understand where the user is focusing and provide feedback. More statistics are being tracked and will be made available.</p>	
  		<footnote>Courtesy of FusionCharts</footnote>
  	   </div>

    </div><!-- /.container -->

    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>

  </body>
</html>
