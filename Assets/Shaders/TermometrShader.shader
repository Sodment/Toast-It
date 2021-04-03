Shader "Custom/TermometrShader"
{
    Properties
    {
        _Color("ColorMainColor", Color) = (1,1,1,1)
        _PerfectColor("PerfectColor", Color)=(0,0,0,0)
        _PerfectRange("PerfectRange", Range(0.05, 0.8)) = 0.1
        _PerfectIntense("PerfectIntense", Range(0.0, 1.0)) = 0.5
        _BonusColor("BonusZoneColor", Color) = (1,1,0,1)
        _BonusRange("BonusRange", Range(0.1, 1.0)) = 0.2
        _GoodColor("GoodZoneColor", Color) = (0,1,0,1)
        _GoodRange("GoodRange", Range(0.2,1.4)) = 0.4
        _BadColor("BadZoneColor",Color) = (1,0,0,1)
        _LineWidth("LineWidth", Range(0.0,0.45)) = 0.4
        _LineBorder("Border", Range(0.35,0.5)) = 0.4
        _CenterX("CenterPointX", Range(0.0,1.0)) = 0.5
        _CenterY("CenterPointY", Range(0.0, 1.0)) = 0.5
        _MainTex("Albedo (RGB)", 2D) = "white" {}
        _Glossiness("Smoothness", Range(0,1)) = 0.5
        _Metallic("Metallic", Range(0,1)) = 0.0

        _AngleOffset("AngleOffset", Range(-3.14,3.14)) = 0.0
        _Perfect("Perfect", Range(0,4.7124)) = 0
        _LerpIntense("Lerp", Range(0,1)) = 0.5
        _ScaleTex("Scale", 2D) = "white"{}
        _ScaleColor("ScaleColor", Color) = (0,0,0,1)

        _ShowStarBonus("ShowBonus", Range(0,1)) = 0
        _StarBonusColor("StarColor", Color) = (1,1,0,1)
        _StarBonusRange("StarRange", Range(0, 1)) = 0.5
        _StarBonusAngle("StarAngle", Range(-3.14, 3.14))=0
        _StarBonusBorder("StarBorder", Range(0,0.5))=0
        _StarBonudDistance("StarWidth", Range(0,0.5))=0
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
            sampler2D _ScaleTex;

            struct Input
            {
                float2 uv_MainTex;
            };

            half _Glossiness;
            half _Metallic;
            fixed4 _Color;

            fixed4 _PerfectColor;
            float _PerfectRange;
            fixed4 _BonusColor;
            float _BonusRange;
            fixed4 _GoodColor;
            float _GoodRange;
            fixed4 _BadColor;
            fixed4 _ScaleColor;

            float _LerpIntense;

            float _LineWidth;
            float _LineBorder;
            
            float _Perfect;
            float _AngleOffset;

            float _CenterX;
            float _CenterY;

            float _PerfectIntense;
            
            float _ShowStarBonus;
            fixed4 _StarBonusColor;
            float _StarBonusRange;
            float _StarBonusAngle;
            float _StarBonusBorder;
            float _StarBonudDistance;

            // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
            // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
            // #pragma instancing_options assumeuniformscaling
            UNITY_INSTANCING_BUFFER_START(Props)
                // put more per-instance properties here
            UNITY_INSTANCING_BUFFER_END(Props)

            void surf(Input IN, inout SurfaceOutputStandard o)
            {
                // Albedo comes from a texture tinted by color
                fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
                float2 center = { 0.5f, 0.5f};
                if (length(IN.uv_MainTex - center) > _LineWidth && length(IN.uv_MainTex - center) < _LineBorder)
                {
                    float y = IN.uv_MainTex.y - _CenterY;
                    float x = IN.uv_MainTex.x - _CenterX;
                    float angle = -_Perfect - atan2(y, x) + _AngleOffset;
                    if (angle < -3.14) {
                        angle += 6.28;
                    }
                    if (abs(angle) < _PerfectRange) {
                        c = lerp(c, _PerfectColor*_PerfectIntense, _LerpIntense);
                    }
                    else if (abs(angle) < _BonusRange) {
                        c = lerp(c, _BonusColor, _LerpIntense);
                    }
                    else if (abs(angle) < _GoodRange) {
                        c = lerp(c, _GoodColor, _LerpIntense);
                    }
                    else {
                        c = lerp(c, _BadColor, _LerpIntense);
                    }
                }

                if(_ShowStarBonus>0.9)
                {
                    center = ( 0.5f, 0.5f );
                    if (length(IN.uv_MainTex - center) > _StarBonudDistance && length(IN.uv_MainTex - center) < _StarBonusBorder) {
                        float y = IN.uv_MainTex.y - center.y;
                        float x = IN.uv_MainTex.x - center.x;
                        float angle = -_StarBonusAngle - atan2(y, x) + _AngleOffset;
                        if (angle < -3.14) {
                            angle += 6.28;
                        }
                        if (abs(angle) < _StarBonusRange) {
                            c = lerp(c, _StarBonusColor, _LerpIntense);
                        }
                    }
                }

                c = lerp(c, tex2D(_ScaleTex, IN.uv_MainTex) * _ScaleColor, tex2D(_ScaleTex, IN.uv_MainTex).a);
               


                o.Albedo = c.rgb;
                o.Metallic = _Metallic;
                o.Smoothness = _Glossiness;
                o.Alpha = c.a;
            }
            ENDCG
        }
            FallBack "Diffuse"
}
