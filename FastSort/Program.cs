﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FastSort
{
    class Program
    {
        static void Main(string[] args)
        {

            CharNode rootNode = new CharNode();
            CharNode currentNode = rootNode;
            int receivedCharCode;
            bool isWordStarted = false;

            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            while ( (receivedCharCode = Console.Read()) != -1)
            {
                char receivedChar = Convert.ToChar(receivedCharCode);
                switch (receivedChar)
                {
                    case ' ':
                    case '\n':
                    case '\r':
                    case '\t':
                    case '\v':
                        if (isWordStarted)
                        {
                            currentNode.MarkAsFullWord();
                            currentNode = rootNode;
                            isWordStarted = false;
                        }
                        break;

                    default:
                        currentNode = currentNode.GetChild(receivedChar);
                        isWordStarted = true;
                        break;
                }
            }
            if (isWordStarted)
            {
                currentNode.MarkAsFullWord();
            }

            List<string> sortedWordList = new List<string>();
            rootNode.FillSortedWordsList("", sortedWordList);

            foreach (string word in sortedWordList)
            {
                Console.WriteLine(word);
            }
        }
    }
}
