using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Insert integers and dequeue them
    // Expected Result: Values come out in ascending order
    // Defect(s) Found: None *as far a s I know*
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Task A", 3);
        priorityQueue.Enqueue("Task B", 1);
        priorityQueue.Enqueue("Task C", 2);

        Assert.AreEqual("Task B", priorityQueue.Dequeue());
        Assert.AreEqual("Task C", priorityQueue.Dequeue());
        Assert.AreEqual("Task A", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Insert integers with duplicates and dequeue them
    // Expected Result: Values come out in ascending order (duplicates included :D )
    // Defect(s) Found: None *as far a s I know*
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Task X", 2);
        priorityQueue.Enqueue("Task Y", 1);
        priorityQueue.Enqueue("Task Z", 2);
        priorityQueue.Enqueue("Task W", 1);

        Assert.AreEqual("Task Y", priorityQueue.Dequeue()); 
        Assert.AreEqual("Task W", priorityQueue.Dequeue()); 
        Assert.AreEqual("Task X", priorityQueue.Dequeue()); 
        Assert.AreEqual("Task Z", priorityQueue.Dequeue()); 
    }

    // Add more test cases as needed below.
}
