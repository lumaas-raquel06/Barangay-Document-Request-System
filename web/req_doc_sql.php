<?php 
include 'usersession.php'; 

if ($_SERVER['REQUEST_METHOD'] == 'POST') {
    // 1. Kuhaon ang residentId gikan sa session (Para secured)
    $resId = $_SESSION['residentId']; 
    
    // 2. I-sanitize ang tanang data gikan sa POST
    $fullname  = mysqli_real_escape_string($conn, $_POST['fullname']);
    $bday      = mysqli_real_escape_string($conn, $_POST['birthdate']); // Gidugang kini
    $age       = mysqli_real_escape_string($conn, $_POST['age']);       // Gidugang kini
    $gender    = mysqli_real_escape_string($conn, $_POST['gender']);    // Gidugang kini
    $address   = mysqli_real_escape_string($conn, $_POST['homeadd']);
    $contact   = mysqli_real_escape_string($conn, $_POST['contact']);
    $purpose   = mysqli_real_escape_string($conn, $_POST['purposes']);
    $document  = mysqli_real_escape_string($conn, $_POST['documents']);
    $fee       = mysqli_real_escape_string($conn, $_POST['fee']);
    $validId   = mysqli_real_escape_string($conn, $_POST['ValidID']);
    $payment   = mysqli_real_escape_string($conn, $_POST['payment']);
    $service   = mysqli_real_escape_string($conn, $_POST['service']);
    $status    = mysqli_real_escape_string($conn, $_POST['status']);

    // 3. Pag-handle sa File Uploads
    $target = "uploads/";
    if (!file_exists($target)) { mkdir($target, 0777, true); }

    $frontID = time() . "_F_" . basename($_FILES['FrontID']['name']);
    $backID  = time() . "_B_" . basename($_FILES['BackID']['name']);
    
    move_uploaded_file($_FILES['FrontID']['tmp_name'], $target . $frontID);
    move_uploaded_file($_FILES['BackID']['tmp_name'], $target . $backID);

    // 4. FIXED INSERT QUERY: Gi-apil na ang Birthdate, Age, ug Gender
    $query = "INSERT INTO request (residentId, Fullname, Birthdate, Age, Gender, HomeAddress, Contact, DateofRequest, Purposes, Documents, Fee, ValidID, FrontID, BackID, Payment, Service, Status) 
              VALUES ('$resId', '$fullname', '$bday', '$age', '$gender', '$address', '$contact', NOW(), '$purpose', '$document', '$fee', '$validId', '$frontID', '$backID', '$payment', '$service', '$status')";

    if (mysqli_query($conn, $query)) {
        echo "<script>alert('Request Submitted Successfully!'); window.location.href='userrequest.php';</script>";
    } else {
        echo "Error: " . mysqli_error($conn);
    }
}
?>