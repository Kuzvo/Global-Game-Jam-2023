using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapePuzzle : MonoBehaviour
{
    public Sprite heart;

    public bool complete = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!complete)
        {
            if (collision.name == "Key")
            {
                Debug.Log("WIN!");
                Destroy(collision.gameObject);
                this.gameObject.GetComponent<SpriteRenderer>().sprite = heart;
                complete = true;
            }
        }
    }
}
