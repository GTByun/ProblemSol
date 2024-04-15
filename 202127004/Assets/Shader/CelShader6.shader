Shader "Unlit/CelShader6"
{
    Properties
    {
        _DiffuseColor ("DiffuseColor", Color) = (1,1,1,1)
        _ShadowColor ("ShadowColor", Color) = (1,1,1,1)
        _SpecularColor ("SpecularColor", Color) = (1,1,1,1)
        _Outline ("Outline", Range(0, 1)) = 0.1
        _BandNum("ShadowLevel", Range(1, 10)) = 3
        _Sharpness ("Sharpness", Range(0, 500)) = 1
        _SpecularPower ("SpecularPower", Range(0, 1)) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

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

                float _Outline;

                VertOutput Vert(VertInput vInput)
                {
                    float3 outlinePosition = vInput.vertex + normalize(vInput.normal) * (_Outline * 0.1f);

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
            float4 _ShadowColor;
            float4 _SpecularColor;
            float _BandNum;
            float _Sharpness;
            float _SpecularPower;


            void Surf(Input IN, inout SurfaceOutput o)
            {
                o.Albedo = _DiffuseColor.rgb;
                o.Alpha = 1.0f;
            }

            float4 Lighting_BandedLighting(SurfaceOutput s, float3 lightDir, float3 viewDir, float atten)
            {
                float normalDotLight = dot(s.Normal, lightDir) * 0.5f + 0.5f;

                float3 bandedDiffuse = ceil(normalDotLight * _BandNum) / _BandNum;
                float3 shadowColor = lerp(_ShadowColor.rgb, (1,1,1,1), bandedDiffuse);

                float3 halfVector = normalize(lightDir + viewDir);
                float harpDotNormal = pow(saturate(dot(halfVector, s.Normal)), _Sharpness);

                float3 specularColor = smoothstep(0.005f, 0.01f, harpDotNormal) * _SpecularPower * _SpecularColor;

                float4 returnColor;
                returnColor.rgb = s.Albedo * shadowColor * bandedDiffuse + specularColor;
                returnColor.a = s.Alpha;

                return returnColor;
            }
        ENDCG
    }
}
