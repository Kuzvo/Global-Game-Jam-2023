using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastChain : MonoBehaviour
{

    HingeJoint2D chainStart;

    public Rigidbody2D previousLink;

    public GameObject hingePrefab;

    GameObject playerModel;

    private void Start()
    {
        playerModel = GameObject.Find("Player Model");
        chainStart = GameObject.Find("Chain Start").transform.GetComponent<HingeJoint2D>();
        if (!GetComponent<HingeJoint2D>().connectedBody)
            StartCoroutine(SetupSystem());
    }

    private void OnJointBreak2D(Joint2D joint)
    {
        Vector2 playerVelocity = playerModel.GetComponent<Rigidbody2D>().velocity;
        if (playerVelocity.x == 0)
            chainStart.transform.position += new Vector3(0, -1.5f, 0);
        else if(playerVelocity.y == 0)
            chainStart.transform.position += new Vector3(-1.5f, 0, 0);
/*        if (playerVelocity.x > 0 && playerVelocity.y > 0)
        else if(playerVelocity.x > 0 && playerVelocity.y < 0)
        else if (playerVelocity.x < 0 && playerVelocity.y < 0)*/
        else
            chainStart.transform.position += new Vector3(-1.5f, 0, 0);

        chainStart.transform.position += new Vector3(0, -1.5f, 0);
        transform.parent.parent.position += new Vector3(0, 1.5f, 0);
        // Add hinge and add previous hinge.
        HingeJoint2D currentHinge = gameObject.AddComponent<HingeJoint2D>();
        currentHinge.connectedBody = previousLink;



        GameObject newHinge = Instantiate(hingePrefab, transform.position + new Vector3(0, -1.5f, 0), Quaternion.identity, transform.parent);

        // Assign Previous Link
        newHinge.GetComponent<LastChain>().previousLink = GetComponent<Rigidbody2D>();
        
        Debug.Log("Added");


        // NewHingeRigidBody
        Rigidbody2D newHingeRB = newHinge.GetComponent<Rigidbody2D>();


        chainStart.connectedBody = newHingeRB;

        // Destroy
        Destroy(this);
    }

    IEnumerator SetupSystem()
    {
        yield return new WaitForSeconds(0.005f);
        GetComponent<HingeJoint2D>().connectedBody = previousLink;
        Debug.Log("Set");
    }
}
