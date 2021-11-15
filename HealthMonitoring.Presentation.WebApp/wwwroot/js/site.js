// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener("DOMContentLoaded", function (event) {

    const showNavbar = (toggleId, navId, bodyId, headerId) => {
        const toggle = document.getElementById(toggleId),
            nav = document.getElementById(navId),
            bodypd = document.getElementById(bodyId),
            headerpd = document.getElementById(headerId)

        // Validate that all variables exist
        if (toggle && nav && bodypd && headerpd) {
            toggle.addEventListener('click', () => {
                // show navbar
                nav.classList.toggle('show')
                // change icon
                toggle.classList.toggle('bx-x')
                // add padding to body
                bodypd.classList.toggle('body-pd')
                // add padding to header
                headerpd.classList.toggle('body-pd')
            })
        }
    }

    showNavbar('header-toggle', 'nav-bar', 'body-pd', 'header')

    /*===== LINK ACTIVE =====*/
    const linkColor = document.querySelectorAll('.nav_link')

    function colorLink() {
        if (linkColor) {
            linkColor.forEach(l => l.classList.remove('active'))
            this.classList.add('active')
        }
    }
    linkColor.forEach(l => l.addEventListener('click', colorLink))
        
    function ReloadPage() {
        window.location.reload();
    }


    // Your code to run since DOM is loaded and ready
});


jQuery(document).ready(function () {
    var products = [];
    $("#exerciseInput").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#exerciseTable tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });

    $("#productInput").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#sse *").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });

    $('#product-add-button').click(function () {
        var select = document.getElementById('products');
        var selectCount = select.children.length;
        const pp = [];
        for (var i = 0; i < selectCount; i++) {
            pp.push(select.children[i].value);
        }
        
        var product = document.getElementById('prod').value;
        var weight = document.getElementById('weight').value;
        var isIncludProduct = pp.includes(product);

        if (weight != "" && isIncludProduct) {
            products.push({ Name: product, Weight: weight });
            $('#sse').append('<li>' + product + '</li>');
        } else if (weight == "") {
            alert("Enter product weight");
        } else {
            alert("Choose a product from the list");
        }
    });
    $('#create-recept-button').click(function () {
        var receptname = document.getElementById('receptName').value;
        if (receptname != "" && products.length > 0) {
            $.post("/Recept/Create", {
                products: products,
                receptName: receptname
            });
            alert("Recipe successfully added");
            window.location.reload();
        } else if (products.length == 0) {
            alert("You have't added any products");
        } else {
            alert("Typing the recept name");
        }
    });

    $('#yearSelect').change(function () {
        debugger;
        var year = document.getElementById('yearSelect').value;
        var chart = new CanvasJS.Chart("chartContainer", {
            animationEnabled: true,
            theme: "light2", // "light1", "dark1", "dark2"
            exportEnabled: false,
            title: {
                text: "Received calories in " + year
            },
            data: [{
                type: "column",
                dataPoints: model[0][year]
            }]
        });
        chart.render();
    });
    $('#yearSelect2').change(function () {
        debugger;
        var year = document.getElementById('yearSelect2').value;
        var chart = new CanvasJS.Chart("chartContainer2", {
            animationEnabled: true,
            theme: "light2", // "light1", "dark1", "dark2"
            exportEnabled: false,
            title: {
                text: "Expended calories in " +  year
            },
            data: [{
                type: "column",
                dataPoints: model[1][year]
            }]
        });
        chart.render();
    });
        
        
    /*});*/
});


