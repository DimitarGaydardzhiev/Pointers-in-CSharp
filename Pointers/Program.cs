namespace Pointers
{
    class Program
    {
        static void Main(string[] args)
        {
            unsafe
            {
                Console.WriteLine(new string('-', 20));
                Console.WriteLine("Basic pointers example with inline declaration");
                Console.WriteLine(new string('-', 20));
                int number = 1;
                int* customPointer = &number;
                int** customPointerPointer = &customPointer;
                int*** customPointerPointerPointer = &customPointerPointer;

                Console.WriteLine($"The value of the integer is {number}");
                Console.WriteLine($"Address of {nameof(customPointer)}: {(int)customPointer}");
                Console.WriteLine($"Address of {nameof(customPointerPointer)}: {(int)customPointerPointer}");
                Console.WriteLine($"Address of {nameof(customPointerPointerPointer)}: {(int)customPointerPointerPointer}");
                Console.WriteLine();
            }

            Console.WriteLine(new string('-', 20));
            Console.WriteLine("Pointers example with method declaration");
            Console.WriteLine(new string('-', 20));
            UnsafeMethod();

            Console.ReadKey();
        }

        static unsafe void UnsafeMethod()
        {
            byte[] byteArray = { 1, 2, 3 };
            fixed (byte* pointerToSecondElement = &(byteArray[2]))
            {
                Console.WriteLine($"First element address: {(long)pointerToSecondElement:X}.");
                Console.WriteLine($"First element value: {*pointerToSecondElement}.");
            }

            //// Uncomment this line and you will get an error here.
            //// You are not allowed to get the address of an array element outside the fixed statement
            //// This is because the GC can change this address anytime, but it will be locked if used in fixed
            // byte* pointerToSecondElement1 = &(byteArray[2]);
        }
    }
}