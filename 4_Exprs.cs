using System.Linq.Expressions;

namespace LesserKnown.NET;

// Source: https://learn.microsoft.com/en-us/dotnet/csharp/advanced-topics/expression-trees/expression-trees-interpreting
public class Exprs
{
    public void Run()
    {
        // Create an expression tree.
        Expression<Func<int, bool>> exprTree = num => num < 5;

        // Decompose the expression tree.
        ParameterExpression param = (ParameterExpression)exprTree.Parameters[0];
        BinaryExpression operation = (BinaryExpression)exprTree.Body;
        ParameterExpression left = (ParameterExpression)operation.Left;
        ConstantExpression right = (ConstantExpression)operation.Right;

        Console.WriteLine($"Decomposed expression: {param.Name} => {left.Name} {operation.NodeType} {right.Value}");

        // This code produces the following output:

        // Decomposed expression: num => num LessThan 5
    }
}
