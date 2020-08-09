using PersonDatabase.API.Models;

namespace PersonDatabase.API.Services.Communication
{
    public class PersonResponse : BaseResponse
    {
        public Person Person { get; private set; }

        private PersonResponse(bool success, string message, Person person) : base(success, message)
        {
            Person = person;
        }

        public PersonResponse(Person person) : this(true, string.Empty, person)
        { }

        public PersonResponse(string message) : this(false, message, null)
        { }
    }
}