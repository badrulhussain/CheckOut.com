using CKOBankSimulator.Controllers.Model;

namespace CKOBankSimulator.DummyDb
{
    public interface IMockDB
    {
        List<Account> GetAccounts();
    }
}
