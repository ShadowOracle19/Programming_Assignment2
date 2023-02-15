using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Actions{

	public class AT_CollectBakedBread : ActionTask{
		public Baker baker;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			return null;
		}

        //This is called once each time the task is enabled.
        //Call EndAction() to mark the action as finished, either in success or failure.
        //EndAction can be called from anywhere.
        protected override void OnExecute()
        {
            baker.agent.destination = baker.nearestOven.transform.position;
        }

        //Called once per frame while the action is active.
        protected override void OnUpdate()
        {
            if (UnityEngine.Vector3.Distance(baker.gameObject.transform.position, baker.nearestOven.transform.position) < 2)
            {
                EndAction(true);
            }
        }

        //Called when the task is disabled.
        protected override void OnStop()
        {
            baker.breadHeld += baker.nearestOven.breadHeld;
            baker.nearestOven.breadHeld = 0;
            baker.collectBread = false;
        }

        //Called when the task is paused.
        protected override void OnPause(){
			
		}
	}
}