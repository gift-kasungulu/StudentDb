
DataAccessLayer obj = new DataAccessLayer();
Console.WriteLine("******************************************************************************");
Console.WriteLine("WELCOME TO STUDENT REGISTRATION, PLEASE CHOOSE AN OPTION");
Console.WriteLine("******************************************************************************");
Console.WriteLine("1. View Registered Student");
Console.WriteLine("2. View The Registered Courses");
Console.WriteLine("3. Add New Student");
Console.WriteLine("4. Add New Courses");
Console.WriteLine("5. update to Student");
Console.WriteLine("6. update to Courses");
Console.WriteLine("7. Delete from Student");
Console.WriteLine("8. Delete from Courses");
var input = Convert.ToInt32(Console.ReadLine());
Console.Clear();

if(input==1){
     obj.GetStudent();
}else if(input==2){
    obj.GetCourses();
}else if(input==3){
    obj.insertvalueTOStudent();
}else if(input==4){
    obj.insertvalueTOCourses();
}else if(input==5){
    obj.updatestudent();
}else if(input==6){
    obj.updateCourses();
}else if(input==7){
    obj.Deletestudent();
}else if(input==8){
    obj.Deletecourse();
}else{
    Console.WriteLine("invalid option!! ");
}
