namespace LesserKnown.NET
{
    public class MemoryTDemo:MainDemo
    {
        //Source: https://www.codemag.com/Article/2207031/Writing-High-Performance-Code-Using-SpanT-and-MemoryT-in-C

        public void Run()
        {

            // System.Memory<T>, a wrapper over a contiguous region of memory. A Memory<T> instance
            // can be backed by an array of type T or a memory manager. As it can be stored on the
            // managed heap, Memory<T> has none of the limitations of Span<T>.

            string countriesStr = "India Belgium Australia USA UK Netherlands";
            IEnumerable<ReadOnlyMemory<char>> countries = ExtractStrings(countriesStr.AsMemory());

            var data = ExtractStrings(countriesStr.AsMemory());
            foreach (var str in data)
                Console.WriteLine(str);
            EndDemo();
        }
        public static IEnumerable<ReadOnlyMemory<char>> ExtractStrings(ReadOnlyMemory<char> c)
        {
            int index = 0, length = c.Length;
            for (int i = 0; i < length; i++)
            {
                if (char.IsWhiteSpace(c.Span[i]) || i == length)
                {
                    yield return c[index..i];
                    index = i + 1;
                }
            }
        }
    }
}
