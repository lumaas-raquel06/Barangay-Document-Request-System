<?php
include("connect.php");
session_start();

if ($_SERVER["REQUEST_METHOD"] == "POST") {

    $uname = $_POST['Username'];
    $pwd   = $_POST['Password'];

    // I-call ang API
    $api_url = "http://localhost/Barangay-Documents-Online-Request-System/api/verify_resident.php"
             . "?username=" . urlencode($uname)
             . "&password=" . urlencode($pwd);

    $response = file_get_contents($api_url);
    $data     = json_decode($response, true);

    if ($data['success'] == true) {
        $_SESSION['login_user'] = $uname;
        $_SESSION['residentId'] = $data['data']['residentId'];
        $_SESSION['fullname']   = $data['data']['firstname'] . ' ' . $data['data']['lastname'];
        header("location: userportal.php");
        exit();
    } else {
        echo "<script type='text/javascript'>
            alert('You are not registered in Brgy. Ayahag, Saint Bernard, Southern Leyte.');
            window.location.href = 'login.php';
        </script>";
    }
}
?>