namespace PayrollConsoleApp.Dtos;

public class ProductFeeDto
{
    public int ProductId { get; set; }

    public float Price { get; set; }

    public float OffPrice { get; set; }

    public int DiscountRate { get; set; }
}
