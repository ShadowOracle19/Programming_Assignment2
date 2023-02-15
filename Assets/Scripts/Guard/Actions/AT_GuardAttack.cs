using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions{

	public class AT_GuardAttack : ActionTask{
		public Guard guard;

        public float attackCooldownMax = 5;
        public float attackCooldownTime = 0;
        public bool attackOnCooldown = false;

		public float loseWitchMaxTime = 5;
		public float loseWitchTime = 0;
		public bool witchOutOfRange = false;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit(){
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            attackCooldownTime = 0;
            attackOnCooldown = false;

			loseWitchTime = 0;
			witchOutOfRange = false;
		}

           
        
    

		//Called once per frame while the action is active.
		protected override void OnUpdate(){
			guard.agent.destination = guard.player.transform.position;

			if (!attackOnCooldown)
			{
                if (Vector3.Distance(guard.gameObject.transform.position, guard.player.transform.position) < 2)
                {
                    guard.player.GetComponent<Health>().health -= 5;
					attackOnCooldown = true;
                }
            }

            

			if(Vector3.Distance(guard.gameObject.transform.position, guard.player.transform.position) > 10)
			{
			    witchOutOfRange = true;
			}
			else
			{
				witchOutOfRange = false;
			}

			if (guard.player.GetComponent<Health>().health == 0)
			{
				guard.foundWitch = false;
				guard.isInvestigating = false;
				EndAction(true);
			}
			if(guard.health <= 0)
			{
				guard.dead = true;
				EndAction(true);
			}

			if(witchOutOfRange)
			{
				if(loseWitchTime < loseWitchMaxTime)
				{
					loseWitchTime += Time.deltaTime;
				}
				else
				{
                    guard.foundWitch = false;
                    guard.isInvestigating = false;
					witchOutOfRange = false;
                    EndAction(true);
                }
			}

            if (attackOnCooldown)
            {
                if (attackCooldownTime < attackCooldownMax)
                {
                    attackCooldownTime += Time.deltaTime;
                }
                else
                {
                    attackOnCooldown = false;
                    attackCooldownTime = 0;
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