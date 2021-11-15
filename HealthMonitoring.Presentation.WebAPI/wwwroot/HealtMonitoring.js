function showRegisterForm() {
    $('.loginBox').fadeOut('fast', function () {
        $('.registerBox').fadeIn('fast');
        $('.login-footer').fadeOut('fast', function () {
            $('.register-footer').fadeIn('fast');
        });
        $('.modal-title').html('Register');
    });
    $('.error').removeClass('alert alert-danger').html('');

}
function showLoginForm() {
    $('#loginModal .registerBox').fadeOut('fast', function () {
        $('.loginBox').fadeIn('fast');
        $('.register-footer').fadeOut('fast', function () {
            $('.login-footer').fadeIn('fast');
        });

        $('.modal-title').html('Login');
    });
    $('.error').removeClass('alert alert-danger').html('');
}

function openLoginModal() {
    showLoginForm();
    setTimeout(function () {
        $('#loginModal').modal('show');
    }, 230);

}
function openRegisterModal() {
    showRegisterForm();
    setTimeout(function () {
        $('#loginModal').modal('show');
    }, 230);

}

function loginRequest() {
    const url = "http://localhost:47109/Account/Login/";
    const data = {
        'login': document.getElementById('login').value,
        'password': document.getElementById('password').value
    };

    console.log(JSON.stringify(data))
    fetch(url, {
        method: "POST",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
        },
        body: JSON.stringify(data)
    })
        .then(response => response.json())
        .then(data => window.location.replace(data))
        .catch(error => console.error("error"));
}



function registerRequest() {
    /*   Remove this comments when moving to server
    $.post( "/login", function( data ) {
            if(data == 1){
                window.location.replace("/home");            
            } else {
                 shakeModal(); 
            }
        });
    */

    /*   Simulate error message from the server   */
    shakeModal();
}

function shakeModal() {
    $('#loginModal .modal-dialog').addClass('shake');
    $('.error').addClass('alert alert-danger').html("Invalid email/password combination");
    $('input[type="password"]').val('');
    setTimeout(function () {
        $('#loginModal .modal-dialog').removeClass('shake');
    }, 1000);
}


$(document).ready(function () {
    /*   Проверка авторизации   */

    var loginButton = document.getElementById('loginButton');
    var logoutButton = document.getElementById('logoutButton');

    // var user = {
    //     Login: "Juni",
    //     Password: "2034329"
    // };
    // var json = JSON.stringify(user);
    // var request = new XMLHttpRequest();
    // request.open("POST", "http://localhost:47109/account/login");
    // request.setRequestHeader('Content-type', 'application/json; charset=utf-8');
    // // request.onreadystatechange = function () {
    // //     if (request.readyState == 4 && request.status == 200)
    // //         document.getElementById("output").innerHTML = request.responseText;
    // // }
    // request.send(json);

    // loginButton.onclick = function(){
    //     loginButton.style.display = 'none';
    //     logoutButton.style.display = '';
    // }
    // logoutButton.onclick = function(){
    //     loginButton.style.display = '';
    //     logoutButton.style.display = 'none';
    // }
    openLoginModal();
});