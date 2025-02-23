using NUnit.Framework;
using System;

[TestFixture]
public class CalculatorTests
{
    private Calculator calculator;

    [SetUp]
    public void Setup()
    {
        calculator = new Calculator();
    }

    [Test]
    public void Add_ShouldReturnCorrectSum()
    {
        Assert.AreEqual(5, calculator.Add(2, 3));
    }

    [Test]
    public void Subtract_ShouldReturnCorrectDifference()
    {
        Assert.AreEqual(2, calculator.Subtract(5, 3));
    }

    [Test]
    public void Multiply_ShouldReturnCorrectProduct()
    {
        Assert.AreEqual(15, calculator.Multiply(3, 5));
    }

    [Test]
    public void Divide_ShouldReturnCorrectQuotient()
    {
        Assert.AreEqual(2, calculator.Divide(10, 5));
    }

    [Test]
    public void Divide_ByZero_ShouldThrowException()
    {
        Assert.Throws<DivideByZeroException>(() => calculator.Divide(10, 0));
    }
}
