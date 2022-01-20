using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeConsole.Data
{
    public class Employment
    {
        //An instance of this class will hold data about a person's
        //employment
        //The code of this class is the definition of that data
        //The characteristics (data) of the class
        //  Title, Supervisory Level, Years of Employment within the
        //  company

        //the 4 components of a class definition are
        //  data fields
        //  property
        //  constructor
        //  behaviour (method)

        //data fields
        //  are storage area in your class
        //  these are treated as variables
        //  these may be public, private, public readonly
        private string _Title;
        private double _Years;

        //properties
        //  these are access techniques to retrieve or set data in
        //  your class without directly touching the storage data field

        //fully implemented property
        //  a) a declared storage area (data field)
        //  b) a declared property signature
        //  c) a coded get "method"
        //  d) an optional coded set "method"

        //Use fully implemented property when:
        //  a) if you are storing the associate data in an explicitly
        //      declared data field
        //  b) if you are during validation access incoming data
        //  c) creating a property that generates output from other data
        //      sources within the class (readonly properties); this
        //      property would have only a get method
        public string Title
        {
            get
            {
                //accessor
                //the get "method" wil return the contents of a data
                //  field or fields as an expression
                return _Title;
            }
            set
            {
                //mutator
                //the set "method" receives an incoming value and places it
                //  in the associated data field
                //during the setting, you might wish to validate the
                //  incoming data
                //during the setting, you might wish to do some type of
                //  logical processing using the data to set another field
                //the incoming piece of data is referred to using the
                //  keyword "value"

                //ensure that the incoming data is not null or empty or
                //  just whitespace
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Title is a required" +
                        " piece of data.");
                }

                //data is considered valid
                _Title = value;

            }
        }

        //auto-implemented property

        //these properties differ from fully implemented properties only
        //  in syntax
        //each property is responsible for a single piece of data
        //these properties do NOT reference a declared private data member
        //the system generates an internal storage area of the return data
        //  type
        //the system manages the internal storage for the accessor and
        //  mutator
        //there is NO additional logic applied to the data value

        //using an enum for this field will AUTOMATICALLY restrict the
        //  values this property can contain
        public SupervisoryLevel Level { get; set; }
        
        //this property Years could be coded either as a fully implemented
        //  property or an auto-implemented property
        public double Years
        {
            get { return _Years; } 
            set
            {
                if (!Utilities.IsPositve(value))
                {
                    throw new ArgumentNullException("Years cannot be a negative value.");
                }
                _Years = value;
            }
        }

        //constructors
        //purpose is to initialize the physical object (instance) during
        //  its creation
        //the result of creation is to ensure that the coder gets an
        //  instance in a known state
        //if your class definition has NO constructor coded, then the data
        //  members / auto implemented properties are set to the C# default
        //  data type value
        //You can code one or more constructors in your class definition
        //IF YOU CODE A CONSTRUCTOR FOR THE CLASS, YOU ARE RESPONSIBLE FOR
        //  ALL CONSTRUCTORS USED BY THE CLASS!!!
        //generally, if you are going to code your own constructor(s), you
        //  code two types
        //  Default: this constructor does NOT take in any parameters (it
        //      mimics the default system constructor)
        //  Greedy: this constructor has a list of parameters, for each
        //      property, declared for incoming data
        //
        //syntax: accesstype classname([list of parameters]) {constructor
        //  body}
        //IMPORTANT: the constructor does NOT have a return datatype (unlike
        //  a method)
        //  You do NOT call a constructor directly, called using the new
        //      operator (the keyword: new)
        //
        //Default constructor
        public Employment()
        {
            //constructor body
            //a) empty
            //b) you COULD assign literal values to your properties with
            //      this constructor
            Level = SupervisoryLevel.TeamMember;
            Title = "Unknown";
        }

        //Greedy constructor
        public Employment(string title, SupervisoryLevel level, double years)
        {
            //constructor body
            //a) a parameter for each property
            //b) you COULD do validation within the constructor instead of
            //  within the property
            //c) validation for public readonly members
            //  validation for a property with a private set
            Title = title;
            Level = level;
            Years = years;
        }

        //constructors can be made for just one or more properties, but
        //  this can lead to too many constructors, so usually you make
        //  one greedy constructor asking for all properties

        //Behaviours (aka methods)
        //Behaviours are no different than methods elsewhere

        //Syntax: accesstype [static] returndatatype BehaviourName([list
        // of parameters])
        //          { code body }

        //there may be times you wish to obtain all the data in your
        //  instance all at once for display
        //generally to accomplish this, your class overrides the .ToString()
        //  method of classes
        public override string ToString()
        {
            //comma separated value list (csv)
            return $"{Title},{Level},{Years}";
        }

        public void SetEmployeeResponsibilityLevel(SupervisoryLevel level)
        {
            //you could do validation within this method to ensure
            //  acceptable value
            if (level < 0)
            {
                throw new Exception("Responsibility level must be positive");
            }
            Level = level;
        }
    }
}
