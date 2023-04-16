using System;
using NUnit.Framework;

namespace Memory.Tests;

[TestFixture]
public sealed class AllocationTests
{
    [SetUp]
    public void SetUp()
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }

    [Test]
    public unsafe void CreatingArray_1MB_OnStack()
    {
        var allocatedMemory = GC.GetAllocatedBytesForCurrentThread();
        var array = stackalloc byte[1 << 20];
        var allocatedMemoryDiff = GC.GetAllocatedBytesForCurrentThread() - allocatedMemory;

        Assert.That(allocatedMemoryDiff, Is.AtMost(0), "Expected to have no heap allocations");
    }

    [Test]
    public void CreatingArray_1MB_OnHeap()
    {
        var allocatedMemory = GC.GetAllocatedBytesForCurrentThread();
        var array = new byte[1 << 20];
        var allocatedMemoryDiff = GC.GetAllocatedBytesForCurrentThread() - allocatedMemory;

        Assert.That(allocatedMemoryDiff, Is.AtLeast(array.Length), "Expected to allocate at least 1MB");
    }
}