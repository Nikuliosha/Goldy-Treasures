
using UnityEngine;

public class BackGroundScroller : MonoBehaviour
{
    [Range(-1f, 1f)]
    public float scrollSpeed = 0.5f;
    private float offset;
    private Material mat;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;


    }

    // Update is called once per frame
    void Update()
    {
        offset += (Time.deltaTime * scrollSpeed) / 10f; //the division is because we dont want super fast scrolling.
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
