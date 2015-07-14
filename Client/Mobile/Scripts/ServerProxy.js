var Proxy = {}

Proxy.StudentPickedUp = function (student)
{
    console.log("student was picked up ");
    console.log(student);
    console.log(teacher);
}

Proxy.GetStudentsList = function ()
{
    return DataBase.Students;
}

Proxy.GetGradeDivision = function()
{
    return DataBase.Grades;
}

Proxy.GetHealthIssues = function () {
    return DataBase.HealthIssues;
}

Proxy.GetClassesDivision = function () {
    return DataBase.Classes;
}

Proxy.IsTokenValid = function (uName, token)
{
    var Request =
       {
           UserName: uName,
           Token: token,
       };
    var json = JSON.stringify(Request);
    
    var UserLoginDetao = Proxy.SendRequest("/IsTokenValid", json, false, function(data){console.log(data)});
    return false;

}

Proxy.IsUserAuthenticated = function (uName, pass, callback, callbackSucess, callbackFail) {
    var Request =
        {
            UserName: uName,
            Password: pass,
        };
    var json = JSON.stringify(Request);
    Proxy.SendRequest("/LoginRequest", json, false, callback, callbackSucess, callbackFail);
    //return uName == 1 && pass == 1;
}

Proxy.SendRequest = function (url, json, isAsync, callBack, callbackSucess, callbackFail) {
    $.ajax({
        type: "POST",
        url: Config.ServerUrl + url,
        data: json,
        async:isAsync,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            console.log(data);
            //means request failed
            if (data == null) {
                callbackFail();
            }
                //sucess
            else {
                callBack(data)
                if (typeof callbackSucess != 'undefined' && callbackSucess != null)
                    callbackSucess();
            }
        },
        error: function (data) {
            console.log(data);
            alert("error in request");
        }
    });  

}

