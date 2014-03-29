<?php
echo "hello world";

$now = time() * 1000;
function start(){
	
	$expireTime = 2592000; //number of seconds in 30 days.
	setcookie(startTime, time(), time() + $expireTime);
	setcookie(startDate, date('Y-m-d'), time()+$expireTime);
}
?>