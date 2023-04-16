using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Memory.Tests;

[TestFixture]
public sealed class GarbageCollectionTests
{
    [SetUp]
    public void SetUp()
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }

    [Test]
    public void VerifyThatUnreferencedObjectsAreCollected()
    {
        var list = new LinkedList<object>();

        // Generate some objects
        for (int i = 0; i < 1 << 10; i++)
        {
            list.AddLast(new object());
        }

        var allocatedMemory = GC.GetTotalMemory(forceFullCollection: true);

        // Remove references to generated objects
        list.Clear();

        var allocatedMemoryDiff = GC.GetTotalMemory(forceFullCollection: true) - allocatedMemory;
        Assert.That(allocatedMemoryDiff, Is.Negative, "Expected to free up some memory");
    }
}