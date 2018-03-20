﻿Shader "Custom/MyColoredDiffuseWithLightEstimation"
{
	Properties
	{
			_Color ("Color", Color) = (1,1,1,1)
			_MainTex ("Base (RGB)", 2D) = "white" {}
	}

	SubShader 
	{
			Tags { "RenderType"="Opaque" }
			LOD 150

			CGPROGRAM
			#pragma surface surf Lambert noforwardadd finalcolor:lightEstimation

			sampler2D _MainTex;
			fixed _GlobalLightEstimation;
			fixed4 _Color;

			struct Input
			{
					float2 uv_MainTex;
			};

			void lightEstimation(Input IN, SurfaceOutput o, inout fixed4 color)
			{
					color *= _GlobalLightEstimation * _Color;
			}

			void surf (Input IN, inout SurfaceOutput o)
			{
					fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
					o.Albedo = c.rgb;
					o.Alpha = c.a;
			}
			ENDCG
	}

	Fallback "Mobile/VertexLit"
}