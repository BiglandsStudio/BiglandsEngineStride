// asp3.0

// ���̍s��3dsMAX���������p�[�T�[�œǂݍ��ނ��߂Ɏg���邨�܂��Ȃ��B
//string ParamID = "0x003";

// �ϊ��s��
// �E���̃p�����[�^�̓r���[�|�[�g�̃J�����ʒu�ƃ��f���̔z�u�����f���܂��B
float4x4 g_mtxWorld			: WORLD;
float4x4 g_mtxView			: VIEW;
float4x4 g_mtxProjection	: PROJECTION;
float4x4 g_mtxWorldViewProj : WORLDVIEWPROJ;
float4x4 g_mtxWorldView		: WORLDVIEW;
float4x4 g_imtxView			: VIEWI;

// ���C�g�p�����[�^
// �E���̃p�����[�^�̓V�[�����ɂ��郉�C�g�̏�񂪔��f���܂��B
// �E�p�����[�^��View���W�n�Ŏw�肳��܂��B
float3 g_vtLightDir : Direction
<  
	string UIName = "* PARALLEL LIGHT"; 
	string Object = "TargetLight";
	int refID = 0;
> = {-0.577, -0.577, 0.577};

float4 g_colorLight : LIGHTCOLOR
<
	int LightRef = 0;
> = float4(0.0f, 0.0f, 0.0f, 0.0f);

// ���C�e�B���O�̗L��/����
bool g_enablesLighting
<
	string UIName = "* LIGHTING";
> = true;

// �g�U���˃J���[�̃\�[�X�I��
int g_diffuseColorSelect
<
	string UIName = "* DIFFUSE COLOR (0:Mate/1:Vert/2:Mate*Vert)";
	string UIType = "Spinner";
	int UIMin = 0;
	int UIMax = 2;
	int UIStep = 1;
> = 0;

// �g�U���˂̌Œ�J���[
float4 g_diffuseColor
<
	string UIName = "  + material color";
> = float4( 0.80f, 0.80f, 0.80f, 1.0f );

// ���Ȕ���
float3 g_emissionColor
<
	string UIName = "  + emission color";
> = float3( 0.00f, 0.00f, 0.00f);

// ���C�e�B���O�ɂ�����g�U���ˋP�x�̃X�P�[��
float g_diffuseAttenuation
<
	string UIName = "  + luminance attenuation";
	float UIMin = 0.0f;
	float UIMax = 1.0f;
	float UIStep = 0.01f;
> = 1.0f;

// �X�y�L�����[�̐ݒ�
bool g_enablesSpecular
<
	string UIName = "* SPECULAR";
> = false;

int g_specularColorSelector
<
	string UIName = "  + color (0:Mate/1:Vert/2:Mate*Vert/3:Fragment)";
	string UIType = "Spinner";
	int UIMin = 0;
	int UIMax = 3;
	int UIStep = 1;
> = 0;

float3 g_colorSpecular
<
	string UIName = "  |  + specular color";
> = float3( 0.80f, 0.80f, 0.80f );

float g_SpecularPower
<
	string UIName = "  + specular power";
	string UIType = "FloatSpinner";
	float UIMin = 0.01f;
	float UIMax = 256.0f;
> = 32.0f;

// �����X�y�L�����[
bool g_enablesRimSpecular
<
	string UIName = "* RIM-SPECULAR";
> = false;

float3 g_colorRimSpecular
<
	string UIName = "  + specular color";
> = float3( 0.80f, 0.80f, 0.80f );

float g_rimSpecularPower
<
	string UIName = "  + specular power";
	string UIType = "FloatSpinner";
	float UIMin = 0.0f;
	float UIMax = 256.0f;
> = 5.0f;

float g_rimSpecularSelfLuminous
<
	string UIName = "  + self luminous";
	string UIType = "FloatSpinner";
	float UIMin = 0.0f;
	float UIMax = 2.0f;
> = 1.0f;


// �x�[�X�J���[�e�N�X�`��
// �E�r�b�g�}�b�v
// �E�}�b�v�`�����l��
bool g_enablesBaseColorTex
<
	string UIName = "* BASE COLOR TEXTURE";
> = false;


texture g_texBaseColor : DiffuseMap
<
	string UIName = "  + texture";
	int Texcoord = 0;
	int MapChannel = 1;
>;

sampler2D g_texsmpBaseColor = sampler_state
{
	Texture = <g_texBaseColor>;
	MinFilter = Linear;
	MagFilter = Linear;
	MipFilter = Linear;
	AddressU = WRAP;
	AddressV = WRAP;
};

int g_blendBaseColorTexture
<
	string UIName = "  + Blend (0:ModRGBA/1:ModRGB/2:AddRGB/...)";
	string UIType = "Spinner";
	int UIMin = 0;
	int UIMax = 6;
	int UIStep = 1;
> = 0;

// �⏕�J���[�e�N�X�`��
// �E�r�b�g�}�b�v
// �E�}�b�v�`�����l��
bool g_enablesUtilColorTex
<
	string UIName = "* UTIL COLOR TEXTURE";
> = false;

