using UnityEngine;
using UnityEngine.EventSystems;

public class DotSpawner : MonoBehaviour {
    [SerializeField] GameObject dotPrefab = null;
    [SerializeField] Camera cam = null;
    [SerializeField] Player player = null;
    [SerializeField] RectTransform gameWorldRt = null;

    public Player Player => player;


    public void SpawnNewDot(Vector3 worldPosition) {
        SpawnNewDot(RectTransformUtility.WorldToScreenPoint(cam, worldPosition));
    }

    public void SpawnNewDot(Vector2 screenPosition) {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(gameWorldRt, screenPosition, cam, out var localPoint);
        var dot = Instantiate(dotPrefab, gameWorldRt.transform).GetComponent<Dot>();
        dot.transform.localPosition = localPoint;
        dot.Player = player;
    }
}
