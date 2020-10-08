import java.util.Arrays;
public class Main
{
	public static void main(String[] args) {
		int[] array = {1,2,3,4,5,5,6,7,8,9};
		int[] array2 = {1,8,3,4,2,5,7,9,6};
		
		System.out.println(isSorted(array));
	    System.out.println(isSorted(array2));
	    
	    getMode(array);
	    
	}
    /*
        This function checks array is sorted or unsorted.
     */
	static String isSorted(int[] array){
	    int counter = 0;
	    int temp = array[0];
	    for (int i = 0;i < array.length;i++){  // O(n) time complexity
	        if(temp <= array[i]){
	            temp = array[i];
	            counter++;
	        }
	    }
	    return counter == array.length ? "Sorted" : "Not Sorted";
	}
	/*
        This function calculate mode in given array.
     */
	static void getMode(int[] array){
	    int temp = array[0];
	    int counter = 0;
	    int maxAgainCount = 0;
	    int mod = 0;
	    
	    // O (n^2) time complexity
	    for (int i = 0; i < array.length;i++){
	        for (int j = 0; j < array.length;j++){
	            if(array[i] == array[j]){
	                counter++;
	            }
	            if(maxAgainCount<counter){
	                maxAgainCount = counter;
	                mod = array[i];
	            }
	        }
	        counter = 0;
	    }
	    System.out.println("Mode : " + mod);
	}
}