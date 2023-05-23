using UnityEngine;
using System.Collections.Generic;

public sealed class Spawner : MonoBehaviour
{
    public MyComponent _prefab = null;

    List<MyComponent> _spawned = new List<MyComponent>();

    async void Start()
    {
        for (var i = 0; i < 256; i++)
            _spawned.Add(Instantiate(_prefab));

        await Awaitable.WaitForSecondsAsync(3);

        foreach (var o in _spawned)
            Destroy(o.gameObject);

        // _spawned should be cleared!
    }
}
