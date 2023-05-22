using UnityEngine;
using System.Collections.Generic;

public sealed class Spawner : MonoBehaviour
{
    [SerializeField] MyComponent _prefab = null;
    [SerializeField] int _spawnCount = 100;

    List<MyComponent> _spawned = new List<MyComponent>();

    async void Start()
    {
        for (var i = 0; i < _spawnCount; i++)
            _spawned.Add(Instantiate(_prefab));

        await Awaitable.WaitForSecondsAsync(3);

        foreach (var o in _spawned) Destroy(o.gameObject);

        //Resources.UnloadUnusedAssets();
    }
}
