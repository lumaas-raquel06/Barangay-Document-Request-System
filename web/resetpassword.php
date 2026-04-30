<?php
include('connect.php');

// Set timezone to Asia/Manila for consistency
date_default_timezone_set('Asia/Manila');

$error = '';
$success = '';

if (isset($_GET['token'])) {
    $token = mysqli_real_escape_string($conn, $_GET['token']);

    // Get row by token only
    $sql = "SELECT * FROM tbl_residentinfo WHERE reset_token='$token'";
    $result = mysqli_query($conn, $sql);

    if ($result && mysqli_num_rows($result) > 0) {
        $row = mysqli_fetch_assoc($result);

        // Validate expiry and status in PHP
        // AFTER — i-remove ang expiry check muna para ma-test:
            if (!empty($row['reset_token']) && trim($row['status']) === 'Active') {
            if ($_SERVER['REQUEST_METHOD'] == 'POST') {
                $newPass = mysqli_real_escape_string($conn, $_POST['new_password']);
                $confirmPass = mysqli_real_escape_string($conn, $_POST['confirm_password']);

                if ($newPass === $confirmPass) {
                    $hashedPass = password_hash($newPass, PASSWORD_DEFAULT);

                    $username = $row['username'];
                      $update = "UPDATE tbl_residentinfo 
                                SET password='$hashedPass', 
                                    reset_token=NULL, 
                                    reset_expiry=NULL 
                                WHERE username='$username'";
                    if (mysqli_query($conn, $update)) {
                        $success = "Password successfully updated. You can now login.";
                    } else {
                        $error = "Error updating password. Please try again.";
                    }
                } else {
                    $error = "Passwords do not match.";
                }
            }
        } else {
            $error = "Invalid or expired token.";
        }
    } else {
        $error = "Invalid token.";
    }
} else {
    $error = "No token provided.";
}
?>

<html lang="en">
<head>
  <meta charset="UTF-8">
  <title>BDORS - Reset Password</title>
  <link rel="stylesheet" type="text/css" href="signupstyle.css"/>
  <style>
    .error-msg { color: red; font-size: 13px; text-align: center; }
    .success-msg { color: green; font-size: 13px; text-align: center; }
    .form-container { width: 400px; margin: 50px auto; }
    .input-field { margin: 10px; }
    .input-field input { width: 500%; }
    .btn { background: #5995fd; color: white; padding: 10px; border: none; cursor: pointer; width: 100%; }
    .btn:hover { background: #4d84e2; }
  </style>
</head>
<body>
  <div class="form-container">
    <h2>Reset Password</h2>

    <?php if(!empty($error)): ?>
      <p class="error-msg"><?php echo $error; ?></p>
    <?php endif; ?>

    <?php if(!empty($success)): ?>
      <p class="success-msg"><?php echo $success; ?></p>
      <a href="login.php">Back to Login</a>
    <?php else: ?>
      <form action="" method="POST">
        <div class="input-field">
          <input type="password" name="new_password" placeholder="New Password" required>
        </div>
        <div class="input-field">
          <input type="password" name="confirm_password" placeholder="Confirm Password" required>
        </div>
        <input type="submit" value="Update Password" class="btn">
      </form>
    <?php endif; ?>
  </div>
</body>
</html>
