<?php
include 'usersession.php';

if ($_SERVER['REQUEST_METHOD'] == 'POST') {
    $id        = mysqli_real_escape_string($conn, $_POST['request_id']);
    $purpose   = mysqli_real_escape_string($conn, $_POST['purposes']);
    $document  = mysqli_real_escape_string($conn, $_POST['documents']);
    $payment   = mysqli_real_escape_string($conn, $_POST['payment']);
    $service   = mysqli_real_escape_string($conn, $_POST['service']);
    
    // Pag-compute pag-usab sa Fee basig gi-usab ang Document
    $fee = 0;
    if($document == 'Barangay Clearance') $fee = 75;
    else if($document == 'Certificate of Indigency') $fee = 100;
    else if($document == 'Barangay ID') $fee = 50;
    else if($document == 'Community Tax Return') $fee = 20;

    $resId = $_SESSION['residentId'];

    // UPDATE query: Usbon ang data ug i-reset ang status sa 'Pending for Approval' 
    // para ma-review sa admin ang kausaban
    $sql = "UPDATE request SET 
            Purposes = '$purpose', 
            Documents = '$document', 
            Fee = '$fee', 
            Payment = '$payment', 
            Service = '$service',
            Status = 'Pending for Approval'
            WHERE id = '$id' AND residentId = '$resId'";

    if (mysqli_query($conn, $sql)) {
        echo "<script>alert('Request updated and resubmitted successfully!'); window.location.href='userrequest.php';</script>";
    } else {
        echo "Error: " . mysqli_error($conn);
    }
}
?>