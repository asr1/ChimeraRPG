$(function() {

    $("#contactForm input,#contactForm textarea").jqBootstrapValidation({
        preventSubmit: true,
        submitError: function($form, event, errors) {
            // additional error messages or events
        },
        submitSuccess: function($form, event) {
            event.preventDefault(); // prevent default submit behaviour
            // get values from FORM
            var name = $("input#name").val();
            var email = $("input#email").val();
            //var phone = $("input#phone").val();
            var message = $("textarea#message").val();
            var firstName = name; // For Success/Failure Message
            // Check for white space in name for Success/Fail message
            if (firstName.indexOf(' ') >= 0) {
                firstName = name.split(' ').slice(0, -1).join(' ');
            }
            $.ajax({
                url: "././mail/contact_me.php",
                type: "POST",
                data: {
                    name: name,
                    email: email,
                    message: message
                },
                cache: false,
                success: function() {
					var settings = {
					  "async": true,
					  "crossDomain": true,
					  "dataType": "jsonp",
					  "url": "https://api.sendgrid.com/api/mail.send.json?api_user=azure_4a85e6d827d40f1a6618214e611f355a%40azure.com&api_key=podidd53e&to%5B%5D=alexandersrinehart%40gmail.com&toname%5B%5D=alexandersrinehart%40gmail.com&subject=subject&text=testingtextbody&from=alexandersrinehart%40gmail.com",
					  "method": "POST",
					  "headers": {
						"authorization": "Bearer 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",
						"cache-control": "no-cache",
						"postman-token": "9dbd20d7-4eca-894e-58f0-f019a570e1db"
					  }
					}

					$.ajax(settings).done(function (response) {
					  console.log(response);
					});                  


				  // Success message
                    $('#success').html("<div class='alert alert-success'>");
                    $('#success > .alert-success').html("<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;")
                        .append("</button>");
                    $('#success > .alert-success')
                        .append("<strong>Your message has been sent. </strong>");
                    $('#success > .alert-success')
                        .append('</div>');

                    //clear all fields
                    $('#contactForm').trigger("reset");
                },
                error: function() {
                    // Fail message
                    $('#success').html("<div class='alert alert-danger'>");
                    $('#success > .alert-danger').html("<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;")
                        .append("</button>");
                    $('#success > .alert-danger').append("<strong>Sorry " + firstName + ", it seems that my mail server is not responding. Please try again later!");
                    $('#success > .alert-danger').append('</div>');
                    //clear all fields
                    $('#contactForm').trigger("reset");
                },
            })
        },
        filter: function() {
            return $(this).is(":visible");
        },
    });

    $("a[data-toggle=\"tab\"]").click(function(e) {
        e.preventDefault();
        $(this).tab("show");
    });
});


/*When clicking on Full hide fail/success boxes */
$('#name').focus(function() {
    $('#success').html('');
});
