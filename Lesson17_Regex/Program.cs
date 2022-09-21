using System.Net.Mail;
using System.Text.RegularExpressions;


#nullable disable



// [abc]
// [a-d]
// ^Kamran.*([2][3-4])$

// string pattern = @"he..o";
// string text = "hello";
// 
// // var regex = new Regex(pattern);
// // Console.WriteLine(regex.IsMatch(text));
// 
// 
// Console.WriteLine(Regex.IsMatch(text, pattern));






// string pattern = "(Mr\\.? |Mrs\\.? |Miss |Ms\\.? )";
// string[] names = { "Mr. Henry Hunt", "Ms. Sara Samuels",
//                          "Abraham Adams", "Ms. Nicole Norris" };
// 
// foreach (string name in names)
//     Console.WriteLine(Regex.Replace(name, pattern, string.Empty));




// string pattern = @"[a-z0-9]+@[a-z]+\.[a-z]{2,3}";
// Console.WriteLine(Regex.IsMatch("dsadsfd@gmail.ru", pattern));





try
{
    MailAddress mailAddress = new("miri@mail.ru");
    Console.WriteLine("True");
}
catch (Exception)
{
    Console.WriteLine("False");
}