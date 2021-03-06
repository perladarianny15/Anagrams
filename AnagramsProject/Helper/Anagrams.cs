﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AnagramsProject.Helper
{
    public class Anagrams
    {
        public static (Dictionary<String, List<String>>, List<String>) Get(String[] arr)
        {
            Dictionary<String, List<String>> map = new Dictionary<String, List<String>>();

            for (int i = 0; i < arr.Length; i++)
            {
                String word = arr[i];
                char[] letters = word.ToCharArray();
                Array.Sort(letters);
                String newWord = new String(letters);

                if (map.ContainsKey(newWord))
                {
                    map[newWord].Add(word);
                }
                else
                {
                    List<String> words = new List<String>();
                    words.Add(word);
                    map.Add(newWord, words);
                }
            }

            List<String> value = new List<String>();
            foreach (KeyValuePair<String,
                                 List<String>>
                        entry in map)
            {
                value.Add(entry.Key);
            }

            return (map, value);
            

        }
        public static void PrintAnagrams(Dictionary<String, List<String>> map, List<String> value)
        {
            int k = 0;
            string FileLine = string.Empty;
            foreach (KeyValuePair<String,
                                 List<String>>
                        entry in map)
            {
                List<String> values = map[value[k++]];

                if (values.Count > 1)
                {
                    Console.Write("[");
                    int len = 1;
                    foreach (String s in values)
                    {
                        Console.Write(s);
                        if (len++ < values.Count)
                            Console.Write(", ");
                    }

                    Console.Write("]");

                    Console.WriteLine("\n");

                    //Write Anagrams into a File
                    FileLine = string.Join(",", values);

                    List<string> lines = new List<string>();
                    lines.Add(FileLine);
                    File.AppendAllLines(@"AnagramResults.txt", lines);
                }
            }
            Console.WriteLine("Total of words: " + map.Count);

        }
        public static void BiggestWord(Dictionary<String, List<String>> map, List<String> value)
        {
            int count = 0;
            //int k = 0;
            string key = "";
            
            foreach (var item in map)
            {
                //values = map[value[k++]];
                if (item.Value.Count > count)
                {
                    count = item.Value.Count;
                    key = item.Key;
                }
            }
            List<String> values = map[key];
            Console.Write("[");
            int len = 1;
            foreach (String s in values)
            {
                Console.Write(s);
                if (len++ < values.Count)
                    Console.Write(", ");
            }

            Console.Write("]");
        }
    }
}
