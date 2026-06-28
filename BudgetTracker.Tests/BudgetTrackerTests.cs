using NUnit.Framework;
using System;
using System.Linq;
using BudgetTracker;
using BudgetTracker.Core.Models;

namespace BudgetTracker.Tests
{
    [TestFixture]
    public class BudgetTrackerTests
    {
        private BudgetTracker tracker;

        [SetUp]
        public void Setup()
        {
            tracker = new BudgetTracker();
        }

        [Test]
        public void AddTransaction_WithIncomeTransaction_ShouldAddTransaction()
        {
            var transaction = new Transaction(
                1000.00m,
                "Paycheck",
                "Job",
                new DateTime(2026, 6, 27),
                TransactionType.Income);

            tracker.AddTransaction(transaction);

            var transactions = tracker.GetAllTransactions();

            Assert.That(transactions.Count, Is.EqualTo(1));
            Assert.That(transactions[0].Type, Is.EqualTo(TransactionType.Income));
        }

        [Test]
        public void AddTransaction_WithExpenseTransaction_ShouldAddTransaction()
        {
            var transaction = new Transaction(
                50.00m,
                "Groceries",
                "Food",
                new DateTime(2026, 6, 27),
                TransactionType.Expense);

            tracker.AddTransaction(transaction);

            var transactions = tracker.GetAllTransactions();

            Assert.That(transactions.Count, Is.EqualTo(1));
            Assert.That(transactions[0].Type, Is.EqualTo(TransactionType.Expense));
        }

        [TestCase(0)]
        [TestCase(-10)]
        public void AddTransaction_WithZeroOrNegativeAmount_ShouldThrowArgumentException(decimal amount)
        {
            var transaction = new Transaction(
                amount,
                "Invalid transaction",
                "Test",
                DateTime.Today,
                TransactionType.Expense);

            Assert.Throws<ArgumentException>(() =>
                tracker.AddTransaction(transaction));
        }

        [Test]
        public void AddTransaction_WithEmptyDescription_ShouldThrowArgumentException()
        {
            var transaction = new Transaction(
                100.00m,
                "",
                "Job",
                DateTime.Today,
                TransactionType.Income);

            Assert.Throws<ArgumentException>(() =>
                tracker.AddTransaction(transaction));
        }

        [Test]
        public void AddTransaction_WithNullDescription_ShouldThrowArgumentException()
        {
            var transaction = new Transaction(
                100.00m,
                null!,
                "Job",
                DateTime.Today,
                TransactionType.Income);

            Assert.Throws<ArgumentException>(() =>
                tracker.AddTransaction(transaction));
        }

        [Test]
        public void AddTransaction_WithValidTransactions_ShouldStoreAllTransactions()
        {
            tracker.AddTransaction(
                new Transaction(
                    1000.00m,
                    "Paycheck",
                    "Job",
                    DateTime.Today,
                    TransactionType.Income));

            tracker.AddTransaction(
                new Transaction(
                    100.00m,
                    "Groceries",
                    "Food",
                    DateTime.Today,
                    TransactionType.Expense));

            var transactions = tracker.GetAllTransactions();

            Assert.That(transactions.Count, Is.EqualTo(2));
        }

        [Test]
        public void GetAllTransactions_ShouldReturnListOfAllTransactions()
        {
            tracker.AddTransaction(new Transaction(1000.00m, "Paycheck", "Job", DateTime.Today, TransactionType.Income));
            tracker.AddTransaction(new Transaction(100.00m, "Groceries", "Food", DateTime.Today, TransactionType.Expense));

            var expected = new List<Transaction>
            {
                new Transaction(1000.00m, "Paycheck", "Job", DateTime.Today, TransactionType.Income),
                new Transaction(100.00m, "Groceries", "Food", DateTime.Today, TransactionType.Expense)
            };

            var transactions = tracker.GetAllTransactions();

            Assert.That(transactions, Is.EqualTo(expected));
            Assert.That(transactions, Is.Not.Null);
            Assert.That(transactions.Count, Is.EqualTo(2));

        }

        [Test]
        public void GetTotalIncome_ShouldAddAllIncomeTransactions()
        {
            tracker.AddTransaction(new Transaction(1000m, "Paycheck", "Job", DateTime.Today, TransactionType.Income));
            tracker.AddTransaction(new Transaction(250m, "Freelance", "Side Job", DateTime.Today, TransactionType.Income));
            tracker.AddTransaction(new Transaction(50m, "Groceries", "Food", DateTime.Today, TransactionType.Expense));

            Assert.That(tracker.GetTotalIncome(), Is.EqualTo(1250m));
        }

        [Test]
        public void GetTotalExpenses_ShouldAddAllExpenseTransactions()
        {
            tracker.AddTransaction(new Transaction(1000m, "Paycheck", "Job", DateTime.Today, TransactionType.Income));
            tracker.AddTransaction(new Transaction(50m, "Groceries", "Food", DateTime.Today, TransactionType.Expense));
            tracker.AddTransaction(new Transaction(25m, "Gas", "Transportation", DateTime.Today, TransactionType.Expense));

            Assert.That(tracker.GetTotalExpenses(), Is.EqualTo(75m));
        }

        [Test]
        public void GetBalance_ShouldReturnIncomeMinusExpenses()
        {
            tracker.AddTransaction(new Transaction(1000m, "Paycheck", "Job", DateTime.Today, TransactionType.Income));
            tracker.AddTransaction(new Transaction(100m, "Groceries", "Food", DateTime.Today, TransactionType.Expense));
            tracker.AddTransaction(new Transaction(50m, "Gas", "Transportation", DateTime.Today, TransactionType.Expense));

            Assert.That(tracker.GetBalance(), Is.EqualTo(850m));
        }

        [Test]
        public void GetTransactionsByCategory_ShouldGroupTransactionsByCategory()
        {
            tracker.AddTransaction(new Transaction(50m, "Groceries", "Food", DateTime.Today, TransactionType.Expense));
            tracker.AddTransaction(new Transaction(25m, "Lunch", "Food", DateTime.Today, TransactionType.Expense));
            tracker.AddTransaction(new Transaction(40m, "Gas", "Transportation", DateTime.Today, TransactionType.Expense));

            var grouped = tracker.GetTransactionsByCategory();

            Assert.That(grouped.ContainsKey("Food"), Is.True);
            Assert.That(grouped.ContainsKey("Transportation"), Is.True);
            Assert.That(grouped["Food"].Count, Is.EqualTo(2));
            Assert.That(grouped["Transportation"].Count, Is.EqualTo(1));
        }

        [Test]
        public void GetCategoryTotal_ShouldReturnTotalSpendingForSpecificCategory()
        {
            tracker.AddTransaction(new Transaction(50m, "Groceries", "Food", DateTime.Today, TransactionType.Expense));
            tracker.AddTransaction(new Transaction(25m, "Lunch", "Food", DateTime.Today, TransactionType.Expense));
            tracker.AddTransaction(new Transaction(1000m, "Paycheck", "Job", DateTime.Today, TransactionType.Income));

            Assert.That(tracker.GetCategoryTotal("Food"), Is.EqualTo(75m));
        }

        [Test]
        public void GetCategoryTotal_WithNoTransactionsInCategory_ShouldReturnZero()
        {
            tracker.AddTransaction(new Transaction(50m, "Groceries", "Food", DateTime.Today, TransactionType.Expense));

            Assert.That(tracker.GetCategoryTotal("Entertainment"), Is.EqualTo(0m));
        }
    }
}