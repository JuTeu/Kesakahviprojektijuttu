Shader "Custom/Liquid"
{
    Properties
    {
        _Color ("Tint", Color) = (1, 1, 1, 1)
        _MainTex ("Texture", 2D) = "white" {}
        _NoiseTex ("Noise Texture", 2D) = "white" {}
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

        GrabPass { }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4 _MainTex_ST;
            sampler2D _NoiseTex;
            float4 _NoiseTex_ST;
            fixed4 _Color;
            sampler2D _GrabTexture;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                fixed4 color : COLOR;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float2 grabCoord : TEXCOORD1;
                float3 worldPos : TEXCOORD2;
                float4 vertex : SV_POSITION;
                fixed4 color : COLOR;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex);
                o.grabCoord = (float2(o.vertex.x, o.vertex.y * -1) + o.vertex.w) * 0.5;
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);

                
                o.color = v.color;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float3 distortion = tex2D(_NoiseTex, i.worldPos / 4 + _Time.y * 0.1);
                distortion *= 0.005;
                float2 coords = float2(i.grabCoord.x + distortion.x, i.grabCoord.y + distortion.x);
                fixed4 col = tex2D(_GrabTexture, coords + 0.004);
                col *= _Color;
                col *= i.color;
                return col;
            }
            ENDCG
        }
    }
}
