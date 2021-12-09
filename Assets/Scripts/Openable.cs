using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class Openable : MonoBehaviour
{
    public GameObject Task;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("hoi");
        if (collision.CompareTag("Player"))
        {
            Task.gameObject.SetActive(true);
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Task.gameObject.SetActive(false);
    }
}
