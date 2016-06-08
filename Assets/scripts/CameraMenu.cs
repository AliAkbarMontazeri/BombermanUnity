using UnityEngine;
using System.Collections;

public class CameraMenu : MonoBehaviour {

    public void SetMax(float MaxX, float MaxY)
    {
        xMax = MaxX;
        yMax = MaxY;
    }
    float xMin = 8.150f;

    float yMin = 6;

    float xMax = -9.15f;

    float yMax = -6;

       void OnDrawGizmosSelected()
    {
        var size = Camera.main.orthographicSize;
        var aspect = Camera.main.aspect;
        Gizmos.color = Color.green;
        var bleft = new Vector2(xMin - size * aspect, yMin - size);
        var bright = new Vector2(xMax + size * aspect, yMin - size);
        var tleft = new Vector2(xMin - size * aspect, yMax + size);
        var tright = new Vector2(xMax + size * aspect, yMax + size);
        Gizmos.DrawLine(bleft, bright);
        Gizmos.DrawLine(tleft, tright);

        Gizmos.DrawLine(bleft, tleft);
        Gizmos.DrawLine(bright, tright);
    }
}
