<html>
<html lang="en">  
<head>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <title> BDORS </title>
  <link rel="stylesheet" type="text/css" href="signupstyle.css"/>
  <script src="https://kit.fontawesome.com/b0811c54d0.js" crossorigin="anonymous"></script>
</head>
<body>
  <div class="container">
    <div class="forms-container">
      <div class="signin-signup">

        <!-- SIGN IN FORM ONLY -->
        <form action="signup.php" class="sign-in-form" method="POST">
          <div class="backhome">
            <ul>
              <li><a href="index.php">Back to Home</a></li>
            </ul>
          </div>
          <h2 class="title">Sign in</h2>
          <div class="input-field"> 
            <i class="fas fa-user"></i>
            <input type="text" placeholder="Username" name="Username" required>
          </div>
          <div class="input-field"> 
            <i class="fas fa-lock"></i>
            <input type="password" placeholder="Password" name="Password" required>
          </div>
          <input type="submit" value="Login" class="btn solid">
        </form> 

      </div>
    </div>

    <div class="panels-container"> 
      <div class="panel left-panel"> 
        <div class="content"> 
          <h3>Brgy. Ayahag</h3>
          <p>Saint Bernard, Southern Leyte</p>
          <p>Login your account to request your barangay documents online.</p>
        </div>
        <img src="img/log.svg" class="image">
      </div>
      <!-- RIGHT PANEL HIDDEN -->
      <div class="panel right-panel"> 
        <div class="content"> 
          <h3>One of us?</h3>
          <p>Login your account and request your documents now.</p>
        </div>
        <img src="img/register.svg" class="image">
      </div>
    </div>
  </div>	
  
  <!-- WALA NA ANG app.js para dili na mag-toggle ang sign up -->
</body>
</html>