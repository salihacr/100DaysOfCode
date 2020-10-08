import java.util.Arrays;
public class Main
{
	public static void main(String[] args) {
	    
	    int[] array = {12,15,1,3,5,89,21,60,34,54,78,25,41,27,7,105,42,66};
	    System.out.println("Largest Second Element : "+ 
	        findLargestSecondElement(array));
	        
	        
	   System.out.println(counterOddAndEven(array,true));
	   System.out.println(counterOddAndEven(array,false));
	   sortArraySeparately(array);
	    
    }
    static void sortArraySeparately(int[] array){
        
        // o(n) space complexity
        int[] odd = new int[counterOddAndEven(array)];
        int[] even = new int[counterOddAndEven(array)];
        
        int j = 0, k = 0;
        for(int i = 0; i< array.length; i++){
            if(array[i] % 2 == 1){
                odd[j] = array[i];
                j++;
            }
            if(array[i] % 2 == 0){
                even[k] = array[i];
                k++;
            }
        }
        sortArray(odd);
        for(int i = 0; i<odd.length; i++){
            System.out.print(" " + odd[i]);
        }
        sortArray(even);
        for(int i = 0; i<even.length; i++){
            System.out.print(" " + even[i]);
        }
    }
    
    static int counterOddAndEven(int[] array, boolean odd){
        int counter = 0;
        for(int i = 0; i< array.length; i++){
            if(odd){
                if(array[i] % 2 == 1){
                    counter++;
                }
            }
            else{
                if(array[i] % 2 == 0){
                    counter++;
                }
            }
        }
        return counter;
    }
    
    static int[] sortArray(int[] array){
        
    }
    
	static int findLargestSecondElement(int[] array){
	    int max = array[0], max2= array[0];
	    for(int i = 0; i < array.length; i++){
	        if(array[i] > max){
	            max = array[i];
	        }
	    }
	    for(int i = 0; i < array.length; i++){
	        if((array[i] > max2) && (array[i] != max)){
	            max2 = array[i];
	        }
	    }
	    return max2;
	}
}