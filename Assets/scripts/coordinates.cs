using UnityEditor;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class coordinates : MonoBehaviour
{
    [SerializeField] private Color defaultcolor = Color.white;
    [SerializeField] private Color blockedcolor = Color.grey;
    [SerializeField] private Color exploredcolor = Color.yellow;
    [SerializeField] private Color pathcolor = new Color(1f, 0.5f, 0);
    private Vector2 position1;
    TMP_Text label;
    private Vector2Int coordinates1;
    private bool ispressedkey;
    private gridmanager _gridmanager;
    
    // Start is called before the first frame update
    private void Awake()
    {
        _gridmanager = FindObjectOfType<gridmanager>();
        label = GetComponent<TMP_Text>();
        label.enabled = true;
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
        if (_gridmanager == null)
            return;
        Node node = _gridmanager.GetNode(coordinates1);
        
        if (node == null)
            return;
        if (!node.iswalkable)
            label.color = blockedcolor;
        else if (node.ispath)
            label.color = pathcolor;
        else if (node.isexplored)
            label.color = exploredcolor;
        else
            label.color = defaultcolor;

        //label.color = waypoint.IsPlaycable ? defaultcolor : blockedcolor;
    }
    void UpdateObjectCoord()
    {
        transform.parent.name = coordinates1.ToString();
    }
    private void DisplayCoord()
    {
         var position = transform.parent.position;
         coordinates1.x = Mathf.RoundToInt(position.x / _gridmanager.UnityGridSiza);
         coordinates1.y = Mathf.RoundToInt(position.z / _gridmanager.UnityGridSiza);
         label.text = $"{coordinates1.x}, {coordinates1.y}";
    }
}
