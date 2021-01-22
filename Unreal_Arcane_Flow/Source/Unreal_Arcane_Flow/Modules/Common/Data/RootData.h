// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Unreal_Arcane_Flow/Modules/Data/BaseData.h"
#include "RootData.generated.h"

UCLASS(Blueprintable, BlueprintType)
class UNREAL_ARCANE_FLOW_API URootData: public UBaseData
{
	GENERATED_BODY()

protected:
	virtual void OnInitialize(AUnit* Unit) override;
};
