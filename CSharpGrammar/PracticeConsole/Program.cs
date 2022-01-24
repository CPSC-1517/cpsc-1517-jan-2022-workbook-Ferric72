using PracticeConsole.Data; //gives reference to the location of classes
                            //  within the specified namespace
                            //this allows the developer to avoid having to
                            //  use a fully qualified name every time a
                            //  reference is made to a class in the namespace
using System; //in  .net 6 some using statements visible in .net 5 are
              //are already implemented in the project and do not
              //need to be explicitly coded.

              //there will be times that you will still need to code
              //using statements to explicitly reference other namespaces

// See https://aka.ms/new-console-template for more information
DisplayString("Hello World!");

//Fully qualified name:
//PracticeConsole.Data.Employment job = CreateJob();
Employment Job = CreateJob();
ResidentAddress Address = CreateAddress();

//create a Person
Person Me = CreatePerson(Job, Address);
if (Me != null)
DisplayPerson(Me);

static void DisplayString(string text)
{
    Console.WriteLine(text);
}

static void DisplayPerson(Person person)
{
    DisplayString($"{person.FirstName} {person.LastName}");
    DisplayString($"{person.Address.ToString()}");
    foreach(var emp in person.EmploymentPositions)
    {
        DisplayString($"{emp.ToString()}");
    }
}

Employment CreateJob()
{
    Employment Job = null; //a reference to a variable capable of holding an
                    //instance of Employment
                    //its initial value will be null
    try
    {
        Job = new Employment();
        DisplayString($"good job {Job.ToString()}");
       
        Job = new Employment("Boss", SupervisoryLevel.Supervisor, 5.5);
        DisplayString($"greedy good job {Job.ToString}");

        //checking exceptions
        //bad data: title
        //Job = new Employment("", SupervisoryLevel.Supervisor, 5.5);
        //bad data: level
        Job = new Employment("Boss", SupervisoryLevel.Supervisor, -5.5);
    }
    catch (ArgumentException ex) //specific exception message
    {
        DisplayString(ex.Message);
    }
    catch (Exception ex) //general catch all
    {
        DisplayString("Run time error: " + ex.Message);
    }
    return Job;
}

ResidentAddress CreateAddress()
{
    ResidentAddress Address = new ResidentAddress();
    DisplayString($"default Address {Address.ToString()}");
    Address = new ResidentAddress(10767, "106 ST NW", null, null,
        "Edmonton", "AB");
    DisplayString($"greedy Address {Address.ToString()}");
    return Address;
}

Person CreatePerson(Employment job, ResidentAddress address)
{
    List<Employment> Jobs = new List<Employment>();
    Person thePerson = null;
    try
    {
        //create a good person using greedy constructor no job list
        thePerson = new Person("DonNoJob", "Welch", null, address);

        //create a good person using greedy constructor with an empty
        //  job list
        thePerson = new Person("DonEmptyJob", "Welch", Jobs, address);

        //create a good person using greedy constructor with a job list
        
        Jobs.Add(new Employment("worker", SupervisoryLevel.TeamMember, 2.1));
        Jobs.Add(new Employment("leader", SupervisoryLevel.TeamLeader, 7.8));
        Jobs.Add(job);
        thePerson = new Person("DonEmptyJob", "Welch", Jobs, address);

        //exception testing
        //no first name
        thePerson = new Person(null, "Welch", Jobs, address);
        //no last name
        thePerson = new Person("Don", null, Jobs, address);

        //can I change the firstname using an assignment statement
        //the FirstName is a private set.
        //you are not allowed to use a private set on the receiving
        //  side of an assignment statement.
        //THIS WILL NOT COMPILE
        //thePerson.FirstName = "NewName";

        //can I use a behaviour (method) to change the contents of a
        //  private set property?
        thePerson.ChangeName("Lowand", "Behold");

        //can I add another job after the person instance was created?
        thePerson.AddEmployment(new("DP IT", SupervisoryLevel.DepartmentHead, 0.8));
        //you don't need to declare the class type after keyword new now in newer
        //  C# versions
        //thePerson.AddEmployment(new Employment("DP IT", SupervisoryLevel.DepartmentHead, 0.8));
    
        //can I change the public field Address directly
        ResidentAddress oldAddress = thePerson.Address;
        oldAddress.City = "Vancouver";
        thePerson.Address = oldAddress;
    }
    catch (ArgumentException ex) //specific exception message
    {
        DisplayString(ex.Message);
    }
    catch (Exception ex) //general catch all
    {
        DisplayString("Run time error: " + ex.Message);
    }
    return thePerson;
}
