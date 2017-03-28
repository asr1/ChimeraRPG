<?php
// Check for empty fields
if(empty($_POST['name'])  		||
   empty($_POST['email']) 		||
   empty($_POST['phone']) 		||
   empty($_POST['message'])	||
   !filter_var($_POST['email'],FILTER_VALIDATE_EMAIL))
   {
	echo "No arguments Provided!";
	return false;
   }
	
$name = $_POST['name'];
$email_address = $_POST['email'];
$phone = $_POST['phone'];
$message = $_POST['message'];
//Modify below this point.	

$client = new http\Client;
$request = new http\Client\Request;

$request->setRequestUrl('https://api.sendgrid.com/api/mail.send.json');
$request->setRequestMethod('POST');
$request->setQuery(new http\QueryString(array(
  'api_user' => 'azure_4a85e6d827d40f1a6618214e611f355a@azure.com',
  'api_key' => 'podidd53e',
  'to[]' => 'alexandersrinehart@gmail.com',
  'toname[]' => 'alexandersrinehart@gmail.com',
  'subject' => 'subject',
  'text' => 'testingtextbody',
  'from' => 'alexandersrinehart@gmail.com'
)));

$request->setHeaders(array(
  'postman-token' => 'f35f4a8b-a61d-a5c6-f06d-c2a0d46e75f4',
  'cache-control' => 'no-cache',
  'authorization' => 'Bearer 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'
));

$client->enqueue($request)->send();
$response = $client->getResponse();

echo $response->getBody();
return true;			
?>