texture g_texUtilColor : DiffuseMap
<
	string UIName = "  + texture";
	int Texcoord = 1;
	int MapChannel = 1;
>;

sampler2D g_texsmpUtilColor = sampler_state
{
	Texture = <g_texUtilColor>;
	MinFilter = Linear;
	MagFilter = Linear;
	MipFilter = Linear;
	AddressU = WRAP;
	AddressV = WRAP;
};

int g_blendUtilColorTexture
<
	string UIName = "  + Blend (0:ModRGBA/1:ModRGB/2:AddRGB)";
	string UIType = "Spinner";
	int UIMin = 0;
	int UIMax = 8;
	int UIStep = 1;
> = 0;

// �O���X�}�b�v
bool g_enablesGlossMap
<
	string UIName = "* GLOSS MAP";
> = false;

int g_indexGlossSrc
<
	string UIName = "  + source (0:BaseTex/1:UtilTex/2:Fragment)";
	int UIMin = 0;
	int UIMax = 2;
	int UIStep = 1;
> = 0;

// �@���}�b�v�e�N�X�`��
// �E�r�b�g�}�b�v
// �E�}�b�v�`�����l��
// �E���x�N�g��
bool g_enablesNormalMap
<
	string UIName = "* NORMAL MAP";
> = false;

texture g_texNormalMap : NormalMap
<
	string UIName = "  + texture";
	int Texcoord = 2;
	int MapChannel = 1;
>;

sampler2D g_texsmpNormalMap = sampler_state
{
	Texture = <g_texNormalMap>;
	MinFilter = Linear;
	MagFilter = Linear;
	MipFilter = Linear;
	AddressU = WRAP;
	AddressV = WRAP;
};

// �@���}�b�v�̊��x�N�g���̑I��(���[�J�����W�n/�ڐ����W�n)
int g_normalMapType
<
	string UIName = "  + Type (0:ObjLocal/1:Tangent)";
	string UIType = "Spinner";
	int UIMin = 0;
	int UIMax = 1;
	int UIStep = 1;
> = 0;

// ���[�J�����W�n�ł̖@���}�b�v��RGB�̊��x�N�g���B
int g_normalMapAxisR
<
	string UIName = "  |  + base axis of R";
	string UIWidget = "Slider";
	int UIMin = 0;
	int UIMax = 5;
	int UIStep = 1;
> = 0;

int g_normalMapAxisG
<
	string UIName = "  |  + base axis of G";
	string UIWidget = "Slider";
	int UIMin = 0;
	int UIMax = 5;
	int UIStep = 1;
> = 2;

int g_normalMapAxisB
<
	string UIName = "  |  + base axis of B";
	string UIWidget = "Slider";
	int UIMin = 0;
	int UIMax = 5;
	int UIStep = 1;
> = 4;

const float3 g_vtBaseAxis[6] =
{
	{  1, 0, 0, },		// +X
	{ -1, 0, 0, },		// -X
	{ 0,  1, 0, },		// +Y
	{ 0, -1, 0, },		// -Y
	{ 0, 0,  1, },		// +Z
	{ 0, 0, -1, },		// -Z
};

// �ڐ����W�n�ł̖@���}�b�v�́AR��G�������B
bool g_swapTangentAndBinormal
<
	string UIName = "  |  + swap Tangent and Binormal.";
> = false;

// �ڐ����W�n��Tangent���x�N�g���̌����𔽓]����B
bool g_flipTangent
<
	string UIName = "  |  + flip Tangent";
> = false;

// �ڐ����W�n��Binormal���x�N�g���̌����𔽓]����B
bool g_flipBinormal
<
	string UIName = "  |  + flip Binormal";
> = false;

// �@���}�b�v�̃f�o�b�O
bool g_debugShowNormalDir
<
	string UIName = "  + output normal direction to color (debug)";
> = false;


// ���}�b�v�e�N�X�`��
// �E�r�b�g�}�b�v
// �E�����J���[
// �E�t���l����
bool g_enablesEnvironmentMap
<
	string UIName = "* ENVIRONMENT MAP";
> = false;

texture g_texCubeEnvironmentMap
<
	string UIName = "  + cube map texture";
	string Type = "Cube";
>;

samplerCUBE	g_texsmpCubeEnvironmentMap = sampler_state
{
	Texture = <g_texCubeEnvironmentMap>;
	MinFilter = Linear;
	MagFilter = Linear;
	MipFilter = Linear;
	AddressU = WRAP;
	AddressV = WRAP;
};

texture g_texSphereEnvironmentMap
<
	string UIName = "  + sphere map texture";
>;

sampler2D	g_texsmpSphericalEnvironmentMap = sampler_state
{
	Texture = <g_texSphereEnvironmentMap>;
	MinFilter = Linear;
	MagFilter = Linear;
	MipFilter = Linear;
	AddressU = WRAP;
	AddressV = WRAP;
};

float4 g_colorEnvironmentMapModulate
<
	string UIName = "  + adjust color";
> = float4( 1.00f, 1.00f, 1.00f, 1.0f );

int g_environmentMapType
<
	string UIName = "  + type (0:Cube/1:Spherical)";
	int UIMin = 0;
	int UIMax = 1;
	int UIStep = 1;
