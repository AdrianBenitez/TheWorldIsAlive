Shader "Custom/RoughnessBendGlass" {
    Properties {
        _Color ("Main Color", Color) = (1,1,1,1)
        _MainTex ("Base (RGBA)", 2D) = "white" {}
        _Roughness ("Roughness", Range(0,1)) = 0
        _Curvature("Curvature", Float) = 0.001
        _Metalness("Metalness", Range(0, 1)) = 0 
        }

    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        LOD 250
        CGPROGRAM
        #pragma surface surf Standard vertex:vert addshadow
        /* the shader now uses the standard lighting model instead of the
        lambert lighting model. The standard lighting model is better, and
        is the lighting model that the textures that I made go with.
        */
       
        sampler2D _MainTex;
        sampler2D _BumpMap;
        fixed4 _Color;
        half _Metalness;
        uniform float _Curvature;
        half _Roughness;
       
        struct Input {
            float2 uv_MainTex;
            float2 uv_DecalTex;
            float2 uv_BumpMap;
        };
        void vert(inout appdata_full v)
            {
                float4 worldSpace = mul(unity_ObjectToWorld, v.vertex);
                worldSpace.xyz -= _WorldSpaceCameraPos.xyz;
                worldSpace = float4(0.0f, (worldSpace.z * worldSpace.z) * -_Curvature, 0.0f, 0.0f);

                v.vertex += mul(unity_WorldToObject, worldSpace);
            }
       
        void surf (Input IN, inout SurfaceOutputStandard o) {
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
            o.Albedo = lerp(_Color, c.rgb, c.a);
            o.Alpha = 1;
            o.Normal = UnpackNormal (tex2D (_BumpMap, IN.uv_BumpMap));
           
            o.Smoothness = _Roughness;
            o.Metallic = _Metalness;
        }
        ENDCG
    }
    Fallback "Diffuse"
}