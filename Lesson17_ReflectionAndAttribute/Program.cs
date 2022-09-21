#define Debug
#undef Debug

#nullable disable



using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;


namespace Lesson17_ReflectionAndAttribute;




// Pre-defiend attributes
// Custom attributes




// [Obsolete]
// [Conditional]
// [CallerArgumentExpression] (C# 10)
// [CallerMemberName]


[Obsolete("Kohnelmish, bunun evezin ...")]
class Student
{
    [ColumName("Identification")]
    public int Id { get; set; }
    

    public string Name { get; set; }

    [Obsolete("Kohnelmish, bunun evezin ...", true)]
    public string Surname { get; set; }

    public Student()
    {
        Console.WriteLine("ctor");
    }
}


struct Location : INotifyPropertyChanged
{
    public double Longitude { get; set; }
    public double Latitude { get; set; }

    private int _id;

    public int Id
    {
        get { return _id; }
        set
        {
            _id = value;
            NotifyPropertyChanged();
        }
    }




    public event PropertyChangedEventHandler PropertyChanged;

    private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
    {
        Console.WriteLine(propertyName);
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }


    [Conditional("Debug")]
    public void Display()
    {
        Console.WriteLine(Longitude);
        Console.WriteLine(Latitude);
    }
}





[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
class ColumNameAttribute : Attribute
{
    public string PropertyName { get; }

    public ColumNameAttribute(string propertyName)
    {
        PropertyName = propertyName;
    }
}







class Program
{
    static void Write(object obj, [CallerArgumentExpression("obj")] string msj = null)
    {
        Console.WriteLine($"Expression: {msj}");
    }

    static void Main()
    {
        #region Pre-defiend attributes

        //// Obsolete
        // Student student = new Student() {};
        // // Console.WriteLine(student.Id);




        //// Conditional
        // Location loc = new();
        // loc.Display();






        // // CallerArgumentExpression
        // 
        // Write(new object());
        // Write("Hello World");
        // Write(42 + 42 + 42);
        // Write(() => { });
        // 
        // int i = 10;
        // Write(i);
        #endregion




        #region Custom attribute

        var properties = typeof(Student).GetProperties();

        foreach (var property in properties)
        {
            if (property.IsDefined(typeof(ColumNameAttribute)))
                Console.WriteLine(property.GetCustomAttribute<ColumNameAttribute>().PropertyName);
            else
                Console.WriteLine(property.Name);
        }
        #endregion






        #region Reflection
        // Assembly assembly = Assembly.GetExecutingAssembly();
        // var types = assembly.GetTypes();
        // 
        // // assembly.CreateInstance(types[0].FullName);
        // 
        // foreach (var type in types)
        // {
        //     Console.WriteLine(type.Name);
        //     Console.WriteLine(type.IsPublic);
        // 
        //     // Console.WriteLine(type.FullName);
        // 
        //     foreach (var propInfo in type.GetProperties())
        //     {
        //         Console.WriteLine(propInfo.Name);
        //     }
        // }
        #endregion
    }
}