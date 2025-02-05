using System;
class Array2D{
	static void Main(){
		//Input the number of rows:
		Console.Write("Enter the number of rows :");
		int rows = Convert.ToInt32(Console.ReadLine());
		//Input the number of columns:
		Console.Write("Enter the number of columns :");
		int col = Convert.ToInt32(Console.ReadLine());
		
		Copy2DTo1D(rows,col);
	}
	static void Copy2DTo1D(int rows, int col){
		int[,] matrix = new int[rows,col];
		for(int i = 0; i < rows ; i++){
			for(int j = 0 ; j < col ;j++){
				Console.Write($"Enter element at position ({i},{j}): ");
				matrix[i,j] = Convert.ToInt32(Console.ReadLine());
			}
		}
		int[] array = new int[rows * col];
		
		// Copy the elements from the 2D array to the 1D array
        int index = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < col; j++)
            {
                array[index] = matrix[i, j];
                index++;
            }
        }

        // Display the 1D array
        Console.WriteLine("The elements in the 1D array are:");
        foreach (var element in array)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
	}
}