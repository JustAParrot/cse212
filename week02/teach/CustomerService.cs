/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService
{
    public static void Run()
    {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);


        //I did this one before the team meeting because i couldn't understand it well... lucky it worked

        // Test 1
        // Scenario: Create a queue with invalid size
        // Expected Result: Queue max size defaults to 10
        Console.WriteLine("Test 1");
        var cs = new CustomerService(0);
        Console.WriteLine(cs);
        Console.WriteLine("== Good Stuff ==");

        // Test 2
        // Scenario: Add one customer, then serve them
        // Expected Result: Customer is added, then served with correct details
        Console.WriteLine("Test 2");
        cs = new CustomerService(5);
        cs.ForceAddCustomer("Alice", "A001", "Password reset");
        Console.WriteLine(cs);
        cs.ForceServeCustomer();
        Console.WriteLine(cs);
        Console.WriteLine("== Good Stuff ==");

        // Test 3
        // Scenario: Add customers beyond max size
        // Expected Result: When full, shows error message
        Console.WriteLine("Test 3");
        cs = new CustomerService(2);
        cs.ForceAddCustomer("Bob", "B001", "Login issue");
        cs.ForceAddCustomer("Carol", "C002", "Account locked");
        cs.ForceAddCustomer("Dave", "D003", "Forgot PIN");
        Console.WriteLine(cs);
        Console.WriteLine("== Not Good Stuff ==");

        // Test 4
        // Scenario: Serve from empty queue
        // Expected Result: Shows error message
        Console.WriteLine("Test 4");
        cs = new CustomerService(3);
        cs.ForceServeCustomer();
        Console.WriteLine("== Not Good Stuff ==");

        // Add more Test Cases As Needed Below
    }

    // Helper added for debugging, testing, and because I over complicated this     *I don't know why my code is so trash* :(
    public void ForceAddCustomer(string name, string accountId, string problem)
    {
        if (_queue.Count >= _maxSize)
        {
            Console.WriteLine("Maximum Number of Customers in Queue >:( ");
            return;
        }
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    public void ForceServeCustomer()
    {
        ServeCustomer();
    }


    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize)
    {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer
    {
        public Customer(string name, string accountId, string problem)
        {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString()
        {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer()
    {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize)
        {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer()
    {
        if (_queue.Count <= 0)
        {
            Console.WriteLine("No customers in queue.");
            return;
        }
        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString()
    {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}