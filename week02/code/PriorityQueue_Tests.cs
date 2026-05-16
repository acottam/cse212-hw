using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue one item and dequeue it.
    // Expected Result: The value of the single item is returned.
    // Defect(s) Found: 
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Alice", 5);

        // Dequeue should return "Alice" since it's the only item in the queue.
        var result = priorityQueue.Dequeue();
        
        // Verify the result is "Alice".
        Assert.AreEqual("Alice", result);
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities and dequeue.
    // Expected Result: The item with the highest priority is returned first.
    // Defect(s) Found: 
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        // Enqueue items with varying priorities.
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 10);
        priorityQueue.Enqueue("Med", 5);

        // Dequeue should return "High" since it has the highest priority (10).
        var result = priorityQueue.Dequeue();
        
        // Verify the result is "High".
        Assert.AreEqual("High", result);
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same highest priority.
    // Expected Result: The first item added with that priority is returned (FIFO).
    // Defect(s) Found: Dequeue uses >= which selects the LAST item with the highest priority
    // instead of the FIRST. Should use > to preserve FIFO order.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        // Enqueue multiple items with the same priority.
        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Third", 5);

        // Dequeue should return "First" since it was the first item added with the highest priority (5).
        var result = priorityQueue.Dequeue();

        // Verify the result is "First".
        Assert.AreEqual("First", result);
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue.
    // Expected Result: InvalidOperationException is thrown with message "The queue is empty."
    // Defect(s) Found: 
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        
        // Attempting to dequeue from an empty queue should throw an exception.
        try
        {
            priorityQueue.Dequeue();
            
            // If no exception is thrown, the test should fail.
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            // Verify the exception message is correct.
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }

    [TestMethod]
    // Scenario: Enqueue and dequeue multiple times to verify items are removed from the queue.
    // Expected Result: Each dequeue removes the highest priority item, queue shrinks each time.
    // Defect(s) Found: Dequeue never removes the item from the queue (missing RemoveAt call),
    // so the same item is returned every time.
    public void TestPriorityQueue_5()
    {
        var priorityQueue = new PriorityQueue();

        // Enqueue multiple items with different priorities.
        priorityQueue.Enqueue("A", 3);
        priorityQueue.Enqueue("B", 7);
        priorityQueue.Enqueue("C", 5);

        // Dequeue should return "B" first (highest priority), then "C", then "A".
        Assert.AreEqual("B", priorityQueue.Dequeue());

        // After "B" is removed, "C" should be next highest priority.
        Assert.AreEqual("C", priorityQueue.Dequeue());
        
        // After "C" is removed, "A" should be next highest priority.
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Verify the highest priority item at the end of the queue is found.
    // Expected Result: The last item (highest priority) is returned.
    // Defect(s) Found: Loop condition uses `index < _queue.Count - 1` which skips the last item
    // in the queue. Should be `index < _queue.Count`.
    public void TestPriorityQueue_6()
    {
        var priorityQueue = new PriorityQueue();
        
        // Enqueue multiple items with different priorities.
        priorityQueue.Enqueue("First", 1);
        priorityQueue.Enqueue("Second", 2);
        priorityQueue.Enqueue("Third", 10);
        var result = priorityQueue.Dequeue();
        
        // Verify the result is "Third" since it has the highest priority (10).
        Assert.AreEqual("Third", result);
    }
}