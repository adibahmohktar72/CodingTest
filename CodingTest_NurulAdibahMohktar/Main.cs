using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodingTest_NurulAdibahMohktar
{
    public partial class Main : Form
    {
        double sumOfString = 0.0;
        public Main()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            sumOfString = CalculateString(tbInputNumber.Text);
            tbResult.Text = sumOfString.ToString();
        }

        public double CalculateString(string num)
        {
            double result = 0, resultNumInBracket = 0.0, numDouble = 0.0, firstnum = 0.0;
            bool hasBracket = false;
            //separate commas
            string[] numWithoutSpaces = num.Split();
            string preOperator = "";
            string[] tempStringResult = null;

            //tempStringResult = BracketCalculation(numWithoutCommas);

            //Find string array if has bracket
            foreach (string content in numWithoutSpaces)
            {
                if(content.Contains("(") || content.Contains(")"))
                {
                    hasBracket = true;
                    break;
                }
            }

            if(hasBracket)
            {
                tempStringResult = BracketCalculation(numWithoutSpaces);
            }
            else
            {
                tempStringResult = DoCalculation(numWithoutSpaces);
            }

            return result = Convert.ToDouble(tempStringResult[0]);
        }

        public string[] BracketCalculation(string[] num)
        {
            string[] result = null;
            List<int> openBracketIdx = new List<int>();
            List<int> closeBracketIdx = new List<int>();
            string[] tempNumString = null;
            string valStringInBracket = "";
            List<String> tempString = new List<string>();
            List<string> updateNumWithoutSpaces = new List<string>();

            //find "(" and ")" index and store into list
            for (int i = 0; i< num.Length; i++)
            {
                if (num[i].Contains("("))
                {
                    openBracketIdx.Add(i);
                }

                if (num[i].Contains(")"))
                {
                    closeBracketIdx.Add(i);
                }
            }

            foreach(string str in num)
            {
                updateNumWithoutSpaces.Add(str);
            }

            //check if bracket is same amount or not
            if (openBracketIdx.Count != closeBracketIdx.Count)
                MessageBox.Show("Invalid input format. Please insert again.");

            //get string num between the most inner "(" and ")
            for (int idx = openBracketIdx.Count - 1; idx > -1 ; idx--)
            {
                //if ((string.Concat(num)).Contains("."))
                //{
                    string[] tempNumStringArray = null;
                    List<String> tempNumStringList = new List<string>();
                    for (int x = openBracketIdx[idx] + 1; x < closeBracketIdx[0]; x++)
                    {
                        tempNumStringList.Add(num[x]);
                    }
                    tempString = tempNumStringList;
                #region Old code
                /*
                }
                else
                {
                    /*
                    valStringInBracket = (string.Concat(num)).Substring(openBracketIdx[idx] + 1, closeBracketIdx[0] - (openBracketIdx[idx] + 1));
                    
                    foreach (char ch in valStringInBracket)
                    {
                        tempString.Add(ch.ToString());
                    }
                    *//*
                    string[] tempNumStringArray = null;
                    List<String> tempNumStringList = new List<string>();
                    for (int x = openBracketIdx[idx] + 1; x < closeBracketIdx[0]; x++)
                    {
                        tempNumStringList.Add(num[x]);
                    }
                    tempString = tempNumStringList;
                }
                */
                #endregion
                tempNumString = DoCalculation(tempString.ToArray());

                //update num in string
                //insert tempNumString to index of open bracket
                updateNumWithoutSpaces.Insert(openBracketIdx[idx], string.Concat(tempNumString));
                //remove item after index of opern bracket until index of close bracket
                for (int incr = openBracketIdx[idx] + 1; incr < updateNumWithoutSpaces.IndexOf(")") + 1; incr++)
                {
                    updateNumWithoutSpaces.RemoveAt(incr);
                    incr = openBracketIdx[idx];
                }
                //add ) at end of string if there is still open bracket left
                if(updateNumWithoutSpaces.IndexOf("(") > -1)
                    updateNumWithoutSpaces.Add(")");

                num = updateNumWithoutSpaces.ToArray();
                tempString.Clear();

                //update closeBracket idx
                closeBracketIdx.Clear();
                for (int i = 0; i < num.Length; i++)
                {
                    if (num[i].Contains(")"))
                    {
                        closeBracketIdx.Add(i);
                    }
                }
            }

            return result = DoCalculation(num);
        }

        public string[] DoCalculation(string[] num)
        {
            string[] result = null;
            string[] tempNumWithoutSpaces = null;
            int firstIdxMultiply = 0, firstIdxDivide = 0, firstIdxPlus = 0, firstIdxMinus = 0;


            //check if current string has * and / operator
            if ((string.Concat(num).Contains("*")) || (string.Concat(num).Contains("/")))
            {
                //check which operator in front, then do the operation first
                firstIdxMultiply = Array.IndexOf(num, "*");
                firstIdxDivide = Array.IndexOf(num, "/");

                tempNumWithoutSpaces = num;

                if (firstIdxMultiply < firstIdxDivide)
                {
                    tempNumWithoutSpaces = MultiplyCalculation(tempNumWithoutSpaces);
                    tempNumWithoutSpaces = DivideCalculation(tempNumWithoutSpaces);

                    //check + and - operator position
                    firstIdxPlus = Array.IndexOf(tempNumWithoutSpaces, "+");
                    firstIdxMinus = Array.IndexOf(tempNumWithoutSpaces, "-");

                    if (firstIdxPlus < firstIdxMinus)
                    {
                        tempNumWithoutSpaces = PlusCalculation(tempNumWithoutSpaces);
                        tempNumWithoutSpaces = MinusCalculation(tempNumWithoutSpaces);
                    }
                    else
                    {
                        tempNumWithoutSpaces = MinusCalculation(tempNumWithoutSpaces);
                        tempNumWithoutSpaces = PlusCalculation(tempNumWithoutSpaces);
                    }
                }
                else
                {
                    tempNumWithoutSpaces = DivideCalculation(tempNumWithoutSpaces);
                    tempNumWithoutSpaces = MultiplyCalculation(tempNumWithoutSpaces);

                    //check + and - operator position
                    firstIdxPlus = Array.IndexOf(tempNumWithoutSpaces, "+");
                    firstIdxMinus = Array.IndexOf(tempNumWithoutSpaces, "-");

                    if (firstIdxPlus < firstIdxMinus)
                    {
                        tempNumWithoutSpaces = PlusCalculation(tempNumWithoutSpaces);
                        tempNumWithoutSpaces = MinusCalculation(tempNumWithoutSpaces);
                    }
                    else
                    {
                        tempNumWithoutSpaces = MinusCalculation(tempNumWithoutSpaces);
                        tempNumWithoutSpaces = PlusCalculation(tempNumWithoutSpaces);
                    }
                }
                num = tempNumWithoutSpaces;
            }
            else
            {
                //only + and - operator
                //check + and - operator position
                firstIdxPlus = Array.IndexOf(num, "+");
                firstIdxMinus = Array.IndexOf(num, "-");

                tempNumWithoutSpaces = num;

                if (firstIdxPlus < firstIdxMinus)
                {
                    tempNumWithoutSpaces = PlusCalculation(tempNumWithoutSpaces);
                    tempNumWithoutSpaces = MinusCalculation(tempNumWithoutSpaces);
                }
                else
                {
                    tempNumWithoutSpaces = MinusCalculation(tempNumWithoutSpaces);
                    tempNumWithoutSpaces = PlusCalculation(tempNumWithoutSpaces);
                }
                num = tempNumWithoutSpaces;
            }


            return result = num;
        }

        public String[] MultiplyCalculation(String[] numbers)
        {
            string[] result = null;
            double tempResult = 0.0;
            List<string> updateNumWithoutSpaces = new List<string>();

            //calculate number with this operation first. Then continue with + and - operation
            int numLength = (string.Concat(numbers)).Length;


            //count operator * and / in num string and
            //find position of operator * and /
            double prevNum = 0.0, nextNum = 0.0;

            for (int idx = 0; idx < numbers.Length; idx++)
            {
                if (numbers[idx].Contains("*"))
                {
                    prevNum = Convert.ToDouble(numbers[idx - 1]);
                    nextNum = Convert.ToDouble(numbers[idx + 1]);

                    tempResult = prevNum * nextNum;
                    //update list number in numWithoutCommas with latest value
                    numbers[idx - 1] = tempResult.ToString();

                    foreach (string val in numbers)
                    {
                        updateNumWithoutSpaces.Add(val);
                    }

                    //Set new list of numWithoutCommas
                    updateNumWithoutSpaces.RemoveAt(idx); //index of current multiply operator
                    updateNumWithoutSpaces.RemoveAt(idx); //index of num next index of current multiply operator -> length has been reduced

                    numbers = updateNumWithoutSpaces.ToArray();
                    updateNumWithoutSpaces.Clear();
                    idx = -1;
                }
            }

            return result = numbers;
        }

        public String[] DivideCalculation(String[] numbers)
        {
            string[] result = null;
            double tempResult = 0.0;
            List<string> updateNumWithoutSpaces = new List<string>();

            //calculate number with this operation first. Then continue with + and - operation
            int numLength = (string.Concat(numbers)).Length;


            //count operator * and / in num string and
            //find position of operator * and /
            double prevNum = 0.0, nextNum = 0.0;

            for (int idx = 0; idx < numbers.Length; idx++)
            {
                if (numbers[idx].Contains("/"))
                {
                    prevNum = Convert.ToDouble(numbers[idx - 1]);
                    nextNum = Convert.ToDouble(numbers[idx + 1]);

                    tempResult = prevNum / nextNum;
                    //update list number in numWithoutCommas with latest value
                    numbers[idx - 1] = tempResult.ToString();

                    foreach (string val in numbers)
                    {
                        updateNumWithoutSpaces.Add(val);
                    }

                    //Set new list of numWithoutCommas
                    updateNumWithoutSpaces.RemoveAt(idx); //index of current divide operator
                    updateNumWithoutSpaces.RemoveAt(idx); //index of num next index of current divide operator -> length has been reduced

                    numbers = updateNumWithoutSpaces.ToArray();
                    updateNumWithoutSpaces.Clear();
                    idx = -1;
                }
            }
            return result = numbers;
        }

        public String[] PlusCalculation(String[] numbers)
        {
            string[] result = null;
            double tempResult = 0.0;
            List<string> updateNumWithoutSpaces = new List<string>();

            //calculate number with this operation first. Then continue with + and - operation
            int numLength = (string.Concat(numbers)).Length;


            //count operator * and / in num string and
            //find position of operator * and /
            double prevNum = 0.0, nextNum = 0.0;

            for (int idx = 0; idx < numbers.Length; idx++)
            {
                if (numbers[idx].Contains("+"))
                {
                    prevNum = Convert.ToDouble(numbers[idx - 1]);
                    nextNum = Convert.ToDouble(numbers[idx + 1]);

                    tempResult = prevNum + nextNum;
                    //update list number in numWithoutCommas with latest value
                    numbers[idx - 1] = tempResult.ToString();

                    foreach (string val in numbers)
                    {
                        updateNumWithoutSpaces.Add(val);
                    }

                    //Set new list of numWithoutCommas
                    updateNumWithoutSpaces.RemoveAt(idx); //index of current plus operator
                    updateNumWithoutSpaces.RemoveAt(idx); //index of num next index of current plus operator -> length has been reduced

                    numbers = updateNumWithoutSpaces.ToArray();
                    updateNumWithoutSpaces.Clear();
                    idx = -1;
                }
            }
            return result = numbers;
        }

        public String[] MinusCalculation(String[] numbers)
        {
            string[] result = null;
            double tempResult = 0.0;
            List<string> updateNumWithoutSpaces = new List<string>();

            //calculate number with this operation first. Then continue with + and - operation
            int numLength = (string.Concat(numbers)).Length;


            //count operator * and / in num string and
            //find position of operator * and /
            double prevNum = 0.0, nextNum = 0.0;

            for (int idx = 0; idx < numbers.Length; idx++)
            {
                if (numbers[idx].Contains("-") && idx != 0)
                {
                    prevNum = Convert.ToDouble(numbers[idx - 1]);
                    nextNum = Convert.ToDouble(numbers[idx + 1]);

                    tempResult = prevNum - nextNum;
                    //update list number in numWithoutCommas with latest value
                    numbers[idx - 1] = tempResult.ToString();

                    foreach (string val in numbers)
                    {
                        updateNumWithoutSpaces.Add(val);
                    }

                    //Set new list of numWithoutCommas
                    updateNumWithoutSpaces.RemoveAt(idx); //index of current divide operator
                    updateNumWithoutSpaces.RemoveAt(idx); //index of num next index of current divide operator -> length has been reduced

                    numbers = updateNumWithoutSpaces.ToArray();
                    updateNumWithoutSpaces.Clear();
                    idx = -1;
                }
            }
            return result = numbers;
        }


    }
}
