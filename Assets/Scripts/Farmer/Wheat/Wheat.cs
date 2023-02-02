using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wheat : MonoBehaviour
{
    public bool isReadyToCollect = false;
    public bool isCursed = false;
    public bool needsToBePlanted = false;

    public float growthSpeed = 1.0f;
    public float maxGrowthTime = 5.0f;
    private float growthTime;
    public int currentGrowthLevel = 0;
    public int maxGrowthLevel = 6;

    public SpriteRenderer wheatImage1;
    public SpriteRenderer wheatImage2;

    public List<Sprite> wheatGrowthLevel;
    public Sprite wheatGrowthEmpty;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isCursed)
        {
            wheatImage1.color = Color.grey;
            wheatImage2.color = Color.grey;
            return;
        }
        if(needsToBePlanted)
        {
            wheatImage1.sprite = wheatGrowthEmpty;
            wheatImage2.sprite = wheatGrowthEmpty;
            return;
        }
        if(!isReadyToCollect || !isCursed)
        {
            growthTime -= Time.deltaTime * growthSpeed;
            if(growthTime < 0)
            {
                GrowPlant();
            }
        }
    }

    public void GrowPlant()
    {
        if(currentGrowthLevel == maxGrowthLevel)
        {
            isReadyToCollect = true;
            wheatImage1.sprite = wheatGrowthLevel[maxGrowthLevel];
            wheatImage2.sprite = wheatGrowthLevel[maxGrowthLevel];
            return;
        }

        currentGrowthLevel += 1;
        growthTime = maxGrowthTime;

        wheatImage1.sprite = wheatGrowthLevel[currentGrowthLevel];
        wheatImage2.sprite = wheatGrowthLevel[currentGrowthLevel];
    }

    public int CollectCrop()
    {
        isReadyToCollect = false;
        needsToBePlanted = true;

        return 1;
    }

    public void PlantCrop()
    {
        wheatImage1.color = Color.white;
        wheatImage2.color = Color.white;
        needsToBePlanted = false;
        isCursed = false;

        currentGrowthLevel = 0;
        growthTime = maxGrowthTime;
        wheatImage1.sprite = wheatGrowthLevel[0];
        wheatImage2.sprite = wheatGrowthLevel[0];
    }

}
