// Copyright Epic Games, Inc. All Rights Reserved.
/*===========================================================================
	Generated code exported from UnrealHeaderTool.
	DO NOT modify this manually! Edit the corresponding .h files instead!
===========================================================================*/

#include "UObject/GeneratedCppIncludes.h"
#include "Unreal_Arcane_Flow/Unreal_Arcane_FlowGameModeBase.h"
#ifdef _MSC_VER
#pragma warning (push)
#pragma warning (disable : 4883)
#endif
PRAGMA_DISABLE_DEPRECATION_WARNINGS
void EmptyLinkFunctionForGeneratedCodeUnreal_Arcane_FlowGameModeBase() {}
// Cross Module References
	UNREAL_ARCANE_FLOW_API UClass* Z_Construct_UClass_AUnreal_Arcane_FlowGameModeBase_NoRegister();
	UNREAL_ARCANE_FLOW_API UClass* Z_Construct_UClass_AUnreal_Arcane_FlowGameModeBase();
	ENGINE_API UClass* Z_Construct_UClass_AGameModeBase();
	UPackage* Z_Construct_UPackage__Script_Unreal_Arcane_Flow();
// End Cross Module References
	void AUnreal_Arcane_FlowGameModeBase::StaticRegisterNativesAUnreal_Arcane_FlowGameModeBase()
	{
	}
	UClass* Z_Construct_UClass_AUnreal_Arcane_FlowGameModeBase_NoRegister()
	{
		return AUnreal_Arcane_FlowGameModeBase::StaticClass();
	}
	struct Z_Construct_UClass_AUnreal_Arcane_FlowGameModeBase_Statics
	{
		static UObject* (*const DependentSingletons[])();
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam Class_MetaDataParams[];
#endif
		static const FCppClassTypeInfoStatic StaticCppClassTypeInfo;
		static const UE4CodeGen_Private::FClassParams ClassParams;
	};
	UObject* (*const Z_Construct_UClass_AUnreal_Arcane_FlowGameModeBase_Statics::DependentSingletons[])() = {
		(UObject* (*)())Z_Construct_UClass_AGameModeBase,
		(UObject* (*)())Z_Construct_UPackage__Script_Unreal_Arcane_Flow,
	};
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AUnreal_Arcane_FlowGameModeBase_Statics::Class_MetaDataParams[] = {
		{ "Comment", "/**\n * \n */" },
		{ "HideCategories", "Info Rendering MovementReplication Replication Actor Input Movement Collision Rendering Utilities|Transformation" },
		{ "IncludePath", "Unreal_Arcane_FlowGameModeBase.h" },
		{ "ModuleRelativePath", "Unreal_Arcane_FlowGameModeBase.h" },
		{ "ShowCategories", "Input|MouseInput Input|TouchInput" },
	};
#endif
	const FCppClassTypeInfoStatic Z_Construct_UClass_AUnreal_Arcane_FlowGameModeBase_Statics::StaticCppClassTypeInfo = {
		TCppClassTypeTraits<AUnreal_Arcane_FlowGameModeBase>::IsAbstract,
	};
	const UE4CodeGen_Private::FClassParams Z_Construct_UClass_AUnreal_Arcane_FlowGameModeBase_Statics::ClassParams = {
		&AUnreal_Arcane_FlowGameModeBase::StaticClass,
		"Game",
		&StaticCppClassTypeInfo,
		DependentSingletons,
		nullptr,
		nullptr,
		nullptr,
		UE_ARRAY_COUNT(DependentSingletons),
		0,
		0,
		0,
		0x009002ACu,
		METADATA_PARAMS(Z_Construct_UClass_AUnreal_Arcane_FlowGameModeBase_Statics::Class_MetaDataParams, UE_ARRAY_COUNT(Z_Construct_UClass_AUnreal_Arcane_FlowGameModeBase_Statics::Class_MetaDataParams))
	};
	UClass* Z_Construct_UClass_AUnreal_Arcane_FlowGameModeBase()
	{
		static UClass* OuterClass = nullptr;
		if (!OuterClass)
		{
			UE4CodeGen_Private::ConstructUClass(OuterClass, Z_Construct_UClass_AUnreal_Arcane_FlowGameModeBase_Statics::ClassParams);
		}
		return OuterClass;
	}
	IMPLEMENT_CLASS(AUnreal_Arcane_FlowGameModeBase, 180205673);
	template<> UNREAL_ARCANE_FLOW_API UClass* StaticClass<AUnreal_Arcane_FlowGameModeBase>()
	{
		return AUnreal_Arcane_FlowGameModeBase::StaticClass();
	}
	static FCompiledInDefer Z_CompiledInDefer_UClass_AUnreal_Arcane_FlowGameModeBase(Z_Construct_UClass_AUnreal_Arcane_FlowGameModeBase, &AUnreal_Arcane_FlowGameModeBase::StaticClass, TEXT("/Script/Unreal_Arcane_Flow"), TEXT("AUnreal_Arcane_FlowGameModeBase"), false, nullptr, nullptr, nullptr);
	DEFINE_VTABLE_PTR_HELPER_CTOR(AUnreal_Arcane_FlowGameModeBase);
PRAGMA_ENABLE_DEPRECATION_WARNINGS
#ifdef _MSC_VER
#pragma warning (pop)
#endif
