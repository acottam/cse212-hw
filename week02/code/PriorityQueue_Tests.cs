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
        var result = priorityQueue.Dequeue();
        Assert.AreEqual("Alice", result);
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities and dequeue.
    // Expected Result: The item with the highest priority is returned first.
    // Defect(s) Found: 
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 10);
        priorityQueue.Enqueue("Med", 5);
        var result = priorityQueue.Dequeue();
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
        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Third", 5);
        var result = priorityQueue.Dequeue();
        Assert.AreEqual("First", result);
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue.
    // Expected Result: InvalidOperationException is thrown with message "The queue is empty."
    // Defect(s) Found: 
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
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
        priorityQueue.Enqueue("A", 3);
        priorityQueue.Enqueue("B", 7);
        priorityQueue.Enqueue("C", 5);

        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
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
        priorityQueue.Enqueue("First", 1);
        priorityQueue.Enqueue("Second", 2);
        priorityQueue.Enqueue("Third", 10);
        var result = priorityQueue.Dequeue();
        Assert.AreEqual("Third", result);
    }
}