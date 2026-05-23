Shader "NA/NA_Particles_Shader" {
	Properties {
		[PowerSlider(5.0)] _Specular ("Specular", Range(0.03, 1)) = 0.078125
		[PowerSlider(5.0)] _Glossiness ("Glossiness", Range(0, 5)) = 0.5
		_Color ("Color", Vector) = (1,1,1,1)
		_MainTex ("Base (RGB) Gloss (A)", 2D) = "white" {}
		[NoScaleOffset] _BumpMap ("Normalmap", 2D) = "bump" {}
		[Toggle(_EMISSION_ON)] _EMISSION_ON ("Use Emission", Float) = 0
		[NoScaleOffset] _Emission ("Emission", 2D) = "black" {}
		_EmissionColor1 ("Emission Color1", Vector) = (1,1,1,1)
		_EmissionColor2 ("Emission Color2", Vector) = (1,1,1,1)
		_EmissionSpeed ("Emission Speed", Float) = 2
		[Toggle(_VERTEXCOLOR_ON)] _VERTEXCOLOR_ON ("Use vertex Color", Float) = 0
		[Toggle(_UV_ANIMATION_ON)] _UV_ANIMATION_ON ("Use uv Aniamtion", Float) = 0
		_AnimSpeed ("Anim Speed", Float) = 2
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType"="Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		sampler2D _MainTex;
		fixed4 _Color;
		struct Input
		{
			float2 uv_MainTex;
		};
		
		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
	Fallback "Mobile/VertexLit"
}