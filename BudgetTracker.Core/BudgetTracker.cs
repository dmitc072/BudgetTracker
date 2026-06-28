using BudgetTracker.Core.Models;

namespace BudgetTracker
{
    public class BudgetTracker
    {
        private List<Transaction> transactions = new List<Transaction>();

        // Megan's half (requirements 1-6): adding, validating, storing, listing
         public void AddTransaction(Transaction transaction)
        {
            if (transaction.Amount <= 0)
            {
                throw new ArgumentException(
                    "Amount must be greater than zero.");
            }

            if (string.IsNullOrWhiteSpace(
                    transaction.Description))
            {
                throw new ArgumentException(
                    "Description cannot be empty.");
            }

            transactions.Add(transaction);
        }

        // Requirement 6
        public List<Transaction> GetAllTransactions()
        {
            return new List<Transaction>(transactions);
        }

        // Duane's half (requirements 7-12): calculations and categories
        public decimal GetTotalIncome()
        {
            return transactions
                .Where(t => t.Type == TransactionType.Income)
                .Sum(t => t.Amount);
        }

        public decimal GetTotalExpenses()
        {
            return transactions
                .Where(t => t.Type == TransactionType.Expense)
                .Sum(t => t.Amount);
        }

        public decimal GetBalance()
        {
            return GetTotalIncome() - GetTotalExpenses();
        }

        public Dictionary<string, List<Transaction>> GetTransactionsByCategory()
        {
            return transactions
                .GroupBy(t => t.Category)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        public decimal GetCategoryTotal(string category)
        {
            return transactions
                .Where(t => t.Type == TransactionType.Expense &&
                            t.Category == category)
                .Sum(t => t.Amount);
        }
    }
}
