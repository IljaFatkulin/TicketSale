<?php 
session_start();

include("connection.php");
include("functions.php");

$user_data = check_login($con);

?>

<!DOCTYPE html>
<html>
<head>
      <link rel="stylesheet" href="css/index.css">
      <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
<title>Page Title</title>
<script>

</script>
<style>
    html {
      scroll-behavior: smooth;
    }
    p {
      white-space: pre-line;
    }

    body {
  background-image: url('bgdefault.png');
  
}
    </style>
</head>
<body>

<section class="home">
<nav class="nav">
    <div class="container">
        <div class="logo">
            <a href="#"><button class="btn default">TicketSale</button></a>
            <a href="aobutus.html"><button class="btn default">About Us</button></a>
            <a href="gallery.html"><button class="btn default">Gallery</button></a>
        </div>
        <div id="mainListDiv" class="main_list">
            <ul class="btn">
                <li><a><button class="btn name"><?php echo $user_data['user_name']; ?></button></a></li>
                <li><a href='logout.php'><button class="btn default">Logout</button></a></li>
            </ul>
        </div>
    </div>
</nav>
</section>
<div style="height: 100%">

            <div style = "position:relative; left:33.3%; top:-50px;">
               <p class="myP"><img class="img2"; src="img/logo.jpg" alt="Avatar"></p>
            </div>
        <h2 class="myH2"><a name="ABOUT">&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbspTicketSale</h2>



        <div class="flex-container">

            <div class="flex-child magenta" height="1000px">
                &nbsp&nbsp <p class="myP"><a name="CONTACTS"><b>FOLLOW US</b></a></p>
                <p class="myP"style = "position:relative; left:2%; top:20px;"><img class="img3_logo" src="img/twitter.png" alt="Avatar"><a href="https://twitter.com/tiket2" aligh="center"> &nbsp&nbsp Twitter</a></p> 
                <p class="myP"style = "position:relative; right:0%; top:20px;"><img class="img4_logo" src="img/facebook.png" alt="Avatar"><a href="https://www.facebook.com/eskyglobal/" aligh="center"> Facebook</a></p> 
                <p class="myP"style = "position:relative; left:1.7%; top:20px;"><img class="img5_logo" src="img/instagram.jfif" alt="Avatar"><a href="https://www.instagram.com/esky_travel/" aligh="center"> &nbsp&nbsp Instagram</a></p> 
                <p class="myP"style = "position:relative; left:0.4%; top:20px;"><img class="img7_logo" src="img/youtube-logo.png" alt="Avatar"><a href="https://www.youtube.com/eSkyTravel" aligh="center">  YouTube</a></p> 
        <br><br>
        <hr color="#B2BEB5" height="10px" width="98%">

        &nbsp&nbsp <p class="myP"><a name="CONTACTS"><b>Download App:</b></a></p>

        <button class="btndow"><i class="fa fa-download"></i> Download</button>

            </div>
            
            <div class="flex-child green" height="1000px">
                &nbsp&nbsp <p class="myP"><a name="BASIC"><b>Basic information:</b></a></p><br><br>
                
                <p class="myP"style = "position:relative; left:1.7%; top:11px;">Baltijas vadošā aviokompānija
                    Latvijas aviokompānija Air Baltic Corporation AS (airBaltic) tika nodibināta 1995. gadā. Galvenais akcionārs ir Latvijas valsts ar 97.97% akciju, bet pārējiem akcionāriem pieder 2.03% akciju. 
                    airBaltic ir “hibrīda” aviokompānija, kas apvieno labāko tradicionālo tīkla aviokompāniju un zemo cenu pārvadātāju praksi.
                    2008. gadā airBaltic mainīja savu darbības modeli, pārejot no pasažieru pārvadāšanas no viena punkta līdz otram punktam uz tīkla aviokompānijas modeli, padarot Rīgu par tranzītmezglu. 
                    Aviokompānija piedāvā biļetes par pievilcīgām cenām sava lidojumu tīkla ietvaros, kas aptver Eiropu, Skandināviju, NVS un Tuvos Austrumus. 
                    Šīs cenas spēj konkurēt ne tikai ar citu aviokompāniju piedāvātajām cenām, bet arī ar autobusu, vieglo automašīnu, vilcienu un prāmju pārvadājumu cenām.</p>
                <br><br>
            </div>  
          </div>
        </div>

        <br><br><br><div class="main">
            <h1></h1>
                </div>

                <hr color="#B2BEB5" height="10px" width="98%">
                <div><br><br>

                    <div class="botomnav-1">
                <a font="10px">GLEK RP is not affiliated with or endorsed by Take-Two, Rockstar North Interactive, or any other rights holder.
                    <br>All the used trademarks belong to their respective owners.</a>
                    </div>
                    <p class="botomnav-3">
                        <b>tiketsale@gmail.com • +371 24004321 (Weekdays 9-17 GMT+3)</b>
                    </div>

                    <div class="botomnav-2">
                        <b>Copyright © TicketSale &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</b>
                    </div>

                </div><br><br><br>
                <div id="id01" class="modal">
                    <form action="login.php" method="post">
                        <div class="imgcontainer">
                            <span onclick="document.getElementById('id01').style.display='none'" class="close" title="Close Modal">&times;</span>
                          </div>
                        <h2>&nbsp&nbspLOGIN</h2>
                
                        <?php if (isset($_GET['error'])) { ?>
                
                            <p class="error"><?php echo $_GET['error']; ?></p>
                
                        <?php } ?>
                
    
    
                        <div class="container">
                        <label><b>User Name</b></label>
                
                        <input type="text" name="uname" placeholder="User Name"><br>
                
                        <label>Password</label>
                
                        <input type="password" name="password" placeholder="Password"><br> 
                
                        <button type="submit">Login</button>
                        </div>
                        <div class="container" style="background-color:#f1f1f1">
                            <button type="button" onclick="document.getElementById('id01').style.display='none'" class="cancelbtn">Cancel</button>
                          </div>
                     </form>
                    </div>
    
    
    
    
    
    
                    <script>
                        // Get the modal
                        var modal = document.getElementById('id01');
                        
                        // When the user clicks anywhere outside of the modal, close it
                        window.onclick = function(event) {
                            if (event.target == modal) {
                                modal.style.display = "none";
                            }
                        }
                        </script>     

</body>
</html>