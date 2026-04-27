<?php
header("Content-Type: application/json");
header("Access-Control-Allow-Origin: *");
header("Access-Control-Allow-Methods: GET");

$conn = new mysqli("localhost", "root", "", "bdors");

if ($conn->connect_error) {
    http_response_code(500);
    echo json_encode([
        "success" => false,
        "message" => "Database connection failed"
    ]);
    exit();
}

if ($_SERVER['REQUEST_METHOD'] == 'GET') {
    $username = $conn->real_escape_string($_GET['username'] ?? '');
    $password = $_GET['password'] ?? '';

    if (empty($username) || empty($password)) {
        http_response_code(400);
        echo json_encode([
            "success" => false,
            "message" => "Username and password are required"
        ]);
        exit();
    }

    // Kuhaon ang hashed password gikan sa database
    $sql = "SELECT residentId, fname, lname, email, status, password 
            FROM tbl_residentinfo 
            WHERE username='$username' 
            AND status='Active'";

    $result = $conn->query($sql);

    if ($result->num_rows > 0) {
        $row = $result->fetch_assoc();

        // I-verify gamit password_verify()
        if (password_verify($password, $row['password'])) {
            http_response_code(200);
            echo json_encode([
                "success" => true,
                "message" => "Login successful",
                "data" => [
                    "residentId" => $row['residentId'],
                    "firstname"  => $row['fname'],
                    "lastname"   => $row['lname'],
                    "email"      => $row['email'],
                    "status"     => $row['status']
                ]
            ]);
        } else {
            http_response_code(401);
            echo json_encode([
                "success" => false,
                "message" => "Invalid credentials."
            ]);
        }
    } else {
        http_response_code(401);
        echo json_encode([
            "success" => false,
            "message" => "Not registered in Brgy. Ayahag, Saint Bernard, Southern Leyte."
        ]);
    }
}

$conn->close();
?>