<?php 
include 'usersession.php'; 

// Fetch resident info para sa sidebar
$resId = $_SESSION['residentId']; 
$query_user = "SELECT * FROM tbl_residentinfo WHERE residentId = '$resId'"; 
$result_user = mysqli_query($conn, $query_user); 
$row_user = mysqli_fetch_array($result_user, MYSQLI_ASSOC); 

// Helper function - GI-FIX NA: Naggamit na og residentId
function fetchRequests($conn, $resId, $status) {
    // Siguroha nga 'residentId' ang column name sa imong database 'request' table
    $sql = "SELECT * FROM request WHERE residentId = '$resId' AND Status = '$status' ORDER BY id DESC";
    return mysqli_query($conn, $sql);
}
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title> BDORS - All Requests </title>
    <script src="https://kit.fontawesome.com/b0811c54d0.js" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    
    <style>
        @import url("https://fonts.googleapis.com/css2?family=Poppins:wght@200;300;400;500;600;700;800&display=swap");

        * { margin: 0; padding: 0; font-family: "Poppins", sans-serif; }

        header { z-index: 1; position: fixed; background: #22242A; padding: 20px; width: 100%; top: 0; height: 30px; }
        .left_area h3 { color: #fff; margin: 0; text-transform: uppercase; font-size: 22px; font-weight: 900; }
        .left_area span { color: #5995fd; }
        .logout_btn { padding: 5px; background: #5995fd; float: right; text-decoration: none; margin-top: -30px; margin-right: 40px; border-radius: 2px; font-size: 15px; font-weight: 600; color: #fff; }
        
        .sidebar { z-index: 1; top: 0; background: #2F323A; margin-top: 70px; padding-top: 30px; position: fixed; left: 0; width: 250px; height: 100%; transition: 0.5s; }
        .profile_info { display: flex; flex-direction: column; align-items: center; color: #fff; margin-bottom: 20px; }
        .sidebar .profile_image { width: 70px; height: 70px; border-radius: 100px; margin-bottom: 10px; }
        .sidebar h4 { color: #ccc; margin-bottom: 20px; }
        .sidebar a { color: #fff; display: block; width: 100%; line-height: 60px; text-decoration: none; padding-left: 40px; box-sizing: border-box; transition: 0.3s; }
        .sidebar a:hover { background: #5995fd; }
        .sidebar i { padding-right: 10px; }

        .content { margin-left: 250px; margin-top: 60px; padding: 20px; background: #f1f1f1; min-height: 100vh; }

        .tab-box { background: #fff; padding: 20px; border-radius: 8px; box-shadow: 0 0 10px rgba(0,0,0,0.1); }
        .tabs { display: flex; border-bottom: 2px solid #ddd; margin-bottom: 20px; overflow-x: auto; }
        .tab-btn { padding: 10px 20px; cursor: pointer; border: none; background: none; font-weight: 600; color: #555; transition: 0.3s; border-bottom: 3px solid transparent; }
        .tab-btn.active { color: #5995fd; border-bottom: 3px solid #5995fd; }
        
        .tab-content { display: none; }
        .tab-content.active { display: block; }

        table { width: 100%; border-collapse: collapse; margin-top: 10px; }
        table thead tr { background-color: #131F33; color: #ffffff; text-align: left; }
        table th, table td { padding: 12px 15px; border: 1px solid #ddd; font-size: 13px; }
        table tbody tr:nth-of-type(even) { background-color: #f3f3f3; }
        
        .status-pill { padding: 4px 10px; border-radius: 20px; font-weight: bold; font-size: 11px; text-transform: uppercase; }
        .pending { background: #ffeeba; color: #856404; }
        .approved { background: #d4edda; color: #155724; }
        .rejected { background: #f8d7da; color: #721c24; }
        .completed { background: #d1ecf1; color: #0c5460; }
        .cancelled { background: #e2e3e5; color: #383d41; }

        .delete_btn { color: #d9534f; text-decoration: none; font-size: 18px; }
		/* Modal Design */
		.modal {
			display: none; 
			position: fixed; 
			z-index: 1000; 
			left: 0; top: 0;
			width: 100%; height: 100%;
			background-color: rgba(0,0,0,0.5);
		}

		.modal-content {
			background-color: #fefefe;
			margin: 5% auto;
			padding: 25px;
			border-radius: 8px;
			width: 50%;
			box-shadow: 0 5px 15px rgba(0,0,0,0.3);
		}

		.modal-header {
			border-bottom: 1px solid #ddd;
			padding-bottom: 10px;
			margin-bottom: 20px;
			display: flex;
			justify-content: space-between;
			align-items: center;
		}

		.modal-body p {
			margin-bottom: 10px;
			font-size: 14px;
		}

		.modal-body b { color: #333; width: 150px; display: inline-block; }

		.close { color: #aaa; font-size: 28px; font-weight: bold; cursor: pointer; }
		.close:hover { color: black; }

		.btn-resubmit {
			background-color: #5995fd;
			color: white;
			padding: 10px 20px;
			border: none;
			border-radius: 4px;
			cursor: pointer;
			text-decoration: none;
			display: inline-block;
			margin-top: 20px;
		}
    </style>
</head>

<body>
    <header>
        <div class="left_area"><h3> BD<span>ORS</span></h3></div>
        <div class="right_area"><a href="userlogout.php" class="logout_btn">Logout</a></div>
    </header>

    <div class="sidebar">
        <div class="profile_info">
            <img src="img/ava.png" class="profile_image">
            <h4><?php echo $row_user['fname']; ?></h4>
        </div>
        <a href="userportal.php"><i class="fas fa-desktop"></i><span>Dashboard</span></a>
        <a href="userreq_doc.php"><i class="fas fa-file-alt"></i><span>Request Document</span></a>
        <a href="userrequest.php"><i class="fas fa-folder-open"></i><span>All Requests</span></a>
        <a href="usersetting.php"><i class="fas fa-sliders-h"></i><span>Settings</span></a>
    </div>

    <div class="content">
        <div class="tab-box">
            <h2 style="margin-bottom: 15px; color: #333;">Request History</h2>
            
            <div class="tabs">
                <button class="tab-btn active" onclick="showTab(event, 'Pending')">Pending</button>
                <button class="tab-btn" onclick="showTab(event, 'Approved')">Approved</button>
                <button class="tab-btn" onclick="showTab(event, 'Rejected')">Rejected</button>
                <button class="tab-btn" onclick="showTab(event, 'Completed')">Completed</button>
                <button class="tab-btn" onclick="showTab(event, 'Cancelled')">Cancelled</button>
            </div>

            <?php 
            $tab_list = [
                'Pending'   => 'Pending for Approval',
                'Approved'  => 'Approved',
                'Rejected'  => 'Rejected',
                'Completed' => 'Completed',
                'Cancelled' => 'Cancelled'
            ];

            foreach ($tab_list as $tab_id => $db_status): 
                $active_class = ($tab_id == 'Pending') ? 'active' : '';
            ?>
                <div id="<?php echo $tab_id; ?>" class="tab-content <?php echo $active_class; ?>" style="display: <?php echo ($tab_id == 'Pending') ? 'block' : 'none'; ?>">
                    <table border="0">
                        <thead>
                            <tr>
                                <th>Date Requested</th>
                                <th>Purpose</th>
                                <th>Document</th>
                                <th>Fee</th>
                                <th>Payment</th>
                                <th>Service</th>
                                <th>Status</th>
                                <th>Action</th>
                            </tr>
                        </thead>
                        <tbody>
                            <?php 
                            // GI-FIX: residentId na ang gina-pasa sa function
                            $res = fetchRequests($conn, $resId, $db_status);
                            if(mysqli_num_rows($res) > 0):
                                while($row = mysqli_fetch_assoc($res)): 
                            ?>
                                <tr>
									<td><?php echo $row['DateofRequest']; ?></td>
									<td><?php echo $row['Purposes']; ?></td>
									<td><b><?php echo $row['Documents']; ?></b></td>
									<td>₱<?php echo $row['Fee']; ?></td>
									<td><?php echo $row['Payment']; ?></td>
									<td><?php echo $row['Service']; ?></td>
									<td><span class="status-pill <?php echo strtolower($tab_id); ?>"><?php echo $row['Status']; ?></span></td>
									<td align="center">
										<a href="javascript:void(0)" 
										onclick='openModal(<?php echo json_encode($row); ?>)' 
										style="color: #5995fd; margin-right: 10px;">
											<i class="fas fa-eye"></i> Details
										</a>

										<?php if($db_status == 'Pending for Approval'): ?>
											<a href="cancelreq.php?id=<?php echo $row['id']; ?>" 
											style="color: #f94144;" 
											onclick="return confirm('Are you sure you want to cancel this request?');">
												<i class="fas fa-times-circle"></i> Cancel
											</a>
										<?php endif; ?>
									</td>
								</tr>
                            <?php 
                                endwhile; 
                            else:
                                echo "<tr><td colspan='8' align='center'>No records found for $tab_id requests.</td></tr>";
                            endif;
                            ?>
                        </tbody>
                    </table>
                </div>
            <?php endforeach; ?>
        </div>
    </div>
	<div id="detailsModal" class="modal">
		<div class="modal-content" style="width: 50%; margin: 2% auto;">
			<div class="modal-header">
				<h3><i class="fas fa-edit"></i> Edit & Resubmit Request</h3>
				<span class="close" onclick="closeModal()">&times;</span>
			</div>
			<form id="resubmitForm" action="resubmit_sql.php" method="POST">
				<div class="modal-body">
					<input type="hidden" name="request_id" id="edit_id">
					
					<div style="display: grid; grid-template-columns: 1fr 1fr; gap: 15px; margin-bottom: 15px;">
						<div class="input-group">
							<label>Document Type</label>
							<select name="documents" id="edit_doc" required style="width:100%; padding:10px; border: 1px solid #ccc; border-radius: 4px;">
								<option value="Barangay Clearance">Barangay Clearance</option>
								<option value="Certificate of Indigency">Certificate of Indigency</option>
								<option value="Barangay ID">Barangay ID</option>
								<option value="Community Tax Return">Community Tax Return</option>
							</select>
						</div>
						<div class="input-group">
							<label>Payment Method</label>
							<select name="payment" id="edit_payment" style="width:100%; padding:10px; border: 1px solid #ccc; border-radius: 4px;">
								<option value="COD">Cash on Delivery (COD)</option>
								<option value="On Pickup">On Pickup</option>
							</select>
						</div>
						<div class="input-group">
							<label>Service Option</label>
							<select name="service" id="edit_service" style="width:100%; padding:10px; border: 1px solid #ccc; border-radius: 4px;">
								<option value="For Delivery">For Delivery</option>
								<option value="For Pickup">For Pickup</option>
							</select>
						</div>
						<div class="input-group">
							<label>Date of Request</label>
							<input type="text" id="edit_date" readonly style="width:100%; padding:10px; background:#eee; border: 1px solid #ccc; border-radius: 4px;">
						</div>
					</div>

					<div class="input-group" style="margin-bottom: 15px;">
						<label>Purpose</label>
						<textarea name="purposes" id="edit_purpose" rows="3" required 
							style="width:100%; padding:10px; border: 1px solid #ccc; border-radius: 4px; box-sizing: border-box; resize: none;"></textarea>
					</div>

					<div style="margin-top: 15px; background: #fff3cd; border-left: 4px solid #ffc107; padding: 12px; border-radius: 4px;">
						<p style="margin:0; font-size: 13px; color: #856404;">
							<strong>Note:</strong> Basic information (Name, Address, etc.) cannot be modified here. 
							If there are errors in your personal details, please update them in the <strong>Settings</strong> section.
						</p>
					</div>
				</div>
				
				<div class="modal-footer" style="text-align: right; margin-top: 20px; border-top: 1px solid #eee; padding-top: 15px;">
					<button type="button" onclick="closeModal()" style="padding: 10px 20px; background: #6c757d; color: white; border:none; border-radius:4px; cursor:pointer; margin-right: 5px;">Cancel</button>
					<button type="submit" class="btn-resubmit" style="padding: 10px 20px; background: #5995fd; color: white; border:none; border-radius:4px; cursor:pointer; font-weight: 600;">
						<i class="fas fa-paper-plane"></i> Save & Resubmit
					</button>
				</div>
			</form>
		</div>
	</div>
    <script>
        function showTab(evt, statusName) {
            var i, tabcontent, tablinks;
            tabcontent = document.getElementsByClassName("tab-content");
            for (i = 0; i < tabcontent.length; i++) {
                tabcontent[i].style.display = "none";
                tabcontent[i].classList.remove("active");
            }
            tablinks = document.getElementsByClassName("tab-btn");
            for (i = 0; i < tablinks.length; i++) {
                tablinks[i].classList.remove("active");
            }
            document.getElementById(statusName).style.display = "block";
            evt.currentTarget.classList.add("active");
        }

		function openModal(data) {
			var modal = document.getElementById("detailsModal");
			
			// I-set ang mga values sa input fields base sa data gikan sa row
			document.getElementById("edit_id").value = data.id;
			document.getElementById("edit_purpose").value = data.Purposes;
			document.getElementById("edit_doc").value = data.Documents;
			document.getElementById("edit_payment").value = data.Payment;
			document.getElementById("edit_service").value = data.Service;
			document.getElementById("edit_date").value = data.DateofRequest;

			modal.style.display = "block";
		}

		function closeModal() {
			document.getElementById("detailsModal").style.display = "none";
		}

		// Close modal if user clicks outside of it
		window.onclick = function(event) {
			var modal = document.getElementById("detailsModal");
			if (event.target == modal) {
				modal.style.display = "none";
			}
		}
    </script>
</body>
</html>