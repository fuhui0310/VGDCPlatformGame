using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPlace : MonoBehaviour {

    public GameObject grid; // grid where blocks are placed

    public int whichBlock; // which block type is selected
    public List<GameObject> blockTypes; // list of the types of available blocks to use
    public List<GameObject> placedBlocks; // list of created blocks
    public List<int> blocksRemaining; // List of how many blocks of each type the player can use

    public changeCursor cursor; // the cursor where blocks can be placed

    private const float XPLATOFFSET = -.25f;
    private const float YPLATOFFSET = 2.0f;
    private const float XCRUSHOFFSET = 4.3f;
    private const float YCRUSHOFFSET = 1.5f;
    private AudioSource audioData;


    // Use this for initialization
    void Start ()
    {
        audioData = GetComponent<AudioSource>();
        whichBlock = 0;
        Debug.Log(blockTypes.Count);
	}

    void SwitchBlocks()
    {
        if (Input.GetKeyDown("q") && whichBlock > 0)
            whichBlock--;
        
        if (Input.GetKeyDown("e") && whichBlock < (blockTypes.Count-1))
            whichBlock++;
    }

    void PlaceBlock()
    {
        // If left mouse button clicked
        if (blockTypes.Count > 0 && cursor.groundchecker.IsGrounded())
        {
            if (Input.GetMouseButtonDown(0) && blocksRemaining[whichBlock] > 0)
            {
                // create a new block of the type currently selected at the cursors position
                GameObject newBlock = Instantiate(blockTypes[whichBlock], grid.transform);
                // shouldn't actaully use the cursor position exactly, because it will not be centered. Give Offset depending on block used
                if (whichBlock == 0) // Platform block
                    newBlock.transform.position = new Vector3(cursor.transform.position.x + XPLATOFFSET, cursor.transform.position.y + YPLATOFFSET, 0.0f);
                else // Crush block (really bad design tbh)
                {
                    newBlock.transform.position = new Vector3(cursor.transform.position.x + XCRUSHOFFSET, cursor.transform.position.y + YCRUSHOFFSET, 0.0f);
                    Debug.Log(newBlock.transform.position);
                }


                audioData.PlayOneShot(audioData.clip);

                placedBlocks.Add(newBlock);
                blocksRemaining[whichBlock]--;
            }
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        PlaceBlock();
        SwitchBlocks();
    }
}
