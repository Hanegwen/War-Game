using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class AIMovement : MonoBehaviour
{
    [SerializeField]
    float DecisionDelayTime = 1;

    [SerializeField]
    float RaycastDistance = 100;

    [SerializeField]
    Vector3 GoalPosition;

    [SerializeField]
    Quaternion GoalRotation;

    [Tooltip("Can be Between 0 - 1, suggest around .01")]
    [SerializeField]
    float movementspeed = .1f;

    [Tooltip("Can be Between 0 - 1, suggest around .1")]
    [SerializeField]
    float rotationspeed = .1f;

	// Use this for initialization
	void Start ()
    {
        GoalPosition = this.transform.position;
        GoalRotation = this.transform.rotation;
	}
	
	// Update is called once per frame
	void Update ()
    {
        DecideNextPoint();
        MoveToGoalPosition();
	}

    void RotateToNextPoint()
    {
        if(this.transform.rotation != GoalRotation)
        {
            print("Should be Rotating to Goal Rotation");
            transform.rotation = Quaternion.Lerp(this.transform.rotation, GoalRotation, rotationspeed);
        }
    }

    void MoveToGoalPosition()
    {
        if(this.transform.position != GoalPosition)
        {
            print("Should be Moving to Goal Point");
            transform.position = Vector3.Lerp(this.transform.position, GoalPosition, movementspeed);
        }
    }

    void DecideNextPoint()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward * RaycastDistance);
        Debug.DrawLine(this.transform.position, this.transform.forward * RaycastDistance, Color.black);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.GetComponent<FirstPersonController>() != null)
            {
                print("Hit Player");
                GoalPosition = hit.collider.gameObject.transform.position;
                GoalRotation = hit.collider.gameObject.transform.rotation;
            }    
           
        }
    }

    IEnumerator DecisionDelay()
    {
        yield return new WaitForSeconds(DecisionDelayTime);
    }
}
