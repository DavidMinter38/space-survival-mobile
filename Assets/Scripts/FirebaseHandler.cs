using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;

public class FirebaseHandler : MonoBehaviour
{
    FirebaseDatabase database;
    DatabaseReference reference;

    string[] names = new string[5];
    string[] scores = new string[5];

    void Awake()
    {
        database = FirebaseDatabase.GetInstance(url: "https://space-survival-mobile-default-rtdb.firebaseio.com/");
        reference = database.RootReference;

        database.GetReference("scores").ValueChanged += HandleValueChanged;
    }

    public void UploadData(string[] newNames, string[] newBestTimes)
    {
        reference.Child("scores").Child("names").SetValueAsync(newNames);
        reference.Child("scores").Child("times").SetValueAsync(newBestTimes);
    }

    //Template for HandleValueChanged: https://firebase.google.com/docs/database/unity/retrieve-data#value-events
    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        DataSnapshot snapshot = args.Snapshot;
        for(int i=0; i< scores.Length; i++)
        {
            names[i] = snapshot.Child("names").Child(i.ToString()).GetValue(true).ToString();
            scores[i] = snapshot.Child("times").Child(i.ToString()).GetValue(true).ToString();
        }
    }

    public string[] GetNames()
    {
        return names;
    }

    public string[] GetScores()
    {
        return scores;
    }

}
