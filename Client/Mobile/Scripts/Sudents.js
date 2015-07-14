var Student = {};
//take from db
Student.CurrentStudent = null;


Student.StudentPickedUpApproval = function (thisStudent, by, other) {
    console.log("student PickedUp");
    console.log(other);
    console.log(by);
    thisStudent.PickUp;
    thisStudent.PickUp.When = new Date().toLocaleTimeString().toString();
    if (by == 'otherPicker') {
        thisStudent.PickUp.ByWhom = other;
    }
    else
        thisStudent.PickUp.ByWhom = by;

    thisStudent.IsPickedUp = 'true';
    Proxy.StudentPickedUp(thisStudent);
    Student.MoveToStudentListPickUpTemplate();
    console.log(thisStudent);
}

Student.MoveToStudentListPickUpTemplate = function () {
    $("#PickUp").trigger("create");
    Student.UpdateStudentsLists();
    window.location.replace('#PickUp');
}

Student.SetCurrentStudentGeneric = function (thisStudent) {
    Student.CurrentStudent = thisStudent;
    console.log(Student.CurrentStudent);
}

Student.SetCurrentStudentHealth = function (thisStudent) {
    Student.SetCurrentStudentGeneric(thisStudent);
    $(".StudentFullInfoHealth").html("");
    $("#StudentHealthDetailsTemplate").tmpl(Student.CurrentStudent).appendTo(".StudentFullInfoHealth");
    $("#SudentInfoHealth").trigger("create");
    return false;
}
Student.SetCurrentStudent = function (thisStudent) {
    Student.SetCurrentStudentGeneric(thisStudent);
    $(".StudentFullInfo").html("");
    $("#StudentDetailsTemplate").tmpl(Student.CurrentStudent).appendTo(".StudentFullInfo");
    $("#SudentInfo").trigger("create");
    return false;
}

Student.UpdateStudentsLists = function () {
    $(".studentsList").empty();
    $("#StudentListPickUpTemplate").tmpl(Student.Students).appendTo(".studentsList");
    $(".studentsList").listview("refresh");
}

Student.GetGradesList = function ()
{
    var grades = Branch.GetGradesList();
    var tempGradesList = [];
    var gradesHistory = localStorage.getItem(Config.SelectedGrades).split(',');

    for (i = 0; i < grades.length; i++)
    {
        if (gradesHistory.indexOf(grades[i])>-1)
            tempGradesList.push(new OptionalGrades(grades[i], true))
        else 
            tempGradesList.push(new OptionalGrades(grades[i], false))
    }

    return tempGradesList;

}

Student.GetClassesList = function () {
    var classes = Branch.GetClassesList();
    var tempClassesList = [];
    var classesHistory = localStorage.getItem(Config.SelectedClass).split(',');

    for (i = 0; i < classes.length; i++) {
        if (classesHistory.indexOf(classes[i]) > -1)
            tempClassesList.push(new OptionalClasses(classes[i], true))
        else
            tempClassesList.push(new OptionalClasses(classes[i], false))
    }

    return tempClassesList;

}

Student.UpdateStudentsData = function () {
    Student.GradesList = Branch.GetGradesList();
    Student.ClassesList = Branch.GetClassesList();
    Student.HealthIssues = Branch.GetHealthIssues();
    Student.Students = Branch.GetStudentsList();
};
//Student.UpdateStudentsData();

$(function () {
    $("input[name='cbGradeSelected'], input[name='cbClassesSelected']").on('change', Student.FilterChanged);

    
    $("#btnPickUpShowAllStudents").on('click', function ()
    {
        $("input[name='cbGradeSelected'], input[name='cbClassesSelected']").each(function () {
            $(this).prop('checked', true);
            $(this).checkboxradio("refresh")
        });
        
        $('input[data-type="search"]').val('');
        $('input[data-type="search"]').trigger("keyup");
         
        Student.FilterChanged();
    });

});

Student.FilterChanged = function () {
    var SelectedClass = [];
    var SelectedGrades = [];
    $('input[name="cbGradeSelected"]:checked').each(function () {
        SelectedGrades.push($(this).val());
    });
    $('input[name="cbClassesSelected"]:checked').each(function () {
        SelectedClass.push($(this).val());
    });

    var pickUplistviewChildren = $('.studentsList').children();
    $.each(pickUplistviewChildren, function (i, val) {
        var tempItem = $(val).find("a");
        if (tempItem.length > 0) {
            var sCls = $(tempItem).data('sclass').toString();
            var grd = $(tempItem).data('grade');
            if (SelectedGrades.indexOf(grd) > -1
               && SelectedClass.indexOf(sCls) > -1) {
                $(val).removeClass("ui-hidden-component");
            }
            else
                $(val).addClass("ui-hidden-component");
        }

    });
    localStorage.setItem(Config.SelectedGrades, SelectedGrades);
    localStorage.setItem(Config.SelectedClass, SelectedClass);

    
    var classes = localStorage.getItem(Config.SelectedClass).split(',');
    var grades = localStorage.getItem(Config.SelectedGrades).split(',');


};
Student.UpdateGradesByLocalStorage = function (filterItem,takeClass)
{
    var valueFromLocalStorage = "SelectedGrades";
    if (takeClass)
        valueFromLocalStorage = "SelectedClass";

    //check if exists first
    var storageArray = localStorage.getItem(valueFromLocalStorage).split(',');
    //$('input[name="cbGradeSelected"]:checked').each(function (index,val) {
        //measne not in the array so un check it
        //if (grades.indexOf(val) < 0)
        //{
            //console.log(val);
            //console.log($(val));

            //$(val).prop('checked', false);
             
        //}
    //});

    if (storageArray.indexOf(filterItem.data) > -1)
        return true;
    return false;

};

Student.ApprovedClicked = function (selector)
{
    $(selector).prop('checked', true);
}




function htmlDetail(data) { data.bla = "true"; console.log("****"); console.log(data); }

//comment out code

//overide the filter
//$(document).delegate('[data-role="page"]', 'pageinit',
//      function () {
//          var $listview = $(this).find('[data-role="listview"][data-filter="true"]');
//          $(this).delegate('input[data-type="search"]', 'keyup change',
//            function () {
//                var SelectedClass = [];
//                var SelectedGrades = [];
//                var TempChecked = $('input[name="checkboxGradeGan"]:checked').each(function () {
//                    SelectedGrades.push($(this).val());
//                });
//                TempChecked = $('input[name="cbClassesSelected"]:checked').each(function () {
//                    SelectedClass.push($(this).val());
//                });

//                var $this = $(this);
//                if ($this.val() == '') {
//                    $listview.children().removeClass("ui-hidden-component");
//                } else {

//                    if (SelectedGrades.indexOf($this.grade) > -1
//                        && SelectedClass.indexOf($this.sClass) > -1)

//                  gshhi");
//                }
//            });
//          //if ($('input[data-type="search"]').val() == '') {
//              //$listview.children().addClass("ui-hidden-component");
//          //}
//      });
