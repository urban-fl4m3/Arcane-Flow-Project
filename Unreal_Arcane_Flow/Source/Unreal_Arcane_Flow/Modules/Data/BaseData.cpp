// Fill out your copyright notice in the Description page of Project Settings.

#include "BaseData.h"

void UBaseData::Init(AUnit* Unit)
{
	Owner = Unit;
	OnInitialize(Owner);
}

// ReSharper disable once CppMemberFunctionMayBeConst
UBaseData* UBaseData::GetInstance(AActor &Parent, UBaseData* SubclassOf)
{
	UBaseData* DataInstance = dynamic_cast<decltype(this)>(
		Parent.CreateComponentFromTemplate(
			SubclassOf,
			SubclassOf->GetFName()));

	Parent.AddInstanceComponent(DataInstance);
	DataInstance->RegisterComponent();

	return DataInstance;
}
