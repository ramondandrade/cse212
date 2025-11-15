using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities and dequeue them
    // Expected Result: Items should be dequeued in order of highest priority first
    // Defect(s) Found: Loop boundary error (should be < _queue.Count), items not removed after dequeue, wrong priority selection 
    public void TestPriorityQueue_BasicPriorityOrdering()
    {
        var priorityQueue = new PriorityQueue();
        
        // Add items with different priorities
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 5);
        priorityQueue.Enqueue("Medium", 3);
        
        // Should dequeue in priority order: High(5), Medium(3), Low(1)
        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with same priority and verify FIFO behavior
    // Expected Result: Items with same priority should be dequeued in FIFO order
    // Defect(s) Found: Using >= comparison causes later items to be selected instead of first items (breaks FIFO) 
    public void TestPriorityQueue_SamePriorityFIFO()
    {
        var priorityQueue = new PriorityQueue();
        
        // Add items with same priority in specific order
        priorityQueue.Enqueue("First", 3);
        priorityQueue.Enqueue("Second", 3);
        priorityQueue.Enqueue("Third", 3);
        
        // Should dequeue in FIFO order for same priority
        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Mixed priorities with some duplicates
    // Expected Result: Higher priorities first, then FIFO within same priorities
    // Defect(s) Found: Combination of loop boundary, removal, and FIFO issues causing incorrect ordering 
    public void TestPriorityQueue_MixedPriorities()
    {
        var priorityQueue = new PriorityQueue();
        
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 2);
        priorityQueue.Enqueue("D", 5);
        priorityQueue.Enqueue("E", 1);
        
        // Expected order: B(5), D(5), A(2), C(2), E(1)
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("D", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("E", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from empty queue
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: No defects found - exception handling works correctly 
    public void TestPriorityQueue_EmptyQueueException()
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
        catch (Exception e)
        {
            Assert.Fail($"Unexpected exception type: {e.GetType()}");
        }
    }

    [TestMethod]
    // Scenario: Single item enqueue and dequeue
    // Expected Result: Same item should be returned
    // Defect(s) Found: Item not removed from queue after dequeue - queue remains non-empty 
    public void TestPriorityQueue_SingleItem()
    {
        var priorityQueue = new PriorityQueue();
        
        priorityQueue.Enqueue("Only", 10);
        Assert.AreEqual("Only", priorityQueue.Dequeue());
        
        // Queue should now be empty
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown for empty queue.");
        }
        catch (InvalidOperationException)
        {
            // Expected behavior
        }
    }

    [TestMethod]
    // Scenario: Enqueue items, dequeue some, then enqueue more
    // Expected Result: Should maintain correct priority ordering throughout
    // Defect(s) Found: Items accumulate due to no removal, causing incorrect ordering in subsequent operations 
    public void TestPriorityQueue_InterleavedOperations()
    {
        var priorityQueue = new PriorityQueue();
        
        priorityQueue.Enqueue("A", 3);
        priorityQueue.Enqueue("B", 1);
        
        Assert.AreEqual("A", priorityQueue.Dequeue()); // Remove highest priority
        
        priorityQueue.Enqueue("C", 5); // Add higher priority
        priorityQueue.Enqueue("D", 1); // Add same priority as B
        
        // Expected order: C(5), B(1), D(1)
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("D", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Test with negative priorities
    // Expected Result: Higher numbers still have higher priority (even if negative)
    // Defect(s) Found: Loop boundary and FIFO issues affect negative priority handling as well 
    public void TestPriorityQueue_NegativePriorities()
    {
        var priorityQueue = new PriorityQueue();
        
        priorityQueue.Enqueue("A", -1);
        priorityQueue.Enqueue("B", -5);
        priorityQueue.Enqueue("C", 0);
        
        // Expected order: C(0), A(-1), B(-5)
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
    }
}