Shader "Custom/Liquid"
{
    Properties
    {
        _Color ("Tint", Color) = (1, 1, 1, 1)
        _MainTex ("Texture", 2D) = "white" {}
        _NoiseTex ("Noise Texture", 2D) = "white" {}
        [PerRenderData]_Width ("Width", float) = 1
        [PerRenderData]_Height ("Height", float) = 1
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
            float _Width;
            float _Height;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                fixed4 color : COLOR;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float2 effectFade : TEXCOORD1;
                float2 grabCoord : TEXCOORD2;
                float3 worldPos : TEXCOORD3;
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
                o.effectFade = v.uv;

                
                o.color = v.color;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float distance = saturate(sin(i.uv.x * 3.1415) * _Width / 2 * sin(i.uv.y * 3.1415) * _Height / 2);

                float clippingGradient = (i.uv.y - 1) * _Height * -1;
                float3 warble = tex2D(_NoiseTex, i.worldPos / 16 + _Time.y * 0.1);
                warble += tex2D(_NoiseTex, float2(i.worldPos.x / 20 + _Time.y * 0.06, i.worldPos.y / 7 - _Time.y * 0.07));
                //return fixed4(warble.xxx, 1);
                clip(clippingGradient * warble.x - 0.045);
                //return fixed4(test.xxx * warble.xxx - 0.01, 1);
                float3 distortion = (warble - 0.5) * distance * 0.005;
                float2 coords = float2(i.grabCoord.x + distortion.x, i.grabCoord.y + distortion.x);
                fixed4 col = tex2D(_GrabTexture, coords);
                col *= _Color;
                col *= i.color;
                return col;
            }
            ENDCG
        }
    }
}
