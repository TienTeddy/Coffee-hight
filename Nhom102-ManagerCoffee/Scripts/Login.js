
function statusChangeCallback(response) {  // Called with the results from FB.getLoginStatus().
    console.log('statusChangeCallback');
    console.log(response);                   // The current login status of the person.
    if (response.status === 'connected') {   // Logged into your webpage and Facebook.
        testAPI();
    } else {                                 // Not logged into your webpage or we are unable to tell.
        $('#status').hide(800);
        $('#user').hide(800);
        $('#logout').hide();
        $('#login').show();
    }
}


function checkLoginState() {               // Called when a person is finished with the Login Button.
    FB.getLoginStatus(function (response) {   // See the onlogin handler
        statusChangeCallback(response);
    });
}


window.fbAsyncInit = function () {
    FB.init({
        appId: '1629619917220597',
        cookie: true,                     // Enable cookies to allow the server to access the session.
        xfbml: true,                     // Parse social plugins on this webpage.
        version: 'v8.0'           // Use this Graph API version for this call.
    });


    FB.getLoginStatus(function (response) {   // Called after the JS SDK has been initialized.
        statusChangeCallback(response);        // Returns the login status.
    });
};

function testAPI() {                      // Testing Graph API after login.  See statusChangeCallback() for when this call is made.
    console.log('Welcome!  Fetching your information.... ');
    FB.api('/me', { locale: 'en_US', fields: 'id,first_name,last_name,email,link,gender,locale,picture' },
        function (response) {
            document.getElementById('status').innerHTML = 'Thanks for logging in, ' + response.first_name + '!';
            document.getElementById('user').innerHTML = '<p><b>FB ID:</b> ' + response.id + '</p><p><b>Name:</b> ' + response.first_name + ' '
                + response.last_name + '</p><p><b>Email:</b> ' + response.email + '</p><p><b>Gender:</b> '
                + response.gender + '</p><p><b>Locale:</b> ' + response.locale + '</p><p><b>Link:</b>' + response.picture.data.url + '</p> <p><b>' + 'Picture:</b> <img src="'
                + response.picture.data.url + '"/></p><p><b>FB Profile:</b> <a target="_blank" href="' + response.link + '">click to view profile</a></p>';
            //console.log(response.picture);
        });
    $('#status').show(800);
    $('#user').show(800);
    $('#logout').show();
}

function logout() {
    FB.logout(function (response) {
        console.log(response);
    });
    $('#status').hide(800);
    $('#user').hide(800);
    $('#logout').hide();
    $('#login').show();
}

/*--Login Google*/
function onSignIn(googleUser) {
    var profile = googleUser.getBasicProfile();
    document.getElementById('user2').innerHTML = '<p><b>ID:</b>' + profile.getId() + '</p>'
        + '<p><b>Name:</b>' + profile.getName() + '</p>'
        + '<p><b>Image URL:</b>' + profile.getImageUrl() + '</p>'
        + '<p><b>Email:</b>' + profile.getEmail() + '</p>';
}

function signOut() {
    var auth2 = gapi.auth2.getAuthInstance();
    auth2.signOut().then(function () {
        console.log('User signed out.');
    });
    $('#user2').hide(800);
}
