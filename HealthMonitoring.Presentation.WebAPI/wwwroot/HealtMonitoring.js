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

function closeLoginModal() {
    showLoginForm();
    setTimeout(function () {
        $('#loginModal').modal('hide');
    }, 230);
}

function openRegisterModal() {
    showRegisterForm();
    setTimeout(function () {
        $('#loginModal').modal('show');
    }, 230);

}

function loginRequest() {
    var loginButton = document.getElementById('loginButton');
    var logoutButton = document.getElementById('logoutButton');

    var url = "http://localhost:47109/Account/Login";
    const data = {
        Login: document.getElementById('login').value,
        Password: document.getElementById('password').value
    };
    console.log(JSON.stringify(data))
    fetch(url, {
        method: "POST",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    })
        .then(response => {
            if (response.ok) {
                loginButton.style.display = 'none';
                logoutButton.style.display = '';
                closeLoginModal();
            } else {
                response.json().then(data => shakeModal(data.msg));
            }
        })
        .catch(error => shakeModal(error));
}

function logoutRequest() {
    var loginButton = document.getElementById('loginButton');
    var logoutButton = document.getElementById('logoutButton');

    var url = "http://localhost:47109/Account/Logout";

    fetch(url, {
        method: "GET",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }
    })
        .then(response => {
            if (response.ok) {
                loginButton.style.display = '';
                logoutButton.style.display = 'none';
            }
        })
        .catch(error => alert(error));
}

function registerRequest() {
    var loginButton = document.getElementById('loginButton');
    var logoutButton = document.getElementById('logoutButton');

    var url = "http://localhost:47109/Account/Register";
    const data = {
        Login: document.getElementById('registerLogin').value,
        Password: document.getElementById('registerPassword').value
    };
    console.log(JSON.stringify(data))
    fetch(url, {
        method: "POST",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    })
        .then(response => {
            if (response.ok) {
                loginButton.style.display = 'none';
                logoutButton.style.display = '';
                closeLoginModal();
            } else {
                response.json().then(data => shakeModal(data));
            }
        })
        .catch(error => shakeModal(error));
}

function allCopletedExercises() {
    var url = "http://localhost:47109/Activity/GetAllCompletedExercises";
    var tbody = document.getElementById('exerciseTable');
    fetch(url, {
        method: "GET",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }
    })
        .then(response => response.json())
        .then(data => {
            data.forEach((n, index) => {
                console.log(n);
                var row = document.createElement("TR");
                var td1 = document.createElement("TD");
                var td2 = document.createElement("TD");
                var td3 = document.createElement("TD");
                var td4 = document.createElement("TD");
                var td5 = document.createElement("TD");
                var td6 = document.createElement("TD");

                td1.append(document.createTextNode(index+1));                
                td2.append(document.createTextNode(n.exercise));
                td3.append(document.createTextNode(n.expendedTime));
                td4.append(document.createTextNode(n.distanceTraveled));
                td5.append(document.createTextNode(n.expendedCalories));
                td6.append(document.createTextNode(n.date));

                row.append(td1,td2,td3,td4,td5,td6);
                tbody.append(row);

            })
        })
        .catch(error => alert(error));
}

function allExercises() {
    var url = "http://localhost:47109/Activity/GetExercises";
    var exercisesSelect = document.getElementById('exercisesSelect');
    fetch(url, {
        method: "GET",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }
    })
        .then(response => response.json())
        .then(data => {
            data.forEach((n, index) => {
                exercisesSelect.appendChild(new Option(n.name, n.name));
            })
        })
        .catch(error => alert(error));
}

function addCopletedExercise() {
    var exercise = document.getElementById('exercisesSelect').value;
    var date = document.getElementById('dateSelect').value;
    var time = document.getElementById('expendedTime').value;
    var distance = document.getElementById('distanceTraveled').value;

    var url = "http://localhost:47109/Activity/AddCompletExercise";
    const data = {
        UserLogin: "ff",
        Exercise: exercise,
        Date: date,
        ExpendedTime: time,
        DistanceTraveled: distance,
        ExpendedCalories: 0
    };
    console.log(JSON.stringify(data))
    fetch(url, {
        method: "POST",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    })
        .then(response => {
            if (response.ok) {
                console.log("ok");
            } else {
                response.json().then(data => console.log(data));
            }
        })
        .catch(error => shakeModal(error));
}

function allEatenDishes() {
    var url = "http://localhost:47109/Dish/GetAllEatenDishes";
    var tbody = document.getElementById('dishesTable');
    fetch(url, {
        method: "GET",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }
    })
        .then(response => response.json())
        .then(data => {
            data.forEach((n, index) => {
                console.log(n);
                var row = document.createelement("tr");
                var td1 = document.createelement("td");
                var td2 = document.createelement("td");
                var td3 = document.createelement("td");
                var td4 = document.createelement("td");
                var td5 = document.createelement("td");

                td1.append(document.createtextnode(index + 1));
                td2.append(document.createtextnode(n.name));
                td3.append(document.createtextnode(n.weight));
                td4.append(document.createtextnode(n.calories));
                td5.append(document.createtextnode(n.date));

                row.append(td1, td2, td3, td4, td5);
                tbody.append(row);
            })
        })
        .catch(error => alert(error));
}

function allDishes() {
    var url = "http://localhost:47109/Dish/GetDishes";
    var dishSelect = document.getElementById('dishSelect');
    fetch(url, {
        method: "GET",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }
    })
        .then(response => response.json())
        .then(data => {
            data.forEach((n, index) => {
                dishSelect.appendChild(new Option(n.name, n.name));
            })
        })
        .catch(error => alert(error));
}

function shakeModal(data) {
    $('#loginModal .modal-dialog').addClass('shake');
    $('.error').addClass('alert alert-danger').html(data);
    $('input[type="password"]').val('');
    setTimeout(function () {
        $('#loginModal .modal-dialog').removeClass('shake');
    }, 1000);
}


$(document).ready(function () {
        allCopletedExercises();
        allExercises();
        $("#exerciseInput").on("keyup", function () {
            var value = $(this).val().toLowerCase();
            $("#exerciseTable tr").filter(function () {
                $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
            });
        });
});