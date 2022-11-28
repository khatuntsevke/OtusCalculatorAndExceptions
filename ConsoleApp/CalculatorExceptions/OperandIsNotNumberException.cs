namespace ConsoleApp.CalculatorExceptions
{
    internal class OperandIsNotNumberException : ExpressionHandlerException
    {
        public string? OperatorStr { get; set; }
    }
}
