using UnityEngine;

public sealed class MyComponent : MonoBehaviour
{
    byte[] _bitmap;
    Texture2D _texture;

    void Start()
    {
        transform.localRotation = Random.rotation;
        transform.localPosition = Random.insideUnitSphere * 5;

        _bitmap = BitmapGenerator.GenerateRandom(512, 512);
        _texture = new Texture2D(512, 512, TextureFormat.RGBA32, false);

        _texture.LoadRawTextureData(_bitmap);
        _texture.Apply();

        GetComponent<Renderer>().material.mainTexture = _texture;
    }

    // _texture should be released in OnDestroy!
}
