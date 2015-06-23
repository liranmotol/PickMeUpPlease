var Student = {};
//take from db
Student.CurrentStudent = null;


//Student.StudentPickedUpApproval = function (thisStudent, other, by) {
Student.StudentPickedUpApproval = function (thisStudent, by, other) {
    console.log("student PickedUp");
    //console.log(thisStudent);
    console.log(other);
    console.log(by);
    thisStudent.pickUp.when = new Date().toLocaleTimeString().toString();
    if (by == 'otherPicker') {
        thisStudent.pickUp.byWhom = other;
    }
    else
        thisStudent.pickUp.byWhom = by;

    thisStudent.isPickedUp = 'true';
    Proxy.StudentPickedUp(thisStudent);
    Student.MoveToStudentListPickUpTemplate();
    console.log(thisStudent);
    //thisStudent.pickUp.byWhom = 
}

Student.MoveToStudentListPickUpTemplate = function () {
    //$("#PickUp").html("");
    //$("#StudentListPickUpTemplate").tmpl(Student.Students).appendTo(".studentsList");
    $("#PickUp").trigger("create");
    Student.UpdateStudentsLists();
    window.location.replace('#PickUp');
}

Student.SetCurrentStudent = function (thisStudent) {
    Student.CurrentStudent = thisStudent;
    console.log(Student.CurrentStudent);
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

Student.GradesList = Proxy.GetGradeDivision();
Student.ClassesList = Proxy.GetClassesDivision();
Student.HealthIssues = Proxy.GetHealthIssues();
Student.Students = Proxy.GetStudentsList();

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

//                    $listview.children().addClass("ui-hidden-component");
//                }
//            });
//          //if ($('input[data-type="search"]').val() == '') {
//              //$listview.children().addClass("ui-hidden-component");
//          //}
//      });


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
};



function htmlDetail(data){console.log(data);}