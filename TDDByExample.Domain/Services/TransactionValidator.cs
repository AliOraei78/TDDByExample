namespace TDDByExample.Domain.Services;

public class TransactionValidator
{
    public bool ValidateAmount(decimal amount)
    {
        return amount > 0;
    }
}