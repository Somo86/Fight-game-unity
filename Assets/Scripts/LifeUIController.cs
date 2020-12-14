using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeUIController : MonoBehaviour
{
    public Text PointsText;
    private float TextDuration = 2f;
    private CharacterController parentController;

    private void Start() {
        parentController = gameObject.transform.root.gameObject.GetComponent<CharacterController>();
    }

    private void FixedUpdate() {
        if(parentController != null)
        {
            // Keep text always oriented to right
            Vector3 theScale = transform.localScale;
            if(parentController.facingRight)
            {
                theScale.x = Mathf.Abs(theScale.x);
            } else {
                theScale.x = Mathf.Abs(theScale.x) * -1; 
            }
            transform.localScale = theScale;
        }
    }

    public void ShowLosePoints(int points)
    {
        PointsText.text = "- " + points.ToString();
        PointsText.color = Color.red;
        Invoke(nameof(RemoveText), TextDuration);
    }

    public void ShowWinPoints(int points)
    {
        PointsText.text = "+ " + points.ToString();
        PointsText.color = Color.green;
        Invoke(nameof(RemoveText), TextDuration);
    }

    private void RemoveText()
    {
        PointsText.text = "";
    }
}
