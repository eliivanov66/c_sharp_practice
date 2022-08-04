Console.WriteLine("Введите целое число: ");
double number = Convert.ToDouble(Console.ReadLine());
double result = .0;

number = Math.Abs(number);

result = -number;

while(result <= number)
{
 Console.WriteLine(result);

result = result+1.0;

}
