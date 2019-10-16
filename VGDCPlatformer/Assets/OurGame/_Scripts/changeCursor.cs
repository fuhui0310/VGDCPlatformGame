using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class changeCursor : MonoBehaviour {

    public List<Texture2D> cursorTexture; // list of textures the cursor can have. Should be the same as available blocks
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public BlockPlace blockPlace;
    public CharacterController2D groundchecker;

    void OnMouseEnter()
    {
        // make cursor visible and set texture appropriatley. also keeps track of cursor position in the world
        if (blockPlace.blockTypes.Count > 0 && groundchecker.IsGrounded())
        {
            Cursor.visible = true;
            Cursor.SetCursor(cursorTexture[blockPlace.whichBlock], hotSpot, cursorMode);
            Vector3 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cursorPos.z = 0.0f;
            transform.position = cursorPos;
        }
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }

    // Use this for initialization
    void Start ()
    {
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        // called when mouse is in the game screen
        OnMouseEnter();
	}
}
