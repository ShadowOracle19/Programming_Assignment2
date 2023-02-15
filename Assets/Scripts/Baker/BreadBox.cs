using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BreadBox : MonoBehaviour
{
    public int breadHeld = 0;
    public TextMeshPro text;

    public void Update()
    {
        text.text = breadHeld.ToString();
    }

}
