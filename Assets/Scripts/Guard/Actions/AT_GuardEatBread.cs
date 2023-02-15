using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Actions{

	public class AT_GuardEatBread : ActionTask{
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
			guard.agent.destination = guard.breadBox.transform.position;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate(){
            if (UnityEngine.Vector3.Distance(guard.gameObject.transform.position, guard.breadBox.transform.position) < 2)
            {
				guard.health = guard.maxHealth;
				guard.breadBox.breadHeld -= 1;
                EndAction(true);
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