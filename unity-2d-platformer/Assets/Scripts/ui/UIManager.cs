//Jeshan Soosainathan - 000924893
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public Player player;

    public GameObject silverKey;

    public List<GameObject> keys = new List<GameObject>();

    public Transform KeyHolderUI;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Show keys on the UI
  public  void UpdateUI()
    {

        foreach (var key in keys)
        {

            Destroy(key);


        }

        for (int i = 0; i < player.platformKeys; i++)
        {

            GameObject newKey = Instantiate(silverKey, KeyHolderUI);

            keys.Add(newKey);


        }





    }


}
