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

    string[] scores = new string[5];

    void Awake()
    {
        database = FirebaseDatabase.GetInstance(url: "https://space-survival-mobile-default-rtdb.firebaseio.com/");
        reference = database.RootReference;

        database.GetReference("scores").ValueChanged += HandleValueChanged;
    }

    public void UploadData(string[] newBestTimes)
    {
        reference.Child("scores").SetValueAsync(newBestTimes);
    }

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
            scores[i] = snapshot.Child(i.ToString()).GetValue(true).ToString();
        }
    }

    public string[] GetScores()
    {
        return scores;
    }

}
