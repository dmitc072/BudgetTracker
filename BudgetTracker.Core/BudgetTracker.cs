using BudgetTracker.Core.Models;

namespace BudgetTracker
{
    public class BudgetTracker
    {
        private List<Transaction> transactions = new List<Transaction>();

        // Megan's half (requirements 1-6): adding, validating, storing, listing
        public void AddTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public List<Transaction> GetAllTransactions()
        {
            throw new NotImplementedException();
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
