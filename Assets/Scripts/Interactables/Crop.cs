using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : Interactable
{
    public Transform crop;
    public float growthTime = 5f;
    protected float timer;

    public bool harvestable = false;
    public Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Timer
        //If crop is harvestable
        timer += Time.deltaTime;
        if (growthTime < timer)
        {
            crop.position = startPos + new Vector3(0, 0.5f, 0);
            promptmessage = "Harvest";
            harvestable = true;
        }
    }

    protected override void Interact()
    {
        //If gameobject is harvestable 
        if (harvestable)
        {
            Destroy(this.gameObject);
        }

        Debug.Log("Interacted with " + gameObject.name);
    }
}
