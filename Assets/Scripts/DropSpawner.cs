using UnityEngine;

public class DropSpawner : MonoBehaviour
{

    public Transform posTransform;
    public GameObject[] prefab;
    private GameObject[] prefabObject = { null, null, null, null, null, null, null };
    private bool[] isSpawned = { false, false, false, false, false, false, false };


    private void Update()
    {
        if (prefabObject[0] == null && !isSpawned[0])
        {
            Invoke(nameof(HealthInstantiation), 2f);
            isSpawned[0] = true;
        }

        if (prefabObject[1] == null && !isSpawned[1])
        {
            Invoke(nameof(BrushInstantiation), 5f);
            isSpawned[1] = true;
        }

        if (prefabObject[2] == null && !isSpawned[2])
        {
            Invoke(nameof(AxeInstantiation), 8f);
            isSpawned[2] = true;
        }

        if (prefabObject[3] == null && !isSpawned[3])
        {
            Invoke(nameof(SnakeInstantiation), 13f);
            isSpawned[3] = true;
        }

        if (prefabObject[4] == null && !isSpawned[4])
        {
            Invoke(nameof(SpellInstantiation), 16f);
            isSpawned[4] = true;
        }

        if (prefabObject[5] == null && !isSpawned[5])
        {
            Invoke(nameof(ShieldInstantiation), 20f);
            isSpawned[5] = true;
        }

        if (prefabObject[6] == null && !isSpawned[6])
        {
            Invoke(nameof(FreezerInstantiation), 23f);
            isSpawned[6] = true;
        }
    }

    private void HealthInstantiation()
    {
        float pointX = Random.Range(-posTransform.position.x, posTransform.position.x);
        float pointZ = Random.Range(-posTransform.position.z, posTransform.position.z);
        prefabObject[0] = Instantiate(prefab[0], new(pointX, 0, pointZ), Quaternion.identity, transform);
        isSpawned[0] = false;
    }

    private void BrushInstantiation()
    {
        float pointX = Random.Range(-posTransform.position.x, posTransform.position.x);
        float pointZ = Random.Range(-posTransform.position.z, posTransform.position.z);
        prefabObject[1] = Instantiate(prefab[1], new(pointX, 0.1f, pointZ), prefab[1].transform.rotation, transform);
        isSpawned[1] = false;
    }

    private void AxeInstantiation()
    {
        float pointX = Random.Range(-posTransform.position.x, posTransform.position.x);
        float pointZ = Random.Range(-posTransform.position.z, posTransform.position.z);
        prefabObject[2] = Instantiate(prefab[2], new(pointX, 0.1f, pointZ), prefab[2].transform.rotation, transform);
        isSpawned[2] = false;
    }

    private void SnakeInstantiation()
    {
        float pointX = Random.Range(-posTransform.position.x, posTransform.position.x);
        float pointZ = Random.Range(-posTransform.position.z, posTransform.position.z);
        prefabObject[3] = Instantiate(prefab[3], new(pointX, 0.1f, pointZ), prefab[3].transform.rotation, transform);
        isSpawned[3] = false;
    }

    private void SpellInstantiation()
    {
        float pointX = Random.Range(-posTransform.position.x, posTransform.position.x);
        float pointZ = Random.Range(-posTransform.position.z, posTransform.position.z);
        prefabObject[4] = Instantiate(prefab[4], new(pointX, 0.1f, pointZ), prefab[4].transform.rotation, transform);
        isSpawned[4] = false;
    }

    private void ShieldInstantiation()
    {
        float pointX = Random.Range(-posTransform.position.x, posTransform.position.x);
        float pointZ = Random.Range(-posTransform.position.z, posTransform.position.z);
        prefabObject[5] = Instantiate(prefab[5], new(pointX, 0.1f, pointZ), prefab[5].transform.rotation, transform);
        isSpawned[5] = false;
    }

    private void FreezerInstantiation()
    {
        float pointX = Random.Range(-posTransform.position.x, posTransform.position.x);
        float pointZ = Random.Range(-posTransform.position.z, posTransform.position.z);
        prefabObject[6] = Instantiate(prefab[6], new(pointX, 0.1f, pointZ), prefab[6].transform.rotation, transform);
        isSpawned[6] = false;
    }
}
