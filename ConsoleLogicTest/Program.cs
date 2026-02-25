// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

//Console.WriteLine("Enter a number");

//Console.WriteLine(Login());

//string Login()
//{
//    return "Called from method";
//}

var c = new Dog();
c.Validate("vamshi");
c.Validate("vamshi",28);

Console.ReadLine();


//  Method Overload
public class Dog
{
    public string Name { get; set; }
    public string Validate(string name)
    {
        return "1st method";
    }
    public string Validate(string name,int age)
    {
        return "1st method";
    }
}