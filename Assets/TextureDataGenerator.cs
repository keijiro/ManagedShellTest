using UnityEngine;
using Unity.Collections;
using Unity.Burst;
using System;
using Random = UnityEngine.Random;

[BurstCompile]
public static class TextureDataGenerator
{
    public static void LoadRandomPattern(Texture2D tex)
    {
        var (w, h) = (tex.width, tex.height);

        using var data = new NativeArray<Color32>
          (w * h, Allocator.Temp, NativeArrayOptions.UninitializedMemory);

        var hue = Random.value;
        var c1 = Color.HSVToRGB(hue, Random.value, 1);
        var c2 = Color.HSVToRGB(hue, Random.value, 1);
        var c3 = Color.HSVToRGB(hue, Random.value, 1);
        var c4 = Color.HSVToRGB(hue, Random.value, 1);

        FillData(data, w, h, c1, c2, c3, c4);

        tex.LoadRawTextureData(data);
        tex.Apply();
    }

    [BurstCompile]
    static void FillData
      (in NativeArray<Color32> data, int w, int h,
       in Color c1, in Color c2, in Color c3, in Color c4)
    {
        var span = data.AsSpan();
        var idx = 0;
        for (var y = 0; y < h; y++)
        {
            var v = (float)y / h;
            var c5 = Color.Lerp(c1, c2, v);
            var c6 = Color.Lerp(c3, c4, v);
            for (var x = 0; x < w; x++)
            {
                var u = (float)x / w;
                span[idx++] = Color.Lerp(c5, c6, u);
            }
        }
    }
}
