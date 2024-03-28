using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Task1 : MonoBehaviour
{
    List<string> Names = new List<string>{"Able", "Blade", "Cain", "David", "Essau", "Florence", "Gabriel", "Harry", "Isaac", "Jacob", "Kevin", "Leo", "Michael", "Nevaeh", "Oscar", "Peter", "Quinn", "Ramlethal", "Samson", "Tiberius", "Udas","Valentine", "Westley", "Xaiver", "Yahweh", "Zachariah"};
    List<string> LastName = new List<string>{"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};

    Queue<string> logInQueue = new();

    float timeBetweenLogin = 3f;
    float currentLoginTime;
    // Start is called before the first frame update
    void Start()
    {
            //Start the Queue
            currentLoginTime = timeBetweenLogin;
            StartQueue();
    }

    void Update()
    {
        if(currentLoginTime > 0)
        {
            currentLoginTime -= Time.deltaTime;
        }

        if(currentLoginTime <= 0)
        {
            LoginUser();

            //Add new person to the queue


        }
    }

    void StartQueue()
    {
        Debug.Log("Starting the queue.");
        for(int i = 0; i < 5; i++)
        {
            GenerateRandomUser();
        }

        var firstInLine = logInQueue.ToArray();
        Debug.Log("The queue is created with 5 users: " + firstInLine[0] + firstInLine[1] + firstInLine[2] + firstInLine[3] + firstInLine[4]);

    }

    void GenerateRandomUser()
    {
        int random = Random.Range(0, Names.Count);
        string newName = Names[random] + " "+ LastName[random] + " ";
        logInQueue.Enqueue(newName);
        Debug.Log(newName + " is now trying to log in and added to the queue.");
    }
    void LoginUser()
    {
        Debug.Log(logInQueue.Peek() + " is now inside the game.");
        logInQueue.Dequeue();
        currentLoginTime = timeBetweenLogin;
        GenerateRandomUser();
    }
}
