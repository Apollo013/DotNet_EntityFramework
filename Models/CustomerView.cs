using Models.Base;

namespace Models
{
    public class CustomerView : Entity
    {
        public string Name { get; private set; }

        public string WorkEmail { get; private set; }

        public string WorkPhone { get; private set; }

        private CustomerView() { }
        private CustomerView(string name, string workEmail, string workPhone)
        {
            Name = name;
            WorkEmail = workEmail;
            WorkPhone = workPhone;
        }

        public static CustomerView Create(string name, string workEmail, string workPhone)
        {
            return new CustomerView(name, workEmail, workPhone);
        }
    }
}
