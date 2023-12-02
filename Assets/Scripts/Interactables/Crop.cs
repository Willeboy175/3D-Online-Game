using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : Interactable
{
    public Transform crop;
    public float growthTime = 5f;
    private float timer;

    public Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (growthTime < timer)
        {
            crop.position = startPos + new Vector3(0, 0.5f, 0);
            promptmessage = "Harvest";
        }
    }

    protected override void Interact()
    {
        if (growthTime < timer)
        {
            Destroy(this.gameObject);
        }

        Debug.Log("Interacted with " + gameObject.name);
    }
}
