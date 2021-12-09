using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetermScript : MonoBehaviour
{
    private int imposter;
    public GameObject imposterPrefab;
    public GameObject crewmatePrefab;


    // Start is called before the first frame update
    void Start()
    {
        imposter = Random.Range(0, 5);

        if (imposter == 1)
        {
            Debug.Log("imposter!");
            GameObject crew = Instantiate(imposterPrefab) as GameObject;
            crew.transform.position = new Vector2(0, 0);
        }


        else
        {
            Debug.Log(" Not imposter!");
            GameObject imposter = Instantiate(crewmatePrefab) as GameObject;
            imposter.transform.position = new Vector2(0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
