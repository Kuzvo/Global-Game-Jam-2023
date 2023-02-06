using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pluck : MonoBehaviour
{
    public Rigidbody2D chainStart;
    public float pluckStrength = -100f;

    public GameObject blood;

    public AudioSource death;
    IEnumerator PluckAway()
    {
        death.Play();
        for (int i = 0; i < 10; i++)
        {
            chainStart.AddForce(transform.up * pluckStrength);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Sam");
    }

    public void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.tag == "Spikes") {

            Instantiate(blood, transform.position, Quaternion.identity);
            GetComponent<PlayerMovement>().DamagePlayer(1);
        }
    }

    public void Plucknfuck() {
        chainStart.bodyType = RigidbodyType2D.Dynamic;
        Destroy(this.GetComponent<PlayerMovement>());
        StartCoroutine(PluckAway());
    }
}
