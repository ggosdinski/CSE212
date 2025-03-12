using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add multiple items and remove the highest priority one
    // Expected Result: The item with the highest priority is dequeued first (FIFO for ties)
    // Defect(s) Found: None
    public void TestPriorityQueue_HighestPriorityRemoved()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("LowPriority", 1);
        priorityQueue.Enqueue("HighPriority", 5);
        priorityQueue.Enqueue("MediumPriority", 3);

        string result = priorityQueue.Dequeue();
        Assert.AreEqual("HighPriority", result);
    }

    [TestMethod]
    // Scenario: Remove items when multiple have the same highest priority
    // Expected Result: The first inserted item with the highest priority is removed (FIFO)
    // Defect(s) Found: None
    public void TestPriorityQueue_FIFO_TieBreaker()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("FirstHigh", 5);
        priorityQueue.Enqueue("SecondHigh", 5);
        priorityQueue.Enqueue("LowPriority", 1);

        string result1 = priorityQueue.Dequeue();
        string result2 = priorityQueue.Dequeue();

        Assert.AreEqual("FirstHigh", result1);
        Assert.AreEqual("SecondHigh", result2);
    }

    [TestMethod]
    // Scenario: Remove items in correct priority order
    // Expected Result: Items should be dequeued in order of priority, maintaining FIFO for ties
    // Defect(s) Found: None
    public void TestPriorityQueue_CorrectOrder()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 1);
        priorityQueue.Enqueue("D", 3);

        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("D", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue
    // Expected Result: Exception is thrown
    // Defect(s) Found: None
    public void TestPriorityQueue_EmptyQueueException()
    {
        var priorityQueue = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }
}
