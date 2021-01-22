// Copyright Epic Games, Inc. All Rights Reserved.
/*===========================================================================
	Generated code exported from UnrealHeaderTool.
	DO NOT modify this manually! Edit the corresponding .h files instead!
===========================================================================*/

#include "UObject/GeneratedCppIncludes.h"
#include "Unreal_Arcane_Flow/Modules/Data/BaseData.h"
#ifdef _MSC_VER
#pragma warning (push)
#pragma warning (disable : 4883)
#endif
PRAGMA_DISABLE_DEPRECATION_WARNINGS
void EmptyLinkFunctionForGeneratedCodeBaseData() {}
// Cross Module References
	UNREAL_ARCANE_FLOW_API UClass* Z_Construct_UClass_UBaseData_NoRegister();
	UNREAL_ARCANE_FLOW_API UClass* Z_Construct_UClass_UBaseData();
	ENGINE_API UClass* Z_Construct_UClass_UActorComponent();
	UPackage* Z_Construct_UPackage__Script_Unreal_Arcane_Flow();
// End Cross Module References
	void UBaseData::StaticRegisterNativesUBaseData()
	{
	}
	UClass* Z_Construct_UClass_UBaseData_NoRegister()
	{
		return UBaseData::StaticClass();
	}
	struct Z_Construct_UClass_UBaseData_Statics
	{
		static UObject* (*const DependentSingletons[])();
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam Class_MetaDataParams[];
#endif
		static const FCppClassTypeInfoStatic StaticCppClassTypeInfo;
		static const UE4CodeGen_Private::FClassParams ClassParams;
	};
	UObject* (*const Z_Construct_UClass_UBaseData_Statics::DependentSingletons[])() = {
		(UObject* (*)())Z_Construct_UClass_UActorComponent,
		(UObject* (*)())Z_Construct_UPackage__Script_Unreal_Arcane_Flow,
	};
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_UBaseData_Statics::Class_MetaDataParams[] = {
		{ "BlueprintType", "true" },
		{ "IncludePath", "Modules/Data/BaseData.h" },
		{ "IsBlueprintBase", "true" },
		{ "ModuleRelativePath", "Modules/Data/BaseData.h" },
	};
#endif
	const FCppClassTypeInfoStatic Z_Construct_UClass_UBaseData_Statics::StaticCppClassTypeInfo = {
		TCppClassTypeTraits<UBaseData>::IsAbstract,
	};
	const UE4CodeGen_Private::FClassParams Z_Construct_UClass_UBaseData_Statics::ClassParams = {
		&UBaseData::StaticClass,
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
		METADATA_PARAMS(Z_Construct_UClass_UBaseData_Statics::Class_MetaDataParams, UE_ARRAY_COUNT(Z_Construct_UClass_UBaseData_Statics::Class_MetaDataParams))
	};
	UClass* Z_Construct_UClass_UBaseData()
	{
		static UClass* OuterClass = nullptr;
		if (!OuterClass)
		{
			UE4CodeGen_Private::ConstructUClass(OuterClass, Z_Construct_UClass_UBaseData_Statics::ClassParams);
		}
		return OuterClass;
	}
	IMPLEMENT_CLASS(UBaseData, 2438341547);
	template<> UNREAL_ARCANE_FLOW_API UClass* StaticClass<UBaseData>()
	{
		return UBaseData::StaticClass();
	}
	static FCompiledInDefer Z_CompiledInDefer_UClass_UBaseData(Z_Construct_UClass_UBaseData, &UBaseData::StaticClass, TEXT("/Script/Unreal_Arcane_Flow"), TEXT("UBaseData"), false, nullptr, nullptr, nullptr);
	DEFINE_VTABLE_PTR_HELPER_CTOR(UBaseData);
PRAGMA_ENABLE_DEPRECATION_WARNINGS
#ifdef _MSC_VER
#pragma warning (pop)
#endif
