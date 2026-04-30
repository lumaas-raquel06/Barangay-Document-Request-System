<?php
header("Content-Type: application/json");
header("Access-Control-Allow-Origin: *");
header("Access-Control-Allow-Methods: GET, POST");

$conn = new mysqli("localhost", "root", "", "bdors");

if ($conn->connect_error) {
    http_response_code(500);
    echo json_encode(["success" => false, "message" => "Connection failed"]);
    exit();
}

$method = $_SERVER['REQUEST_METHOD'];

// ========== POST — Add New Resident ==========
if ($method == 'POST') {
    $data = json_decode(file_get_contents("php://input"), true);

    $residentId  = $conn->real_escape_string($data['residentId']);
    $fname       = $conn->real_escape_string($data['fname']);
    $mname       = $conn->real_escape_string($data['mname']);
    $lname       = $conn->real_escape_string($data['lname']);
    $ext         = $conn->real_escape_string($data['ext']);
    $placeOfBirth = $conn->real_escape_string($data['placeOfBirth']);
    $age         = $conn->real_escape_string($data['age']);
    $gender      = $conn->real_escape_string($data['gender']);
    $bday        = $conn->real_escape_string($data['bday']);
    $isVoter     = $conn->real_escape_string($data['isVoter']);
    $civilStatus = $conn->real_escape_string($data['civilStatus']);
    $nationality = $conn->real_escape_string($data['nationality']);
    $contact     = $conn->real_escape_string($data['contact']);
    $username    = $conn->real_escape_string($data['username']);
    $email       = $conn->real_escape_string($data['email']);
    $status      = $conn->real_escape_string($data['status']);

    // I-hash ang password gamit PHP
    $plainPassword  = $data['password'];
    $hashedPassword = password_hash($plainPassword, PASSWORD_DEFAULT);

    $sql = "INSERT INTO tbl_residentinfo 
            (residentId, fname, mname, lname, ext, placeOfBirth, age, gender, 
             bday, isVoter, civilStatus, nationality, contact, username, 
             password, email, status)
            VALUES 
            ('$residentId', '$fname', '$mname', '$lname', '$ext', '$placeOfBirth',
             '$age', '$gender', '$bday', '$isVoter', '$civilStatus', '$nationality',
             '$contact', '$username', '$hashedPassword', '$email', '$status')";

    if ($conn->query($sql)) {
        http_response_code(201);
        echo json_encode([
            "success" => true,
            "message" => "Resident added successfully",
            "credentials" => [
                "username" => $username,
                "password" => $plainPassword // i-return ang plain para ma-inform ang admin
            ]
        ]);
    } else {
        http_response_code(500);
        echo json_encode([
            "success" => false,
            "message" => "Error: " . $conn->error
        ]);
    }
}

// ========== GET — Get All Residents ==========
if ($method == 'GET') {
    $sql = "SELECT residentId, fname, mname, lname, gender, 
                   bday, age, contact, email, status 
            FROM tbl_residentinfo 
            WHERE status='Active'";
    
    $result = $conn->query($sql);
    $residents = [];
    
    while ($row = $result->fetch_assoc()) {
        $residents[] = $row;
    }
    
    http_response_code(200);
    echo json_encode([
        "success" => true,
        "data" => $residents
    ]);
}

$conn->close();
?>