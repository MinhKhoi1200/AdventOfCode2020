using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2020Classes.Day14
{
    public class BitMaskUtility
    {
        public static long ApplyBitMaskToMemoryContent(string bitMask, long inputNumber)
        {
            var inputNumberInBinary = Convert.ToString(inputNumber, 2);

            var paddedInputBinary = PadBinaryExpression(inputNumberInBinary, bitMask.Length);

            var outputNumberInBinary = "";

            for (var index = 0; index < bitMask.Length; index++)
            {
                if (bitMask[index].Equals('X'))
                {
                    outputNumberInBinary += paddedInputBinary[index];
                }
                else
                {
                    outputNumberInBinary += bitMask[index];
                }
            }

            var outputNumber = Convert.ToInt64(outputNumberInBinary, 2);

            return outputNumber;
        }

        public static List<long> ApplyBitMaskToMemoryAddress(string bitMask, long inputAddress)
        {
            var inputAddressInBinary = Convert.ToString(inputAddress, 2);

            var paddedInputBinary = PadBinaryExpression(inputAddressInBinary, bitMask.Length);

            var outputAddressBinary = "";

            var numberOfFloatingBits = 0;

            for (var index = 0; index < bitMask.Length; index++)
            {
                if (bitMask[index].Equals('0'))
                {
                    outputAddressBinary += paddedInputBinary[index];
                }
                else
                {
                    if (bitMask[index].Equals('X'))
                    {
                        numberOfFloatingBits += 1;
                    }

                    outputAddressBinary += bitMask[index];
                }
            }

            var binaryPermutations = GenerateBinaryPermutations(numberOfFloatingBits);

            var outputBinaryLists = binaryPermutations.Select(binaryPermutation => ReplaceAddressFloatingBits(outputAddressBinary, binaryPermutation)).ToList();

            var outputInt64Lists = outputBinaryLists.Select(i => Convert.ToInt64(i, 2)).ToList();

            return outputInt64Lists;
        }

        private static string PadBinaryExpression(string inputBinExpression, int numberOfBits)
        {
            if (inputBinExpression.Length > numberOfBits)
            {
                return null;
            }

            var numberOfPaddingZeros = numberOfBits - inputBinExpression.Length;

            var paddedZeros = new string('0', numberOfPaddingZeros);

            return paddedZeros + inputBinExpression;
        }

        private static List<string> GenerateBinaryPermutations(int numberOfDigits)
        {
            if (numberOfDigits == 1)
            {
                return new List<string> {"0", "1"};
            }

            var lowerDigitsPermutations = GenerateBinaryPermutations(numberOfDigits - 1);

            var binaryPermutations = lowerDigitsPermutations
                .Select(lowerDigitsPermutation => '0' + lowerDigitsPermutation).ToList();
            binaryPermutations.AddRange(
                lowerDigitsPermutations.Select(lowerDigitsPermutation => '1' + lowerDigitsPermutation));

            return binaryPermutations;
        }

        private static string ReplaceAddressFloatingBits(string address, string bitsToReplace)
        {
            var newAddressBinaryStringBuilder = new StringBuilder();
            var newAddressBinary = "";
            var bitIndex = 0;
            foreach (var bit in address)
            {
                switch (bit)
                {
                    case 'X':
                        newAddressBinaryStringBuilder.Append(bitsToReplace[bitIndex]);
                        bitIndex += 1;
                        break;
                    case '0':
                    case '1':
                        newAddressBinaryStringBuilder.Append(bit);
                        break;
                }
            }

            newAddressBinary = newAddressBinaryStringBuilder.ToString();

            return newAddressBinary;

        }
    }
}
