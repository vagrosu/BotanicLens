
using System;
using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine;

public class FirebaseHandler
{
    private DatabaseReference databaseReference;
    public List<string> plants;
    public FirebaseHandler()
    {
        plants = new List<string>();
        InitializeFirebase();
    }

    private void InitializeFirebase()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            FirebaseApp app = FirebaseApp.DefaultInstance;
            databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
            string collectionName = "inventory";
            databaseReference.Child("inventory").Child("2343432").SetValueAsync("Cactus");
            RetrieveCollectionElements(databaseReference.Child(collectionName));
        });
    }

    private async void RetrieveCollectionElements(DatabaseReference collectionReference)
    {
        try
        {
            DataSnapshot snapshot = await collectionReference.GetValueAsync();

            if (snapshot != null && snapshot.Exists)
            {
                foreach (var childSnapshot in snapshot.Children)
                {
                    string key = childSnapshot.Key;
                    string value = childSnapshot.GetRawJsonValue();

                    Debug.Log($"Key: {key}, Value: {value}");
                    this.plants.Add(value);
                }
            }
            else
            {
                Debug.Log("Collection is empty or does not exist.");
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"Error retrieving collection elements: {e.Message}");
        }
    }
}
