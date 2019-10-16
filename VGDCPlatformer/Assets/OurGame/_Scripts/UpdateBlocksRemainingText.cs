using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateBlocksRemainingText : MonoBehaviour
{
    public BlockPlace blockPlace; // Need to know how many blocks of the type are left to display apporpriate text

    private RectTransform myRectTransform;

    public Text remainingBlocksText;

    // Use this for initialization
    void Start ()
    {
        myRectTransform = GetComponent<RectTransform>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        myRectTransform.position = Input.mousePosition;
        if(blockPlace.blockTypes.Count > 0)
            remainingBlocksText.text = blockPlace.blocksRemaining[blockPlace.whichBlock].ToString();
    }
}
