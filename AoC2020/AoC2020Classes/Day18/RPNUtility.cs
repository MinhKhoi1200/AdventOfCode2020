using System.Collections.Generic;
using System.Linq;

namespace AoC2020Classes.Day18
{
    public static class RpnUtility
    {
        internal static IEnumerable<string> ConvertToRpn(IEnumerable<string> rawExpression, Dictionary<string, int> operatorPrecedence)
        {
            var outputStack = new Stack<string>();

            var operationStack = new Stack<string>();

            foreach (var currentInputElement in rawExpression)
            {
                if (int.TryParse(currentInputElement, out _))
                {
                    outputStack.Push(currentInputElement);
                }
                else if (IsOperator(operatorPrecedence, currentInputElement))
                {
                    if (operationStack.Any())
                    {
                        if (operationStack.Peek() != "(")
                        {
                            if (operatorPrecedence[currentInputElement] <= operatorPrecedence[operationStack.Peek()])
                            {
                                outputStack.Push(operationStack.Pop());
                            }
                        }

                        operationStack.Push(currentInputElement);
                    }
                    else
                    {
                        operationStack.Push(currentInputElement);
                    }
                }
                else
                    switch (currentInputElement)
                    {
                        case "(":
                            operationStack.Push(currentInputElement);
                            break;
                        case ")":
                        {
                            while (operationStack.Peek() != "(")
                            {
                                var topOperationStack = operationStack.Pop();

                                outputStack.Push(topOperationStack);
                            }

                            operationStack.Pop();
                            break;
                        }
                    }
            }

            while (operationStack.Any())
            {
                outputStack.Push(operationStack.Pop());
            }

            return outputStack.ToList();

        }

        internal static long EvaluateRpn(IEnumerable<string> inputRpn)
        {
            var resultStack = new Stack<long>();
            foreach (var currentItem in inputRpn.Reverse())
            {
                if (int.TryParse(currentItem, out var result))
                {
                    resultStack.Push(result);
                }
                else
                {
                    var rightNumber = resultStack.Pop();
                    var leftNumber = resultStack.Pop();

                    switch (currentItem)
                    {
                        case "+":
                            resultStack.Push(leftNumber + rightNumber);
                            break;
                        case "*":
                            resultStack.Push(leftNumber * rightNumber);
                            break;
                    }
                }
            }

            return resultStack.Pop();
        }
        
        private static bool IsOperator(Dictionary<string, int> operatorPrecedence, string currentInputElement)
        {
            return operatorPrecedence.ContainsKey(currentInputElement);
        }
    }
}