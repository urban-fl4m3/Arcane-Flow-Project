// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Unreal_Arcane_Flow/Modules/Units/Unit.h"
#include "BaseBehaviour.generated.h"

UCLASS(Abstract, Blueprintable, BlueprintType)
class UNREAL_ARCANE_FLOW_API UBaseBehaviour : public UActorComponent
{
	GENERATED_BODY()

public:
	void Init(AUnit* Unit);
	
	UBaseBehaviour* GetInstance(AActor &Parent, UBaseBehaviour* SubclassOf);

protected:
	AUnit* Owner;
	
	virtual void OnInitialize(AUnit* Unit) PURE_VIRTUAL(UBaseBehaviour::OnInitialize, );
};
