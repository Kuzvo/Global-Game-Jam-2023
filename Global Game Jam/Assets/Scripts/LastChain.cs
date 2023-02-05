using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastChain : MonoBehaviour
{
    public GameObject hingePrefab;

    GameObject playerModel;

    [SerializeField]
    GameObject lastLink;

    bool isAble = true;
    HingeJoint2D hingeJoint2D;

    [SerializeField]
    float timeBetweenSpawn = 0.25f;

    private void Start()
    {
        playerModel = GameObject.Find("Player Model");
    }

    private void OnJointBreak2D(Joint2D joint)
    {
        isAble = false;
        Debug.Log("Hinge Broken");
        GameObject newHinge = Instantiate(hingePrefab, lastLink.transform.position, Quaternion.identity, null);
        newHinge.GetComponent<HingeJoint2D>().connectedBody = lastLink.GetComponent<Rigidbody2D>();

        lastLink = newHinge;
        hingeJoint2D = gameObject.AddComponent<HingeJoint2D>();
        hingeJoint2D.connectedBody = newHinge.GetComponent<Rigidbody2D>();
        // Create new HingeJoint for this
        // Assign this.hingejoint2d to the new hinge
        StartCoroutine(ChangeActive());

    }

    IEnumerator ChangeActive()
    {
        yield return new WaitForSeconds(timeBetweenSpawn);
        isAble = true;
        hingeJoint2D.breakForce = 1000.0f;
    }
}