> = 0;

bool g_enablesFresnelTerm
<
	string UIName = "  + use fresnel";
> = false;

float g_fresnelR0
<
	string UIName = "    + front face coefficient";
	float UIMin = 0.0f;
	float UIMax = 1.0f;
	float UIStep = 0.01f;
> = 0.2f;

float g_fresnelR1
<
	string UIName = "    + side face coefficient";
	float UIMin = 0.0f;
	float UIMax = 10.0f;
	float UIStep = 0.01f;
> = 0.8f;

// �p�����b�N�X�}�b�v
bool g_enablesParallaxMap
<
	string UIName = "* PARALLAX MAP";
> = false;

int g_parallaxMapSource
<
	string UIName = "  + source (0:BaseTex/1:UtilTex/2:NormalTex)";
	int UIMin = 0;
	int UIMax = 2;
	int UIStep = 1;
> = 0;

float g_parallaxMapBiglandsEngine
<
	string UIName = "  + BiglandsEngine";
> = 0.03f;


// �֊s�̃J���[
float4 g_edgeColor
<
	string UIName = "* Edge color";
> = float4( 0.0f, 0.0f, 0.0f, 1.0f );

// �֊s�̕�
float g_edgeSize
<
	string UIName = "  + edge size(1/1000)";
> = 4.0f;

// �t�H�O�̉e��
bool g_enablesFog
<
	string UIName = "* FOG";
> = true;

// ����(���O���[�o��)
float3 g_ambientLightColor
<
	string UIName = "* AMBIENT LIGHT COLOR";
> = float3(0.3, 0.3, 0.3);

// �t�H�O(���O���[�o��)
// �E���
// �E�t�H�O�J���[
// �E���j�A�t�H�O�̊J�n/�I������
// �E�w���t�H�O�̔Z�x�W��
int g_fogDensityType
<
	string UIName = "* FOG DENSITY(0:non/ 1:linear/ 2:exp/ 3:exp2)";
	int UIMin = 0;
	int UIMax = 3;
	int UIStep = 1;
> = 0;

float4 g_fogColor
<
	string UIName = "  + color";
> = float4( 0.80f, 0.80f, 0.80f, 1.0f );

float g_fogStart
<
	string UIName = "  + start distance(only linear fog)";
	int UIMin = 0.0;
	int UIMax = 1000000.0;
	float UIStep = 1.0;
> = 1.0;

float g_fogEnd
<
	string UIName = "  + end distance(only linear fog)";
	int UIMin = 0.0;
	int UIMax = 1000000.0;
	float UIStep = 1.0;
> = 100.0;

float g_fogDensity
<
	string UIName = "  + density(only exp and exp2 fog)";
	int UIMin = 0.0;
	int UIMax = 100.0;
	float UIStep = 0.01;
> = 1.0;

//----------------------------------------------------------------------------

// ���_�J���[�𒸓_�V�F�[�_�ɓ��͂������ꍇ�ɂ́ATEXCOORD�Ɋ��蓖�Ă�B
int texcoord3 : Texcoord
<
	int Texcoord = 3;		// ���_�J���[���󂯎��TEXCOORD�ԍ�
	int MapChannel = 0;		// ���_�J���[���w��MAX�ł̃}�b�v�`�����l���ԍ�
>;

struct VSOutput
{
	float4 vtPosition			: POSITION;
   	float3 vtViewDirection		: TEXCOORD0;
   	float2 uv0					: TEXCOORD1;
   	float2 uv1					: TEXCOORD2;
   	float2 uv2					: TEXCOORD3;
   	
   	float3 Nv					: TEXCOORD4;
   	float3 Ns					: TEXCOORD5;
   	float3 Nt					: TEXCOORD6;

	float4 color				: TEXCOORD7;
	
	float fogDistance			: FOG;
};

struct PSInput
{
   	float3 vtViewDirection		: TEXCOORD0;
   	float2 uv0					: TEXCOORD1;
   	float2 uv1					: TEXCOORD2;
   	float2 uv2					: TEXCOORD3;

   	float3 Nv					: TEXCOORD4;
   	float3 Ns					: TEXCOORD5;
   	float3 Nt					: TEXCOORD6;

	float4 color				: TEXCOORD7;

	float fogDistance			: FOG;
};

