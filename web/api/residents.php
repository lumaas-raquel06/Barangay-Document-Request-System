<?php
header("Content-Type: application/json");
header("Access-Control-Allow-Origin: *");
header("Access-Control-Allow-Methods: GET, POST");

// Siguroha nga husto ang database name (bdors)
$conn = new mysqli("localhost", "root", "", "bdors");

if ($conn->connect_error) {
    http_response_code(500);
    echo json_encode(["success" => false, "message" => "Connection failed: " . $conn->connect_error]);
    exit();
}

$method = $_SERVER['REQUEST_METHOD'];

// ========== POST — Add New Resident ==========
if ($method == 'POST') {
    $data = json_decode(file_get_contents("php://input"), true);

    // I-verify kon naay data nga nadawat
    if (!$data) {
        http_response_code(400);
        echo json_encode(["success" => false, "message" => "No data provided"]);
        exit();
    }

    $residentId   = $conn->real_escape_string($data['residentId']);
    $fname        = $conn->real_escape_string($data['fname']);
    $mname        = $conn->real_escape_string($data['mname']);
    $lname        = $conn->real_escape_string($data['lname']);
    $ext          = $conn->real_escape_string($data['ext']);
    $placeOfBirth = $conn->real_escape_string($data['placeOfBirth']);
    $age          = $conn->real_escape_string($data['age']);
    $gender       = $conn->real_escape_string($data['gender']);
    $bday         = $conn->real_escape_string($data['bday']);
    $isVoter      = $conn->real_escape_string($data['isVoter']);
    $civilStatus  = $conn->real_escape_string($data['civilStatus']);
    $nationality  = $conn->real_escape_string($data['nationality']);
    $contact      = $conn->real_escape_string($data['contact']);
    $username     = $conn->real_escape_string($data['username']);
    $email        = $conn->real_escape_string($data['email']);
    $status       = $conn->real_escape_string($data['status']);

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
                "password" => $plainPassword 
            ]
        ]);
    } else {
        http_response_code(500);
        echo json_encode([
            "success" => false,
            "message" => "SQL Error: " . $conn->error
        ]);
    }
}

// ========== GET — Get Residents (All or Specific) ==========
if ($method == 'GET') {
    // I-check kon naay 'id' parameter sa URL
    $residentId = isset($_GET['id']) ? $conn->real_escape_string($_GET['id']) : null;

    if ($residentId) {
        // Query para sa specific nga residentId gamit ang JOIN
        $sql = "SELECT r.*, u.email 
                FROM tbl_residentinfo r
                LEFT JOIN user_resident u ON r.residentId = u.residentId
                WHERE r.residentId = '$residentId'";
    } else {
        // Default: I-fetch tanan kon walay ID nga gi-specify
        $sql = "SELECT r.*, u.email 
                FROM tbl_residentinfo r
                LEFT JOIN user_resident u ON r.residentId = u.residentId
                WHERE r.status='Active'";
    }
    
    $result = $conn->query($sql);
    
    if (!$result) {
        http_response_code(500);
        echo json_encode(["success" => false, "message" => "Database Query Error: " . $conn->error]);
        exit();
    }

    $residents = [];
    while ($row = $result->fetch_assoc()) {
        $residents[] = $row;
    }
    
    http_response_code(200);
    echo json_encode([
        "success" => true,
        "count" => count($residents),
        "data" => $residents
    ]);
}
$conn->close();
?>