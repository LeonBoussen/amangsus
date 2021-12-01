using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ImpostorWindow : MonoBehaviour
{

    public float timeleft = 5.0f;
    public Text countDown;

    // Update is called once per frame
    void Update()
    {
        if (timeleft >= 0)
        {
            timeleft -= Time.deltaTime;
            countDown.text = (timeleft).ToString("0");
            print(timeleft);
        }

        if (timeleft < 1 | timeleft == 0)
        {
            SceneManager.LoadScene(1);
        }


    }
}
