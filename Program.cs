using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                for(int i = 0;i< nums.Length; i++)
                {
                    // Calculate the index corresponding to the value at nums[i]
                    int index = Math.Abs(nums[i]) - 1;
                    if (nums[index] > 0)
                    {
                        nums[index] = -nums[index]; // marking index as visited
                    }
                }

                List<int> missing = new List<int>();
                // Identify indices that were not visited
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] > 0)
                    {
                        missing.Add(i + 1); // collect unvisited indices
                    }
                }
                    return missing; 
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                int left = 0, right = nums.Length - 1;
                while (left < right)
                {
                    // Swap if left is odd and right is even
                    if (nums[left] % 2 > nums[right] % 2)
                    {
                        int temp = nums[left];
                        nums[left] = nums[right];
                        nums[right] = temp;
                    }
                    // Move left pointer if it's even
                    if (nums[left] % 2 == 0)
                        left++;
                    // Move right pointer if it's odd
                    if (nums[right] % 2 == 1)
                        right--;
                }
                return nums;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                Dictionary<int, int> map = new Dictionary<int, int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    int complement = target - nums[i];
                    // Check if the complement exists in the dictionary
                    if (map.ContainsKey(complement))
                    {
                        return new int[] { map[complement], i };
                    }
                    // Add the current number to the dictionary
                    if (!map.ContainsKey(nums[i]))
                        map[nums[i]] = i;
                }
                return new int[0];
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                Array.Sort(nums);
                int n = nums.Length;
                // Compare product of three largest numbers and product of two smallest and the largest number
                return Math.Max(nums[n - 1] * nums[n - 2] * nums[n - 3],nums[0] * nums[1] * nums[n - 1]);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                if (decimalNumber == 0) 
                    return "0";
                string binary = "";
                while (decimalNumber > 0)
                {
                    binary = (decimalNumber % 2) + binary;// prepend binary digits
                    decimalNumber /= 2;
                }
                return binary;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                int left = 0, right = nums.Length - 1;
                while (left < right)
                {
                    int mid = (left + right) / 2;
                    if (nums[mid] > nums[right])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid;
                    }
                }
                return nums[left]; // the smallest value
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                string s = x.ToString();
                char[] arr = s.ToCharArray();
                Array.Reverse(arr);
                return s == new string(arr);// true if original and reversed match
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                if (n == 0) 
                    return 0;
                if (n == 1) 
                    return 1;

                int a = 0, b = 1;
                for (int i = 2; i <= n; i++)
                {
                    int temp = a + b;
                    a = b;
                    b = temp;
                }
                return b;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
