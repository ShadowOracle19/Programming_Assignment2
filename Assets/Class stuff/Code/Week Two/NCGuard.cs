using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NCGuard : MonoBehaviour
{
    public bool finishedInvestigating = false;
    public bool hearNoise = false;

    public void HearNoise()
    {
        hearNoise = true;
    }
    public void FinishInvestigating()
    {
        finishedInvestigating = true;
    }
}