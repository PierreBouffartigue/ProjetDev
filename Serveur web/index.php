<?php 
	$host   = "mysql:host=localhost;dbname=unity";
	$user   = "root";
	$pass   = "";
	$option = array(PDO::MYSQL_ATTR_INIT_COMMAND => "SET NAMES utf8");
	try{
		$con = new PDO($host,$user, $pass, $option);
		$con->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
	}catch (Exception $e){die('Erreur : ' . $e->getMessage());}

	if (isset($_POST["username"]) && !empty($_POST["username"]) && 
		isset($_POST["password"]) && !empty($_POST["password"])){

		Login($_POST["username"], $_POST["password"]);
	}

	function Login($username, $password){
		GLOBAL $con;

		$sql = "SELECT id,username FROM users WHERE username=? AND password=?";
		$st=$con->prepare($sql);

		$st->execute(array($username, sha1($password)));
		$all=$st->fetchAll();
		if (count($all) == 1){
			echo "SERVER: ID#".$all[0]["id"]." - ".$all[0]["username"];
			exit();
		}

		echo "SERVER: error, invalid username or password";
		exit();
	}

	echo "SERVER: error, enter a valid username & password";

?>