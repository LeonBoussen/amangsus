using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    public float scroll_Speed = 0.1f;
    private MeshRenderer mesh_renderer;
    // Start is called before the first frame update
    void Awake()
    {
        mesh_renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Time.time * scroll_Speed;

        Vector2 offset = new Vector2(x, 0);

        mesh_renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