VSOutput VS(
	float3 iPosition	: POSITION,
	float3 iNormal		: NORMAL,
	float2 iTexCoord0	: TEXCOORD0,
	float2 iTexCoord1	: TEXCOORD1,
	float2 iTexCoord2	: TEXCOORD2,

	float3 iColor		: TEXCOORD3,

	float3 iTangent		: TANGENT,
	float3 iBinormal	: BINORMAL)
{
	VSOutput o;

	// ���X�^���C�Y�ׂ̈ɒ��_�̓������W���o�́B
	o.vtPosition = mul(float4(iPosition,1), g_mtxWorldViewProj);

	// View���W�n�ł̃s�N�Z�����王�_�ւ̃x�N�g�����v�Z�B
	// PerPixelLighting�ɂ����ĎQ�Ƃ����B
	if(g_mtxProjection[3][3] == 0.0f)
	{
		// �����ϊ��̏ꍇ�B���ʁB
		o.vtViewDirection = -1.0f * mul(float4(iPosition,1), g_mtxWorldView).xyz;
	}
	else
	{
		// ���ˉe�s��̏ꍇ�A�s�N�Z���̈ʒu�ɂ�����炸���������͕��s�ɂȂ�B
		o.vtViewDirection = float3(0,0,-1);
	}

	if(g_enablesNormalMap || g_parallaxMapBiglandsEngine)
	{
		float3 tmpNs;
		float3 tmpNt;
		float3 tmpNv;
		if(g_enablesNormalMap && (g_normalMapType == 0))
		{
			// ���f���̃��[�J�����W�n�ł̖@���}�b�v
			// �@���}�b�v�̊��x�N�g���p�ɁA���f�����W�n�̊��x�N�g����
			// �r���[���W�n�֕ϊ����ďo�́B
			tmpNs = g_vtBaseAxis[g_normalMapAxisR];
			tmpNt = g_vtBaseAxis[g_normalMapAxisG];
			tmpNv = cross(tmpNs, tmpNt);
			if(dot(g_vtBaseAxis[g_normalMapAxisB], tmpNv) < 0)
			{
				tmpNv *= -1.0f;
			}
		}
		else
		{
			// �e�N�X�`���̐ڐ���Ԃł̖@���}�b�v
			// MAX�̃v���r���[�Ŏg�p�����Tangent��Binormal�͋t�ɂȂ��Ă���I�H
			// r -> binormal
			// g -> tangent
			tmpNs = g_swapTangentAndBinormal? iTangent: iBinormal;
			tmpNt = g_swapTangentAndBinormal? iBinormal: iTangent;
			tmpNv = cross(iTangent, iBinormal);
			if(dot(iNormal, tmpNv) < 0)
			{
				tmpNv *= -1.0f;
			}
			tmpNs *= g_flipTangent? -1.0f: 1.0f;
			tmpNt *= g_flipBinormal? -1.0f: 1.0f;
		}
		o.Ns = mul(tmpNs, (float3x3)g_mtxWorldView);
		o.Nt = mul(tmpNt, (float3x3)g_mtxWorldView);
		o.Nv = mul(tmpNv, (float3x3)g_mtxWorldView);
	}
	else
	{
		// View���W�n�ł̖@���x�N�g�����o�́B
		o.Nv = mul(iNormal, (float3x3)g_mtxWorldView);
		// �@���}�b�v�p�̊��x�N�g���͏o�͂��Ȃ��B
		o.Ns = float3(0, 0, 0);
		o.Nt = float3(0, 0, 0);
	}

	// �e�N�X�`����UV�A�h���X�����̂܂܏o�́B
	// (MAX��)MapChannel��TexCoord�Ƃ̊����́AMAX��DirectX9Shader��
	// �}�b�s���O����������B
	o.uv0 = iTexCoord0;
	o.uv1 = iTexCoord1;
	o.uv2 = iTexCoord2;

	// �J���[�����̂܂܏o��
	o.color = float4(iColor, 1);

	// �t�H�O�̋������o��
	// ���`�t�H�O�ł́A�J�n��������I�������̊Ԃł̐��K�����ς܂��Ă����B
	if(g_fogDensityType == 1)
	{
		o.fogDistance = (g_fogEnd - o.vtPosition.w) / (g_fogEnd - g_fogStart);
	}
	else
	{
		o.fogDistance = o.vtPosition.w;
	}

	return o;
}

