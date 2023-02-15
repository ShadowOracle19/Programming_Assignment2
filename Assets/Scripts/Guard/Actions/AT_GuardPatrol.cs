using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions{

	public class AT_GuardPatrol : ActionTask{

		public Guard guard;

		private int destPoint = 0;

		public Transform[] patrolPoints;


		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute(){
			
		}


        void GotoNextPoint()
        {
            // Returns if no points have been set up
            if (patrolPoints.Length == 0)
                return;

            // Set the agent to go to the currently selected destination.
            guard.agent.destination = patrolPoints[destPoint].position;

            // Choose the next point in the array as the destination,
            // cycling to the start if necessary.
            destPoint = (destPoint + 1) % patrolPoints.Length;
        }

        //Called once per frame while the action is active.
        protected override void OnUpdate(){
			
		}

		//Called when the task is disabled.
		protected override void OnStop(){
			
		}

		//Called when the task is paused.
		protected override void OnPause(){
			
		}
	}
}