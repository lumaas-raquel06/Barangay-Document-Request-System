<?php
include("connect.php");
session_start();

if ($_SERVER["REQUEST_METHOD"] == "POST") {
    // 1. Kuhaon ang Username ug Password gikan sa form
    // Wala na tay gipangita nga 'Email' diri para mawala ang error
    $uname = $_POST['Username'];
    $pwd   = $_POST['Password'];

    // 2. Pangitaon ang account sa user_resident table
    // Gi-JOIN nato sa tbl_residentinfo para makuha ang Full Name sa resident
    $sql = "SELECT u.residentId, u.password, r.fname, r.lname 
            FROM user_resident u 
            JOIN tbl_residentinfo r ON u.residentId = r.residentId 
            WHERE u.username = ? LIMIT 1";
            
    $stmt = $conn->prepare($sql);
    
    if (!$stmt) {
        // I-display ang error kung naay problema sa SQL syntax o column names
        die("SQL Error: " . $conn->error);
    }

    $stmt->bind_param("s", $uname);
    $stmt->execute();
    $result = $stmt->get_result();

    if ($row = $result->fetch_assoc()) {
        // 3. I-verify ang gi-type nga password batok sa hash nga naa sa database
        if (password_verify($pwd, $row['password'])) {
            // KUNG SAKTO ANG PASSWORD:
            $_SESSION['login_user'] = $uname;
            $_SESSION['residentId'] = $row['residentId'];
            $_SESSION['fullname']   = $row['fname'] . ' ' . $row['lname'];
            
            // Redirect sa portal
            header("location: userportal.php");
            exit();
        } else {
            // KUNG SAYOP ANG PASSWORD:
            echo "<script>alert('Invalid Password. Please try again.'); window.location.href='login.php';</script>";
        }
    } else {
        // KUNG WALA ANG USERNAME:
        echo "<script>alert('Username not found. Please contact the Brgy. Admin.'); window.location.href='login.php';</script>";
    }
}
?>