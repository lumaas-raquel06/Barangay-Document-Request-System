<?php 
include 'usersession.php'; 

// 1. I-fetch ang records gamit ang residentId gikan sa session
$resId = $_SESSION['residentId'];
$query = "SELECT * FROM tbl_residentinfo WHERE residentId = '$resId'";
$result = mysqli_query($conn, $query);
$row = mysqli_fetch_array($result, MYSQLI_ASSOC);

// Pag-calculate sa Full Name
$fullname = $row['lname'] . ", " . $row['fname'] . " " . $row['mname'];

// Pag-combine sa Address (House #, Block, Lot, Street, Area)
$full_address = $row['houseNumber'] . " Block " . $row['block'] . " Lot " . $row['lot'] . ", " . $row['streetName'] . ", " . $row['areaType'];

$currentDate = date("Y-m-d");
?>
<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <title> BDORS - Request Document </title>
  <script src="https://kit.fontawesome.com/b0811c54d0.js" crossorigin="anonymous"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  
  <style>
    @import url("https://fonts.googleapis.com/css2?family=Poppins:wght@200;300;400;500;600;700;800&display=swap");
    * { margin: 0; padding: 0; font-family: "Poppins", sans-serif; }
    header { z-index: 1; position: fixed; background: #22242A; padding: 20px; width: 100%; top: 0; height: 30px; }
    .left_area h3 { color: #fff; margin: 0; text-transform: uppercase; font-size: 22px; font-weight: 900; }
    .left_area span { color: #5995fd; }
    .logout_btn { padding: 5px; background: #5995fd; float: right; text-decoration: none; margin-top: -30px; margin-right: 40px; border-radius: 2px; font-size: 15px; font-weight: 600; color: #fff; transition: 0.5s; }
    .sidebar { z-index: 1; top: 0; background: #2F323A; margin-top: 70px; padding-top: 30px; position: fixed; left: 0; width: 250px; height: 100%; transition: 0.5s; overflow-y: auto; }
    .profile_info { display: flex; flex-flow: column; justify-content: center; align-items: center; color: #fff; font-size: 17px; margin-bottom: 20px; }
    .sidebar .profile_info .profile_image { width: 70px; height: 70px; border-radius: 100px; margin-bottom: 10px; }
    .sidebar a { color: #fff; display: block; width: 100%; line-height: 60px; text-decoration: none; padding-left: 40px; box-sizing: border-box; transition: 0.05s; }
    .sidebar a:hover { background: #5995fd; }
    .sidebar i { padding-right: 10px; }
    .content { margin-left: 250px; margin-top: 60px; padding: 20px; min-height: 100vh; background: url(img/bg.jpg) no-repeat; background-size: cover; }
    form { background: #fff; width: 60%; margin: 10px auto; padding: 25px; border-radius: 5px; }
    .welcome p { font-size: 25px; text-align: center; font-weight: 600; margin-bottom: 20px; }
    .input-group { margin-bottom: 15px; }
    .input-group label { display: block; margin-bottom: 5px; font-weight: 500; }
    input[type=text], input[type=date], select { width: 100%; padding: 12px; border: 1px solid #ccc; border-radius: 4px; box-sizing: border-box; }
    input[readonly] { background-color: #eee; cursor: not-allowed; }
    .fee-box { font-weight: bold; padding: 10px; border-bottom: 2px solid #000; width: fit-content; min-width: 100px; margin-bottom: 20px; font-size: 18px; }
    input[type=submit] { width: 100%; background-color: #5995fd; color: white; padding: 14px; border: none; border-radius: 4px; cursor: pointer; font-weight: 600; }
    @media screen and (max-width: 780px){
      .sidebar { display: none; }
      .content { margin-left: 0; }
      form { width: 90%; }
    }
  </style>
</head>

<body>
    <input type="checkbox" id="check" style="display:none;">
    <header>
        <div class="left_area"><h3> BD<span>ORS</span></h3></div>
        <div class="right_area"><a href="userlogout.php" class="logout_btn">Logout</a></div>
    </header>

    <div class="sidebar">
        <div class="profile_info">
            <img src="img/ava.png" class="profile_image">
            <h4><?php echo $row['fname']; ?></h4>
        </div>
        <a href="userportal.php"><i class="fas fa-desktop"></i><span>Dashboard</span></a>
        <a href="userreq_doc.php"><i class="fas fa-file-alt"></i><span>Request Document</span></a>
        <a href="userrequest.php"><i class="fas fa-folder-open"></i><span>All Requests</span></a>
        <a href="usersetting.php"><i class="fas fa-sliders-h"></i><span>Settings</span></a>
    </div>

    <div class="content">
        <div class="welcome"><p>REQUEST DOCUMENT</p></div>
        
        <form action="req_doc_sql.php" method="POST" enctype="multipart/form-data">
            <div class="input-group">
                <label>Full Name</label>
                <input type="text" name="fullname" value="<?php echo $fullname; ?>" readonly>
            </div>
            <div class="input-group">
                <label>Date of Birth</label>
                <input type="text" name="birthdate" value="<?php echo $row['bday']; ?>" readonly>
            </div>
            <div class="input-group">
                <label>Age</label>
                <input type="text" name="age" value="<?php echo $row['age']; ?>" readonly>
            </div>
            <div class="input-group">
                <label>Gender</label>
                <input type="text" name="gender" value="<?php echo $row['gender']; ?>" readonly>
            </div>
            <div class="input-group">
                <label>Address</label>
                <input type="text" name="homeadd" value="<?php echo $full_address; ?>" readonly>
            </div>
            <div class="input-group">
                <label>Contact Number</label>
                <input type="text" name="contact" value="<?php echo $row['contact']; ?>" readonly>
            </div>
            <div class="input-group">
                <label>Date of Request</label>
                <input type="date" name="datepicker" value="<?php echo $currentDate; ?>" readonly>
            </div>

            <hr style="margin: 20px 0;">

            <div class="input-group">
                <label>Purpose</label>
                <input type="text" name="purposes" placeholder="Enter purpose" required>
            </div>
            <div class="input-group">
                <label>Documents</label>
                <select id="document" name="documents" required>
                    <option value="" disabled selected>Please Select</option>
                    <option value="Barangay Clearance">Barangay Clearance</option>
                    <option value="Certificate of Indigency">Certificate of Indigency</option>
                    <option value="Barangay ID">Barangay ID</option>
                    <option value="Community Tax Return">Community Tax Return (Cedula)</option>
                </select>
            </div>

            <label>Fee</label>
            <div id="fee_display" class="fee-box">₱ 0.00</div>
            <input type="hidden" id="fee_val" name="fee" value="0">

            <div class="input-group">
                <label>Select ID Type</label>
                <select name="ValidID" required>
                    <option value="" disabled selected>-- Select --</option>
                    <option value="School ID">School ID</option>
                    <option value="Voter's ID">Voter's ID</option>
                    <option value="PhilHealth ID">PhilHealth ID</option>
                    <option value="Driver's Licence">Driver's Licence</option>
                </select>
            </div>

            <div class="input-group">
                <label>FRONT Photo of ID</label>
                <input type="file" name="FrontID" accept="image/*" required>
            </div>
            <div class="input-group">
                <label>BACK Photo of ID</label>
                <input type="file" name="BackID" accept="image/*" required>
            </div>

            <div class="input-group">
                <label>Payment Option</label>
                <select name="payment" required>
                    <option value="COD">Cash on Delivery (COD)</option>
                    <option value="On Pickup">On Pickup</option>
                </select>
            </div>
            <div class="input-group">
                <label>Service Option</label>
                <select name="service" required>
                    <option value="For Delivery">For Delivery</option>
                    <option value="For Pickup">For Pickup</option>
                </select>
            </div>

            <input type="hidden" name="status" value="Pending for Approval">
            <input type="submit" value="Submit Request" onclick="return confirm('Place this request?');">
        </form>
    </div>

    <script>
        $(document).on("change", "#document", function(){
            var doc = $(this).val();
            var price = 0;
            if(doc == 'Barangay Clearance') price = 75;
            else if(doc == 'Certificate of Indigency') price = 100;
            else if(doc == 'Barangay ID') price = 50;
            else if(doc == 'Community Tax Return') price = 20;

            $("#fee_display").text('₱ ' + price + '.00');
            $("#fee_val").val(price);
        });
    </script>
</body>
</html>