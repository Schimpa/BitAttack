using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewBoundsLimiter : MonoBehaviour {

    public ScrollRect scrollRect;

    private float boundsYMin;    // The min position
    private float boundsYMax;    // The max position

    private float boundsXMin;    // The min position
    private float boundsXMax;    // The max position

    void Start() {
        boundsXMin = 0f;
        boundsXMax = 0f;

        boundsYMin = 0f;
        boundsYMax = 0f; // The max position is the Y-size of the viewport 
    
    }

    public void checkYValueBounds() {
        float contentPositionY = scrollRect.content.localPosition.y;
        boundsYMax = System.Math.Abs(scrollRect.viewport.localPosition.y);

        if (contentPositionY > boundsYMax) {
            scrollRect.content.localPosition = new Vector3(
                scrollRect.content.localPosition.x,
                boundsYMax,
                scrollRect.content.localPosition.z);
        } else if (contentPositionY < boundsYMin) {
            scrollRect.content.localPosition = new Vector3(
                scrollRect.content.localPosition.x,
                boundsYMin,
                scrollRect.content.localPosition.z);
        }
    }

    public void checkXValueBounds() {
        float contentPositionX = scrollRect.content.localPosition.x;
        boundsXMin = scrollRect.viewport.localPosition.x;

        if (contentPositionX < boundsXMin) {
            scrollRect.content.localPosition = new Vector3(
                boundsXMin,
                scrollRect.content.localPosition.y,
                scrollRect.content.localPosition.z);
        } else if (contentPositionX > boundsXMax) {
            scrollRect.content.localPosition = new Vector3(
                boundsXMax,
                scrollRect.content.localPosition.y,
                scrollRect.content.localPosition.z);
        }
    }


}
