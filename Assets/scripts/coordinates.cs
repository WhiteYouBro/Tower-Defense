using UnityEditor;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class coordinates : MonoBehaviour
{
    private Vector2 position1;
    TMP_Text label;
    private Vector2Int coordinates1;
    private bool ispressedkey;
    private Color blockedcolor = Color.grey;
    private Color defaultcolor = Color.white;
    private waypoint waypoint;
    
    // Start is called before the first frame update
    private void Awake()
    {
        waypoint = GetComponentInParent<waypoint>();
        label = GetComponent<TMP_Text>();
        label.enabled = false;
        DisplayCoord();
    }
    private void Update()
    {
        ColorOfCoord();
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.enabled;
        }
        if (Application.isPlaying)
            return;
        DisplayCoord();
        UpdateObjectCoord();
    }
    void ColorOfCoord()
    {
        label.color = waypoint.IsPlaycable ? defaultcolor : blockedcolor;
    }
    void UpdateObjectCoord()
    {
        transform.parent.name = coordinates1.ToString();
    }
    private void DisplayCoord()
    {
         var position = transform.parent.position;
         coordinates1.x = Mathf.RoundToInt(position.x / EditorSnapSettings.move.x);
         coordinates1.y = Mathf.RoundToInt(position.z / EditorSnapSettings.move.z);
         label.text = $"{coordinates1.x}, {coordinates1.y}";
    }
}
