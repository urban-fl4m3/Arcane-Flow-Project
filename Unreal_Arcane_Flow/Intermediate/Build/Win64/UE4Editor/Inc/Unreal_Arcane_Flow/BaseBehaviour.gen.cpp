// Copyright Epic Games, Inc. All Rights Reserved.
/*===========================================================================
	Generated code exported from UnrealHeaderTool.
	DO NOT modify this manually! Edit the corresponding .h files instead!
===========================================================================*/

#include "UObject/GeneratedCppIncludes.h"
#include "Unreal_Arcane_Flow/Modules/Behaviours/BaseBehaviour.h"
#ifdef _MSC_VER
#pragma warning (push)
#pragma warning (disable : 4883)
#endif
PRAGMA_DISABLE_DEPRECATION_WARNINGS
void EmptyLinkFunctionForGeneratedCodeBaseBehaviour() {}
// Cross Module References
	UNREAL_ARCANE_FLOW_API UClass* Z_Construct_UClass_UBaseBehaviour_NoRegister();
	UNREAL_ARCANE_FLOW_API UClass* Z_Construct_UClass_UBaseBehaviour();
	ENGINE_API UClass* Z_Construct_UClass_UActorComponent();
	UPackage* Z_Construct_UPackage__Script_Unreal_Arcane_Flow();
// End Cross Module References
	void UBaseBehaviour::StaticRegisterNativesUBaseBehaviour()
	{
	}
	UClass* Z_Construct_UClass_UBaseBehaviour_NoRegister()
	{
		return UBaseBehaviour::StaticClass();
	}
	struct Z_Construct_UClass_UBaseBehaviour_Statics
	{
		static UObject* (*const DependentSingletons[])();
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam Class_MetaDataParams[];
#endif
		static const FCppClassTypeInfoStatic StaticCppClassTypeInfo;
		static const UE4CodeGen_Private::FClassParams ClassParams;
	};
	UObject* (*const Z_Construct_UClass_UBaseBehaviour_Statics::DependentSingletons[])() = {
		(UObject* (*)())Z_Construct_UClass_UActorComponent,
		(UObject* (*)())Z_Construct_UPackage__Script_Unreal_Arcane_Flow,
	};
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_UBaseBehaviour_Statics::Class_MetaDataParams[] = {
		{ "BlueprintType", "true" },
		{ "IncludePath", "Modules/Behaviours/BaseBehaviour.h" },
		{ "IsBlueprintBase", "true" },
		{ "ModuleRelativePath", "Modules/Behaviours/BaseBehaviour.h" },
	};
#endif
	const FCppClassTypeInfoStatic Z_Construct_UClass_UBaseBehaviour_Statics::StaticCppClassTypeInfo = {
		TCppClassTypeTraits<UBaseBehaviour>::IsAbstract,
	};
	const UE4CodeGen_Private::FClassParams Z_Construct_UClass_UBaseBehaviour_Statics::ClassParams = {
		&UBaseBehaviour::StaticClass,
		"Engine",
		&StaticCppClassTypeInfo,
		DependentSingletons,
		nullptr,
		nullptr,
		nullptr,
		UE_ARRAY_COUNT(DependentSingletons),
		0,
		0,
		0,
		0x00B000A5u,
		METADATA_PARAMS(Z_Construct_UClass_UBaseBehaviour_Statics::Class_MetaDataParams, UE_ARRAY_COUNT(Z_Construct_UClass_UBaseBehaviour_Statics::Class_MetaDataParams))
	};
	UClass* Z_Construct_UClass_UBaseBehaviour()
	{
		static UClass* OuterClass = nullptr;
		if (!OuterClass)
		{
			UE4CodeGen_Private::ConstructUClass(OuterClass, Z_Construct_UClass_UBaseBehaviour_Statics::ClassParams);
		}
		return OuterClass;
	}
	IMPLEMENT_CLASS(UBaseBehaviour, 2370444350);
	template<> UNREAL_ARCANE_FLOW_API UClass* StaticClass<UBaseBehaviour>()
	{
		return UBaseBehaviour::StaticClass();
	}
	static FCompiledInDefer Z_CompiledInDefer_UClass_UBaseBehaviour(Z_Construct_UClass_UBaseBehaviour, &UBaseBehaviour::StaticClass, TEXT("/Script/Unreal_Arcane_Flow"), TEXT("UBaseBehaviour"), false, nullptr, nullptr, nullptr);
	DEFINE_VTABLE_PTR_HELPER_CTOR(UBaseBehaviour);
PRAGMA_ENABLE_DEPRECATION_WARNINGS
#ifdef _MSC_VER
#pragma warning (pop)
#endif
