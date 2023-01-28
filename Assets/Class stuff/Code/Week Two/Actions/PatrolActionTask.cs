using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions{

	public class PatrolActionTask : ActionTask{
		//The waypoints that the character will be cycling through as a path
		public List<Transform> waypoints;
		//The distance from the current target at which it will switch to the next target
		public float distanceToSwitchTargets = 0.5f;
		//The speed that the character is moving at
		public float speed = 0.25f;
		//The transform of the character that is moving through the scene
		public Transform characterTransform;
		//The index of the waypoints list pointing to the waypoint that the character is currently trying to move towards
		private int currentWaypointIndex = 0;
		


		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			
			if(waypoints.Count == 0)
			{
				Debug.LogWarning("Patrol state might have unexpected behaviour, character["+characterTransform.gameObject.name+"] has no waypoints set.");
				return "";
			}


			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute(){
			
			//When entering into the patrol state, we want to determine what the nearest point is to the character
			//in the list of waypoints that we have available.

			//We start off saying that the closest distance is infinity, this way, the first point in our list will be closer than the
			//value that have stored in here.
			float closestDistance = Mathf.Infinity;
			int iterator = 0;

			foreach(Transform waypoint in waypoints)
			{
				//We get the distance from the current point to the position of the character
				float distanceToWaypoint = Vector3.Distance(waypoint.position, characterTransform.position);

				//If the distance is less than the closest distance so far, we set this point as the current closest point so far
				if(distanceToWaypoint < closestDistance)
				{
					closestDistance = distanceToWaypoint;
					currentWaypointIndex = iterator;
				}
				iterator++;
			}
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate(){
			
			//We get the current waypoint that the character is trying to get to and then grab its position as our target
			//(this could be useful in the case of trying to move towards a moving target)
			Vector3 currentTargetWayPoint = waypoints[currentWaypointIndex].position;

			//We want to determine the direction to move in, so we do some vector math by subtracting the character's position from the target we want to move towards
			//This gives us the direction.
			Vector3 directionToTarget = (currentTargetWayPoint - characterTransform.position);

			//We want to normalize the direction because if the target is far away, the magnitude of the direction vector will be big
			//and if the target is close, the magnitude of the direction will be small.
			//We want to apply a consistent movement speed to the character regardless of how far away the target is.
			//So we set the size of the vector to be consistent in all cases, but keep the directional information.
			Vector3 normalizedDirectionToTarget = directionToTarget.normalized;

			//We now update the position of the character based on the speed and direction the character is moving in that we set before.
			characterTransform.position += normalizedDirectionToTarget * speed;
			
			//If, after moving, the character is close enough to the target, we update to target the next point along the path.
			float distanceToTarget = Vector3.Distance(currentTargetWayPoint, characterTransform.position);
			if(distanceToTarget < distanceToSwitchTargets)
			{
				currentWaypointIndex++;
				//If the target would be outside of the list of waypoints, we wrap back around to the first point.
				if(currentWaypointIndex >= waypoints.Count)
				{
					currentWaypointIndex = 0;
				}
			}
		}

		//Called when the task is disabled.
		protected override void OnStop(){
			
		}

		//Called when the task is paused.
		protected override void OnPause(){
			
		}
	}
}