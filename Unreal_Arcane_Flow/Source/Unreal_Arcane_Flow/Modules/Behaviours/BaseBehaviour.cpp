// Fill out your copyright notice in the Description page of Project Settings.

#include "BaseBehaviour.h"

void UBaseBehaviour::Init(AUnit* Unit)
{
	Owner = Unit;
	OnInitialize(Owner);
}

// ReSharper disable once CppMemberFunctionMayBeConst
UBaseBehaviour* UBaseBehaviour::GetInstance(AActor &Parent, UBaseBehaviour* SubclassOf)
{
	UBaseBehaviour* DataInstance = dynamic_cast<decltype(this)>(
        Parent.CreateComponentFromTemplate(
            SubclassOf,
            SubclassOf->GetFName()));

	Parent.AddInstanceComponent(DataInstance);
	DataInstance->RegisterComponent();

	return DataInstance;
}
