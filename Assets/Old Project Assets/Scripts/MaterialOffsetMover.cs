using UnityEngine;

public class MaterialOffsetMover : MonoBehaviour
{
    // The speed at which the offset will move
    public Vector2 speed = new Vector2(0.1f, 0.1f);

    // The material whose offset will be moved
    private Material material;

    void Start()
    {
        // Get the Renderer component and assign the material
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            material = renderer.material;
        }
        else
        {
            Debug.LogError("Renderer component not found.");
        }
    }

    void Update()
    {
        // Check if the material is assigned
        if (material != null)
        {
            // Calculate the offset
            Vector2 offset = material.GetTextureOffset("_MainTex");

            // Update the offset based on time and speed
            offset += speed * Time.deltaTime;

            // Apply the new offset to the material
            material.SetTextureOffset("_MainTex", offset);
        }
    }
}