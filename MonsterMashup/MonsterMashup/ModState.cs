﻿using MonsterMashup.Component;
using MonsterMashup.Helper;
using MonsterMashup.UI;
using System.Collections.Generic;
using IRBTModUtils.Extension;
using UnityEngine;

namespace MonsterMashup
{
    public static class ModState
    {

        // -- Teams we can use for spawning OpFors
        internal static Team TargetTeam = null;
        internal static Team TargetAllyTeam = null;
        internal static Team HostileToAllTeam = null;

        internal static List<(MechComponent source, LinkedActorComponent linkedTurret)> ComponentsToLink = new List<(MechComponent source, LinkedActorComponent linkedTurret)>();

        internal static Dictionary<string, FootprintVisualization> FootprintVisuals = new Dictionary<string, FootprintVisualization>();

        internal static Dictionary<AbstractActor, ParentRelationships> ParentState = new Dictionary<AbstractActor, ParentRelationships>();
        
        // TODO Eliminate everything below?
        //internal static Dictionary<string, AbstractActor> LinkedActorsToParent = new Dictionary<string, AbstractActor>();
        
        //internal static Dictionary<string, Transform> AttachTransforms = new Dictionary<string, Transform>();
        internal static Dictionary<Weapon, Transform> WeaponAttachTransforms = new Dictionary<Weapon, Transform>();
        
        //internal static Dictionary<string, List<AbstractActor>> ParentToLinkedActors = new Dictionary<string, List<AbstractActor>>();
        //internal static Dictionary<string, List<SupportSpawnState>> ChildSpawns = new Dictionary<string, List<SupportSpawnState>>();

        internal static HashSet<AbstractActor> Parents = new HashSet<AbstractActor>();
        
        internal static Dictionary<string, int> ActorDistinctIds = new Dictionary<string, int>();
        internal static Dictionary<AbstractActor, int> ActorIds = new Dictionary<AbstractActor, int>();
        internal static int NextActorId = 1;

        internal static int GetActorId(AbstractActor actor)
        {
            if(!ActorIds.TryGetValue(actor, out int actorId))
            {
                // force to lower to ignore case conditions
                var actorDistinctId = actor.DistinctId().ToLower();
                if (!ActorDistinctIds.TryGetValue(actorDistinctId, out actorId))
                {
                    actorId = NextActorId++;
                    ActorDistinctIds.Add(actorDistinctId, actorId);
                }
                
                ActorIds.Add(actor, actorId);
            }
            return actorId;
            
        }
        

        internal static void Reset()
        {
            TargetTeam = null;
            TargetAllyTeam = null;
            HostileToAllTeam = null;

            ComponentsToLink.Clear();

            foreach (FootprintVisualization footprintVis in FootprintVisuals.Values)
            {
                footprintVis.Destroy();
            }
            FootprintVisuals.Clear();

            ParentState.Clear();

            //LinkedActorsToParent.Clear();
            //ParentToLinkedActors.Clear();
            //AttachTransforms.Clear();
            WeaponAttachTransforms.Clear();
            //ChildSpawns.Clear();            
            Parents.Clear();
            
            ActorDistinctIds.Clear();
            ActorIds.Clear();
        }
    }

}


