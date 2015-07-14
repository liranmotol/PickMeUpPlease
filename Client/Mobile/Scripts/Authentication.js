var Authentication = {};

Authentication.Token = null;

Authentication.IsUserLoggedIn = function () {
    var uName = localStorage.getItem(Config.UserName);
    var token = localStorage.getItem(Config.Token);
    var logedTime = localStorage.getItem(Config.LoginTime);


    if (typeof uName != 'undefined' && uName != null
                 && typeof token != 'undefined' && token != null
                 && typeof logedTime != 'undefined' && logedTime != null) {
        console.log(Date.parse(logedTime));
        console.log(new Date() - Date.parse(logedTime));

        return ((new Date() - Date.parse(logedTime)) / 1000 / 60 / 60 < 12);
    }

    return false;
};

Authentication.SetUserToken = function (loginResponse) {
    console.log(loginResponse);
    if (loginResponse != null) {
        Authentication.SetUserPassToken(loginResponse.UserName, loginResponse.Password, loginResponse.Token)
        // window.location.replace("http://localhost:37985/Main.html");
        Authentication.Token = loginResponse.Token;
        //localStorage.setItem(Config.Token, token);
    }

}
Authentication.IsUserTokenAuthenticated = function (userName, token) {
    if (Proxy.IsTokenValid(userName, token)) {
        return true;
    }
    else {
        //window.location.replace("/Login.html");
        return false;
    }
}

Authentication.IsUserPassAuthenticated = function (userName, pass, callbackSucess, callbackFail) {
    //send request to proxy, if sucesss activate Authentication.SetUserToken, callbackSucess functions.
    //fail will execute callbackFail
    Proxy.IsUserAuthenticated(userName, pass, Authentication.SetUserToken, callbackSucess, callbackFail);

}

Authentication.GetUserName = function () {
    var uName = localStorage.getItem(Config.UserName);
    return uName;
}

Authentication.GetToken = function () {
    if (Authentication.Token == null)
        Authentication.Token = localStorage.getItem(Config.Token);
    return Authentication.Token;
}


Authentication.GetPassword = function () {
    var pass = localStorage.getItem(Config.Password);
    return pass;

}

Authentication.SetUserPassToken = function (user, pass, token) {
    localStorage.setItem(Config.UserName, user);
    if (typeof pass != 'undefined')
        localStorage.setItem(Config.Password, pass);
    localStorage.setItem(Config.Token, token);
    localStorage.setItem(Config.LoginTime, new Date());
}

Authentication.CleanLocalStorage = function () {
    //localStorage.removeItem(Config.UserName);
    //localStorage.removeItem(Config.Password);
    localStorage.removeItem(Config.Token);
}

Authentication.GoToLogin = function () {
    window.location.replace("/login.html");
}
Authentication.GoToApp = function () {
    window.location.replace("/main.html#MainMenu");
}