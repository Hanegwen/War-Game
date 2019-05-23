using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class AIBrain : MonoBehaviour
{
    [SerializeField]
    Transform eyepoint;

    [SerializeField]
    float DecisionDelayTime = 1;

    [SerializeField]
    float RaycastDistance = 100;

    [SerializeField]
    float viewRange = 45;

    [SerializeField]
    Vector3 DistanceToLastHitPlayer;

    AIMovement aiMovement;
    AIAttack aiAttack;
    // Start is called before the first frame update
    void Start()
    {
        aiMovement = GetComponent<AIMovement>();
        aiAttack = GetComponent<AIAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        DecideNextPoint();
        TellToAttackPlayer();
    }

    void TellToAttackPlayer()
    {
        print("Distance to Last Hit Player " + DistanceToLastHitPlayer.magnitude);
        if(DistanceToLastHitPlayer.magnitude < aiAttack.AttackRange)
        {
            aiAttack.Attack(DistanceToLastHitPlayer.magnitude);
        }
    }

    void DecideNextPoint()
    {
        RaycastHit hit;

        List<Ray> rayRange = new List<Ray>();

        for (float i = viewRange * -1; i < viewRange; i++)
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

                    DistanceToLastHitPlayer = this.transform.position - hit.collider.transform.position;

                    aiMovement.GoalPosition = new Vector3(hit.collider.gameObject.transform.position.x, this.gameObject.transform.position.y, hit.collider.gameObject.transform.position.z);
                    aiMovement.GoalRotation = hit.collider.gameObject.transform.rotation;
                }

            }
        }
    }

    IEnumerator DecisionDelay()
    {
        yield return new WaitForSeconds(DecisionDelayTime);
    }
}
