//http://docs.unity3d.com/Manual/SL-SurfaceShaderExamples.html
Shader "Eric/Card" {
    Properties {
      _CardTemplateTex ("Card Template Tex", 2D) = "white" {}
      _CardTex ("Card Tex", 2D) = "white" {}
    }
    SubShader {
      Tags { "RenderType" = "Opaque" }
      CGPROGRAM
      #pragma surface surf Lambert
      struct Input {
          float2 uv_CardTemplateTex;
          float2 uv_CardTex;
      };
      sampler2D _CardTemplateTex;
      sampler2D _CardTex;
      
      void surf (Input IN, inout SurfaceOutput o) {
      
          float4 templateAlbedo = tex2D (_CardTemplateTex, IN.uv_CardTemplateTex).rgba;
          float templateAlpha = templateAlbedo.a;
          float3 cardAlbedo = tex2D (_CardTex, IN.uv_CardTemplateTex).rgb;
          o.Albedo = lerp(cardAlbedo, templateAlbedo.rgb, templateAlpha);
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }