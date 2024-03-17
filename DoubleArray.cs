using System;
using static System.Console;
namespace MyNameSpace {
	class MyProgram {
		static void Main(){
			int[] myArray = {1,2,3};
			for( int i = 0; i<myArray.Length; i++ ){
				myArray[i] *=2;
			}
			WriteLine(String.Join(", ", myArray));
			
			for( int num in myArray ) {
				num *=2;
			}
			WriteLine(String.Join(", ", myArray));
		}
	}
}
