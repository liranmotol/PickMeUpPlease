//for tests only
$(function() {
    //Student.CurrentStudent = Student.Students[0];
    //Student.SetCurrentStudent(Student.CurrentStudent);
    //get from local storage pick up filter values
});


if (Authentication.IsUserLoggedIn()) {
    if (window.location.pathname.indexOf("Main.html") < 0)
        window.location.replace("/Main.html#MainMenu");
}
