using UnityEngine;
using static UnityEngine.Mathf;

public static class ProceduralMeshFunctionLibrary {
    public delegate Vector3 Function (float u, float v);

    public enum FunctionName {Gridshell, Donut, TrefoilKnot, SpiralCone}

    static Function[] functions = {Gridshell, Donut, TrefoilKnot, SpiralCone};

    public static Function GetFunction(FunctionName name) {
        return functions[(int)name];
    }

    public static Vector3 Gridshell (float u, float v) {
        u *= PI;
        v *= 5f * PI;
        float x = v;
        float y = (2f + 0.25f * Sin(v)) * Cos(u);
        float z = (2f + 0.25f * Sin(v)) * Sin(u);
        return new Vector3(x, y, z);  
    }

    public static Vector3 Donut (float u, float v) {
        u *= 2f * PI;
        v *= 2f * PI;
        float x = Sin(5f * v) / 13f + (1.3f + Sin(u)) * Cos(v);
        float y = Sin(5f * v) / 13f + (2f / 3f) * Cos(u) + (1.3f + Sin(u)) * Sin(v);
        float z = Sin(5f * v) / 13f + Sin(100f * v) * 0.01f - Sin(3f * u) * 0.1f + Cos(u);
        return new Vector3(x, y, z);  
    }

    public static Vector3 TrefoilKnot (float u, float v) {
        u *= 12f * PI;
        v = (v + 1f) / 3f * PI;
        float x = v * (-1.5f*Cos(2f * u) + Cos(u));
        float y = v * (1.5f * Sin(2f * u) + Sin(u));
        float z = 0.25f * u;
        return new Vector3(x, y, z);
    }

    public static Vector3 SpiralCone (float u, float v) {
        u *= 2f * PI;
        v *= PI;
        float x = (v / 3f) * Cos(u);
        float y = (v / 3f) * Sin(u);
        float z = v;
        return new Vector3(x, y, z);
    }
}