float4 PS(
	PSInput i,
	uniform bool enablesBaseTexture,
	uniform bool enablesUtilTexture,
	uniform bool enablesEnvironmentMap
	) : COLOR0
{
	// �����̕�����View���W�n�֕ϊ��B
	float3 vtLightDir = mul(float4(g_vtLightDir,0), g_mtxView);
	// �s�N�Z�����王�_�֌����������̒P�ʃx�N�g�����v�Z�B
	float3 vtEye = normalize(i.vtViewDirection);

	// �p�����b�N�X�}�b�v�ɂ��e�N�X�`���A�h���X�̃I�t�Z�b�g���v�Z
	float2 uvBiglandsEngine = 0;
	if(g_enablesParallaxMap)
	{
		float height;
		if(g_parallaxMapSource == 0)
		{
			height = tex2D(g_texsmpBaseColor, i.uv0).a;
		}
		else if(g_parallaxMapSource == 1)
		{
			height = tex2D(g_texsmpUtilColor, i.uv1).a;
		}
		else
		{
			height = tex2D(g_texsmpNormalMap, i.uv2).a;
		}
		uvBiglandsEngine =
			(1.0f - height) * -g_parallaxMapBiglandsEngine
		  * float2(dot(i.Ns, vtEye), dot(i.Nt, vtEye));
	}

	// �@���x�N�g��������
	float3 vtNormal;
	if(!g_enablesNormalMap)
	{
		// ���_�V�F�[�_����o�͂��ꂽ�@���x�N�g�����g���B
		vtNormal = i.Nv;
	}
	else
	{
		// �@���}�b�v����x�N�g����ǂݎ��B
		float3 n = tex2D(g_texsmpNormalMap, i.uv2+uvBiglandsEngine).xyz;
		n = 2.0f * (n - 0.5f);
		vtNormal = (n.x * i.Ns) + (n.y * i.Nt) + (n.z * i.Nv);
	}
	// �@���x�N�g���𐳋K���B
	vtNormal = normalize(vtNormal);

	// �x�[�X�e�N�X�`�����t�F�b�`
	float4 textureColor[2];
	textureColor[0] = enablesBaseTexture? tex2D(g_texsmpBaseColor, i.uv0+uvBiglandsEngine): float4(1,1,1,1);
	textureColor[1] = enablesUtilTexture? tex2D(g_texsmpUtilColor, i.uv1+uvBiglandsEngine): float4(1,1,1,1);

	// �|���S���̃x�[�X�J���[������
	float4 colorMaterial =
		// �}�e���A���J���[
		(step(g_diffuseColorSelect, 0) * step(0, g_diffuseColorSelect) * g_diffuseColor)
		// ���_�J���[
	  + (step(g_diffuseColorSelect, 1) * step(1, g_diffuseColorSelect) * i.color)
		// �}�e���A���ƒ��_�J���[�̐�
	  + (step(2, g_diffuseColorSelect) * g_diffuseColor * i.color);

	// �}�e���A���̃x�[�X�J���[�ɑ΂��郉�C�e�B���O���ʂ̋P�x
	float4 lumDiffuse = { 0, 0, 0, 1 };
	float3 lumSpecular = { 0, 0, 0 };
	float3 lumRimSpecular = { 0, 0, 0 };

	// ���C�e�B���O
	if(g_enablesLighting != 0)
	{
		// ���F�̃}�e���A���ɑ΂��Ă̊g�U���˂��v�Z�B
		float d = max(0, dot(vtNormal, vtLightDir));
		lumDiffuse.rgb += d * g_colorLight.rgb;

		// ���������Z
		lumDiffuse.rgb += g_ambientLightColor;

		// ���F�̃}�e���A���ɑ΂��ẴX�y�L�����[���v�Z�B
		if(g_enablesSpecular)
		{
			float3 vtHalf = normalize(vtLightDir + vtEye);
			float s = max(0, dot(vtNormal, vtHalf));
			s = pow(s, g_SpecularPower);
			lumSpecular = s * g_colorLight.rgb;
		}

		// ���F�̃}�e���A���ɑ΂��Ẵ����X�y�L�����[���v�Z�B
		if(g_enablesRimSpecular)
		{
			float fr = pow((1.0f - dot(vtNormal, vtEye)), g_rimSpecularPower);
			float lumi = saturate(dot(vtNormal, vtLightDir) + g_rimSpecularSelfLuminous);
			lumRimSpecular = (fr * lumi) * g_colorLight.rgb;
		}

		// �g�U���˂̌�����K�p�B
		lumDiffuse.rgb *= g_diffuseAttenuation;
		// ���Ȕ����̋P�x�����Z�B
		lumDiffuse.rgb += g_emissionColor;

		// �}�e���A���J���[�Ɋg�U���˂̃V�F�[�f�B���O��K�p�B
		colorMaterial *= lumDiffuse;
	}
	else
	{
		lumDiffuse = float4(1,1,1,1);
		lumSpecular = float3(0,0,0);
	}

	// �e�N�X�`���J���[/�A���t�@��K�p
	// �s�N�Z���̍ŏI�J���[��������ϐ��B
	float4 pixelColor = colorMaterial;
	if(enablesBaseTexture)
	{
		// �x�[�X�J���[�e�N�X�`���̍���
		pixelColor =
			// ModulateRGBA
			(step(g_blendBaseColorTexture,0) * step(0,g_blendBaseColorTexture) *
				pixelColor * textureColor[0])
			// ModulateRGB
		  + (step(g_blendBaseColorTexture,1) * step(1,g_blendBaseColorTexture) *
				float4((pixelColor * textureColor[0]).rgb, pixelColor.a))
			// AddRGB
		  + (step(g_blendBaseColorTexture,2) * step(2,g_blendBaseColorTexture) *
				float4((pixelColor + textureColor[0]).rgb, pixelColor.a))
			// DecalRGBA_Ma 
		  + (step(g_blendBaseColorTexture,3) * step(3,g_blendBaseColorTexture) *
				float4(lerp(pixelColor, textureColor[0], pixelColor.a).rgb,
					   lerp(1, textureColor[0].a, pixelColor.a)))
			// DecalRGB_Ta 
		  + (step(g_blendBaseColorTexture,4) * step(4,g_blendBaseColorTexture) *
				float4(lerp(pixelColor, textureColor[0], textureColor[0].a).rgb,
					   pixelColor.a))
			// ModulateDecalRGBA_Ma 
		  + (step(g_blendBaseColorTexture,5) * step(5,g_blendBaseColorTexture) *
				float4(pixelColor * lerp(float4(1,1,1,1), textureColor[0], pixelColor.a).rgb,
					   lerp(1, textureColor[0].a, pixelColor.a)))
			// ModulateDecalRGB_Ta 
		  + (step(g_blendBaseColorTexture,6) * step(6,g_blendBaseColorTexture) *
				float4(pixelColor * lerp(float4(1,1,1,1), textureColor[0], textureColor[0].a).rgb,
					   pixelColor.a));
	}
	if(enablesUtilTexture)
	{
		// �⏕�J���[�e�N�X�`���̍���
		pixelColor =
			// ModulateRGBA
			(step(g_blendUtilColorTexture,0) * step(0,g_blendUtilColorTexture) *
				(pixelColor * textureColor[1]))
			// ModulateRGB
		  + (step(g_blendUtilColorTexture,1) * step(1,g_blendUtilColorTexture) *
				float4((pixelColor * textureColor[1]).rgb, pixelColor.a))
		  // AddRGB
		  + (step(g_blendUtilColorTexture,2) * step(2,g_blendUtilColorTexture) *
				float4((pixelColor + textureColor[1]).rgb, pixelColor.a))
		  // DecalRGB_Ma
		  + (step(g_blendUtilColorTexture,3) * step(3,g_blendUtilColorTexture) *
				float4(lerp((colorMaterial*textureColor[0]), textureColor[1], colorMaterial.a).rgb,
					   1.0))
		  // DecalRGBA_Ma
		  + (step(g_blendUtilColorTexture,4) * step(4,g_blendUtilColorTexture) *
				float4(lerp((colorMaterial*textureColor[0]), textureColor[1], colorMaterial.a).rgb,
					   lerp(textureColor[0].a, textureColor[1].a, colorMaterial.a)))
		  // DecalRGBA_Ta
		  + (step(g_blendUtilColorTexture,5) * step(5,g_blendUtilColorTexture) *
				float4(lerp((colorMaterial*textureColor[0]), textureColor[1], colorMaterial.a).rgb,
					   lerp(colorMaterial.a*textureColor[0].a, colorMaterial.a, textureColor[1].a)))
		  // ModulateDecalRGB_Ma
		  + (step(g_blendUtilColorTexture,6) * step(6,g_blendUtilColorTexture) *
				float4((colorMaterial * lerp(textureColor[0], textureColor[1], colorMaterial.a)).rgb,
					   1.0))
		  // ModulateDecalRGBA_Ma
		  + (step(g_blendUtilColorTexture,7) * step(7,g_blendUtilColorTexture) *
				float4((colorMaterial * lerp(textureColor[0], textureColor[1], colorMaterial.a)).rgb,
					   lerp(textureColor[0].a, textureColor[1].a, colorMaterial.a)))
		  // ModulateDecalRGBA_Ta
		  + (step(g_blendUtilColorTexture,8) * step(8,g_blendUtilColorTexture) *
				float4((colorMaterial * lerp(textureColor[0], textureColor[1], textureColor[1].a)).rgb,
					   colorMaterial.a * lerp(textureColor[0].a, 1.0, textureColor[1].a)));
	}

	// �O���X�}�b�v�l����
	float glossMap;
	if(!g_enablesGlossMap)
	{
		// ����
		glossMap = 1.0f;
	}
	else
	{
		glossMap = 
			// �x�[�X�J���[�e�N�X�`���̃A���t�@
			(step(g_indexGlossSrc,0) * step(0,g_indexGlossSrc) * textureColor[0].a)
			// �⏕�J���[�e�N�X�`���̃A���t�@
		  + (step(g_indexGlossSrc,1) * step(1,g_indexGlossSrc) * textureColor[1].a)
			// �t���O�����g�̃A���t�@
		  + (step(2,g_indexGlossSrc) * pixelColor.a);
	}

	// �X�y�L�����[�J���[������
	if(g_enablesSpecular)
	{
		float3 colorSpecular = 
			// �}�e���A���J���[
			(step(g_specularColorSelector,0) * step(0,g_specularColorSelector) * g_colorSpecular)
			// ���_�J���[
		  + (step(g_specularColorSelector,1) * step(1,g_specularColorSelector) * i.color.rgb)
			// �}�e���A���ƒ��_�J���[�̐�
		  + (step(g_specularColorSelector,2) * step(2,g_specularColorSelector) * g_colorSpecular * i.color.rgb)
			// �t���O�����g�̃J���[�B
		  + (step(3,g_specularColorSelector) * g_colorSpecular * pixelColor.rgb);

		// �X�y�L�����[���̂���B
		pixelColor.rgb += glossMap * lumSpecular * colorSpecular;
	}

	// �����X�y�L�����[���̂���B
	if(g_enablesRimSpecular)
	{
		float3 colorRimSpecular = 
			// �}�e���A���J���[
			(step(g_specularColorSelector,0) * step(0,g_specularColorSelector) * g_colorRimSpecular)
			// ���_�J���[
		  + (step(g_specularColorSelector,1) * step(1,g_specularColorSelector) * i.color.rgb)
			// �}�e���A���ƒ��_�J���[�̐�
		  + (step(g_specularColorSelector,2) * step(2,g_specularColorSelector) * g_colorRimSpecular * i.color.rgb)
			// �t���O�����g�̃J���[�B
		  + (step(3,g_specularColorSelector) * g_colorRimSpecular * pixelColor.rgb);

		pixelColor.rgb += glossMap * lumRimSpecular * colorRimSpecular;
	}

	// ���}�b�v���̂���
	if(enablesEnvironmentMap)
	{
		float3 colEnvironmentMap;

		half3 rv = normalize(half3(reflect(vtEye, vtNormal)));

		if(g_environmentMapType == 0)
		{
			// ���[���h���W�n�ł̃L���[�u���}�b�v���s���B
			rv = mul(half4(rv,0), g_imtxView);

			// MAX��Direct3D�̍��W�n�̈Ⴂ���C���B
			rv = half3(-1,-1,-1) * rv.xzy;

			colEnvironmentMap =
				g_colorEnvironmentMapModulate
			  * texCUBE(g_texsmpCubeEnvironmentMap, rv).rgb;
		}
		else
		{
			// �r���[���W�n�ł̋�����}�b�v���s��
			half3 r = rv;
			r.z += 1.0;
			r = r * r;
			half m = rsqrt(r.x + r.y + r.z);
			half2 uv = 0.5 * (rv.xy * m + half2(1.0, 1.0));

			colEnvironmentMap =
				g_colorEnvironmentMapModulate
			  * tex2D(g_texsmpSphericalEnvironmentMap, uv).rgb;
		}

		if(g_enablesFresnelTerm)
		{
			// �t���l�����ɂ���Ċ��}�b�v�̋����𒲐�����B
			float f = pow(1.0f - dot(vtEye, vtNormal), 4.0f);
			f = g_fresnelR0 + g_fresnelR1 * f;
			f *= glossMap;
			pixelColor.rgb = lerp(pixelColor.rgb, colEnvironmentMap.rgb, f);
		}
		else
		{
			// ���̂܂܃s�N�Z���̐F�։��Z����B
			pixelColor.rgb += glossMap * colEnvironmentMap.rgb;
		}
	}

	// �t�H�O�Ƃ̍���
	//  �t�H�O�X�C�b�`��OFF�Ȃ�΃t�H�O�𖳌��ɂ���B
	int fogType = (g_enablesFog? 1: 0) * g_fogDensityType;
	if(fogType == 0)
	{
		// �t�H�O����
	}
	else if(fogType == 1)
	{
		// ���`�t�H�O
		pixelColor.rgb = lerp(
			g_fogColor.rgb,
			pixelColor.rgb,
			clamp(i.fogDistance, 0, 1));
	}
	else if(fogType == 2)
	{
		// �w���t�H�O
		float d = ((g_fogDensity * 0.001) * i.fogDistance);
		pixelColor.rgb = lerp(
			g_fogColor.rgb,
			pixelColor.rgb,
			exp(-d));
	}
	else if(fogType == 3)
	{
		// �w���t�H�O2
		float d = ((g_fogDensity * 0.001) * i.fogDistance);
		pixelColor.rgb = lerp(
			g_fogColor.rgb,
			pixelColor.rgb,
			exp(-d*d));
	}

	// �f�o�b�O�ړI�ŁA�@���������J���[�ŏo�́B
	if(g_debugShowNormalDir)
	{
		pixelColor.rgb = float3(vtNormal);
	}

	return pixelColor;
}

