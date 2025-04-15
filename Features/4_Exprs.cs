using System.Linq.Expressions;

namespace LesserKnown.NET;

// Source: https://learn.microsoft.com/en-us/dotnet/csharp/advanced-topics/expression-trees/expression-trees-interpreting
public class ExprsDemo: MainDemo
{
    public void Run()
    {
        // Example 1
        {
            Console.WriteLine("Example 1");

            // Create an expression tree.
            Expression <Func<int, bool>> exprTree = num => num < 5;

            // Decompose the expression tree.
            ParameterExpression param = (ParameterExpression)exprTree.Parameters[0];
            BinaryExpression operation = (BinaryExpression)exprTree.Body;
            ParameterExpression left = (ParameterExpression)operation.Left;
            ConstantExpression right = (ConstantExpression)operation.Right;

            Console.WriteLine($"Decomposed expression: {param.Name} => {left.Name} {operation.NodeType} {right.Value}");

            // This code produces the following output:

            // Decomposed expression: num => num LessThan 5

            // Note: Don't usevar to declare this expression tree, because the natural type of the delegate is Func<int>,
            // not Expression<Func<int>>.
        }
        // Example 2
        {
            Console.WriteLine("Example 2");
            Expression<Func<int>> sum = () => 1 + 2;

            Expression<Func<int, int, int>> addition = (a, b) => a + b;

            Console.WriteLine($"This expression is a {addition.NodeType} expression type");
            Console.WriteLine($"The name of the lambda is {((addition.Name == null) ? "<null>" : addition.Name)}");
            Console.WriteLine($"The return type is {addition.ReturnType.ToString()}");
            Console.WriteLine($"The expression has {addition.Parameters.Count} arguments. They are:");
            foreach (var argumentExpression in addition.Parameters)
            {
                Console.WriteLine($"\tParameter Type: {argumentExpression.Type.ToString()}, Name: {argumentExpression.Name}");
            }

            var additionBody = (BinaryExpression)addition.Body;
            Console.WriteLine($"The body is a {additionBody.NodeType} expression");
            Console.WriteLine($"The left side is a {additionBody.Left.NodeType} expression");
            var left = (ParameterExpression)additionBody.Left;
            Console.WriteLine($"\tParameter Type: {left.Type.ToString()}, Name: {left.Name}");
            Console.WriteLine($"The right side is a {additionBody.Right.NodeType} expression");
            var right = (ParameterExpression)additionBody.Right;
            Console.WriteLine($"\tParameter Type: {right.Type.ToString()}, Name: {right.Name}");
        }
        EndDemo();
    }
}
