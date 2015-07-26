var Branch = {};
Branch.BranchesData = null;
Branch.CurrentBranch = null;
Branch.FillBranchData = function (token, callBackContinueLoading)
{
    var LastSyncTime = 0;// new Date(2000, 1);
    var Request =
        {
            LastSyncTime: LastSyncTime,
            Token: token,
        };
    var json = JSON.stringify(Request);
    Proxy.SendRequest("/GetBranchInfo", json, false, Branch.CallCompleted, callBackContinueLoading, Authentication.GoToLoginOveride);
    
}

Branch.CallCompleted = function (data)
{
    
    console.log(data);
    if (data == null) {
        console.error("data is null");
        alert("Error in App, please login again");
    }
    else if (data.length == 0) 
        {
            console.error("no branched to show");
            alert("Error in App, no branched to show");
    }
    else {
        Branch.BranchesData = data;
        var defualtBranchId = localStorage.getItem(Config.DefualtBranchId);
        if (defualtBranchId != null && typeof defualtBranchId != 'undefined') {
            for (i = 0; i < Branch.BranchesData.Branches.length; i++) {
                if (Branch.BranchesData.Branches[i].Id == defualtBranchId) {
                    Branch.CurrentBranch = Branch.BranchesData.Branches[i];
                    break;
                }
            }
        }
        else {
            Branch.CurrentBranch = Branch.BranchesData.Branches[0];
        }
        //callBackContinueLoading();
      
    }
}

Branch.GetStudentsList = function ()
{
    if (Branch.CurrentBranch!=null)
        return Branch.CurrentBranch.StudentsList;
    return null;
}
Branch.GetHealthIssues = function ()
{
    if (Branch.CurrentBranch != null)
        return Branch.CurrentBranch.OptionalHealthIssues;
    return null;
}
Branch.GetClassesList = function ()
{
    if (Branch.CurrentBranch != null) {
        return Branch.CurrentBranch.OptionalClasses;
    }
    return null;
}
Branch.GetGradesList = function ()
{
    if (Branch.CurrentBranch != null) {
        return Branch.CurrentBranch.OptionalGrades;
    }
    return null;
}