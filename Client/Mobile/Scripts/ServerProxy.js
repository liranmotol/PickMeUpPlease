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
    return uName == 1 && token == "true";
}

Proxy.IsUserAuthenticated = function (uName, pass) {
    return uName == 1 && pass == 1;
}

