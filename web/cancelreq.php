<?php
include 'usersession.php'; // Para makuha ang $conn ug $_SESSION['residentId']

if (isset($_GET['id'])) {
    $id = mysqli_real_escape_string($conn, $_GET['id']);
    $resId = $_SESSION['residentId'];

    // UPDATE Status padung 'Cancelled'
    // Gi-check nato ang residentId para ang tag-iya ra sa request ang maka-cancel
    $sql = "UPDATE request SET Status = 'Cancelled' 
            WHERE id = '$id' AND residentId = '$resId' AND Status = 'Pending for Approval'";

    if (mysqli_query($conn, $sql)) {
        echo "<script>alert('Request has been cancelled.'); window.location.href='userrequest.php';</script>";
    } else {
        echo "Error updating record: " . mysqli_error($conn);
    }
} else {
    header("location: userrequest.php");
}
?>