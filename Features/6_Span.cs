using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;

namespace LesserKnown.NET
{
    public class SpanTDemo:MainDemo
    {
        public void Run()
        {
            // Span and Memory types allow efficient slicing and manipulation of memory without unnecessary allocations.

            // Source: https://www.codemag.com/Article/2207031/Writing-High-Performance-Code-Using-SpanT-and-MemoryT-in-C

            // System.Span<T>, a type that's used to access a contiguous region of memory.
            // A Span<T> instance can be backed by an array of type T, a buffer allocated
            // with stackalloc, or a pointer to unmanaged memory. Because it has to be
            // allocated on the stack, it has a number of restrictions. For example, a field
            // in a class cannot be of type Span<T>, nor can span be used in asynchronous
            // operations.

            // Slicing enables data to be treated as logical chunks that can then be processed
            // with minimal resource overhead. Span<T> can wrap an entire array and, because it
            // supports slicing, you can make it point to any contiguous region within the
            // array.The following code snippet shows how you can use a Span<T> to point to a
            // slice of three elements within the array

            int[] numberArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Span<int> slice = new Span<int>(numberArray, 2, 3);


            Span<int> numbers = stackalloc int[] { 1, 2, 3, 4, 5 };
            //Span<int> numbers = [1, 2, 3, 4, 5];

            numbers[0] = 42;

            Console.WriteLine(numbers[0]); // Outputs: 42

            // create an empty Span, using the Span.Empty property

            Span<char> span1 = Span<char>.Empty;

            // create a byte array in the managed memory and then create a span instance out of it.

            var numberArray2 = new byte[100];
            var span2 = new Span<byte>(numberArray2);

            // allocate a chunk of memory in the stack and use a Span to point to it

            Span<byte> span3 = stackalloc byte[100];

            // create a Span using a byte array, store integers inside the byte array,
            // and calculate the sum of all the integers stored.

            var array4 = new byte[100];
            var span4 = new Span<byte>(array4);

            byte data4 = 0;
            for (int index = 0; index < span4.Length; index++)
                span4[index] = data4++;

            int sum4 = 0;
            foreach (int value in array4)
                sum4 += value;

            // creates a Span from the native memory

            var nativeMemory = Marshal.AllocHGlobal(100);
            Span<byte> span5;
            unsafe
            {
                span5 = new Span<byte>(nativeMemory.ToPointer(), 100);
            }
            EndDemo();
        }
    }
}
