/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Test 1
        // Scenario: Create a queue with invalid size (0). Should default to max size of 10.
        // Expected Result: Queue created with max_size=10
        Console.WriteLine("Test 1");
        var cs1 = new CustomerService(0);
        Console.WriteLine(cs1); // Should show max_size=10
        // Defect(s) Found: None — constructor handles this correctly.
        Console.WriteLine("=================");

        // Test 2
        // Scenario: Add a customer to the queue and verify it was added.
        // Expected Result: Queue contains 1 customer
        Console.WriteLine("Test 2");
        var cs2 = new CustomerService(3);
        Console.SetIn(new StringReader("John\n1234\nBilling issue\n"));
        cs2.AddNewCustomer();
        Console.WriteLine(cs2); // Should show size=1 with John's info
        // Defect(s) Found: None — AddNewCustomer enqueues correctly.
        Console.WriteLine("=================");

        // Test 3
        // Scenario: Add customers up to max size, then try to add one more.
        // Expected Result: Error message displayed when adding beyond max size.
        Console.WriteLine("Test 3");
        var cs3 = new CustomerService(2);
        Console.SetIn(new StringReader("Alice\n001\nProblem1\nBob\n002\nProblem2\nCharlie\n003\nProblem3\n"));
        cs3.AddNewCustomer();
        cs3.AddNewCustomer();
        cs3.AddNewCustomer(); // Should display error — queue is full
        Console.WriteLine(cs3); // Should show size=2
        // Defect(s) Found: Bug — uses > instead of >= so it allows one extra customer.
        Console.WriteLine("=================");

        // Test 4
        // Scenario: Serve a customer from a queue with customers.
        // Expected Result: First customer's details displayed, queue size decreases.
        Console.WriteLine("Test 4");
        var cs4 = new CustomerService(5);
        Console.SetIn(new StringReader("Dana\n100\nLogin issue\nEve\n200\nPayment issue\n"));
        cs4.AddNewCustomer();
        cs4.AddNewCustomer();
        Console.WriteLine("Before serve: " + cs4);
        cs4.ServeCustomer(); // Should display Dana's info
        Console.WriteLine("After serve: " + cs4); // Should show only Eve
        // Defect(s) Found: Bug — RemoveAt(0) is called before reading, so it displays
        //   the second customer instead of the first.
        Console.WriteLine("=================");

        // Test 5
        // Scenario: Serve a customer from an empty queue.
        // Expected Result: Error message displayed (queue is empty).
        Console.WriteLine("Test 5");
        var cs5 = new CustomerService(5);
        cs5.ServeCustomer(); // Should display error — queue is empty
        // Defect(s) Found: Bug — no empty check, throws an exception instead of
        //   displaying an error message.
        Console.WriteLine("=================");
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    public void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
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
    public void ServeCustomer() {
        if (_queue.Count == 0) {
            Console.WriteLine("No customers in the queue.");
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
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}