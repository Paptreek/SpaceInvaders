using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyGroup : MonoBehaviour
{
    // if needing to assign objects to a prefab, may be able to do it inside the script since it doesn't work in the editor

    public List<GameObject> enemies = new List<GameObject>();

    private void Update()
    {
        foreach (GameObject enemy in enemies.ToList())
        {
            if (enemy == null)
            {
                enemies.Remove(enemy);
            }
        }

        if (enemies.Count > 0)
        {
            UpdateBoxColliderSize();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void UpdateBoxColliderSize()
    {
        Vector3 sumVector = Vector3.zero;

        foreach (Transform child in transform)
        {
            sumVector += child.localPosition;
        }

        Vector3 groupCenter = sumVector / transform.childCount;

        GetComponent<BoxCollider2D>().offset = new Vector2(groupCenter.x, groupCenter.y);

        float furthestLeftValue = enemies.Min(enemy => enemy.GetComponent<Enemy>().GetMinBoundsX());
        float furthestRightValue = enemies.Max(enemy => enemy.GetComponent<Enemy>().GetMaxBoundsX());

        float difference = furthestRightValue - furthestLeftValue;

        GetComponent<BoxCollider2D>().size = new Vector2(difference, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            foreach (GameObject enemy in enemies.ToList())
            {
                if (enemy != null)
                {
                    enemy.GetComponent<Enemy>().isDirectionFlipped = true;
                }
            }
        }
    }
}
