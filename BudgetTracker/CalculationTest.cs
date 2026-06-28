using NUnit.Framework;
using BudgetTracker;
using BudgetTracker.Core.Models;

namespace BudgetTracker.Tests
{
    public class CalculationTests
    {
        private BudgetTracker tracker = new BudgetTracker();

        [Test]
        public void GetTotalIncome_NoTransactions_ReturnsZero()
        {
            Assert.That(tracker.GetTotalIncome(), Is.EqualTo(0m));
        }

        [Test]
        public void GetTotalExpenses()
        {
            tracker.AddTransaction(new Transaction(50m, "Groceries", "Food", DateTime.Today, TransactionType.Expense));
            tracker.AddTransaction(new Transaction(30m, "Gas", "Transport", DateTime.Today, TransactionType.Expense));

            Assert.That(tracker.GetTotalExpenses(), Is.EqualTo(80m));

        }
    }
}