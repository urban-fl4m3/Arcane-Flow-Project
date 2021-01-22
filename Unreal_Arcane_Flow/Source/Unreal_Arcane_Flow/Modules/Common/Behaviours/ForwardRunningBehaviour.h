// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Unreal_Arcane_Flow/Modules/Behaviours/BaseBehaviour.h"
#include "ForwardRunningBehaviour.generated.h"

UCLASS(Blueprintable, BlueprintType)
class UNREAL_ARCANE_FLOW_API UForwardRunningBehaviour : public UBaseBehaviour
{
	GENERATED_BODY()
	
protected:
	virtual void OnInitialize(AUnit* Unit) override;
};