//----------------------------------------------------------------------------

//----------------------------------------------------------------------------
struct ExpandMeshVSOutput
{
	float4 vtPosition			: POSITION;
};

ExpandMeshVSOutput ExpandMeshVS(
	float4 iPosition	: POSITION,
	float3 iNormal		: NORMAL)
{
	ExpandMeshVSOutput o;

	// ���X�^���C�Y�ׂ̈ɒ��_�̓������W���o�́B
	o.vtPosition = mul(iPosition, g_mtxWorldViewProj);

	// �X�N���[�����W��Ŗ@�������ɒ��_���g�傷��B
	float2 expand = mul(float4(iNormal,0.0), g_mtxWorldViewProj).xy;
	if(0.000000000001 < dot(expand, expand))
	{
		expand = normalize(expand);
	}
	o.vtPosition.xy += (0.001 * g_edgeSize * o.vtPosition.w) * expand;

	return o;
}

float4 ExpandMeshPS(ExpandMeshVSOutput i) : COLOR0
{
	return g_edgeColor;
}

//----------------------------------------------------------------------------

technique OPACITY
{
    pass P0 
    {		
		VertexShader	= compile vs_3_0 VS();

		PixelShader		= compile ps_3_0 PS(
			g_enablesBaseColorTex,
			g_enablesUtilColorTex,
			g_enablesEnvironmentMap);
		
		ZWriteEnable		= True;
		ZFunc				= LessEqual;

		AlphaBlendEnable	= False;
		AlphaTestEnable		= False;
		
		Wrap0				= COORD0;
    }
}

