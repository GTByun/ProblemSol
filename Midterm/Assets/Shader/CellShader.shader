Shader "Unlit/CellShader"
{
    Properties
    {
        _DiffuseColor ("DiffuseColor", Color) = (1,1,1,1)
        _Brightness ("Brightness", Range(0, 2.0)) = 1.0
        _Ambient ("Ambient", Color) = (0.1,0.1,0.1,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        cull front
        Pass
        {
            CGPROGRAM
                #pragma vertex Vert
                #pragma fragment Frag

                #include "UnityCG.cginc"

                struct VertInput
                {
                    float4 vertex : POSITION;
                    float3 normal : NORMAL;
                };
                
                struct VertOutput
                {
                    float4 vertex : SV_POSITION;
                };

                VertOutput Vert(VertInput vInput)
                {
                    float3 outlinePosition = vInput.vertex + normalize(vInput.normal) * (0.5f * 0.1f);

                    VertOutput vOutput;
                    vOutput.vertex = UnityObjectToClipPos(outlinePosition);
                    return vOutput;
                }

                float4 Frag(VertOutput i) : SV_Target
                {
                    return 0.0f;
                }
            ENDCG
        }

        cull back
        CGPROGRAM
            #pragma surface Surf _BandedLighting
                
            struct Input
            {
                float2 uv_MainTex;
            };

            float4 _DiffuseColor;
            float _Brightness;
            float4 _Ambient;

            void Surf(Input IN, inout SurfaceOutput o)
            {
                o.Albedo = _DiffuseColor.rgb * _Brightness;
                o.Alpha = 1.0f;
            }

            float4 Lighting_BandedLighting(SurfaceOutput s, float3 lightDir, float3 viewDir, float atten)
            {
                float normalDotLight = dot(s.Normal, lightDir) * 0.5f + 0.5f;

                float3 bandedDiffuse = ceil(normalDotLight * 3) / 3;

                float3 halfVector = normalize(lightDir + viewDir);
                float harpDotNormal = pow(saturate(dot(halfVector, s.Normal)), 500);

                float3 specularColor = smoothstep(0.005f, 0.01f, harpDotNormal);

                float4 returnColor;
                returnColor.rgb = s.Albedo * (bandedDiffuse + _Ambient) + specularColor;
                returnColor.a = s.Alpha;

                return returnColor;
            }
            ENDCG
    }
}
