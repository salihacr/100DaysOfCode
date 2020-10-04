using System;

class HelloWorld {
  static void Main() {
    Console.WriteLine(celciusToFahrenheit(30));
    sumFactors(1000);
  }
  /*
    This function convert celcius to fahrenheit.
  */
  static double celciusToFahrenheit(double celcius){
      return ((celcius * 1.8) + 32);
  }
  /*
    This function sum factors from given number. 
  */
  static void sumFactors(int value){
      int i = 1;
      while(i<=value){
          if(value%i==0){
              Console.Write(" "+i);
          }i++;
      }
  }
}
