using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBlock : MonoBehaviour
{

    public BlockPlace blockPlace;
    public GameObject blockType;

    public int numBlocks;

	// Use this for initialization
	void Start ()
    {
		if (numBlocks == 0)
            numBlocks = 1;
	}
	
	// Update is called once per frame
	void Update ()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            
            if (blockPlace.blockTypes.Contains(blockType))
            {
                
                blockPlace.blocksRemaining[blockPlace.blockTypes.IndexOf(blockType)]+= numBlocks;
            }
            else
            {
                Debug.Log("TRIGGERED BUT WHY ELSE IF");
                blockPlace.blockTypes.Add(blockType);
                blockPlace.blocksRemaining.Add(numBlocks);
            }
            /*else if (blockPlace.blockTypes.Count < 1)
            {
                blockPlace.blockTypes.Add(blockType);
                blockPlace.blocksRemaining.Add(1);
            }*/




            Destroy(this.gameObject);
        }
    }
}
