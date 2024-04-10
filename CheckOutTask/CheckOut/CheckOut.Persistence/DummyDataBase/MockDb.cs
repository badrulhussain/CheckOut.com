using CheckOut.Persistence.Entities;

namespace DummyDataBase
{
    public class MockDb : IMockDb
    {
        private List<BankCardDetails> cardDetails;
        private List<PaymentTransaction> paymentTransactions;
        private List<MerchantWallet> merchantWallets;
        private List<Merchant> merchants;

        public MockDb()
        {
            cardDetails = new List<BankCardDetails>();
            paymentTransactions = new List<PaymentTransaction>();
            merchantWallets = new List<MerchantWallet>();
            merchants = new List<Merchant>();

            setupData();
        }

        public List<BankCardDetails> GetListOfBankCardDetails()
        {
            return cardDetails;
        }

        public async Task<List<PaymentTransaction>> GetPaymentTransactions()
        {
            return paymentTransactions;
        }

        public List<Merchant> GetMerchants()
        {
            return merchants;
        }

        public void AddLedgerPaymentTransaction(PaymentTransaction paymentTransaction)
        {
            paymentTransactions.Add(paymentTransaction);
        }

        public void AddMerchantWallet(MerchantWallet merchantWallet)
        {
            merchantWallets.Add(merchantWallet);
        }

        private void setupData()
        {
            // Merchants
            merchants.Add(new Merchant
            {
                Id = 1,
                BankId = 4,
                CompanyName = "Clothing Rental",
                Type = 5137,
            });
            merchants.Add(new Merchant
            {
                Id = 2,
                BankId = 5,
                CompanyName = "Railways",
                Type = 4112,
            });
            merchants.Add(new Merchant
            {
                Id = 3,
                BankId = 6,
                CompanyName = "Travel Agencies",
                Type = 4722,
            });

            // Bank cards
            cardDetails.Add(new BankCardDetails
            {
                Id = 1,
                Email = "John@example.com",
                CardNumber = "5476640000772514",
                Cvv = 123,
                FirstName = "John",
                LastName = "Doe",
                VaildFrom = new DateTime(2022,1,1),
                ExpiryDate = new DateTime(2025, 1, 1)
            });
            cardDetails.Add(new BankCardDetails
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
            cardDetails.Add(new BankCardDetails
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
            cardDetails.Add(new BankCardDetails
            {
                Id = 4,
                Email = "Cevil.Accounts@ClothingRental.com",
                CardNumber = "377848831615296",
                Cvv = 912,
                FirstName = "Cevil",
                LastName = "King",
                VaildFrom = new DateTime(2023, 4, 1),
                ExpiryDate = new DateTime(2026, 4, 1)
            });
            cardDetails.Add(new BankCardDetails
            {
                Id = 5,
                Email = "Bruce.Accounts@Railways.com",
                CardNumber = "5161108763751299",
                Cvv = 812,
                FirstName = "Bruce",
                LastName = "Wane",
                VaildFrom = new DateTime(2023, 5, 1),
                ExpiryDate = new DateTime(2026, 5, 1)
            });
            cardDetails.Add(new BankCardDetails
            {
                Id = 6,
                Email = "Peter.Accounts@TravelAgencies.com",
                CardNumber = "4797140738540",
                Cvv = 712,
                FirstName = "Peter",
                LastName = "Parcker",
                VaildFrom = new DateTime(2023, 6, 1),
                ExpiryDate = new DateTime(2026, 6, 1)
            });

            // Ledger
            paymentTransactions.Add(new PaymentTransaction
            {
                Id = 1,
                MerchantId = 1,
                MerchentType = 5137,
                CustomerEmail = "John@example.com",
                Token  = Guid.Parse("2694c3ce-e2f6-4e13-a901-c4fca0835c86"),
                Amount = 1000m,
                Currency = "USD",
                CreatedOn = new DateTime(2024, 3, 1),
                Status = "Completed"

            });
            paymentTransactions.Add(new PaymentTransaction
            {
                Id = 2,
                MerchantId = 2,
                MerchentType = 4112,
                CustomerEmail = "Adam@example.com",
                Token = Guid.Parse("ab780a86-5527-4a3c-82cb-570e10e0032d"),
                Amount = 50m,
                Currency = "GBP",
                CreatedOn = new DateTime(2024, 4, 1),
                Status = "Pending"
            });
            paymentTransactions.Add(new PaymentTransaction
            {
                Id = 3,
                MerchantId = 3,
                MerchentType = 4722,
                CustomerEmail = "Matthew@example.com",
                Token = Guid.Parse("35b3fe15-e23a-45e3-82ad-ee187a900853"),
                Amount = 3000m,
                Currency = "USD",
                CreatedOn = new DateTime(2024, 2, 20),
                Status = "Failed"
            });

            // Merchant Wallet
            merchantWallets.Add(new MerchantWallet
            {
                Token = Guid.Parse("2694c3ce-e2f6-4e13-a901-c4fca0835c86"),
                CustomerCardNumber = "5476640000772514",
                MerchantCardNumber = "377848831615296",
                MerchantBanlence = 1000m,
                CustomerBanlence = -1000m,
                Currency = "USD",
                CreatedOn = new DateTime(2024, 3, 1)
            });
            merchantWallets.Add(new MerchantWallet
            {
                Token = Guid.Parse("ab780a86-5527-4a3c-82cb-570e10e0032d"),
                CustomerCardNumber = "377455633307906",
                MerchantCardNumber = "5161108763751299",
                MerchantBanlence = 0m,
                CustomerBanlence = 0m,
                Currency = "GBP",
                CreatedOn = new DateTime(2024, 4, 1)
            });
            merchantWallets.Add(new MerchantWallet
            {
                Token = Guid.Parse("35b3fe15-e23a-45e3-82ad-ee187a900853"),
                CustomerCardNumber = "4665420958526038",
                MerchantCardNumber = "4797140738540",
                MerchantBanlence = 0m,
                CustomerBanlence = 0m,
                Currency = "USD",
                CreatedOn = new DateTime(2024, 2, 20)
            });
        }
    }
}
