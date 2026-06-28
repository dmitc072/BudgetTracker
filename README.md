# BudgetTracker

**Group 4 — SWE 6673 Software Testing & Verification**  
Duane Mitchell, Megan Morgan

## Project Overview

A Personal Budget Tracker built in C#. Users can add income and expense transactions, organize them by category, and calculate their current balance. Sprint 1 focuses entirely on business logic so it can be fully tested using NUnit without a GUI.

## Project Structure

```
BudgetTracker/
├── BudgetTracker.sln
├── BudgetTracker.Core/          # Class library — business logic
│   ├── BudgetTracker.cs         # Main service class
│   └── Models/
│       └── Transaction.cs       # Transaction record and TransactionType enum
└── BudgetTracker.Tests/         # NUnit test project
    └── BudgetTrackerTests.cs    # All Sprint 1 tests
```

## Getting Started

**Prerequisites:** .NET 9 SDK or higher

**Build:**
```bash
dotnet build
```

**Run Tests:**
```bash
dotnet test BudgetTracker.Tests/BudgetTracker.Tests.csproj
```

## Sprint 1 Requirements

| # | Requirement | Status |
|---|---|---|
| 1 | Add an income transaction with a positive amount, description, category, and date | ✅ |
| 2 | Add an expense transaction with a positive amount, description, category, and date | ✅ |
| 3 | Reject any transaction with an amount less than or equal to zero | ✅ |
| 4 | Reject any transaction with an empty or null description | ✅ |
| 5 | Store all valid transactions added by the user | ✅ |
| 6 | Return a list of all transactions | ✅ |
| 7 | Calculate total income by adding all income transactions | ✅ |
| 8 | Calculate total expenses by adding all expense transactions | ✅ |
| 9 | Calculate current balance using: total income − total expenses | ✅ |
| 10 | Allow transactions to be grouped by category | ✅ |
| 11 | Return the total spending amount for a specific category | ✅ |
| 12 | Return zero for a category that has no transactions | ✅ |

## Technology

- **Language:** C#
- **Framework:** .NET 9
- **Testing:** NUnit 4
