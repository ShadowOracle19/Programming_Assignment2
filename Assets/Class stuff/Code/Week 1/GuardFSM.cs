using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardFSM : MonoBehaviour
{
    //Defines what the states can be of the enumerated type
    public enum State 
    {
        PATROL, ATTACK, INVESTIGATE, FLEE, DEATH
    }

    //An example of the state which is being used by the guard
    public State currentState = State.PATROL;

    //Our conditional values for the state machine
    public bool seesPlayer = false;
    public bool hearsNoise = false;
    public bool finishedInvestigation = false;
    public bool playerDies = false;
    public bool becomesScaredOfPlayer = false;
    public bool hasNoHealth = false;

    //Visual elements of the guard
    public MeshRenderer guardRenderer;
    public Color patrolColour = Color.white;
    public Color investigateColour = Color.green;
    public Color attackColour = Color.red;
    public Color fleeColour = Color.yellow;
    public Color deathColour = Color.black;

    //Leaving this as is with some resources in the Assets/Textures folder that you could use to implement faces for the guard.
    public SpriteRenderer guardFaceRenderer;

    // Update is called once per frame
    void Update()
    {
        //Because we can transition to death from any state, we want to handle it above all of the state machine logic rather
        //than adding it to every single state.
        if(hasNoHealth)
        {
            //Transition to the death state
            currentState = State.DEATH;
            guardRenderer.material.color = deathColour;
        }

        //You can think of a switch statement as a way to try to replace many blocks of if/else if/else statements if they're all checking the same value
        //The value that you check goes in the parameters of the switch statement line below.
        switch(currentState)
        {
            //"case" is your way of specifying a block of code (between the colon(':') and the 'break') which will run when the variable
            //provided to the switch statement is equal to the specified value. In this case, the block below would run when currentState == State.PATROL.
            case State.PATROL:
                //Behaviour of the character when it is currently patrolling
                if(hearsNoise)
                {
                    //Transition to the investigation state
                    currentState = State.INVESTIGATE;
                    guardRenderer.material.color = investigateColour;
                    
                }
                else if(seesPlayer)
                {
                    //Transition to the attack state
                    currentState = State.ATTACK;
                    guardRenderer.material.color = attackColour;
                }
                break;

            case State.INVESTIGATE:
                //Behaviour of the character when it is currently investigating
                //I've shifted the logic for investigate to a function. If your code is getting unmanageably big like it is in this example, you can
                //clean it up by shifting blocks of code to a function. This can make your code a lot more readable/easy to understand.
                HandleInvestigateState();

                break;

            case State.ATTACK:
                if(playerDies)
                {
                    //Transition to the patrol state
                    currentState = State.PATROL;
                    guardRenderer.material.color = patrolColour;
                }
                else if(becomesScaredOfPlayer)
                {
                    //Transition to the flee state
                    currentState = State.FLEE;
                    guardRenderer.material.color = fleeColour;
                }
                break;

            //You can stack cases like this to make it so that the same section of code runs for both states
            //Can think about it as equivalent to 'else if(currentState == State.FLEE || currentState == State.DEATH)'
            case State.FLEE:
            case State.DEATH:
                //We don't need to do anything in either of these states for the purposes of this example.
                break;

            //"default" handles anything which hasn't been managed by the switch statement to this point
            //Can think about it as equivalent to the final 'else' block
            default:
                Debug.LogError("This state["+currentState.ToString()+"] is not currently implemented.");
                break;
        }

        //Conditional values are reset after every update loop for our hard coded logic.
        //In a practical implementation of the state machine in an actual game, the conditions will be set to true or false based on the actual conditions that the character is checking.
        //IE: In a functional implementation of this particular example, seesPlayer would only be reset when the NPC can no longer see the player 
            //and may be a better check for transitioning from ATTACK to PATROL.
        hearsNoise = false;
        finishedInvestigation = false;
        seesPlayer = false;
        playerDies = false;
        becomesScaredOfPlayer = false;
        hasNoHealth = false;
    }

    //The implementation of the investigate state used to partially clean up the logic of the big 'ol switch statement
    private void HandleInvestigateState()
    {
        if(seesPlayer)
        {
            //Transition to the attack state
            currentState = State.ATTACK;
            guardRenderer.material.color = attackColour;
        }
        else if(finishedInvestigation)
        {
            //Transition to the patrol state
            currentState = State.PATROL;
            guardRenderer.material.color = patrolColour;
            
        }
    }

    //The methods below are used as a way for us to update the conditional values using the buttons in the scene.
    //If you're having trouble getting it to work, double check the following:
    //1. That on the button in the OnClick section, there's an entry in the list added, if not, hit the plus button.
    //2. That you're mapping the CubeGuard object in the OnClick() entry, if not, click, hold and drag the CubeGuard object over to the section that says None(Object) on the button.
    //3. That you're mapping the corresponding method from the GuardFSM script in OnClick() entry, if not, =>
    //=> click the dropdown that says "No Function", navigate to GuardFSM and select the corresponding method for the button. 
    public void HearsNoise()
    {
        hearsNoise = true;
    }

    public void FinishInvestigation()
    {
        finishedInvestigation = true;
    }

    public void SeePlayer()
    {
        seesPlayer = true;
    }

    public void PlayerDies()
    {
        playerDies = true;
    }
    public void BecomeScaredOfPlayer()
    {
        becomesScaredOfPlayer = true;
    }
    public void Die()
    {
        hasNoHealth = true;
    }
}
