using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{

	public class AT_SellBread : ActionTask{
		public Baker baker;
		public Health health;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute(){
			//EndAction(true);
			baker.agent.isStopped = true;
			StartCoroutine(sellBreadReact());
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate(){
			
		}

		IEnumerator sellBreadReact()
		{
			if(baker.breadHeld > 0)
			{
				baker.happySprite.SetActive(true);
				baker.angrySprite.SetActive(false);

				health.health += 5;

                yield return new WaitForSeconds(4.0f);
                baker.happySprite.SetActive(false);
                baker.breadHeld -= 1;
			}
			else
			{
				baker.happySprite.SetActive(false);
                baker.angrySprite.SetActive(true);
				yield return new WaitForSeconds(4.0f);
                baker.angrySprite.SetActive(false);
            }
			EndAction(true);
			yield return null;
		}

		//Called when the task is disabled.
		protected override void OnStop(){
            baker.agent.isStopped = false;
			baker.sellBread = false;
        }

		//Called when the task is paused.
		protected override void OnPause(){
			
		}
	}
}