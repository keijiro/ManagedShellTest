using UnityEngine;
using Unity.Collections;
using Unity.Burst;
using System;
using Random = UnityEngine.Random;

[BurstCompile]
public static class BitmapGenerator
{
    public static byte[] GenerateRandom(int width, int height)
    {
        var bitmap = new byte[4 * width * height];

        var hue = Random.value;
        var c1 = Color.HSVToRGB(hue, Random.value, 1);
        var c2 = Color.HSVToRGB(hue, Random.value, 1);
        var c3 = Color.HSVToRGB(hue, Random.value, 1);
        var c4 = Color.HSVToRGB(hue, Random.value, 1);

        unsafe
        {
            fixed (byte* p = &bitmap[0])
                FillData(p, width, height, c1, c2, c3, c4);
        }

        return bitmap;
    }

    [BurstCompile]
    unsafe static void FillData
      (byte* bitmap, int w, int h,
       in Color c1, in Color c2, in Color c3, in Color c4)
    {
        var idx = 0;
        for (var y = 0; y < h; y++)
        {
            var v = (float)y / h;
            var c5 = Color.Lerp(c1, c2, v);
            var c6 = Color.Lerp(c3, c4, v);
            for (var x = 0; x < w; x++)
            {
                var u = (float)x / w;
                var c = (Color32)Color.Lerp(c5, c6, u);
                bitmap[idx++] = c.r;
                bitmap[idx++] = c.g;
                bitmap[idx++] = c.b;
                bitmap[idx++] = 0xff;
            }
        }
    }
}
