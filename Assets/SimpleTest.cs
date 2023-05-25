using UnityEngine;

public sealed class SimpleTest : MonoBehaviour
{
    Texture2D _tex;

    void Start()
    {
        _tex = new Texture2D(256, 256);
        Destroy(_tex);
    }

    void Update() => Debug.Log(_tex);
    //void Update() => Debug.Log(_tex == null);
}
