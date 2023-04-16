using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Memory.Tests;

[TestFixture]
public sealed class HeapTests
{
    [Test]
    public void Heap_AllocatingTooMuch_ThrowsException()
    {
        Assert.Throws<OutOfMemoryException>(AllocateInfinitely);
    }

    private static void AllocateInfinitely()
    {
        var byteArrays = new List<byte[]>();

        try
        {
            while (true)
            {
                byteArrays.Add(new byte[Array.MaxLength]);
            }
        }
        finally
        {
            TestContext.Out.WriteLine($"Total allocated: {GC.GetTotalAllocatedBytes(precise: true) / 1024 / 1024 / 1024} GiB");
        }
    }
}