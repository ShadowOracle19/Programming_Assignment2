using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions{

	public class AT_GuardDeath : ActionTask{
		public Guard guard;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute(){
            guard.isInvestigating = false;
            guard.foundWitch = false;
            guard.needToHeal = false;
            guard.dead = false;

			StartCoroutine(Dead());
        }

		IEnumerator Dead()
		{
			guard.gameObject.SetActive(false);
			yield return new WaitForSeconds(5);
			guard.gameObject.SetActive(true);
			EndAction(true);
			yield return null;
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