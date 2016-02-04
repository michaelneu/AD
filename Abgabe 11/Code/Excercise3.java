import java.util.*;
import java.lang.*;
import java.io.*;

class Excercise3 {
	
	public static int getMaxClique(int[][] ar){
		if(ar.length == 0)
			return 0;
		int i, index, count, curClique, maxClique = 1;
		int[][] clone, maxClone = null;
		
		for(count = 0; count < ar.length; count++){			
			curClique = 0;
			clone = deepCopy(ar, count);
			index = clone.length-1;
						
			for(i = index; i >= 0 && index >= 0; i--){
				if(clone[index][i] < 1)
					clearColumn(clone, i);										
				
				if(clone[i][index] < 1)
					clearLine(clone, i);	
			}			

			curClique = getCurClique(clone);
			
			if(curClique > maxClique){
				maxClique = curClique;
				maxClone = clone;
			}			
			if(maxClique >= index){
				return maxClique;	
			}
		}

		return maxClique;
	}
	
	public static int getCurClique(int[][] ar){
		int i, j, count = 0;

		for(i = 0; i < ar.length; i++)
			for(j = 0; j < ar.length; j++)
				if(ar[i][j] > 0)
					count++;

		return (int)Math.sqrt((double)count);
	}
	
	public static void clearColumn(int[][]ar, int index){
		for(int i = 0; i < ar.length; i++){
			ar[index][i] = 0;
		}		
	}

	public static void clearLine(int[][]ar, int index){
		for(int i = 0; i < ar.length; i++){
			ar[i][index] = 0;
		}
	}

	public static int[][] deepCopy(int[][] original, int count) {
	    if (original == null) {
	        return null;
	    }
	    final int[][] result = new int[original.length - count][];
	    for (int i = 0; i < original.length - count; i++) {
	        result[i] = Arrays.copyOf(original[i], original[i].length - count);
	    }
	    return result;
	}
	
	public static void main (String[] args) throws java.lang.Exception	{
		int[][] graph = {{1,1,0,0,0,0,1,1,1,1,0,1}, {1,1,1,0,1,0,0,0,0,0,0,0}, {0,1,1,1,0,0,0,1,0,0,0,0},
				 	 	 {0,0,1,1,1,1,0,0,0,0,1,0}, {0,1,0,1,1,1,0,0,0,0,1,0}, {0,0,0,1,1,1,0,0,0,0,1,0},
				 		 {1,0,0,0,0,0,1,1,1,1,0,1}, {1,0,1,0,0,0,1,1,1,1,0,1}, {1,0,0,0,0,0,1,1,1,1,0,1},
				 		 {1,0,0,0,0,0,1,1,1,1,0,1}, {0,0,0,1,1,1,0,0,0,0,1,0}, {1,0,0,0,0,0,1,1,1,1,0,1}};

		int s = getMaxClique(graph);
		System.out.println("Max Clique = " + s);
	}
}