<?php
header("Content-Type: application/json");
header("Access-Control-Allow-Origin: *");
header("Access-Control-Allow-Methods: GET, POST");

// Usba kini base sa imong database credentials
$conn = new mysqli("localhost", "root", "", "bdors");

if ($conn->connect_error) {
    echo json_encode(["success" => false, "message" => "Connection failed: " . $conn->connect_error]);
    exit();
}

$method = $_SERVER['REQUEST_METHOD'];

// ==========================================
// 1. GET - PARA SA PAG-LOAD SA DATA SA C# UI
// ==========================================
if ($method == 'GET') {
    $residentId = isset($_GET['id']) ? $conn->real_escape_string($_GET['id']) : null;
    
    // MAO KINI ANG IDUGANG: Kuhaon ang status gikan sa URL (e.g. ?status=Archived)
    // Kon walay status nga gi-pasa, default sija nga 'Active'
    $status = isset($_GET['status']) ? $conn->real_escape_string($_GET['status']) : 'Active';

    if ($residentId) {
        $sql = "SELECT r.*, u.email FROM tbl_residentinfo r 
                LEFT JOIN user_resident u ON r.residentId = u.residentId 
                WHERE r.residentId = '$residentId'";
    } else {
        // GI-USAB: Imbis 'Active', gigamit nato ang $status nga variable
        $sql = "SELECT r.*, u.email FROM tbl_residentinfo r 
        LEFT JOIN user_resident u ON r.residentId = u.residentId 
        WHERE r.status = '$status' 
        ORDER BY r.residentId DESC";
    }

    $result = $conn->query($sql);
    $residents = [];
    while ($row = $result->fetch_assoc()) {
        $residents[] = $row;
    }
    echo json_encode(["success" => true, "data" => $residents]);
}

// ==========================================
// 2. POST - PARA SA PAG-SAVE GIKAN SA C# FORM
// ==========================================
if ($method == 'POST') {
    $data = json_decode(file_get_contents("php://input"), true);

    if ($data) {
        // Basic Information
        $residentId = $conn->real_escape_string($data['residentId']);
        $fname = $conn->real_escape_string($data['fname']);
        $mname = $conn->real_escape_string($data['mname']);
        $lname = $conn->real_escape_string($data['lname']);
        $ext = $conn->real_escape_string($data['ext']);
        $pob = $conn->real_escape_string($data['placeOfBirth']);
        $age = $conn->real_escape_string($data['age']);
        $gender = $conn->real_escape_string($data['gender']);
        $bday = $conn->real_escape_string($data['bday']);
        $isVoter = $conn->real_escape_string($data['isVoter']);
        $cStatus = $conn->real_escape_string($data['civilStatus']);
        $nat = $conn->real_escape_string($data['nationality']);
        $contact = $conn->real_escape_string($data['contact']);
        
        // Address Fields (Kini ang gi-fix para dili na mag-NULL)
        $hnum = $conn->real_escape_string($data['houseNumber']);
        $blk = $conn->real_escape_string($data['block']);
        $lot = $conn->real_escape_string($data['lot']);
        $street = $conn->real_escape_string($data['streetName']);
        $area = $conn->real_escape_string($data['areaType']);

        // User Account Information
        $email = $conn->real_escape_string($data['email']);
        $username = $conn->real_escape_string($data['username']);
        $password = password_hash($data['password'], PASSWORD_DEFAULT);

        $conn->begin_transaction();
        try {
            // 1. Save sa tbl_residentinfo (Gi-apil na ang tanang columns)
            $sql1 = "INSERT INTO tbl_residentinfo (
                        residentId, fname, mname, lname, ext, placeOfBirth, 
                        age, gender, bday, isVoter, civilStatus, nationality, 
                        contact, status, houseNumber, block, lot, streetName, areaType
                    ) VALUES (
                        '$residentId', '$fname', '$mname', '$lname', '$ext', '$pob', 
                        '$age', '$gender', '$bday', '$isVoter', '$cStatus', '$nat', 
                        '$contact', 'Active', '$hnum', '$blk', '$lot', '$street', '$area'
                    )";
            
            if (!$conn->query($sql1)) {
                throw new Exception("Error saving resident info: " . $conn->error);
            }

            // 2. Save sa user_resident table para sa login credentials
            $sql2 = "INSERT INTO user_resident (residentId, username, password, email) 
                     VALUES ('$residentId', '$username', '$password', '$email')";
            
            if (!$conn->query($sql2)) {
                throw new Exception("Error saving user account: " . $conn->error);
            }

            $conn->commit();
            echo json_encode(["success" => true, "message" => "Resident saved successfully!"]);
            
        } catch (Exception $e) {
            $conn->rollback();
            echo json_encode(["success" => false, "message" => $e->getMessage()]);
        }
    } else {
        echo json_encode(["success" => false, "message" => "No data received."]);
    }
}

$conn->close();
?>