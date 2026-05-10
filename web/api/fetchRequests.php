<?php
header('Content-Type: application/json');
include("../connect.php");

$status = isset($_GET['status']) ? $_GET['status'] : '';
$year = isset($_GET['year']) ? $_GET['year'] : date("Y");
$search = isset($_GET['search']) ? $_GET['search'] : '';

// SQL query nga naay filter para sa Status, Year, ug Search (Fullname)
$sql = "SELECT id, Fullname, Documents, Purposes, DateofRequest FROM request 
        WHERE Status = ? AND YEAR(DateofRequest) = ? 
        AND (Fullname LIKE ? OR Documents LIKE ?)";

$stmt = $conn->prepare($sql);
$searchTerm = "%$search%"; // I-wrap sa percent signs para sa LIKE search
$stmt->bind_param("ssss", $status, $year, $searchTerm, $searchTerm);
$stmt->execute();
$result = $stmt->get_result();

$data = array();
while ($row = $result->fetch_assoc()) {
    $data[] = $row;
}

echo json_encode($data);
?>