technique ALPHATEST
{
    pass P0 
    {		
		VertexShader	= compile vs_3_0 VS();

		PixelShader		= compile ps_3_0 PS(
			g_enablesBaseColorTex,
			g_enablesUtilColorTex,
			g_enablesEnvironmentMap);
		
		ZWriteEnable		= True;
		ZFunc				= LessEqual;

		AlphaBlendEnable	= False;
		AlphaTestEnable		= True;
		AlphaRef			= 80;
    }
}

technique BLEND
{
    pass P0 
    {		
		VertexShader	= compile vs_3_0 VS();

		PixelShader		= compile ps_3_0 PS(
			g_enablesBaseColorTex,
			g_enablesUtilColorTex,
			g_enablesEnvironmentMap);
		
		ZWriteEnable		= False;
		ZFunc				= LessEqual;

		AlphaBlendEnable	= True;
        SrcBlend			= SrcAlpha;
        DestBlend			= InvSrcAlpha;  

		AlphaTestEnable		= True;
		AlphaRef			= 1;
    }
}

technique BLEND_2PASS
{
    pass P0 
    {		
		VertexShader	= compile vs_3_0 VS();

		PixelShader		= compile ps_3_0 PS(
			g_enablesBaseColorTex,
			g_enablesUtilColorTex,
			g_enablesEnvironmentMap);
		
		ZWriteEnable		= False;
		ZFunc				= LessEqual;

		AlphaBlendEnable	= True;
        SrcBlend			= SrcAlpha;
        DestBlend			= InvSrcAlpha;  

		AlphaTestEnable		= True;
		AlphaRef			= 1;
    }
}

