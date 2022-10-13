using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlanetGrid : MonoBehaviour
{
    ObjectPooler planetPooler = null;

    [SerializeField] int m_PlanetAmount = 20;
    [SerializeField] int m_gridMaxDensity = 2;
    [SerializeField] GameObject m_PlanetPrefab = null;
    [SerializeField] GameObject m_GridCellPrefab = null;

    [SerializeField] const int gridHeight = 10;     // The height of the grid
    [SerializeField] const int gridWidth = 10;      // The width of the grid
    [SerializeField] int m_GridDistanceSize = 100; // The distance from one node to another 

    [SerializeField] int playerMaxGridView = 1;     // How many nodes across can the player see / the amount of planets loaded is this grid view + 1 out

    [SerializeField] GridNode[,] map = new GridNode[gridWidth, gridHeight];  // The playing map

    Vector2 m_PlayerGridPosition = Vector2.zero;
    private const int NeighbourCount = 8;
    Queue<GridNode> planets;



    private void Awake()
    {
        planets = new Queue<GridNode>();
        planetPooler = GetComponent<ObjectPooler>();
        planetPooler.CreatePool(m_PlanetAmount, m_PlanetPrefab);

        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                map[x, y] = new GridNode();
                map[x, y].m_GridPos = new Vector2(x, y);
                planets.Enqueue(map[x, y]);
                GameObject temp = Instantiate(m_GridCellPrefab, new Vector3((0.5f * m_GridDistanceSize) + x * m_GridDistanceSize, (0.5f * m_GridDistanceSize) + y * m_GridDistanceSize, 1.0f), m_GridCellPrefab.transform.rotation);
            }
        }

        int planetsLeft = m_PlanetAmount;
        if (planetsLeft > (gridHeight * gridWidth) * m_gridMaxDensity)
        {
            planetsLeft = (gridHeight * gridWidth) * m_gridMaxDensity;
        }

        while (planetsLeft > 0 && planets.Count > 0)
        {

            GridNode node = planets.Dequeue();
            if (node.planetData.Count < m_gridMaxDensity)
            {
                int rand = Random.Range(0, 2);
                if (rand > 0)
                {
                    int x = (int)node.m_GridPos.x;
                    int y = (int)node.m_GridPos.y;
                    PlanetData data = new PlanetData();
                    data.position = new Vector2(Random.Range(m_GridDistanceSize * x, m_GridDistanceSize * x + m_GridDistanceSize), Random.Range(m_GridDistanceSize * y, m_GridDistanceSize * y + m_GridDistanceSize));
                    data.planetType = (PlanetType)Random.Range(0, (int)PlanetType.Size);
                    data.radius = Random.Range(1.0f, 5.0f);
                    data.gridPos = new Vector2(x, y);
                    map[x, y].planetData.Add(data);
                    Debug.Log("Planet Data Created");
                }
                planets.Enqueue(node);

            }

        }

    }

    private void Start()
    {
        OnTravelToNewGrid();

    }

    List<GridNode> GetNeighbours()
    {
        List<GridNode> neighbours = new List<GridNode>();
        GridNode temp;


        for (int i = 0; i < NeighbourCount; i++)
        {
            int x = (int)m_PlayerGridPosition.x;
            int y = (int)m_PlayerGridPosition.y;

            switch (i)
            {
                case 0: x--; y++; break;
                case 1: y++; break;
                case 2: x++; y++; break;
                case 3: x--; break;
                case 4: x++; break;
                case 5: x--; y--; break;
                case 6: y--; break;
                case 7: x++; y--; break;
            }

            if (x >= 0 && x < gridWidth && y >= 0 && y < gridHeight)
            {
                temp = map[x, y];
                if (temp != null)
                    neighbours.Add(temp);
            }
        }

        return neighbours;
    }

    void SpawnPlanets(List<GridNode> neighbours)
    {
        for (int i = 0; i < neighbours.Count; i++)
        {
            SpawnPlanets(neighbours[i]);
        }
    }

    void SpawnPlanets(GridNode node)
    {
        for (int i = 0; i < node.planetData.Count; i++)
        {
            GameObject temp = planetPooler.SpawnFromPool(node.planetData[i].position, this.transform, true);
            temp.GetComponent<Planet>().data = node.planetData[i];

            // Set planet colour to match planet type
        }
    }

    void DespawnPlanets(GridNode node)
    {
        for (int i = 0; i < node.planetObjects.Count; i++)
        {
            planetPooler.ReturnToPool(node.planetObjects[i]);
        }
    }

    void OnTravelToNewGrid()
    {
        SpawnPlanets(GetNeighbours());
    }

    private void OnEnable()
    {
        Debug.Log("PlanetGrid: Enabled");
    }

    private void OnDisable()
    {
        Debug.Log("PlanetGrid: Disabled");
    }
}
