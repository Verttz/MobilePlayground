using UnityEngine;

public class PlaceholderObject : MonoBehaviour {
    public string objectType;
    public Color color = Color.white;
    public Vector3 size = Vector3.one;

    void Start() {
        var renderer = gameObject.AddComponent<MeshRenderer>();
        var filter = gameObject.AddComponent<MeshFilter>();
        filter.mesh = CreateCubeMesh();
        renderer.material = new Material(Shader.Find("Standard")) { color = color };
        transform.localScale = size;
        gameObject.name = objectType;
    }

    Mesh CreateCubeMesh() {
        return Resources.GetBuiltinResource<Mesh>("Cube.fbx");
    }
}
