using System;
class Reverse{
	static void Main(){
		Console.Write("Enter a String :");
		string str = Console.ReadLine();
	Console.WriteLine($"Reversed String : {ReverseString(str)}");
	}
	public static string ReverseString(string s){
		char[] charArray = s.ToCharArray();
        int start = 0;
        string result = "";

        for (int i = 0; i <= charArray.Length; i++)
        {
            if (i == charArray.Length || charArray[i] == ' ')
            {
                int end = i -1 ;
                while (end >= start)
                {
                    result += charArray[end];
                    end--;
                }
                if (i != charArray.Length)
                    result += ' ';
                start = i + 1;
            }
        }
        return result;
	}
}

//i/:-rhea lather
//o/p:-aehr rehtal


