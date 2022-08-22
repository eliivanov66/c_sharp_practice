long factorial(long arg_N)
{
    if (arg_N<=1) return 1;
    else return (arg_N*factorial(arg_N-1));
}
System.Console.WriteLine("Enter N: ");
long N=System.Convert.ToInt32(Console.ReadLine());
System.Console.WriteLine($"{N}! = {factorial(N)}");
for (int i=1; i < N; i++)
{
System.Console.WriteLine($"{i}! = {factorial(i)}");
}
