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

if (isset($data['residentId'])) {
    $id = $conn->real_escape_string($data['residentId']);
    
    // I-prepare ang mga column nga i-update
    $fields = [
        'fname', 'mname', 'lname', 'gender', 
        'bday', 'age', 'contact', 'status'
    ];

    $updates = [];
    foreach ($fields as $field) {
        if (isset($data[$field])) {
            $val = $conn->real_escape_string($data[$field]);
            $updates[] = "$field = '$val'";
        }
    }

    if (!empty($updates)) {
        $sql = "UPDATE tbl_residentinfo SET " . implode(", ", $updates) . " WHERE residentId = '$id'";
        
        if ($conn->query($sql)) {
            echo json_encode(["success" => true, "message" => "Resident info updated"]);
        } else {
            echo json_encode(["success" => false, "message" => "SQL Error: " . $conn->error]);
        }
    } else {
        echo json_encode(["success" => false, "message" => "No fields to update"]);
    }
} else {
    echo json_encode(["success" => false, "message" => "Resident ID is required"]);
}

$conn->close();
?>