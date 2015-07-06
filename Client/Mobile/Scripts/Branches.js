var Branch = {};
Branch.BranchesData = null;
Branch.FillBranchData = function ()
{
    var LastSyncTime = 0;// new Date(2000, 1);
    var Token = Authentication.GetToken();
    var Request =
        {
            LastSyncTime: LastSyncTime,
            Token: Token,
        };
    var json = JSON.stringify(Request);
    Branch.BranchesData = Proxy.SendRequest("/GetBranchInfo", json, false,Branch.CallCompleted);
    console.log("Branch.BranchesData ");
    console.log(Branch.BranchesData);

}
Branch.CallCompleted = function (data)
{
    console.log(data);
    if (data == null)
        console.error("data is null");
    else
        DataBase.Students = data[0].StudentsList;
}