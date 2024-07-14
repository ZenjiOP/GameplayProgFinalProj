Shader "Custom/SemiTransparentRedOutsideSphere"
{
    SubShader
    {
        Tags { "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent"}
        Blend SrcAlpha OneMinusSrcAlpha // Blending mode for transparency
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float3 worldPos : TEXCOORD0;
            };

            float4 _SphereCenters[6];
            float _SphereRadius;

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                return o;
            }

            half4 frag (v2f i) : SV_Target
            {
                float alpha = 0.0; // Initialize alpha outside of the loop
                
                for (int j = 0; j < 6; j++) {
                    
                    float3 sphereCenter = _SphereCenters[j];
                    float sphereRadius = _SphereCenters[j].w;

                    float distToSphere = distance(i.worldPos, sphereCenter.xyz); 
                    alpha += smoothstep(sphereRadius, sphereRadius + 0.3, distToSphere);                   
                }
                
                alpha = 1.0 - (alpha / 6); // Average alpha value for all spheres
                alpha = alpha * 6;
                alpha = min(alpha, 0.5);
                // Set output color based on the calculated alpha value
                return half4(1.0, 0.0, 0.0, alpha);
            }
            ENDCG
        }
    }
}
