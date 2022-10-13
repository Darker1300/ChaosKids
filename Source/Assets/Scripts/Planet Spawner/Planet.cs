using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public PlanetData data;

    void LoadData()
    {
        // Do loading stuff
    }

    private void OnDisable()
    {
        // Return planet back to object pooler
    }
}
