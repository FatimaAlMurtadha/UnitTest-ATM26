namespace ATM.ATM.Tests;

using ATM;
using Xunit;

public class AtmServicesTest
{
  private AtmService _atm = new AtmService(11000);
  private Card _card = new Card("0123-4567-8901-2345", "0123", new Account(9000));

  [Fact]
  public void insertCardIntoAtm()
  {
    Assert.False(_atm.HasCardInserted);

    _atm.InsertCard(_card);

    Assert.True(_atm.HasCardInserted);
  }


  [Fact]
  public void inputWrongPin()
  {
    _atm.InsertCard(_card);

    Assert.False(_atm.EnterPin("1234"));
  }

  [Fact]
  public void inputCorrectPin()
  {
    _atm.InsertCard(_card);

    Assert.True(_atm.EnterPin("0123"));
  }

  [Fact]
  public void withdrawValidAmount()
  {
    // Setup
    _atm.InsertCard(_card);
    _atm.EnterPin("0123");

    //Test
    _atm.Withdraw(5000);

    // Validation
    Assert.Equal(4000, _atm.GetBalance());
  }

  [Fact]
  public void ejectCardFromAtm()
  {
    // Setup
    _atm.InsertCard(_card);

    //Test
    _atm.EjectCard();

    // Validation
    Assert.False(_atm.HasCardInserted);
  }

  [Fact]
  public void withdrawInvalidAmountForAtm()
  {
    // Setup
    _atm.InsertCard(_card);
    _atm.EnterPin("0123");
    _atm.Withdraw(5000);

    //Test
    _atm.Withdraw(7000);

    // Validation
    Assert.Equal(4000, _atm.GetBalance());
    Assert.Equal(6000, _atm.AtmBalance);
  }

  [Fact]
  public void withdrawInvalidAmountForCard()
  {
    // Setup
    _atm.InsertCard(_card);
    _atm.EnterPin("0123");
    _atm.Withdraw(5000);

    //Test
    _atm.Withdraw(6000);

    // Validation
    Assert.Equal(4000, _atm.GetBalance());
    Assert.Equal(6000, _atm.AtmBalance);
  }


}