<?php
header("Content-Type: application/json");
header("Access-Control-Allow-Origin: *");
header("Access-Control-Allow-Methods: POST");

$conn = new mysqli("localhost", "root", "", "bdors");

if ($conn->connect_error) {
    echo json_encode(["success" => false, "message" => "Connection failed"]);
    exit();
}

// Dawaton ang JSON data gikan sa C#
$data = json_decode(file_get_contents("php://input"), true);

if (isset($data['residentId']) && isset($data['email'])) {
    $id = $conn->real_escape_string($data['residentId']);
    $email = $conn->real_escape_string($data['email']);

    $sql = "UPDATE user_resident SET email = '$email' WHERE residentId = '$id'";

    if ($conn->query($sql)) {
        echo json_encode(["success" => true, "message" => "Email updated successfully"]);
    } else {
        echo json_encode(["success" => false, "message" => "SQL Error: " . $conn->error]);
    }
} else {
    echo json_encode(["success" => false, "message" => "Incomplete data for email update"]);
}

$conn->close();
?>