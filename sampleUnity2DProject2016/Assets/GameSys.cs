using UnityEngine;
using System.Collections;

public class GameSys : MonoBehaviour {

    public GameObject holdObj;
    public float holdPositionX;
    public float holdPositionY;
    private float z = 10f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LeftClick();
        }
        if (Input.GetMouseButton(0))
        {
            LeftDrag();
        }
        if (Input.GetMouseButtonUp(0))
        {
            LeftUp();
        }
    }

    private void LeftClick()
    {
        Vector3 tapPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, z);
        if (holdObj == null)
        {
            Collider2D col = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(tapPoint));
            if (col != null)
            {
                this.holdObj = col.gameObject;
                holdPositionX = this.holdObj.transform.position.x;
                holdPositionY = this.holdObj.transform.position.y;
                holdObj.transform.position = Camera.main.ScreenToWorldPoint(tapPoint);
            }
        }

    }
    private void LeftDrag()
    {
        Vector3 tapPoint = Input.mousePosition;
        if (holdObj != null)
        {
            this.holdObj.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(tapPoint.x, tapPoint.y, z));
            Collider2D[] colSet = Physics2D.OverlapPointAll(Camera.main.ScreenToWorldPoint(new Vector3(tapPoint.x, tapPoint.y, z)));
            if (colSet.Length > 1)
            {
                foreach (Collider2D col in colSet)
                {
                    if (!col.gameObject.Equals(this.holdObj))
                    {
                        float tmpPositionX = holdPositionX;
                        float tmpPositionY = holdPositionY;
                        holdPositionX = col.gameObject.transform.position.x;
                        holdPositionY = col.gameObject.transform.position.y;
                        col.gameObject.transform.position = new Vector3(tmpPositionX, tmpPositionY, z);

                    }
                }
            }
        }
    }
    private void LeftUp()
    {
        if (holdObj != null)
        {
            holdObj.transform.position = new Vector3(holdPositionX, holdPositionY, z);
            holdObj = null;
        }
    }

}