using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Actions{

	public class AT_FoundCursedPlant : ActionTask{

		public Farmer farmer;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit()
		{
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute()
		{
			farmer.agent.destination = farmer.cropFound.transform.position;


		}

		//Called once per frame while the action is active.
		protected override void OnUpdate()
		{
			if (UnityEngine.Vector3.Distance(farmer.gameObject.transform.position, farmer.cropFound.transform.position) < 2)
			{
				farmer.cropFound.PlantCrop();
				EndAction(true);
			}
		}

		//Called when the task is disabled.
		protected override void OnStop()
		{
			farmer.cropFound = null;
			farmer.foundCursedCrop = false;
		}

		//Called when the task is paused.
		protected override void OnPause()
		{

		}
	}
}