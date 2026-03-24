namespace ATM.ATM.Tests;
using ATM;
using Xunit;

public class AccountTest
{
    // One test many inputs one value
    [Fact]

    // Make sure that the elemantry balance is working
    public void GetBalanceTest()
    {
        // setup 
        // Arrange Account(5000) تجهيز البيانات
        Account account = new Account(5000);

        // test
        // Act GetBalance() استدعاء الدالة
        // Assert = 5000 التحقق من النتيحة

        Assert.Equal(5000, account.GetBalance());

    }

    [Fact]
    public void Withdraw_WhenAmountEqualsBalance_ShouldReturnZero() // "happy path test"
    {
        // setup
        Account account = new Account(5000);
        // test
        account.Withdraw(5000);
        Assert.Equal(0, account.GetBalance());
    }

    // Many tests many values
    // every inlineData is a test
    // parameterized test

    [Theory]
    // balance, withdrawal, remains
    [InlineData(5000, 5000, 0)]
    [InlineData(5000, 0, 5000)]
    [InlineData(5000, 6000, 5000)]
    [InlineData(5000, -1000, 5000)]
    public void Withdraw_ShouldUpdateBalanceCorrectly(int balance, int withdrawal, int remains)
    {
        // setup
        Account account = new Account(balance);
        // test
        account.Withdraw(withdrawal);
        Assert.Equal(remains, account.GetBalance());
    }


}
