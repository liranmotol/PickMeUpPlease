using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
   public class StudentsModel
    {
public string       studentID;
public string             img;
public string             firstName;
public string             lastName;
public string        grade; 
public string       sClass;
public string       pickUpFrom;
public string       healthIssues;
public CeckedInOutModel  checkedIn;
public CeckedInOutModel pickUp;
public List<string>  pickUpOptions;
public bool        isPickedUp;
public  string      parent1Name;
public  string      parent1Num;
public  string      parent2Name;
public  string      parent2Num;

    }

public class CeckedInOutModel
{
 public  string   byWhom;
 public string when;
}



}
