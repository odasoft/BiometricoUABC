$(document).ready(function () {
    $('#findPerson').on("click", function () {
        console.log("Hello!");
        var names = "";
        if ($("#age").val())
            uri = 'http://localhost:1759/api/recognition/person' + '?Age=' + $("#age").val() + '&EyeColor=' + $("#eyecolor").val() + '&EyeType=' + $("#eyetype").val() + '&FaceColor=' + $("#facecolor").val() + '&FaceShape=' + $("#faceshape").val();
        else
            uri = 'http://localhost:1759/api/recognition/person' + '?EyeColor=' + $("#eyecolor").val() + '&EyeType=' + $("#eyetype").val() + '&FaceColor=' + $("#facecolor").val() + '&FaceShape=' + $("#faceshape").val();
        //uri = 'http://localhost:1759/api/recognition/person' + '?Age=' + $("#age").val() + '&EyeColor=' + $("#eyecolor").val();// + '&EyeType=' + $("#eyetype").val() + '&FaceColor=' + $("#facecolor").val() + '&FaceShape=' + $("#faceshape").val();
        console.log(uri);

        $.get(uri, function (person) {
            $(person).each(function (i, item) {
                console.log('<li>' + item.name + '</li>');
                names += item.name + "\n";
            });
            alert(names);
        });
        $(this).closest('form').find("input[type=text], textarea").val("");
        
        //console.log($("#eyecolor").val());
    });
});