technique ADD
{
    pass P0 
    {		
		VertexShader	= compile vs_3_0 VS();

		PixelShader		= compile ps_3_0 PS(
			g_enablesBaseColorTex,
			g_enablesUtilColorTex,
			g_enablesEnvironmentMap);
		
		ZWriteEnable		= False;
		ZFunc				= LessEqual;

		AlphaBlendEnable	= True;
        SrcBlend			= SrcAlpha;
        DestBlend			= One;  

		AlphaTestEnable		= True;
		AlphaRef			= 1;
    }
}

technique SUB
{
    pass P0 
    {		
		VertexShader	= compile vs_3_0 VS();

		PixelShader		= compile ps_3_0 PS(
			g_enablesBaseColorTex,
			g_enablesUtilColorTex,
			g_enablesEnvironmentMap);
		
		ZWriteEnable		= False;
		ZFunc				= LessEqual;

		AlphaBlendEnable	= True;
        SrcBlend			= SrcAlpha;
        DestBlend			= One;
        BlendOp				= RevSubtract;

		AlphaTestEnable		= True;
		AlphaRef			= 1;
    }
}

technique MODULATE
{
    pass P0 
    {		
		VertexShader	= compile vs_3_0 VS();

		PixelShader		= compile ps_3_0 PS(
			g_enablesBaseColorTex,
			g_enablesUtilColorTex,
			g_enablesEnvironmentMap);
		
		ZWriteEnable		= False;
		ZFunc				= LessEqual;

		AlphaBlendEnable	= True;
        SrcBlend			= DestColor;
        DestBlend			= Zero;  

		AlphaTestEnable		= True;
		AlphaRef			= 1;
    }
}

technique CUSTOM
{
    pass P0 
    {		
		VertexShader	= compile vs_3_0 VS();

		PixelShader		= compile ps_3_0 PS(
			g_enablesBaseColorTex,
			g_enablesUtilColorTex,
			g_enablesEnvironmentMap);
		
		ZWriteEnable		= False;
		ZFunc				= LessEqual;

		AlphaBlendEnable	= True;
        SrcBlend			= SrcAlpha;
        DestBlend			= InvSrcAlpha;  

		AlphaTestEnable		= True;
		AlphaRef			= 1;
    }
}

technique OPACITY_EDGE
{
    pass P0
    {		
		VertexShader	= compile vs_3_0 ExpandMeshVS();

		PixelShader		= compile ps_3_0 ExpandMeshPS();

		CullMode		= CCW;
		ZWriteEnable	= True;
		ZFunc			= LessEqual;

		AlphaBlendEnable	= False;
		AlphaTestEnable		= False;
    }

    pass P1
    {		
		VertexShader	= compile vs_3_0 VS();

		PixelShader		= compile ps_3_0 PS(
			g_enablesBaseColorTex,
			g_enablesUtilColorTex,
			g_enablesEnvironmentMap);

		CullMode		= CW;
		ZWriteEnable	= True;
		ZFunc			= LessEqual;
		
		AlphaBlendEnable	= False;
		AlphaTestEnable		= False;
    }
}

technique SPECULAR_2PASS
{
    pass P0 
    {		
		VertexShader	= compile vs_3_0 VS();

		PixelShader		= compile ps_3_0 PS(
			g_enablesBaseColorTex,
			g_enablesUtilColorTex,
			g_enablesEnvironmentMap);
		
		ZWriteEnable		= False;
		ZFunc				= LessEqual;

		AlphaBlendEnable	= True;
        SrcBlend			= SrcAlpha;
        DestBlend			= InvSrcAlpha;  

		AlphaTestEnable		= True;
		AlphaRef			= 1;
    }
}
