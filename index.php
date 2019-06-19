<?php   try {
    $db = new PDO('mysql:host=localhost;dbname=notify',"root","");
} catch ( PDOException $e ){
     print $e->getMessage();
}?>

<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<title>Document</title>
</head>
<body>
	

	<form action="" method="POST">
		<input type="text" name="message"> <br>
		<button type="submit">Send</button>
	</form>



</body>
</html>

<?php 
if ($_POST) {
	$msg = trim($_POST['message']);

    $query = $db->prepare("UPDATE notifycation SET status = ?, message = ? WHERE id = ?");
    $query->execute(array(1, $msg, 1));
    if ($query) {
        echo "sent";
    }
}
?>