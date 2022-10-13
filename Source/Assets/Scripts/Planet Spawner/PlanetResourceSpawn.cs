using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetResourceSpawn : MonoBehaviour
{
    // Pool resources instead of instantiating
    public PlanetData m_Data = null;
    private float m_HeightVariation = 0.0f;
    [SerializeField] GameObject m_ResourcePrefab = null;
    [SerializeField] ObjectPooler m_ObjectPooler = null;

    private void Awake()
    {
        m_HeightVariation += m_Data.radius * 0.10f;
        m_ObjectPooler.CreatePool(20, m_ResourcePrefab);
    }

    public void SpawnResources()
    {     for(int i = 0; i < m_Data.resourcePositions.Count; i++)
        {
            m_ObjectPooler.SpawnFromPool(m_Data.resourcePositions[i], transform, true);
        }
    }

    public void DespawnResources()
    {
        for(int i = 0; i <= m_Data.resourcePositions.Count; ++i)
        {
            // some despawn stufff here.
        }
    }

    private void GetRandomPositions()
    {
        float degBetweenVertex = 360.0f / m_Data.resourceAmount;
        float currentDeg = degBetweenVertex;

        for (int i = 0; i < m_Data.resourceAmount; i++)
        {
           Vector2 vertPos = new Vector2(m_Data.position.x + ((m_Data.radius + Random.Range(0.0f, m_HeightVariation)) * Mathf.Sin(currentDeg * Mathf.Deg2Rad)), m_Data.position.y + ((m_Data.radius + Random.Range(0.0f, m_HeightVariation)) * Mathf.Cos(currentDeg * Mathf.Deg2Rad)));
           m_Data.resourcePositions.Add(vertPos);
           currentDeg += degBetweenVertex;
        }
    }
}
