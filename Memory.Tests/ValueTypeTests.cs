using System;
using NUnit.Framework;

namespace Memory.Tests;

[TestFixture]
public sealed class ValueTypeTests
{
    [Test]
    public void Integer_PassedByValue()
    {
        var value = 10;
        Increment(value);
        Assert.That(value, Is.EqualTo(10));

        void Increment(int v) => v++;
    }

    [Test]
    public void CustomStruct_PassedByValue()
    {
        var customStruct = new CustomStruct(10);
        Increment(customStruct);
        Assert.That(customStruct.Value, Is.EqualTo(10));

        void Increment(CustomStruct @struct) => @struct.Value++;
    }

    private struct CustomStruct
    {
        public int Value;

        public CustomStruct(int value)
        {
            Value = value;
        }
    }
}