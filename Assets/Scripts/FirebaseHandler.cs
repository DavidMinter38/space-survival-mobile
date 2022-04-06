using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;

public class FirebaseHandler : MonoBehaviour
{
    FirebaseDatabase database;
    DatabaseReference reference;

    void Start()
    {
        database = FirebaseDatabase.GetInstance(url: "https://space-survival-mobile-default-rtdb.firebaseio.com/");
        reference = database.RootReference;
    }

    void Update()
    {
        
    }

    public void UploadData(string[] newBestTimes)
    {
        reference.Child("scores").SetValueAsync(newBestTimes);
    }

    public void RetrieveData()
    {

    }
}
