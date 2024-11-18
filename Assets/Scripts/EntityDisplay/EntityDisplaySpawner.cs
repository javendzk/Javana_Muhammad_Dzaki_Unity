using System.Collections;
using UnityEngine;

public class EntityDisplaySpawner : MonoBehaviour
{
    [SerializeField] private EntityDisplay[] entityDisplayVariants;

    private void Start()
    {
        StartCoroutine(SpawnEntities());
    }

    private IEnumerator SpawnEntities()
    {
        yield return new WaitForSeconds(1f);
        if (entityDisplayVariants.Length > 0 && entityDisplayVariants[0] != null)
        {
            Instantiate(entityDisplayVariants[0], transform);
        }

        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 2; i++)
        {
            if (entityDisplayVariants.Length > 1 && entityDisplayVariants[1] != null)
            {
                Instantiate(entityDisplayVariants[1], transform);
            }
            yield return new WaitForSeconds(Random.Range(0.2f, 0.3f));
        }

        yield return new WaitForSeconds(1f);
        if (entityDisplayVariants.Length > 2 && entityDisplayVariants[2] != null)
        {
            Instantiate(entityDisplayVariants[2], transform);
        }        

        yield return new WaitForSeconds(2f);
        if (entityDisplayVariants.Length > 3 && entityDisplayVariants[3] != null)
        {
            Instantiate(entityDisplayVariants[3], transform);
        }
    }
}
