<?php
include('connect.php');
session_start();

if (!isset($_SESSION['login_user'])) {
    header("location: login.php");
    exit();
}

$user_check = $_SESSION['login_user'];

// Gi-select ang residentId para ma-save sa session
$sql = "SELECT ur.residentId, ur.username, ur.email, r.fname, r.lname, r.status
        FROM user_resident ur
        JOIN tbl_residentinfo r ON ur.residentId = r.residentId
        WHERE ur.username=? AND r.status='Active' LIMIT 1";

$stmt = $conn->prepare($sql);
$stmt->bind_param("s", $user_check);
$stmt->execute();
$result = $stmt->get_result();

if ($result && $result->num_rows > 0) {
    $row = $result->fetch_assoc();
    $_SESSION['residentId'] = $row['residentId']; // Kani ang gamiton nato sa Foreign Key
    $_SESSION['fullname'] = $row['fname'] . " " . $row['lname'];
    $_SESSION['email']    = $row['email'];
} else {
    session_destroy();
    header("location: login.php");
    exit();
}
?>