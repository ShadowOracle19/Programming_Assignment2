using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions{

	public class AT_BakerIdle : ActionTask{
		public Baker baker;

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
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate(){

            if(baker.sellBread)
			{
				EndAction(true);
				return;
			}

            Collider[] hits = Physics.OverlapSphere(baker.gameObject.transform.position, Mathf.Infinity);

            foreach (Collider hit in hits)
            {
                if (hit.gameObject.CompareTag("Oven"))
                {
                    baker.nearestOven = hit.gameObject.GetComponent<Oven>();


                    if (baker.nearestOven.cropsHeld <= baker.nearestOven.numberOfCropsNeededForBread && baker.cropAvailable > 0)
                    {
                        baker.depositCropInOven = true;
                        EndAction(true);
                        break;
                    }

					if(baker.nearestOven.breadHeld > 0)
					{
						baker.collectBread = true;
						EndAction(true);
						break;
					}

                    if (baker.cropAvailable <= 0 && baker.cropCrate.cropTotal > 0)
                    {
                        baker.needCrops = true;
                        EndAction(true);
                        return;
                    }
                }
            }
            

            if (baker.breadHeld >= 3)
            {
                baker.deliverBread = true;
                EndAction(true);
                return;
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