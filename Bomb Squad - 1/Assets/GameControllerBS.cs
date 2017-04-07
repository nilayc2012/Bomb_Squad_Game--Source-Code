using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameControllerBS : MonoBehaviour {

    public GameObject maincam;
    public GameObject bombobj;
    public GameObject failurePanel;
    public Text bombcounttext;
    int bombcount = 3;

    public Text minute, sec;

    int time;
    int count;
    public bool start;
	// Use this for initialization
	void Start () {

        RenderSettings.fog = false;
        start = false;
        time = bombcount * 180;

        count = 0;


        //GameObject[] bombposis = GameObject.FindGameObjectsWithTag("bombpos");
        GameObject[] regions = GameObject.FindGameObjectsWithTag("region");
        bombcounttext.text = bombcount.ToString();

        if(time/60<10)
        {
            minute.text = "0" + (time / 60);
        }
        else
        {
            minute.text = "" + (time / 60);
        }

        if(time%60<10)
        {
            sec.text = "0" + (time % 60);
        }
        else
        {
            sec.text = "" + (time % 60);
        }

        for(int i=0;i<bombcount;i++)
        {
            GameObject bomb= Instantiate(bombobj);

            int regionIndex = UnityEngine.Random.Range(0, regions.Length);

            

            int index = UnityEngine.Random.Range(0, regions[regionIndex].transform.childCount - 1);
            GameObject bombpos = regions[regionIndex].transform.GetChild(index).gameObject;

            bomb.transform.position =new Vector3(bombpos.transform.position.x, 0.1f,bombpos.transform.position.z);

            bomb.SetActive(true);
        }
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!this.GetComponent<FinalOutcome>().finish && start)
        {

            if (time == 0)
            {
                foreach(GameObject panel in GameObject.FindGameObjectsWithTag("panel"))
                {
                    panel.SetActive(false);
                }
                failurePanel.SetActive(true);
            }

            GameObject[] bombs = GameObject.FindGameObjectsWithTag("bomb");

            bombcounttext.text = bombs.Length.ToString();

            count++;

            if (count == 60)
            {
                count = 0;
                if (time >= 1)
                {
                    time--;
                }
                if (time / 60 < 10)
                {
                    minute.text = "0" + (time / 60);
                }
                else
                {
                    minute.text = "" + (time / 60);
                }

                if (time % 60 < 10)
                {
                    sec.text = "0" + (time % 60);
                }
                else
                {
                    sec.text = "" + (time % 60);
                }
            }
        }
	}
}
