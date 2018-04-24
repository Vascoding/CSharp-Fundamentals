namespace DependencyInversion
{
    public class AdditionalStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand + secondOperand;
        }
    }
}