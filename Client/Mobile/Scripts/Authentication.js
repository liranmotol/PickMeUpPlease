var Authentication = {};
Authentication.UserLoggedIn = false;
Authentication.IsUserLoggedIn = function () {
    if (Authentication.UserLoggedIn)
        return true;

    var pass= localStorage.getItem(Config.Password);
    var uName = localStorage.getItem(Config.UserName);
    var token = localStorage.getItem(Config.Token);
    var LoginTime = localStorage.getItem(Config.LoginTime);


    if (Proxy.IsTokenValid(uName, token)) {
        Authentication.UserLoggedIn = true;
        return true;
    }
    else
    {
        //window.location.replace("/Login.html");
        return false;
    }
};



Authentication.IsUserAuthenticated = function (userName, pass)
{
    var token = Proxy.IsUserAuthenticated(userName, pass);
    if (token != null) {
        Authentication.UserLoggedIn = true;
        Authentication.SetUserPassToken(userName, pass, token)
       // window.location.replace("http://localhost:37985/Main.html");
        return true;
    }
    return false;
}

Authentication.GetUserName= function ()
{
    var uName = localStorage.getItem(Config.UserName);
    return uName;
}
Authentication.GetPassword = function ()
{
    var pass = localStorage.getItem(Config.Password);
    return pass;

}

Authentication.SetUserPassToken = function (user,pass,token)
{
    localStorage.setItem(Config.UserName, user);
    localStorage.setItem(Config.Password, pass);
    localStorage.setItem(Config.Token, token);
    localStorage.setItem(Config.LoginTime, new Date().getDay());



}