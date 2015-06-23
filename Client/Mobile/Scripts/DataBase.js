var DataBase = {};
DataBase.Students = [
         {
             studentID: 1,
             img: "http://zizaza.com/cache/big_thumb/iconset/166245/46642/PNG/256/oxygen/software_application_app_mail_email_contact_user_person_customer_face_prefs_preferences_desktop_desk_apps.png",
             firstName: "aLlily",
             lastName: "Ziegler",
             grade: "D", sClass: "5",
             pickUpFrom: "Yard", healthIssues: "glueten,sugar",
             checkedIn: [{ byWhom: "", when: "" }],
             pickUp: { byWhom: "", when: "" },
             pickUpOptions: [{ byWhom: "a2" }, { byWhom: "a4" }, { byWhom: "a5" }],
             isPickedUp: 'false',

         },
           {
               studentID: 2,
               img: "http://zizaza.com/cache/big_thumb/iconset/166245/46642/PNG/256/oxygen/software_application_app_mail_email_contact_user_person_customer_face_prefs_preferences_desktop_desk_apps.png",
               firstName: "bLily",
               lastName: "Ziegler",
               grade: "A", sClass: "1",
               pickUpFrom: "Yard", healthIssues: "",
               pickUp: { byWhom: "", when: "" },
               checkedIn: [{ byWhom: "", when: "" }],
               pickUpOptions: [{ byWhom: "" }, { byWhom: "" }, { byWhom: "" }],
               isPickedUp: 'false'
           },
           ,
{
    studentID: 12,
    img: "http://zizaza.com/cache/big_thumb/iconset/166245/46642/PNG/256/oxygen/software_application_app_mail_email_contact_user_person_customer_face_prefs_preferences_desktop_desk_apps.png",
    firstName: "cLily",
    lastName: "Ziegler",
    grade: "A", sClass: "1",
    pickUpFrom: "Yard", healthIssues: "glueten,sugar,b",
    checkedIn: [{ byWhom: "", when: "" }],
    pickUp: { byWhom: "", when: "" },
    pickUpOptions: [{ byWhom: "" }, { byWhom: "" }, { byWhom: "" }],
    isPickedUp: 'false'
},
           ,
{
    studentID: 11,
    img: "http://zizaza.com/cache/big_thumb/iconset/166245/46642/PNG/256/oxygen/software_application_app_mail_email_contact_user_person_customer_face_prefs_preferences_desktop_desk_apps.png",
    firstName: "dLily",
    lastName: "Ziegler", sClass: "1",
    grade: "B", healthIssues: "glueten,sugar,a",
    pickUpFrom: "Yard",
    checkedIn: [{ byWhom: "", when: "" }],
    pickUp: { byWhom: "", when: "" },
    pickUpOptions: [{ byWhom: "" }, { byWhom: "" }, { byWhom: "" }],
    isPickedUp: 'false'
},
           ,
{
    studentID: 111,
    img: "http://zizaza.com/cache/big_thumb/iconset/166245/46642/PNG/256/oxygen/software_application_app_mail_email_contact_user_person_customer_face_prefs_preferences_desktop_desk_apps.png",
    firstName: "dLily",
    lastName: "Ziegler", sClass: "3",

    grade: "A", healthIssues: "glueten",
    pickUpFrom: "Yard",
    checkedIn: [{ byWhom: "", when: "" }],
    pickUp: { byWhom: "", when: "" },
    pickUpOptions: [{ byWhom: "" }, { byWhom: "" }, { byWhom: "" }],
    isPickedUp: 'false'
},
           ,
{
    studentID: 13,
    img: "http://zizaza.com/cache/big_thumb/iconset/166245/46642/PNG/256/oxygen/software_application_app_mail_email_contact_user_person_customer_face_prefs_preferences_desktop_desk_apps.png",
    firstName: "zLily",
    lastName: "Ziegler",
    sClass: "2",
    grade: "A", healthIssues: "sugar",
    pickUpFrom: "Yard",
    checkedIn: [{ byWhom: "", when: "" }],
    pickUp: { byWhom: "", when: "" },
    pickUpOptions: [{ byWhom: "" }, { byWhom: "" }, { byWhom: "" }],
    isPickedUp: 'true'
},
];

DataBase.Grades = ['GAN', 'A', 'B', 'C', 'D'];
DataBase.Classes = ['1', '2', '3', '4', '5'];
DataBase.HealthIssues = ['Gluten', 'Sugar'];