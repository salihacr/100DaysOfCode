// Functions

$('#getJson').click(function (event) {
    $.getJSON('./data.json', function (data) {
        let persons = data.person;
        persons.forEach(person => {
            $('#jsonOutput').append('<li>Name : ' + person.name + ', Age : ' + person.age + '</li>');
        });

    })
});

$('#getApi').click(function (event) {
    $('#loader').show();
    setTimeout(() => {
        $('#loader').hide();
        $.getJSON('https://api.github.com/users', function (data) {
            let users = data;
            users.forEach(user => {
                $('#apiOutput').append('<li>Name : ' + user.login + '</li>');
            });
        })
    }, 1500);
});