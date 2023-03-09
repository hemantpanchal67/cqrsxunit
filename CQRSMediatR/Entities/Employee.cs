namespace CQRSMediatR.Entities
{
    public class Employee
    {
        public long Id { get; set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Address { get; protected set; }
        public string Phone { get; protected set; }
        public decimal Salary { get; protected set; }

        protected Employee()
        {
        }

        public Employee(string firstName, string lastName, string address, string phone, decimal salary)
          => Copy(firstName, lastName, address, phone, salary);

        private void Copy(string firstName, string lastName, string address, string phone, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Phone = phone;
            Salary = salary;
        }
        public void Update(string firstName, string lastName, string address, string phone, decimal salary)
           => Copy(firstName, lastName, address, phone, salary);
    }
}
