using System;
class HelloWorld {
    /*Test Method*/
    static void Main() {
        Console.WriteLine("Num Of Digits : ",numOfDigits(158469));
        
        /*Binomial Expansion*/
        Console.WriteLine("Binomial Expansion");
        int i = 0, k=10;
        while(i<=k){
            for(int j=k;j>i;j--){
                Console.Write(" ");
            }
            binomialExpansion2(i);i++;
            Console.WriteLine();
        }

        /*Binomial Expansion 2*/
        Console.WriteLine("Binomial Expansion");
        k=10;i=0;
        while(i<=k){
            for(int j=k;j>i;j--){
                Console.Write(" ");
            }
            binomialExpansion(i);i++;
            Console.WriteLine();
        }
    }
    /*
        This function calculate num of digits from given number.
    */
    static int numOfDigits (int num){
        int temp = num;
        int counter = 0;
        while (temp > 0)
        {
            temp /= 10;
            counter++;
        }
        return counter;
    }
    /*
        Factorial Formula for Binomial Expansion
    */
    static double factorial(double n){
        double result = 1,i=1;
        while(i<=n){
            result *= i;i++;
        }
        return result;
    }
    /*
        C(power, i)   = power! / ( (power-i)! * i! ) 
    */ 
    static double C(double n, double i){
        return factorial(n)/(factorial(i)*factorial(n-i));
    }
    /*
        Binom Expansion Formula2 for Each Item
        item =>  (x+y)^n =  (i=0) to (i=n) € C(i to n) * (x^i) * (y^n-i)
    */
    static void binomialExpansion2 (double power){  
        double x = 1, y = 1;
        double result = 0;
        for(double i = 0; i < power; i++){
            result = C(power,i)*(double)Math.Pow(x,i)*(double)Math.Pow(y,power-i);
            Console.Write(" "+result);
        }
        Console.Write(" 1");
    }
    
    /*
    --------------------------------------------------------------------------------------------------------
    */

    /*
        Binom Expansion Formula for Each Item
        item => (n) => " (n!) / ((k!) * ((n-k)!) ) "
                (k)
    */
    static double formula(double n, double index){
        return factorial(n)/(factorial(index)*factorial(n-index));
    }
    /*
        n => rowCount, index => loop current index
    */
    static void binomialExpansion(double rowCount){
        double binomItem = 0;
        for(double i = 0; i<rowCount; i++){
            binomItem = formula(rowCount,i);
            Console.Write(" "+binomItem);
        }
        Console.Write(" 1");
    }    
}
