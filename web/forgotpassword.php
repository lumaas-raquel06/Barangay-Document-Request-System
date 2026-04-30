<?php
include('connect.php');
require 'PHPMailer-7.0.2/src/PHPMailer.php';
require 'PHPMailer-7.0.2/src/SMTP.php';
require 'PHPMailer-7.0.2/src/Exception.php';

use PHPMailer\PHPMailer\PHPMailer;
use PHPMailer\PHPMailer\Exception;

$error = '';
$success = '';

if ($_SERVER['REQUEST_METHOD'] == 'POST') {
    $username = mysqli_real_escape_string($conn, $_POST['username']);
    
    // Check if username exists
    $sql = "SELECT * FROM tbl_residentinfo WHERE username = '$username' AND status = 'Active'";
    $result = mysqli_query($conn, $sql);
    
    if (mysqli_num_rows($result) > 0) {
        $row = mysqli_fetch_assoc($result);
        $email = $row['email'];

        // Generate reset token and expiry
        $token = bin2hex(random_bytes(16));
        $expiry = date("Y-m-d H:i:s", strtotime("+1 hour"));

        $update = "UPDATE tbl_residentinfo 
                   SET reset_token='$token', reset_expiry='$expiry' 
                   WHERE username='$username'";
        mysqli_query($conn, $update);

        // Send email with PHPMailer
        $mail = new PHPMailer(true);
        try {
            $mail->isSMTP();
            $mail->Host = 'smtp.gmail.com';
            $mail->SMTPAuth = true;
            $mail->Username = 'reykelsalinas@gmail.com';   // imong Gmail
            $mail->Password = 'oaublfrgqonzkkks';    // App Password
            $mail->SMTPSecure = 'tls';
            $mail->Port = 587;

            $mail->setFrom('reykelsalinas@gmail.com', 'BDORS System');
            $mail->addAddress($email); // recipient from DB
            $mail->isHTML(true);
            $mail->Subject = 'Password Reset';
            $mail->Body    = "Hello <b>{$row['fname']} {$row['lname']}</b>,<br><br>
                              Click this link to reset your password:<br>
                              <a href='http://localhost/Barangay-Documents-Online-Request-System/resetpassword.php?token=$token'>
                              Reset Password</a><br><br>
                              This link will expire in 1 hour.";

            $mail->send();
            $success = "Reset link sent to your email.";
        } catch (Exception $e) {
            $error = "Message could not be sent. Mailer Error: {$mail->ErrorInfo}";
        }
    } else {
        $error = "Username not found. Please try again.";
    }
}
?>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <title>BDORS - Forgot Password</title>
  <link rel="stylesheet" type="text/css" href="signupstyle.css"/>
  <script src="https://kit.fontawesome.com/b0811c54d0.js" crossorigin="anonymous"></script>
  <style>
    .signin-signup { left: 75% !important; width: 50% !important; z-index: 10 !important; }
    .forms-container { z-index: 10 !important; }
    .sign-in-form { z-index: 10 !important; }
    .right-panel { display: none !important; }
    .left-panel .btn.transparent { display: none !important; }
    .error-msg { color: red; font-size: 13px; margin-top: 5px; text-align: center; }
    .success-msg { color: green; font-size: 13px; margin-top: 5px; text-align: center; }
    .back-link { color: #5995fd; text-decoration: none; font-size: 14px; margin-top: 10px; display: block; text-align: center; }
    .back-link:hover { color: #4d84e2; }
  </style>
</head>
<body>
  <div class="container">
    <div class="forms-container">
      <div class="signin-signup">
        <form action="forgotpassword.php" class="sign-in-form" method="POST">
          <div class="backhome">
            <ul>
              <li><a href="index.php">Back to Home</a></li>
            </ul>
          </div>
          <h2 class="title">Forgot Password</h2>
          <p style="color:#888; font-size:14px; text-align:center; margin-bottom:10px;">
            Enter your username to recover your account.
          </p>

          <?php if(!empty($error)): ?>
            <p class="error-msg"><?php echo $error; ?></p>
          <?php endif; ?>

          <?php if(!empty($success)): ?>
            <p class="success-msg"><?php echo $success; ?></p>
          <?php endif; ?>

          <div class="input-field">
            <i class="fas fa-user"></i>
            <input type="text" placeholder="Username" name="username" required>
          </div>

          <input type="submit" value="Next" class="btn solid">

          <a href="login.php" class="back-link">
            <i class="fas fa-arrow-left"></i> Back to Login
          </a>
        </form>
      </div>
    </div>

    <div class="panels-container">
      <div class="panel left-panel">
        <div class="content">
          <h3>Brgy. Ayahag</h3>
          <p>Saint Bernard, Southern Leyte</p>
          <p>Enter your username to recover your account.</p>
        </div>
        <img src="img/log.svg" class="image">
      </div>
    </div>
  </div>
</body>
</html>
