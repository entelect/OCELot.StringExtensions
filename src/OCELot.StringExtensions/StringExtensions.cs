﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

// ReSharper disable once CheckNamespace - All extensions are within the same name space otherwise they don't show up in intellisense


namespace OCELot.StringExtensions
{
    /// <summary>
    /// Contains a variety of extensions for strings
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Checks if a string contains the specified value according to the provided comparison rules
        /// </summary>
        /// <param name="input">the string to check</param>
        /// <param name="value">the value to check for</param>
        /// <param name="stringComparison">the rules to use in the check</param>
        /// <returns>the value of the expression</returns>
        public static bool Contains(this string input, string value, StringComparison stringComparison)
        {
            return input.IndexOf(value, stringComparison) >= 0;
        }

        /// <summary>
        /// Determines whether the provided list of strings contains the specified string using the provided StringComparison object.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="value">The value.</param>
        /// <param name="stringComparison">The string comparison object to use.</param>
        /// <returns>True if the list contains the value otherwise false</returns>
        public static bool Contains(this IEnumerable<string> input, string value, StringComparison stringComparison)
        {
            return input.Any(item => item.Equals(value, stringComparison));
        }


        /// <summary>
        /// Takes in a Pascal Case string and spaces between the words
        /// </summary>
        /// <param name="input">The string to replace</param>
        /// <returns>The replaced string</returns>
        public static string PascalToSpacedString(this string input)
        {
            const string pascalCaseSplit = @"([a-z](?=[A-Z])|[A-Z](?=[A-Z][a-z]))";
            return Regex.Replace(input, pascalCaseSplit, "$1 ");
        }

        /// <summary>
        /// Takes in a Pascal Case string and splits it into an array of the words
        /// </summary>
        /// <param name="input">The string to replace</param>
        /// <returns>The array of words</returns>
        public static string[] PascalToSpacedStringArray(this string input)
        {
            return input.PascalToSpacedString().Split(' ');
        }

        /// <summary>
        /// Capitalises the first letter of the provided string, if there are multiple words in the string only the first will be capitalised
        /// Use this instead of ToTileCase if you wish to preserve camelCase formatting
        /// </summary>
        /// <param name="input">The string to capitialise the first letter of</param>
        /// <returns></returns>
        public static string CapitaliseFirstLetter(this string input)
        {
            return input.Substring(0, 1).ToUpper() + input.Substring(1);
        }

        /// <summary>
        /// Replaces all the values in a string, regardless of their case with the new value
        /// </summary>
        /// <param name="input">The string to search in</param>
        /// <param name="oldValue">The value to replace, not case sensitive</param>
        /// <param name="newValue">The replacement value</param>
        /// <returns></returns>
        public static string ReplaceIgnoreCase(this string input, string oldValue, string newValue)
        {
            return Regex.Replace(input, oldValue, newValue, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// Takes in a string and removes all whitespace in that string, regardless of its position.
        /// See http://stackoverflow.com/questions/6219454/efficient-way-to-remove-all-whitespace-from-string
        /// </summary>
        /// <param name="input">The string to replace</param>
        /// <returns>The replaced string</returns>
        public static string RemoveAllWhitespace(this string input)
        {
            return new string(input.ToCharArray().Where(c => !Char.IsWhiteSpace(c)).ToArray());
        }

        /// <summary>
        /// Indicates whether the spesified string is null or Empty.
        /// Wraps System.String.IsNullOrEmpty
        /// </summary>
        /// <param name="input">The string to test</param>
        /// <returns>False if input contains characters</returns>
        public static bool IsNullOrEmpty(this string input)
        {
            return string.IsNullOrEmpty(input);
        }

        /// <summary>
        /// Indicates whether the spesified string is null or Empty or only whitespace.
        /// Wraps System.String.IsNullOrWhiteSpace
        /// </summary>
        /// <param name="input">The string to test</param>
        /// <returns>False if input contains characters that are not whitespace characters</returns>
        public static bool IsNullOrWhiteSpace(this string input)
        {
            return string.IsNullOrWhiteSpace(input);
        }
		
		/// <summary>
        /// Will determine if the two strings passed are not equal.
		/// This is simply syntactical sugar to allow you to read the code better 
        /// </summary>
        /// <param name="firstString">A string to compare</param>
		/// <param name="secondString">The other string to compare against</param>
        /// <returns>True if the strings do not match each other</returns>
		public static bool DoesNotEqual(this string firstString, string secondString)
		{
			return !firstString.Equals(secondString);
		}
    }
}
