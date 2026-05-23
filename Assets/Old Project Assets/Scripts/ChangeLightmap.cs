using UnityEngine;

public class ChangeLightmap : MonoBehaviour
{

    [SerializeField] public Texture2D _dir; // The directional lights texture.
    [SerializeField] public Texture2D _light; // The color lightmap texture.
    [SerializeField] public Texture2D _shadow; // The shadow mask texture.

    public void Load()
    {
        LightmapData[] lightmaparray = LightmapSettings.lightmaps;
        LightmapData mapdata = new LightmapData();
        for (var i = 0; i < lightmaparray.Length; i++)
        {

            mapdata.lightmapDir = _dir;
            mapdata.lightmapColor = _light;
            mapdata.shadowMask = _shadow;

            lightmaparray[i] = mapdata;
        }
        LightmapSettings.lightmaps = lightmaparray;
    }
}