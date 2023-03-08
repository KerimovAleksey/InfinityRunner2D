using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _countOfObjects;

    private List<GameObject> _objectsPool = new List<GameObject>();
    protected void Initialize(GameObject prefab)
    {
        for (int i = 0; i < _countOfObjects; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform);
            spawned.SetActive(false);

            _objectsPool.Add(spawned);
        }
    }

	protected void Initialize(GameObject[] prefabs)
	{
		for (int i = 0; i < _countOfObjects; i++)
		{
            int randomIndex = 0;
			int chance = Random.Range(0, 10);
            if (chance == 1)
            {
                randomIndex = 1;
            }
			GameObject spawned = Instantiate(prefabs[randomIndex], _container.transform);
			spawned.SetActive(false);

			_objectsPool.Add(spawned);
		}
	}

	protected bool TryGetObject(out GameObject result)
    {
        result = _objectsPool.FirstOrDefault(p => p.activeSelf == false);

        return result != null;
    }
}
