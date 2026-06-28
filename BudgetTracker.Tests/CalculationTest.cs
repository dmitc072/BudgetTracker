using NUnit.Framework;
using BudgetTracker;

namespace BudgetTracker.Tests
{
    public class CalculationTests
    {
        [Test]
        public void GetTotalIncome_NoTransactions_ReturnsZero()
        {
            var tracker = new BudgetTracker();
            Assert.That(tracker.GetTotalIncome(), Is.EqualTo(0m));
        }
    }
}