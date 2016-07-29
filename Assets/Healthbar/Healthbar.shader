// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4013,x:33182,y:32679,varname:node_4013,prsc:2|diff-7079-OUT,emission-8564-OUT,clip-2321-OUT;n:type:ShaderForge.SFN_TexCoord,id:4282,x:31360,y:33122,varname:node_4282,prsc:2,uv:0;n:type:ShaderForge.SFN_Lerp,id:8564,x:32593,y:32613,varname:node_8564,prsc:2|A-1352-RGB,B-6232-RGB,T-5895-OUT;n:type:ShaderForge.SFN_Color,id:1352,x:32150,y:32393,ptovrint:False,ptlb:node_1352,ptin:_node_1352,varname:node_1352,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Color,id:6232,x:32150,y:32561,ptovrint:False,ptlb:node_6232,ptin:_node_6232,varname:node_6232,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.5294118,c3:0,c4:1;n:type:ShaderForge.SFN_Slider,id:5895,x:31674,y:32683,ptovrint:False,ptlb:Health,ptin:_Health,varname:node_5895,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_RemapRange,id:8437,x:31554,y:33176,varname:node_8437,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-4282-UVOUT;n:type:ShaderForge.SFN_OneMinus,id:3858,x:32449,y:33283,varname:node_3858,prsc:2|IN-5921-OUT;n:type:ShaderForge.SFN_Floor,id:5921,x:32243,y:33267,varname:node_5921,prsc:2|IN-3970-OUT;n:type:ShaderForge.SFN_ComponentMask,id:7626,x:31753,y:32893,varname:node_7626,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-8437-OUT;n:type:ShaderForge.SFN_Subtract,id:3375,x:32137,y:32907,varname:node_3375,prsc:2|A-5895-OUT,B-2795-OUT;n:type:ShaderForge.SFN_Ceil,id:367,x:32701,y:32825,varname:node_367,prsc:2|IN-9674-OUT;n:type:ShaderForge.SFN_Multiply,id:2321,x:32785,y:33128,varname:node_2321,prsc:2|A-367-OUT,B-3858-OUT;n:type:ShaderForge.SFN_Tex2d,id:6139,x:31755,y:33564,ptovrint:False,ptlb:node_6139,ptin:_node_6139,varname:node_6139,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:afa448ab2ae7db94bbeccf7a6540ad67,ntxv:3,isnm:False|UVIN-8437-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4578,x:31844,y:33462,ptovrint:False,ptlb:Power Add,ptin:_PowerAdd,varname:node_4578,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_Add,id:3970,x:32094,y:33384,varname:node_3970,prsc:2|A-1085-RGB,B-4578-OUT;n:type:ShaderForge.SFN_Add,id:9053,x:32543,y:33499,varname:node_9053,prsc:2|A-1085-RGB,B-6139-RGB;n:type:ShaderForge.SFN_Power,id:7079,x:32785,y:33359,varname:node_7079,prsc:2|VAL-957-OUT,EXP-9053-OUT;n:type:ShaderForge.SFN_ValueProperty,id:957,x:32593,y:33359,ptovrint:False,ptlb:Power_Alpha,ptin:_Power_Alpha,varname:node_957,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_Tex2d,id:1085,x:31855,y:33202,ptovrint:False,ptlb:node_1085,ptin:_node_1085,varname:node_1085,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:f248206373809224b98d210346c8086f,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Floor,id:9674,x:32513,y:32813,varname:node_9674,prsc:2|IN-6512-OUT;n:type:ShaderForge.SFN_Sin,id:2795,x:31913,y:32907,varname:node_2795,prsc:2|IN-7626-OUT;n:type:ShaderForge.SFN_Power,id:7177,x:32262,y:32732,varname:node_7177,prsc:2|VAL-5895-OUT,EXP-6601-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6601,x:32080,y:32795,ptovrint:False,ptlb:Ceiling Value,ptin:_CeilingValue,varname:node_6601,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Add,id:6512,x:32322,y:32874,varname:node_6512,prsc:2|A-7177-OUT,B-3375-OUT;proporder:1352-6232-5895-4578-6139-957-1085-6601;pass:END;sub:END;*/

Shader "Shader Forge/Healthbar" {
    Properties {
        _node_1352 ("node_1352", Color) = (1,0,0,1)
        _node_6232 ("node_6232", Color) = (1,0.5294118,0,1)
        _Health ("Health", Range(0, 1)) = 1
        _PowerAdd ("Power Add", Float ) = 0.1
        _node_6139 ("node_6139", 2D) = "bump" {}
        _Power_Alpha ("Power_Alpha", Float ) = 0.1
        _node_1085 ("node_1085", 2D) = "white" {}
        _CeilingValue ("Ceiling Value", Float ) = 1
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
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
            uniform float4 _node_1352;
            uniform float4 _node_6232;
            uniform float _Health;
            uniform sampler2D _node_6139; uniform float4 _node_6139_ST;
            uniform float _PowerAdd;
            uniform float _Power_Alpha;
            uniform sampler2D _node_1085; uniform float4 _node_1085_ST;
            uniform float _CeilingValue;
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
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float2 node_8437 = (i.uv0*2.0+-1.0);
                float4 _node_1085_var = tex2D(_node_1085,TRANSFORM_TEX(i.uv0, _node_1085));
                clip((ceil(floor((pow(_Health,_CeilingValue)+(_Health-sin(node_8437.r)))))*(1.0 - floor((_node_1085_var.rgb+_PowerAdd)))) - 0.5);
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
                float4 _node_6139_var = tex2D(_node_6139,TRANSFORM_TEX(node_8437, _node_6139));
                float3 diffuseColor = pow(_Power_Alpha,(_node_1085_var.rgb+_node_6139_var.rgb));
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float3 emissive = lerp(_node_1352.rgb,_node_6232.rgb,_Health);
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
            uniform float4 _node_1352;
            uniform float4 _node_6232;
            uniform float _Health;
            uniform sampler2D _node_6139; uniform float4 _node_6139_ST;
            uniform float _PowerAdd;
            uniform float _Power_Alpha;
            uniform sampler2D _node_1085; uniform float4 _node_1085_ST;
            uniform float _CeilingValue;
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
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float2 node_8437 = (i.uv0*2.0+-1.0);
                float4 _node_1085_var = tex2D(_node_1085,TRANSFORM_TEX(i.uv0, _node_1085));
                clip((ceil(floor((pow(_Health,_CeilingValue)+(_Health-sin(node_8437.r)))))*(1.0 - floor((_node_1085_var.rgb+_PowerAdd)))) - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 _node_6139_var = tex2D(_node_6139,TRANSFORM_TEX(node_8437, _node_6139));
                float3 diffuseColor = pow(_Power_Alpha,(_node_1085_var.rgb+_node_6139_var.rgb));
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float _Health;
            uniform float _PowerAdd;
            uniform sampler2D _node_1085; uniform float4 _node_1085_ST;
            uniform float _CeilingValue;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float2 node_8437 = (i.uv0*2.0+-1.0);
                float4 _node_1085_var = tex2D(_node_1085,TRANSFORM_TEX(i.uv0, _node_1085));
                clip((ceil(floor((pow(_Health,_CeilingValue)+(_Health-sin(node_8437.r)))))*(1.0 - floor((_node_1085_var.rgb+_PowerAdd)))) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
