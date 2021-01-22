// Fill out your copyright notice in the Description page of Project Settings.

#include "Unit.h"
#include "Engine/EngineTypes.h"
#include "Unreal_Arcane_Flow/Modules/Behaviours/BaseBehaviour.h"
#include "Unreal_Arcane_Flow/Modules/Data/BaseData.h"

// Sets default values
AUnit::AUnit()
{
 	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

	Root = CreateDefaultSubobject<USceneComponent>(TEXT("Root"));
	RootComponent = Root;

	const FAttachmentTransformRules Rules(EAttachmentRule::KeepRelative, EAttachmentRule::KeepRelative,
		EAttachmentRule::KeepRelative, false);

	Mesh = CreateDefaultSubobject<USkeletalMeshComponent>(TEXT("Mesh"));
	Mesh->AttachToComponent(Root, Rules);
}

// Called when the game starts or when spawned
void AUnit::BeginPlay()
{
	Super::BeginPlay();
	
	RegisterExposedParameters<UBaseData>(ExposedData);
	RegisterExposedParameters<UBaseBehaviour>(ExposedBehaviours);
}	

// Called every frame
void AUnit::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
}

