public class Person
{
    private readonly Firstname Firstname;
    private readonly Lastname Lastname;

    public Person(Firstname firstname, Lastname lastname)
    {
        Firstname = firstname ?? throw new ArgumentNullException(nameof(firstname));
        Lastname = lastname ?? throw new ArgumentNullException(nameof(lastname));
    }

    public string GetFirstname() => Firstname.GetValue();

    public string GetLastname() => Lastname.GetValue();

}
