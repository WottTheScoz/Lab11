using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Task2 : MonoBehaviour
{
    List<string> Names = new List<string>{"Able", "Blade", "Cain", "David", "Essau", "Florence", "Gabriel", "Harry", "Isaac", "Jacob", "Kevin", "Leo", "Michael", "Nevaeh", "Oscar", "Peter", "Quinn", "Ramlethal", "Samson", "Tiberius", "Udas","Valentine", "Westley", "Xaiver", "Yahweh", "Zachariah"};


    string[] randomNames = new string[15];

    HashSet<string> nameList;

    HashSet<string> duplicateNames;

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
        foreach(string name in randomNames)
        {
            if(!nameList.Add(name))
            {
                //If you cannot add the name to the hashset, that means the name is already in the set, so it is a duplicate
                duplicateNames.Add(name);
            }
        }
    }

    void PrintOutResults()
    {
        
    }
}
