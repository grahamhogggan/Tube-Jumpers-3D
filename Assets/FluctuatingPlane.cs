using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluctuatingPlane : MonoBehaviour
{
     [Header("Wave Settings")]
    public float waveHeight = 0.5f;    // Max height of the waves
    public float waveFrequency = 1f;   // Base frequency of waves
    public float waveSpeed = 1f;       // Speed of waves
    public int rippleCount = 3;        // Number of overlapping wave layers

    [Header("Noise Settings")]
    public float noiseScale = 0.5f;    // How much noise affects waves
    public float noiseSpeed = 0.3f;    // How fast the noise moves

    private Mesh mesh;
    private Vector3[] baseVertices;
    public static float randomOffset;

    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        baseVertices = mesh.vertices;
        randomOffset = Random.Range(0f, 1000f);
    }

    void Update()
    {
        Vector3[] vertices = new Vector3[baseVertices.Length];
        float time = Time.time * waveSpeed;

        for (int i = 0; i < vertices.Length; i++)
        {
            // Get local vertex and convert to world position
            Vector3 localVertex = baseVertices[i];
            Vector3 worldPos = transform.TransformPoint(localVertex);

            float height = 0f;

            // Multiple sine waves, based on WORLD position
            for (int r = 1; r <= rippleCount; r++)
            {
                float waveX = Mathf.Sin((worldPos.x * waveFrequency * r + time + randomOffset) * 0.5f);
                float waveZ = Mathf.Cos((worldPos.z * waveFrequency * r + time + randomOffset) * 0.5f);
                height += (waveX + waveZ) * (waveHeight / r);
            }

            // Add Perlin noise based on WORLD position
            float noise = Mathf.PerlinNoise(
                (worldPos.x * noiseScale) + (time * noiseSpeed) + randomOffset,
                (worldPos.z * noiseScale) + (time * noiseSpeed) + randomOffset
            ) - 0.5f;

            height += noise * waveHeight;

            // Set vertex back in LOCAL space with new Y
            localVertex.y = height;
            vertices[i] = localVertex;
        }

        mesh.vertices = vertices;
        mesh.RecalculateNormals();
    }
    public float GetWaveHeight(Vector3 worldPos)
{
    float time = Time.time * waveSpeed;
    float height = 0f;

    // Multiple sine/cosine waves
    for (int r = 1; r <= rippleCount; r++)
    {
        float waveX = Mathf.Sin((worldPos.x * waveFrequency * r + time + randomOffset) * 0.5f);
        float waveZ = Mathf.Cos((worldPos.z * waveFrequency * r + time + randomOffset) * 0.5f);
        height += (waveX + waveZ) * (waveHeight / r);
    }

    // Perlin noise
    float noise = Mathf.PerlinNoise(
        (worldPos.x * noiseScale) + (time * noiseSpeed) + randomOffset,
        (worldPos.z * noiseScale) + (time * noiseSpeed) + randomOffset
    ) - 0.5f;

    height += noise * waveHeight;

    return height;
}
}
