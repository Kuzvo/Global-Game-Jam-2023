using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject roomEntrance;
    private void Awake()
    {
        roomEntrance.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        roomEntrance.SetActive(true);
    }
}
