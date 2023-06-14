Shader "Custom/Background"
{
    Properties
    {
        _Color ("Tint", Color) = (1, 1, 1, 1)
        _MainTex ("Texture", 2D) = "white" {}
        _Scaling ("Scaling", float) = 1
        _HorizontalScrollOffset ("Horizontal Scroll Offset", float) = 40
        _VerticalScrollOffset ("Vertical Scroll Offset", float) = 40
        _HorizontalOffset ("Horizontal Offset", float) = 0
        _VerticalOffset ("Vertical Offset", float) = 0
        _TopClamp ("Top Clamp", float) = 1
        _BottomClamp ("Bottom Clamp", float) = -1
    }
    SubShader
    {
        Tags {
            "RenderType"="Transparent"
            "Queue"="Transparent"
        }

        Blend SrcAlpha OneMinusSrcAlpha

        ZWrite off
        Cull off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _Color;
            float _Scaling;
            float _HorizontalScrollOffset;
            float _VerticalScrollOffset;
            float _HorizontalOffset;
            float _VerticalOffset;
            float _TopClamp;
            float _BottomClamp;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                fixed4 color : COLOR;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float3 worldPos : TEXCOORD1;
                float4 vertex : SV_POSITION;
                fixed4 color : COLOR;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.worldPos = mul(unity_ObjectToWorld, v.vertex);
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.color = v.color;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                float x = _HorizontalOffset + i.worldPos.x / _Scaling - _WorldSpaceCameraPos.x / _HorizontalScrollOffset;
                float y = _VerticalOffset + clamp(i.worldPos.y / _Scaling - _WorldSpaceCameraPos.y / _VerticalScrollOffset, _BottomClamp, _TopClamp);
                fixed4 col = tex2D(_MainTex, float2 (x, y));
                //fixed4 col = tex2D(_MainTex, i.worldPos.xy);
                col *= _Color;
                col *= i.color;
                return col;
            }
            ENDCG
        }
    }
}
