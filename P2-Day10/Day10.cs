using System;
class HelloWorld {

    static void Main() {
        toCharArr("test");
        func1("salih");
        func2("computer");
        func3("engineer");
    }
    /*
        This function splits the given word into its letters.
    */
    static char[] toCharArr(string word){
        char[] chars = new char[word.Length];
        int index = 0;
        foreach(var item in word){
            chars[index]= item;
            index++;
        }
        return chars;
    }
    /*
        These functions do this following,
        s
        sa
        sal
        sali
        salih
    */
    // Sample 1 => O(n^2) time complexity
    static void func1(string word){
        char[] chars = toCharArr(word);
        for(int i = 0; i < chars.Length; i++){
            for(int j = 0; j <= i; j++){
                Console.Write(chars[j]);
            }
            Console.WriteLine();
        }
    }
    // Sample 2=> O(n) time complexity
    static void func2(string word){
        string chars = "";
        for(int i = 0; i < word.Length; i++){
            chars+=word[i];
            Console.WriteLine(chars);
        }
    }
    // Sample 3 => O(n^2) time complexity
    static void func3(string word){
        for(int i = 0; i < word.Length; i++){
            for(int j = 0; j <= i; j++){
                Console.Write(word[j]);
            }
            Console.WriteLine();
        }
    }
}
