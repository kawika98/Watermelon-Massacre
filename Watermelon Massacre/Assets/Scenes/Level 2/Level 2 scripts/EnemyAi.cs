using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum Behaviors { Idle, Guard, Combat, Flee };
public class EnemyAi : MonoBehaviour
{
    public Behaviors aiBehaviors = Behaviors.Idle;

    public bool isSuspicious = false;
    public bool isInRange = false;
    public bool FightsRanged = false;

    public GameObject Projectile;

    UnityEngine.AI.NavMeshAgent navAgent;
    Vector3 Destination;
    float Distance;
    public Transform[] Waypoints;
    public int curWaypoint = 0;
    bool ReversePath = false;
    Camera maincamera;
	// Start is called before the first frame update
	#region Behaviors
	void RunBehaviors()
	{
		switch (aiBehaviors)
		{
			case Behaviors.Idle:
				RunIdleNode();
				break;
			case Behaviors.Guard:
				RunGuardNode();
				break;
			case Behaviors.Combat:
				RunCombatNode();
				break;
			case Behaviors.Flee:
				RunFleeNode();
				break;
		}
	}

	void ChangeBehavior(Behaviors newBehavior)
	{
		aiBehaviors = newBehavior;

		RunBehaviors();
	}

	void RunIdleNode()
	{
		Idle();
	}

	void RunGuardNode()
	{
		Guard();
	}

	void RunCombatNode()
	{
		Combat();

	}

	void RunFleeNode()
	{
		Flee();
	}
	#endregion

	#region Actions
	void Idle()
	{
		
	}

	void Guard()
	{
		if (isSuspicious)
		{
			SearchForTarget();
			if (Distance < 2.00f)
			{
				isInRange = true;
				ChangeBehavior(Behaviors.Combat);
			}
		}
		else
		{
			Patrol();
		}
	}

	void Combat()
	{
		if (isInRange)
		{
			if (FightsRanged)
			{
				RangedAttack();
			}
			else
			{
				MeleeAttack();
			}
		}
		else
		{
			SearchForTarget();
		}
	}

	void Flee()
	{
		
		for (int fleePoint = 0; fleePoint < Waypoints.Length; fleePoint++)
		{
			Distance = Vector3.Distance(gameObject.transform.position, Waypoints[fleePoint].position);
			if (Distance > 10.00f)
			{
				Destination = Waypoints[curWaypoint].position;
				navAgent.SetDestination(Destination);
				break;
			}
			else if (Distance < 2.00f)
			{
				ChangeBehavior(Behaviors.Idle);
			}
		}
	}

	void SearchForTarget()
	{
		
		Destination = GameObject.FindGameObjectWithTag("Character").transform.position;
		navAgent.SetDestination(Destination);
		Distance = Vector3.Distance(gameObject.transform.position, Destination);
		if (Distance < 2.00f)
		{
			isInRange = true;
		}
	}
	void Patrol()
	{
		
		Distance = Vector3.Distance(gameObject.transform.position, Waypoints[curWaypoint].position);
		if (Distance > 6.00f)
		{
			Destination = Waypoints[curWaypoint].position;
			navAgent.SetDestination(Destination);
		}
		else
		{
			if (ReversePath)
			{
				if (curWaypoint <= 0)
				{
					ReversePath = false;
				}
				else
				{
					curWaypoint--;
					Destination = Waypoints[curWaypoint].position;
				}
			}
			else
			{
				if (curWaypoint >= Waypoints.Length - 1)
				{
					ReversePath = true;
				}
				else
				{
					curWaypoint++;
					Destination = Waypoints[curWaypoint].position;
				}
			}
		}
	}
	void RangedAttack()
	{
		
		GameObject newProjectile;
		newProjectile = Instantiate(Projectile, transform.position, Quaternion.identity) as GameObject;
		Destroy(newProjectile, 5);
	}
	void MeleeAttack()
	{

		
		Camera.main.SendMessage("stat_health", -2);
	}
	#endregion





	void Start()
	{
		navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();

	}

	void Update()
	{
		

		RunBehaviors();
		
	}
}
