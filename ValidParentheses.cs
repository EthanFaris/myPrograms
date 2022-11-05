using System.Collections.Generic;

namespace Roughwork 
{ 
    
    class quicktests 
    { 
        public static bool IsValid(string s) 
        {
          bool valid = true; // flag indicating string validity.
          char c; // stores current character in the string.
          
          if (s[0] == ')' || s[0] == '}' || s[0] == ']' || s[s.Length - 1] == '(' || s[s.Length - 1] == '[' || s[s.Length - 1] == '{' || s.Length % 2 != 0 || s.Length == 1) // Checking for intial invalid properties. 
          { 
              valid = false; 
              return valid;
          }       

          LinkedList<int> OpenBraceList = new LinkedList<int>(); // Define Linked List to store the index of each open brace in the string.
          
          for (int i = 0; i < s.Length && valid == true; i++) // loop through each char in string. 
          { 
            c = s[i]; 
            switch (c) 
            { 
                case '(': // For each open brace, add its index to the linked list.
                  OpenBraceList.AddLast(i); 
                  break; 
                case '[': 
                  OpenBraceList.AddLast(i); 
                  break; 
                case '{': 
                  OpenBraceList.AddLast(i); 
                  break;
                case ')': // For each closed brace, check that it is opened by the correct brace and remove the corresponding open brace from the linked list.
                  if (OpenBraceList.First == null) 
                  { 
                    valid = false; 
                    break;
                  }
                  else 
                  { 
                    if (s[OpenBraceList.Last.Value] != '(') 
                    { 
                      valid = false; 
                      break;
                    }
                    else 
                    { 
                      OpenBraceList.RemoveLast(); 
                      break;
                    } 
                  }
                  
                case ']': 
                 if (OpenBraceList.First == null) 
                  { 
                    valid = false; 
                    break;
                  }
                  else 
                  { 
                    if (s[OpenBraceList.Last.Value] != '[') 
                    { 
                      valid = false; 
                      break;
                    }
                    else 
                    { 
                      OpenBraceList.RemoveLast(); 
                      break;
                    } 
                  }
                case '}': 
                  if (OpenBraceList.First == null) 
                  { 
                    valid = false; 
                    break;
                  }
                  else 
                  { 
                    if (s[OpenBraceList.Last.Value] != '{') 
                    { 
                      valid = false; 
                      break;
                    }
                    else 
                    { 
                      OpenBraceList.RemoveLast(); 
                      break;
                    } 
                  }
            } 
          }
          
          if (OpenBraceList.First != null) // If Linked List still has elements it means that there was not a proper matching of open and closed braces. 
          { 
            valid = false;  
          }
          return valid;
        }
        
        public static void Main(string[] args) 
        { 
          string s = "(){}[]"; 
          bool b = IsValid(s); 
          Console.WriteLine(b);     
        }

    }
}

