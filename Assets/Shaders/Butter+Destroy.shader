Shader "Custom/Butter+Destroy"
{
    Properties
    {
        _StartColor("StartColor", Color) = (1,1,1,1)
        _FinalColor("FinalColor", Color) = (0,0,0,0)
        _Progress("Done%", Range(0.0,1.0)) = 0.0
        _MainTex("Albedo (RGB)", 2D) = "white" {}
        _ButterTex("Butter", 2D) = "white" {}
        _DestroyTex("DestroyWay", 2D) = "white" {}
        _Glossiness("Smoothness", Range(0,1)) = 0.5
        _Metallic("Metallic", Range(0,1)) = 0.0
        _Fill("Fill", Range(0,3.14)) = 0.0
        _DestroyFill("DestroyFill", Range(0,1)) = 0.0
        _ColorMultipler("ColorMultipler", Range(0.0,1.0)) = 1.0

             _BumpMap("Bumpmap", 2D) = "bump" {}
    }
        SubShader
        {
            Tags { "RenderType" = "Opaque" }
            LOD 200

            CGPROGRAM
            // Physically based Standard lighting model, and enable shadows on all light types
            #pragma surface surf Standard fullforwardshadows

            // Use shader model 3.0 target, to get nicer looking lighting
            #pragma target 3.0

            sampler2D _MainTex;
            sampler2D _ButterTex;
            sampler2D _DestroyTex;
            sampler2D _BumpMap;

            struct Input
            {
                float2 uv_MainTex;
                float2 uv_BumpMap;
            };

            half _Glossiness;
            half _Metallic;
            fixed4 _StartColor;
            fixed4 _FinalColor;
            half _Fill;
            half _Progress;
            half _DestroyFill;
            half _ColorMultipler;

            // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
            // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
            // #pragma instancing_options assumeuniformscaling
            UNITY_INSTANCING_BUFFER_START(Props)
                // put more per-instance properties here
            UNITY_INSTANCING_BUFFER_END(Props)

            void surf(Input IN, inout SurfaceOutputStandard o)
            {
                // Albedo comes from a texture tinted by color
                if (tex2D(_DestroyTex, IN.uv_MainTex).r > _DestroyFill)
                {
                    float angle = atan2((IN.uv_MainTex).y + 0.7, (IN.uv_MainTex).x - 0.7);
                    fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * lerp(_StartColor, _FinalColor, _Progress);
                    if (angle < _Fill)
                    {
                        c = lerp(c, tex2D(_ButterTex, IN.uv_MainTex), tex2D(_ButterTex, IN.uv_MainTex).a);
                        o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
                    }
                    o.Albedo = c.rgb*_ColorMultipler;
                    // Metallic and smoothness come from slider variables
                    o.Metallic = _Metallic;
                    o.Smoothness = _Glossiness;
                    o.Alpha = c.a;
                }
                else { discard; }
            }
            ENDCG
        }
            FallBack "Diffuse"
}
