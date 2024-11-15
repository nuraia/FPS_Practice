using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMovement : MonoBehaviour
{
    public List<GameObject> collectablePrefab = new List<GameObject>();
    public float roadSpeed = 10f;
    void Start()
    {
        SpawnCollectable();
    }

    void Update()
    {
        transform.Translate(Vector3.back * roadSpeed * Time.deltaTime);
    }

    void SpawnCollectable()
    {
        for (int i = 0; i < 10; i++)
        {
            var instatiatedCollectable = Instantiate(collectablePrefab[Random.Range(0, collectablePrefab.Count-1)], transform);
            instatiatedCollectable.transform.position = GetRandomPointInCollider(transform.GetChild(0).GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointInCollider(Collider col)
    {
        Vector3 point = new Vector3(
            Random.Range(col.bounds.min.x, col.bounds.max.x),
            Random.Range(col.bounds.min.y, col.bounds.max.y),
            Random.Range(col.bounds.min.z, col.bounds.max.z)
        );
        if (point != col.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(col);
        }

        point.y = 1.5f;
        return point;
    }
}
