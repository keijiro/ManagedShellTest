using UnityEngine;

public sealed class MyComponent : MonoBehaviour
{
    Texture2D _texture;

    void Start()
    {
        transform.localRotation = Random.rotation;
        transform.localPosition = Random.insideUnitSphere * 5;

        _texture = new Texture2D(512, 512, TextureFormat.RGBA32, false);
        TextureDataGenerator.LoadRandomPattern(_texture);

        GetComponent<Renderer>().material.mainTexture = _texture;
    }

    //void OnDestroy() => Destroy(_texture);
}
