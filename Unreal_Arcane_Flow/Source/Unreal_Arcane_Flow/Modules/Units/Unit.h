// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "Unit.generated.h"

class UBaseBehaviour;
class UBaseData;

UCLASS()
class UNREAL_ARCANE_FLOW_API AUnit : public AActor
{
	GENERATED_BODY()
	
public:	
	AUnit();
	
	template<typename T>
    T* GetMember();
	
	template<typename T>
    void RemoveMember() const;

protected:
	virtual void BeginPlay() override;

private:
	UPROPERTY(EditAnywhere)
	TArray<TSubclassOf<UBaseData>> ExposedData;

	UPROPERTY(EditAnywhere)
	TArray<TSubclassOf<UBaseBehaviour>> ExposedBehaviours;

	template<typename T>
	void RegisterExposedParameters(const TArray<TSubclassOf<T>>& ExposedParameters);
	
public:	
	virtual void Tick(float DeltaTime) override;
	
	UPROPERTY()
	USceneComponent* Root;

	UPROPERTY(EditAnywhere)
	USkeletalMeshComponent*	Mesh;
};


template <typename T>
T* AUnit::GetMember()
{
	return FindComponentByClass<T>();
}

template <typename T>
void AUnit::RemoveMember() const
{
	FindComponentByClass<T>()->DestroyComponent();
}

template <typename T>
void AUnit::RegisterExposedParameters(const TArray<TSubclassOf<T>>& ExposedParameters)
{
	for (auto Parameter: ExposedParameters)
	{
		if (Parameter.Get())
		{
			auto ParameterInstance = Parameter.GetDefaultObject()->GetInstance(*this, Parameter.GetDefaultObject());
			ParameterInstance->Init(this);
		}
	}
}
