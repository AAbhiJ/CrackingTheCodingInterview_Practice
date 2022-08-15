// 1.1 Is Unique : Implement an algorithm to determine if a string has all unique charachters. What if you cannot use additional data structures?

//
// 1) 
//
// Explanation : Here we have are iterating through the sentence, and storing each charachters count in a array (charCount) of 26 length
// where 0 index stores count of letter a or A, 1 index stores count of letter b or B and So on.
// Then we iterating through the charCount Array and if any value in the array is greater than 1, that means the character present more than one in the sentence
// so if it appear more than one we are printing 'Sentence has duplicate character'
//
// Time Complexity : O(N + K)
// Where N : Length of Sentence
// K : charCount Array length (26)
//
// Space Complexity : O(1)

using System;
using System.Collections;

namespace CTCI{
    class IsUniqe1{
        public static void Main(){
            int[] charCounts = new int[26];
            string sentence = "abhiZ";
            int smallCharStart = (int)'a';
            int smallCharEnd = (int)'z';
            int bigCharStart = (int)'A';
            int bigCharEnd = (int)'Z';

            foreach(char c in sentence){
                int currChar = (int)c;
                int MinusChar = -1;
                if(currChar >= smallCharStart && currChar <= smallCharEnd ){
                    MinusChar = smallCharStart;
                }
                else if(currChar >= bigCharStart && currChar <= bigCharEnd ){
                    MinusChar = bigCharStart;
                }
                if(MinusChar!=-1){
                    // Console.WriteLine("currchar " + currChar);
                    // Console.WriteLine("minus " + MinusChar);
                    // Console.WriteLine("diff " + (currChar - MinusChar));
                    charCounts[currChar - MinusChar] += 1;
                    // Console.WriteLine("charinarr " + charCounts[currChar - MinusChar]);
                }
            }
            foreach(int cnt in charCounts){
                // Console.WriteLine("cont " + cnt);
                if(cnt > 1){
                    Console.WriteLine("String has duplicate letters");
                    return;
                }
            }
            Console.WriteLine("String do not has duplicate letters");

        }
    }
}

// ------------------------------------------------------------------------------------------------------------

//
// 2) 
//
// Explanation : Here we are check dulicate character for all 128 char.
// if the sentence length is greater than 128 char then it must have dulicate character since there are only 128 characters.
// then we have taken and initilizing a bool array of length 128 to false
// then we are iterating through the sentence and we are checking if the index value is true; 
// if yes then that means that charachter is present previously so we are returning false(that means duplicate element found)  
// if no then making the index to true.
// if we iterating through complete sentence but did not found any duplicate element then we exists the loop and in end return true. 
//
// Time Complexity : O(N) or O(C)
// the time complexity is O(N) Where N : length of sentence
// but we since the loop will not run for more than 128 (because we are checking on starting the length) we can say it is O(min(C,N)) or O(C) 
// Where C : size of character set(ie. 128)
//
// Space Complexity :  O(1)
// 
using System;
using System.Collections;

namespace CTCI{
    class IsUniqe{
        public static void Main(){
            if(solution2("abhi")){
                Console.WriteLine("Not Duplicate");
            }else{
                Console.WriteLine("Duplicate");
            }
        }

        static bool solution2(string sentence){
            if(sentence.Length > 128){
                return false;   
            }
            bool[] charCounts = new bool[128]; 
            for(int i = 0; i < 128 ; i++){
                charCounts[i] = false;
            }
            
            foreach(char i in sentence){
                if(charCounts[(int)i]){
                    return false;
                }
                charCounts[(int)i] = true;
            }
            return true;
        }
    }
}

