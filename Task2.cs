using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Task2 : MonoBehaviour
{
    List<string> Names = new List<string>{"Able", "Blade", "Cain", "David", "Essau", "Florence", "Gabriel", "Harry", "Isaac", "Jacob", "Kevin", "Leo", "Michael", "Nevaeh", "Oscar", "Peter", "Quinn", "Ramlethal", "Samson", "Tiberius", "Udas","Valentine", "Westley", "Xaiver", "Yahweh", "Zachariah"};


    string[] randomNames = new string[15];

    HashSet<string> nameList = new HashSet<string>();

    HashSet<string> duplicateNames = new HashSet<string>();

    void Awake()
    {
        CreateNameArray();
        CheckDuplicateNames();
        PrintOutResults();
    }


    void CreateNameArray()
    {
        for(int i = 0; i < 15; i++)
        {
            randomNames[i] = Names[Random.Range(0, Names.Count)];
        }
        
    }

    void CheckDuplicateNames()
    {
        for(int i = 0; i < randomNames.Length; i++)
        {
            if (!nameList.Add(randomNames[i]))
            {
                //If you cannot add the name to the hashset, that means the name is already in the set, so it is a duplicate
                duplicateNames.Add(randomNames[i]);
            }
        }
    }

    void PrintOutResults()
    {
        string arrayOutput = "Created the name array: ";

        for(int i = 0; i < randomNames.Length; i++)
        {
            CheckForPeriod(i, randomNames.Length, ref arrayOutput, randomNames[i]);
        }

        string hashOutput = "The array has duplicate names: ";
        string[] duplicateNamesArray = duplicateNames.ToArray();

        for (int i = 0; i < duplicateNamesArray.Length; i++)
        {
            CheckForPeriod(i, duplicateNamesArray.Length, ref hashOutput, duplicateNamesArray[i]);
        }

        Debug.Log(arrayOutput);
        Debug.Log(hashOutput);
    }

    void CheckForPeriod(int loopInt, int loopMaxInt, ref string output, string name)
    {
        if (loopInt == loopMaxInt - 1)
        {
            output += name + ". ";
        }
        else
        {
            output += name + ", ";
        }
    }
}
