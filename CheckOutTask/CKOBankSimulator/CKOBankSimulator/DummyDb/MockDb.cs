using CKOBankSimulator.Controllers.Model;

namespace CKOBankSimulator.DummyDb
{
    public class MockDb : IMockDB
    {
        private List<Account> accounts;

        public MockDb()
        {
            accounts = new List<Account>();

            setupData();
        }

        public List<Account> GetAccounts()
        {
            return accounts;
        }

        private void setupData()
        {
            // Bank cards
            accounts.Add(new Account
            {
                Id = 1,
                Email = "John@example.com",
                CardNumber = "5476640000772514",
                Cvv = 123,
                FirstName = "John",
                LastName = "Doe",
                VaildFrom = new DateTime(2022, 1, 1),
                ExpiryDate = new DateTime(2025, 1, 1)
            });
            accounts.Add(new Account
            {
                Id = 2,
                Email = "Adam@example.com",
                CardNumber = "377455633307906",
                Cvv = 456,
                FirstName = "James",
                LastName = "Adam",
                VaildFrom = new DateTime(2023, 2, 1),
                ExpiryDate = new DateTime(2026, 2, 1)
            });
            accounts.Add(new Account
            {
                Id = 3,
                Email = "Matthew@example.com",
                CardNumber = "4665420958526038",
                Cvv = 789,
                FirstName = "Matthew",
                LastName = "Clark",
                VaildFrom = new DateTime(2023, 3, 1),
                ExpiryDate = new DateTime(2026, 3, 1)
            });

            // Merchent bank cards
            accounts.Add(new Account
            {
                Id = 4,
                Email = "Cevil.accounts@ClothingRental.com",
                CardNumber = "377848831615296",
                Cvv = 912,
                FirstName = "Cevil",
                LastName = "King",
                VaildFrom = new DateTime(2023, 4, 1),
                ExpiryDate = new DateTime(2026, 4, 1)
            });
            accounts.Add(new Account
            {
                Id = 5,
                Email = "Bruce.accounts@Railways.com",
                CardNumber = "5161108763751299",
                Cvv = 812,
                FirstName = "Bruce",
                LastName = "Wane",
                VaildFrom = new DateTime(2023, 5, 1),
                ExpiryDate = new DateTime(2026, 5, 1)
            });
            accounts.Add(new Account
            {
                Id = 6,
                Email = "Peter.accounts@TravelAgencies.com",
                CardNumber = "4797140738540",
                Cvv = 712,
                FirstName = "Peter",
                LastName = "Parcker",
                VaildFrom = new DateTime(2023, 6, 1),
                ExpiryDate = new DateTime(2026, 6, 1)
            });
        }
    }
}
