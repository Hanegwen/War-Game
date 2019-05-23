using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class AIMovement : MonoBehaviour
{

    [SerializeField]
    public Vector3 GoalPosition;

    [SerializeField]
    public Quaternion GoalRotation;

    [Tooltip("Can be Between 0 - 1, suggest around .01")]
    [SerializeField]
    float movementspeed = .1f;

    [Tooltip("Can be Between 0 - 1, suggest around .1")]
    [SerializeField]
    float rotationspeed = .1f;


   // Animator animator;
	// Use this for initialization
	void Start ()
    {
        //animator = FindObjectOfType<Animator>();
        GoalPosition = this.transform.position;
        GoalRotation = this.transform.rotation;
	}
	
	// Update is called once per frame
	void Update ()
    {
        
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
        if (this.transform.position != GoalPosition)
        {
            print("Should be Moving to Goal Point");
            transform.position = Vector3.Lerp(this.transform.position, GoalPosition, movementspeed);
           // animator.SetBool("isWalking", true);
        }
        else
        {
            //animator.SetBool("isWalking", false);
        }
    }

    
}
