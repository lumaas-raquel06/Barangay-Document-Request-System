<?php
header("Content-Type: application/json");
header("Access-Control-Allow-Origin: *");
header("Access-Control-Allow-Methods: POST");

include "../connect.php"; // Dinhi gikan ang $conn

$data = json_decode(file_get_contents("php://input"), true);

if(isset($data['residentId']) && isset($data['status'])) {
    // Siguroha nga $conn (double 'n') ang gamiton parehas sa connection.php
    $id = $conn->real_escape_string($data['residentId']);
    $status = $conn->real_escape_string($data['status']);

    $sql = "UPDATE tbl_residentinfo SET status = '$status' WHERE residentId = '$id'";
    
    if(mysqli_query($conn, $sql)) {
        if(mysqli_affected_rows($conn) > 0) {
            echo json_encode(["success" => true, "message" => "Status updated to $status"]);
        } else {
            echo json_encode(["success" => false, "message" => "No changes made. ID might not exist."]);
        }
    } else {
        echo json_encode(["success" => false, "error" => mysqli_error($conn)]);
    }
} else {
    echo json_encode(["success" => false, "message" => "Incomplete data from C#"]);
}
?>