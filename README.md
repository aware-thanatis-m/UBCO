# UBCOWeb

UBCO Technical Exercise – .NET

Explanation
-----------------------------------------------------------------------
Model: 
-TranslationModel to hold the input string and the result.

Controller:
-Index : method to display the form.
-Submit : method to process with UI, perform to call translationService, and return the result.

View:
Index : 
-There is input type text for input text string and submit button for call controller and label for show result

-------------------------------------------------------------------------

Explanation of TranslationService

-start with result set "UBCO " first

-then foreach loop string foreach(char item in input)
there is 3 if inside loop

-first if item is in vowels then result will add this item double time

-2nd if item is normal letters then
 -check item is uppercase or lower case result will follow this case
 -then findindex of list of letters with item and index + 1 get another character with logic
   -normal case (index + 1) % lettersStr.Length will get next character
   -if character come with z (index + 1) % lettersStr.Length will get b
 -concat result

 -3rd if item come with space or punctuation, whitespace (else from first 2 if)

-end with call method CountWords Splits the input string by whitespace and counts the number of words and then convert to string and concat result

-return value