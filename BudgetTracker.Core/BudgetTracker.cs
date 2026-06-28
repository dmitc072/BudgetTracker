using BudgetTracker.Core.Models;
using BudgetTracker;

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
            return 0m;
        }

        public decimal GetTotalExpenses()
        {
            throw new NotImplementedException();
        }

        public decimal GetBalance()
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, List<Transaction>> GetTransactionsByCategory()
        {
            throw new NotImplementedException();
        }

        public decimal GetCategoryTotal(string category)
        {
            throw new NotImplementedException();
        }
    }
}
