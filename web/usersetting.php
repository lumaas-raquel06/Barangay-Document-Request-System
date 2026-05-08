<?php 
include('usersession.php'); 

$resId = $_SESSION['residentId']; 

// Query aron makuha ang data sa user
$query = "SELECT u.username, u.email, r.fname, r.lname 
          FROM user_resident u 
          INNER JOIN tbl_residentinfo r ON u.residentId = r.residentId 
          WHERE u.residentId = '$resId'";

$results = mysqli_query($conn, $query);
$record = mysqli_fetch_array($results, MYSQLI_ASSOC);

$fname = $record['fname'];
$lname = $record['lname'];
$email = $record['email'];
$uname = $record['username'];
?>

<!DOCTYPE html>
<html lang="en" dir="ltr">
<head>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <title> BDORS - Settings </title>
  <script src="https://kit.fontawesome.com/b0811c54d0.js" crossorigin="anonymous"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  
  <!-- Gi-copy naho ang imong original CSS design -->
  <style>
    @import url("https://fonts.googleapis.com/css2?family=Poppins:wght@200;300;400;500;600;700;800&display=swap");

    *{ margin: 0; padding: 0; font-family: "Poppins", sans-serif; }

    header {
        z-index: 1; position: fixed; background: #22242A; padding: 20px;
        width: 100%; top: 0; height: 30px;
    }

    .left_area h3 { color: #fff; margin: 0; text-transform: uppercase; font-size: 22px; font-weight: 900; }
    .left_area span { color: #5995fd; }

    .logout_btn{
        padding: 5px; background: #5995fd; float: right; text-decoration: none;
        margin-top: -30px; margin-right: 40px; border-radius: 2px;
        font-size: 15px; font-weight: 600; color: #fff; transition: 0.5s;
    }

    .sidebar {
        z-index: 1; top: 0; background: #2F323A; margin-top: 70px;
        padding-top: 30px; position: fixed; left: 0; width: 250px;
        height: 100%; transition: 0.5s; overflow-y: auto; 
    }

    .profile_info {
        display: flex; flex-flow: column; justify-content: center;
        align-items: center; color: #fff; font-size: 17px; margin-bottom: 20px;
    }

    .sidebar .profile_info .profile_image { width: 70px; height: 70px; border-radius: 100px; margin-bottom: 10px; }

    .sidebar a {
        color: #fff; display: block; width: 100%; line-height: 60px;
        text-decoration: none; padding-left: 40px; box-sizing: border-box; transition: 0.05s;
    }

    .sidebar a:hover { background: #5995fd; }
    .sidebar i { padding-right: 10px; }

    label #sidebar_btn {
        z-index: 1; color: #fff; position: fixed; cursor: pointer;
        left: 215px; font-size: 20px; margin: 5px 0; transition: 0.5s;
    }

    #check:checked ~ .sidebar { left: -185px; }
    #check:checked ~ .sidebar a span { display: none; }
    #check:checked ~ .sidebar a { font-size: 20px; margin-left: 165px; width: 100%; }

    .content {
        margin-left: 250px; margin-top: 70px; padding: 20px;
        background: url(img/bg.jpg) no-repeat; background-size: cover;
        min-height: 100vh; transition: 0.5s;
    }

    #check:checked ~ .content { margin-left: 60px; }
    #check { display: none; }

    /* Table & Form Style */
    table {
        background: #fff; width: 80%; text-align: center; margin: 20px auto;
        font-size: 16px; border-collapse: collapse; border-radius: 5px; overflow: hidden;
    }
    th { background: #5995fd; color: white; padding: 15px; }
    td { padding: 12px; border-bottom: 1px solid #cbcbcb; background: #fff; }

    form {
        background: #fff; width: 50%; margin: 30px auto;
        padding: 30px; border-radius: 8px; box-shadow: 0 0 10px rgba(0,0,0,0.1);
    }
    .input-group { margin-bottom: 15px; }
    .input-group label { display: block; margin-bottom: 5px; font-weight: 500; }
    .input-group input {
        width: 100%; padding: 10px; box-sizing: border-box;
        border: 1px solid #ccc; border-radius: 4px;
    }
    .btn {
        width: 100%; padding: 12px; background: #5995fd;
        color: white; border: none; border-radius: 4px; cursor: pointer; font-weight: 600;
    }
    .btn:hover { background: #4d84e2; }

    /* Mobile Nav */
    .mobile_nav { display: none; }
    @media screen and (max-width: 780px){
        .sidebar, #sidebar_btn { display: none; }
        .content { margin-left: 0; }
        .mobile_nav { display: block; width: 100%; }
        .nav_bar {
            background: #222; margin-top: 70px; display: flex;
            justify-content: space-between; align-items: center; padding: 10px 20px;
        }
        .mobile_nav_items { background: #2F323A; display: none; }
        .mobile_nav_items.active { display: block; }
        .mobile_nav_items a { color: #fff; display: block; line-height: 50px; text-decoration: none; text-align: center; }
        form, table { width: 95%; }
    }
  </style>
</head>

<body>
    <input type="checkbox" id="check">
    
    <header>
        <label for="check"><i class="fas fa-bars" id="sidebar_btn"></i></label>
        <div class="left_area"><h3> BD<span>ORS</span></h3></div>
        <div class="right_area"><a href="userlogout.php" class="logout_btn">Logout</a></div>
    </header>

    <div class="mobile_nav">
        <div class="nav_bar">
            <img src="img/ava.png" style="width:50px; border-radius:50%;">
            <i class="fas fa-bars nav_btn" style="color:#fff; cursor:pointer;"></i>
        </div>
        <div class="mobile_nav_items">
            <a href="userportal.php"><i class="fas fa-desktop"></i><span>Dashboard</span></a>
            <a href="userreq_doc.php"><i class="fas fa-file-alt"></i><span>Request Document</span></a>
            <a href="userrequest.php"><i class="fas fa-folder-open"></i><span>All Requests</span></a>
            <a href="usersetting.php"><i class="fas fa-sliders-h"></i><span>Settings</span></a>
        </div>
    </div>

    <div class="sidebar">
        <div class="profile_info">
            <img src="img/ava.png" class="profile_image">
            <h4><?php echo $uname; ?></h4>
        </div>
        <a href="userportal.php"><i class="fas fa-desktop"></i><span>Dashboard</span></a>
        <a href="userreq_doc.php"><i class="fas fa-file-alt"></i><span>Request Document</span></a>
        <a href="userrequest.php"><i class="fas fa-folder-open"></i><span>All Requests</span></a>
        <a href="usersetting.php"><i class="fas fa-sliders-h"></i><span>Settings</span></a>
    </div>

    <div class="content">
        <h2 style="text-align:center; color: #222; margin-bottom: 20px;">USER SETTINGS</h2>
        
        <!-- Display Current Info -->
        <table>
            <thead>
                <tr>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>Email</th>
                    <th>Username</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td><?php echo $fname; ?></td>
                    <td><?php echo $lname; ?></td>
                    <td><?php echo $email; ?></td>
                    <td><?php echo $uname; ?></td>
                </tr>
            </tbody>
        </table>

        <!-- Update Form -->
        <form method="post" action="userserver.php">
            <input type="hidden" name="residentId" value="<?php echo $resId; ?>">
            
            <div class="input-group">
                <label>First Name</label>
                <input type="text" name="FirstName" value="<?php echo $fname; ?>" required>
            </div>
            <div class="input-group">
                <label>Last Name</label>
                <input type="text" name="LastName" value="<?php echo $lname; ?>" required>
            </div>
            <div class="input-group">
                <label>Email</label>
                <input type="email" name="Email" value="<?php echo $email; ?>" required>
            </div>
            <div class="input-group">
                <label>Username</label>
                <input type="text" name="Username" value="<?php echo $uname; ?>" required>
            </div>
            <div class="input-group">
                <label>New Password (Leave blank if no change)</label>
                <input type="password" name="Password" placeholder="Enter new password">
            </div>
            
            <button class="btn" type="submit" name="update" onclick="return confirm('Update your information?');">Update Information</button>
        </form>
    </div>

    <script type="text/javascript">
        $(document).ready(function(){
            $('.nav_btn').click(function(){
                $('.mobile_nav_items').toggleClass('active');
            });
        });
    </script>
</body>
</html>