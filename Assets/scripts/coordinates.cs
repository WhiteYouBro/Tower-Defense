using UnityEditor;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class coordinates : MonoBehaviour
{
    private Vector2 position1;
    TMP_Text label;
    private Vector2Int coordinates1;
    // Start is called before the first frame update
    private void Awake()
    {
        label = GetComponent<TMP_Text>();
        DisplayCoord();
    }
    private void Update()
    {
        if (Application.isPlaying)
            return;
        DisplayCoord();
        UpdateObjectCoord();
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
