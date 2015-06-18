$(document).ready(function () {
    $('#savePerson').on("click", function () {
        console.log("Hello!");

        $.post("http://localhost:1759/api/recognition/person/",
              $("#savePersonForm").serialize(),
              function (value) {
                  console.log(value);
                  
                  $('#name').append('<li>' + value.name + '</li>');
                  $('#age').append('<li>' + value.age + '</li>');
                  $('#eyecolor').append('<li>' + value.eyecolor + '</li>');
                  $('#eyetype').append('<li>' + value.eyetype + '</li>');
                  $('#facecolor').append('<li>' + value.facecolor + '</li>');
                  $('#faceshape').append('<li>' + value.faceshape + '</li>');
                  
                  
              },
              "json"
        );

        $(this).closest('form').find("input[type=text], textarea").val("");

        alert("Success");
    });
});