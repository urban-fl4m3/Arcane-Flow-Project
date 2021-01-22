// Copyright Epic Games, Inc. All Rights Reserved.
/*===========================================================================
	Generated code exported from UnrealHeaderTool.
	DO NOT modify this manually! Edit the corresponding .h files instead!
===========================================================================*/

#include "UObject/GeneratedCppIncludes.h"
#include "Unreal_Arcane_Flow/Modules/Common/Data/RootData.h"
#ifdef _MSC_VER
#pragma warning (push)
#pragma warning (disable : 4883)
#endif
PRAGMA_DISABLE_DEPRECATION_WARNINGS
void EmptyLinkFunctionForGeneratedCodeRootData() {}
// Cross Module References
	UNREAL_ARCANE_FLOW_API UClass* Z_Construct_UClass_URootData_NoRegister();
	UNREAL_ARCANE_FLOW_API UClass* Z_Construct_UClass_URootData();
	UNREAL_ARCANE_FLOW_API UClass* Z_Construct_UClass_UBaseData();
	UPackage* Z_Construct_UPackage__Script_Unreal_Arcane_Flow();
// End Cross Module References
	void URootData::StaticRegisterNativesURootData()
	{
	}
	UClass* Z_Construct_UClass_URootData_NoRegister()
	{
		return URootData::StaticClass();
	}
	struct Z_Construct_UClass_URootData_Statics
	{
		static UObject* (*const DependentSingletons[])();
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam Class_MetaDataParams[];
#endif
		static const FCppClassTypeInfoStatic StaticCppClassTypeInfo;
		static const UE4CodeGen_Private::FClassParams ClassParams;
	};
	UObject* (*const Z_Construct_UClass_URootData_Statics::DependentSingletons[])() = {
		(UObject* (*)())Z_Construct_UClass_UBaseData,
		(UObject* (*)())Z_Construct_UPackage__Script_Unreal_Arcane_Flow,
	};
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_URootData_Statics::Class_MetaDataParams[] = {
		{ "BlueprintType", "true" },
		{ "IncludePath", "Modules/Common/Data/RootData.h" },
		{ "IsBlueprintBase", "true" },
		{ "ModuleRelativePath", "Modules/Common/Data/RootData.h" },
	};
#endif
	const FCppClassTypeInfoStatic Z_Construct_UClass_URootData_Statics::StaticCppClassTypeInfo = {
		TCppClassTypeTraits<URootData>::IsAbstract,
	};
	const UE4CodeGen_Private::FClassParams Z_Construct_UClass_URootData_Statics::ClassParams = {
		&URootData::StaticClass,
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
		0x00B000A4u,
		METADATA_PARAMS(Z_Construct_UClass_URootData_Statics::Class_MetaDataParams, UE_ARRAY_COUNT(Z_Construct_UClass_URootData_Statics::Class_MetaDataParams))
	};
	UClass* Z_Construct_UClass_URootData()
	{
		static UClass* OuterClass = nullptr;
		if (!OuterClass)
		{
			UE4CodeGen_Private::ConstructUClass(OuterClass, Z_Construct_UClass_URootData_Statics::ClassParams);
		}
		return OuterClass;
	}
	IMPLEMENT_CLASS(URootData, 2193278763);
	template<> UNREAL_ARCANE_FLOW_API UClass* StaticClass<URootData>()
	{
		return URootData::StaticClass();
	}
	static FCompiledInDefer Z_CompiledInDefer_UClass_URootData(Z_Construct_UClass_URootData, &URootData::StaticClass, TEXT("/Script/Unreal_Arcane_Flow"), TEXT("URootData"), false, nullptr, nullptr, nullptr);
	DEFINE_VTABLE_PTR_HELPER_CTOR(URootData);
PRAGMA_ENABLE_DEPRECATION_WARNINGS
#ifdef _MSC_VER
#pragma warning (pop)
#endif
