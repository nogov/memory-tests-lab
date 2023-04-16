using NUnit.Framework;

namespace Memory.Tests;

[TestFixture]
public sealed class ReferenceTypeTests
{
    [Test]
    public void Array_PassedByReference()
    {
        var value = new [] { 1, 2, 3 };
        IncrementEach(value);
        Assert.That(value, Is.EquivalentTo(new[] { 2, 3, 4 }));

        static void IncrementEach(int[] array)
        {
            for (var i = 0; i < array.Length; i++)
            {
                array[i]++;
            }
        }
    }

    [Test]
    public void CustomClass_PassedByReference()
    {
        var customClass = new CustomClass(10);
        Increment(customClass);
        Assert.That(customClass.Value, Is.EqualTo(11));

        static void Increment(CustomClass @class) => @class.Value++;
    }

    private sealed class CustomClass
    {
        public CustomClass(int value)
        {
            Value = value;
        }

        public int Value { get; set; }
    }
}