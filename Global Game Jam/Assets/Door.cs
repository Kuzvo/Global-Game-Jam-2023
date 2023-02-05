using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject[] roomEntrances;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < roomEntrances.Length; i++)
        {
            roomEntrances[i].layer = 1;
            StartCoroutine(PivotObjectEnumerator(roomEntrances[i]));
        }
    }


    IEnumerator PivotObjectEnumerator(GameObject pivotObj)
    {
        PivotSettings pivotSettings = pivotObj.GetComponent<PivotSettings>();
        if (pivotSettings == null)
        {
            pivotSettings = pivotObj.GetComponentInParent<PivotSettings>();
            if (pivotSettings == null)
                throw new Exception("Cannot find Pivot Settings on '" + pivotObj.name + "'");
        }
        // If object is in use, Ignores
        if (pivotSettings.inUse == true)
        {
            yield break;
        }

        pivotSettings.open = !pivotSettings.open;
        // Setting up values for object
        pivotSettings.inUse = true;
        bool objState = pivotSettings.currentState;
        bool usingMovement = pivotSettings.usingMovement;

        Quaternion startingAngle;
        Quaternion endingAngle;
        Vector3 startingPos;
        Vector3 endingPos;
        if (objState == false)
        {
            startingAngle = pivotSettings.GetStartingAngle;
            endingAngle = Quaternion.Euler(pivotSettings.endingAngle.x, pivotSettings.endingAngle.y, pivotSettings.endingAngle.z);
            startingPos = pivotSettings.GetStartingPos;
            endingPos = pivotSettings.endingPos;
        }
        else
        {
            endingAngle = pivotSettings.GetStartingAngle;
            startingAngle = Quaternion.Euler(pivotSettings.endingAngle.x, pivotSettings.endingAngle.y, pivotSettings.endingAngle.z);
            endingPos = pivotSettings.GetStartingPos;
            startingPos = pivotSettings.endingPos;
            //AudioManager.Instance.PlayAudio("DoorClose");
        }
        int smoothness = pivotSettings.smoothness;
        float time = pivotSettings.timeToOpen;

        for (float i = 0; i <= smoothness; i++)
        {
            if (usingMovement)
            {
                pivotObj.transform.localPosition = Vector3.Lerp(startingPos, endingPos, i / smoothness);
            }
            pivotObj.transform.localRotation = Quaternion.Lerp(startingAngle, endingAngle, i / smoothness);
            pivotSettings.currentState = !objState;
            yield return new WaitForSeconds(time / smoothness);
        }
        pivotSettings.inUse = false;
        Destroy(this);
    }
}
