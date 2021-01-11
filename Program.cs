﻿using System;
using System.Collections.Generic;


namespace C_
{

    public class Calculator {

        
        #region MATH_OPERATOR_METHODS
        public void Add() {

                String      userAdditionInput = String.Empty;
                long         total = 0;
                List<long>   operands = new List<long>();


                Console.WriteLine("Enter the numbers you wish to add, each followed by 'Enter'. When You're ready to add them all, submit '=':");

            
                while (userAdditionInput != "=") {

                    userAdditionInput = ReadUserInput();
                    

                    TryParseUserInput(userAdditionInput);


                    /* void TryParseUserInput(); --------------------------------------
                    try {
                        us*rAdditionInput_AsLong = int.Parse(userAdditionInput);
                    }
                    catch (FormatException) {
                        if (userAdditionInput != "=") {
                            Console.WriteLine("Can't parse the user's operand as an integer");
                        }
                    }
                    */

                    // AddOperandsToExpressionList() -----------------------------------
                    operands.Add(userAdditionInput_AsLong);
                    userAdditionInput_AsLong = 0;                    
            

                    // DisplayCurrentOperands(); ---------------------------------------
                    foreach (long i in operands) {
                        if (i != 0) { Console.Write(i + " "); }
                    }
                
                }


                // CalculateTotal();        [ResolveExpression()]
                foreach (long i in operands) {
                    total += i;
                }
                Console.WriteLine("\ntotal: " + total);
            }
                
        public long Multiply(long x, long y) {
            
            // Beginning at a different total value can change the reference point
            // If this will be modular, then 0 should be the reference point
            // We don't want the internals of this method depending on any external state,
            // just the arguments we pass in through params x, y. I.e. pure function.
            long total = 0;

            // add one argument x to zero argument y times.
            for (int i = 0; i < y; i++) {
                total += x;
            }
            return total;
        }
        
        public string DivideFirstArgBySecondArg(long remainder, long divisor) {
            
            // subtract one operand from the other until the remainder < y
            // need to figure out the correct way to order and name these
            // try renaming the remainder to numerator and instantiating the remainder in the method: 
            // would result in having stored both the values of the expression and the answer.


            // Beginning at a different total value can change the reference point
            // If this will be modular, then 0 should be the reference point
            // We don't want the internals of this method depending on any external state,
            // just the arguments we pass in through params x, y. I.e. pure function.
            long numOfSubtractions = 0;

            // may need to revisit this to make it cleaner, gut tells me that having this in twice is redundant
            // I could just return x, but then the code becomes non-self documenting. 
            // Soln: name the variables remainder and divisor


            // subtract the divisor from the remainder while the remainder (numerator) is greater than or equal to the divisor.
            // if the divisor is greater than the remainder (numerator), numOfSubtractions remains 0 and the fraction is returned in its simplified form
            while (remainder >= divisor) {
                remainder = remainder - divisor;
                numOfSubtractions++;  
            }

            if (numOfSubtractions > 0) {
                return (numOfSubtractions, remainder).ToString();
            }   else {
                return SimplifyFraction(remainder, divisor);
            }
        }
        #endregion

        #region HELPERS
        // What happens if a, b have no common factors?
        // I think this will be handled by the previous division method but needs to be tested.
        // this should sit within a 'SimplifyFraction(a, b)' function.
        long GetHighestCommonFactor(long a, long b) {

            // is there a way to not have to write this to memory? Overwrite with new value instead somehow.
            long r = a % b;

            if (r != 0) {
                return GetHighestCommonFactor(b, r);
            }
            else{ 
                
                return b; 
            }
        } 

        string SimplifyFraction(long numerator, long divisor) {

            long highestCommonFactor = GetHighestCommonFactor(numerator, divisor);

            // Could use my own divide method here - probably not as fast. 
            long newNumerator = numerator/highestCommonFactor;
            long newDivisor = divisor/highestCommonFactor;

            // redundant, may be over-documentation
            string simplifiedFraction = newNumerator + " / " + newDivisor;

            return simplifiedFraction;
        }        
        #endregion

        string ReadUserInput() {

            Console.WriteLine("");
            return Console.ReadLine();
        }

        long TryParseUserInput(string userAdditionInput) {
            
            try {

                long userAdditionInput_AsLong = int.Parse(userAdditionInput);
                return userAdditionInput_AsLong;


            } catch (FormatException) {

                if (userAdditionInput != "=") {
                    Console.WriteLine("Can't parse the user's operand as an integer");
                }
            }

            return 0;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            
            Calculator calc = new Calculator();
            String userDefinedOperation;

            Console.WriteLine("What would you like to do?");
            userDefinedOperation = Console.ReadLine();

            Console.WriteLine("You would like to: " + userDefinedOperation);
           
            if (userDefinedOperation.ToLower() == "add") {
                calc.Add();
            }
            else if(userDefinedOperation.ToLower() == "divide"){
                
                // Hard coded divide test
                Console.WriteLine(calc.DivideFirstArgBySecondArg(8, 16));

            } else if(userDefinedOperation.ToLower() == "multiply"){

                // Hard Coded Multiply test
                Console.WriteLine(calc.Multiply(2, 8));

            } else if(userDefinedOperation.ToLower() == "exit"){
                
                Console.WriteLine("Goodbye!");
            
            } else {

                Console.WriteLine("Undefined Operation. Please choose 'add,' 'subtract,' 'divide,' or 'multiply.'");

            }
        }   
    }
}