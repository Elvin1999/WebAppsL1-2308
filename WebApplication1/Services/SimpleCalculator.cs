namespace WebApplication1.Services
{
    public class SimpleCalculator : ICalculator
    {
        public int Data { get; set; } = 0;
        public SimpleCalculator()
        {
            Data = 100;
        }
        public decimal Calculate(decimal value)
        {
            Data += 100;
            return Data;
        }
    }
}
