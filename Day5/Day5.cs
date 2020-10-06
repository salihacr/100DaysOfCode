using System;
class HelloWorld {
  static void Main() {

    primeNumbers(1000);
    
    int num = 1258946730;
    Console.WriteLine("Sum of digits of the number '{0}' : {1} ",num,sumOfDigits(num));
  }
  /*
    The function that whether the given numbers is prime.
  */
  static bool isPrime(int num){
      int i = 2;
      bool flag = true;
      while(i < ((num/2)+1)){
          if(num % i == 0){
              flag = false;
          }
          i++;
      }
      return flag;
  }
  /*
    Test function that gives all prime numbers up to the given number.
  */
  static void primeNumbers(int to){
      int i = 2;
      while(i<to){
          if(isPrime(i)){
             Console.WriteLine("{0} is even.",i);
          }i++;
      }
  }
  /*
    Sum of digits from given number.
  */
  static int sumOfDigits(int num){
      int total = 0, i = 0;
      int digit;
      while(i<num){
          digit = num % 10;
          num = num / 10;
          total+=digit;
      }
      return total;
  }
}
