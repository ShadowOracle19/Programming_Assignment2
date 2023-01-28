using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions{

	public class AT_FarmerIdle : ActionTask{
		public Farmer farmer;
		public float detectionRadius = 10;

		//public RaycastHit[] hits;

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

			if(farmer.numberOfCropsHeld == farmer.maxCropsHeld)
			{
				farmer.inventoryFull = true;
				EndAction(true);
				return;
			}

            Collider[] hits = Physics.OverlapSphere(farmer.gameObject.transform.position, Mathf.Infinity);
			
			foreach (Collider hit in hits)
			{
				if(hit.gameObject.CompareTag("CropCrate"))
				{
					farmer.nearestCrate = hit.gameObject.GetComponent<Crate>();
				}

				if (hit.gameObject.CompareTag("Wheat"))
				{
					farmer.cropFound = hit.gameObject.GetComponent<Wheat>();
					

                    if(farmer.cropFound.isReadyToCollect)
					{
						farmer.foundGrownCrop = true;
                        EndAction(true);
						break;
                    }
					if(farmer.cropFound.needsToBePlanted)
					{
						farmer.foundEmptyCrop = true;
						EndAction(true);
						break;
					}
					
					
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