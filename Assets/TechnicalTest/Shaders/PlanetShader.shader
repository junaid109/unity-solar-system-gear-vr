// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4013,x:32719,y:32712,varname:node_4013,prsc:2|diff-1521-OUT,emission-568-OUT;n:type:ShaderForge.SFN_Multiply,id:1521,x:32377,y:32694,varname:node_1521,prsc:2|A-2222-RGB,B-4183-OUT;n:type:ShaderForge.SFN_Multiply,id:568,x:32377,y:32834,varname:node_568,prsc:2|A-5813-RGB,B-9740-OUT;n:type:ShaderForge.SFN_Color,id:5813,x:32017,y:32865,ptovrint:False,ptlb:Glow Color,ptin:_GlowColor,varname:node_5813,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.372513,c2:0.5937911,c3:0.9558824,c4:1;n:type:ShaderForge.SFN_Multiply,id:9740,x:32017,y:33034,varname:node_9740,prsc:2|A-457-OUT,B-328-R,C-8275-OUT;n:type:ShaderForge.SFN_TexCoord,id:2531,x:31278,y:33062,varname:node_2531,prsc:2,uv:0;n:type:ShaderForge.SFN_Panner,id:8622,x:31468,y:33062,varname:node_8622,prsc:2,spu:0.01,spv:0|UVIN-2531-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:328,x:31689,y:33062,ptovrint:False,ptlb:node_328,ptin:_node_328,varname:node_328,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-8622-UVOUT;n:type:ShaderForge.SFN_Slider,id:8275,x:31516,y:33256,ptovrint:False,ptlb:Glow Strength,ptin:_GlowStrength,varname:node_8275,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:4,max:4;n:type:ShaderForge.SFN_Power,id:457,x:31765,y:32824,varname:node_457,prsc:2|VAL-7893-OUT,EXP-7171-OUT;n:type:ShaderForge.SFN_OneMinus,id:7893,x:31437,y:32808,varname:node_7893,prsc:2|IN-2222-B;n:type:ShaderForge.SFN_Vector1,id:7171,x:31437,y:32967,varname:node_7171,prsc:2,v1:2;n:type:ShaderForge.SFN_Vector1,id:4183,x:32153,y:32761,varname:node_4183,prsc:2,v1:1;n:type:ShaderForge.SFN_Tex2d,id:2222,x:31187,y:32705,ptovrint:False,ptlb:node_2222,ptin:_node_2222,varname:node_2222,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:b66bceaf0cc0ace4e9bdc92f14bba709,ntxv:0,isnm:False;proporder:5813-328-8275-2222;pass:END;sub:END;*/

Shader "TechTest/PlanetShader" {
    Properties {
        _GlowColor ("Glow Color", Color) = (0.372513,0.5937911,0.9558824,1)
        _node_328 ("node_328", 2D) = "white" {}
        _GlowStrength ("Glow Strength", Range(0, 4)) = 4
        _node_2222 ("node_2222", 2D) = "white" {}
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform float4 _GlowColor;
            uniform sampler2D _node_328; uniform float4 _node_328_ST;
            uniform float _GlowStrength;
            uniform sampler2D _node_2222; uniform float4 _node_2222_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 _node_2222_var = tex2D(_node_2222,TRANSFORM_TEX(i.uv0, _node_2222));
                float3 diffuseColor = (_node_2222_var.rgb*1.0);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float4 node_5910 = _Time + _TimeEditor;
                float2 node_8622 = (i.uv0+node_5910.g*float2(0.01,0));
                float4 _node_328_var = tex2D(_node_328,TRANSFORM_TEX(node_8622, _node_328));
                float3 emissive = (_GlowColor.rgb*(pow((1.0 - _node_2222_var.b),2.0)*_node_328_var.r*_GlowStrength));
/// Final Color:
                float3 finalColor = diffuse + emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform float4 _GlowColor;
            uniform sampler2D _node_328; uniform float4 _node_328_ST;
            uniform float _GlowStrength;
            uniform sampler2D _node_2222; uniform float4 _node_2222_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 _node_2222_var = tex2D(_node_2222,TRANSFORM_TEX(i.uv0, _node_2222));
                float3 diffuseColor = (_node_2222_var.rgb*1.0);
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
