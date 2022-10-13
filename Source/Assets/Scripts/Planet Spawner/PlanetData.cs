using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PlanetType
{
    Dirt,
    Water,
    Rock,
    Size
}

public class PlanetData
{
    public Vector2 position = Vector2.zero;
    public PlanetType planetType = PlanetType.Dirt;
    public float radius = 0.5f;
    public Vector2 gridPos = Vector2.zero;
    public int resourceAmount = 0;
    public List<Vector2> resourcePositions = new List<Vector2>();
}
