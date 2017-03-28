<?php
ini_set('display_errors',1);
error_reporting(E_ALL);

echo "working"

echo $_POST['pdf'][]
$target_dir = "Uploads/";
$target_file = $target_dir . basename($_FILES["fileToUpload"]["name"]);
$uploadOk = 1;
$fileType = pathinfo($target_file, PATHINFO_EXTENSION);
echo "file name is " . $target_file;

if(file_exists($target_file)){
	echo "Sorry, file exists<br>";
	$uploadOk = 0;
}

if ($uploadOk == 0){
	echo "File was not uploaded." . "<br>";
}
else{
	if(move_uploaded_file($_FILES["fileToUpload"]["tmp_name"], $target_file)){
		echo "The file " . basename($_FILES["fileToUpload"]["name"]) . " has been uploaded.";
	} else {
		echo "Sorry, there was an error." . "<br>";
		echo "The file " . basename($_FILES["fileToUpload"]["name"]) . " has failed to upload.";
	}
}
?>