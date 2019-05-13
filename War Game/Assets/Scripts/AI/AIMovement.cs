using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class AIMovement : MonoBehaviour
{
    [SerializeField]
    Transform eyepoint;

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

    [SerializeField]
    float viewRange = 45;

    Animator animator;
	// Use this for initialization
	void Start ()
    {
        animator = FindObjectOfType<Animator>();
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
        if (this.transform.position != GoalPosition)
        {
            print("Should be Moving to Goal Point");
            transform.position = Vector3.Lerp(this.transform.position, GoalPosition, movementspeed);
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    void DecideNextPoint()
    {
        RaycastHit hit;

        List<Ray> rayRange = new List<Ray>();

        for(float i = viewRange * -1; i < viewRange; i++)
        {
            float range = i / 90;
            Debug.DrawLine(eyepoint.transform.position, (eyepoint.transform.forward + eyepoint.transform.right * range) * RaycastDistance, Color.red);

            Ray ray = new Ray(eyepoint.transform.position, (eyepoint.transform.forward + eyepoint.transform.right * range) * RaycastDistance);
            rayRange.Add(ray);
        }

        foreach (Ray ray in rayRange)
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.GetComponent<FirstPersonController>() != null)
                {
                    print("Hit Player");
                    
                    GoalPosition = new Vector3(hit.collider.gameObject.transform.position.x, this.gameObject.transform.position.y, hit.collider.gameObject.transform.position.z);
                    GoalRotation = hit.collider.gameObject.transform.rotation;
                }

            }
        }
    }

    IEnumerator DecisionDelay()
    {
        yield return new WaitForSeconds(DecisionDelayTime);
    }
}
