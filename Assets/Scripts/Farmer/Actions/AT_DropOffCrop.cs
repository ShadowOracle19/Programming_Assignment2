using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Actions{

	public class AT_DropOffCrop : ActionTask{
		public Farmer farmer;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute(){
            farmer.agent.destination = farmer.nearestCrate.transform.position;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate(){
            if (UnityEngine.Vector3.Distance(farmer.gameObject.transform.position, farmer.nearestCrate.transform.position) < 2)
            {
                EndAction(true);
            }
        }

		//Called when the task is disabled.
		protected override void OnStop(){
            farmer.nearestCrate.cropTotal += farmer.numberOfCropsHeld;
            farmer.numberOfCropsHeld = 0;
            farmer.inventoryFull = false;
        }

		//Called when the task is paused.
		protected override void OnPause(){
			
		}
	}
}