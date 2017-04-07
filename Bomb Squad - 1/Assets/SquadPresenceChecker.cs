﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SquadPresenceChecker : MonoBehaviour {

    int count1;

    public Text message;
    public GameObject panel;
    public GameObject panel2;

    public static bool isSquadHere;

    // Use this for initialization
    void Start () {
        count1 = 0;
        isSquadHere = false;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        
        int count = 0;
        GameObject[] soldiers = GameObject.FindGameObjectsWithTag("soldier");

        foreach (GameObject soldier in soldiers)
        {
            if (soldier.GetComponent<NavigationControllerBS>().isHere)
            {
                count++;
            }
        }
        if (count == soldiers.Length)
        {
            message.text = "Choose Soldiers";
            count1++;
            Camera.main.transform.position = new Vector3(GameObject.FindGameObjectWithTag("soldier").transform.position.x,30, GameObject.FindGameObjectWithTag("soldier").transform.position.z);
            panel2.GetComponent<SoldierApproach>().enabled = false;
            panel.SetActive(true);
            if (count1 == 50)
            {
                panel.SetActive(false);
                count1 = 0;
                count = 0;
                foreach (GameObject soldier in soldiers)
                {
                    soldier.GetComponent<NavigationControllerBS>().isHere = false;
                }
            }
        }

       
    }
}
