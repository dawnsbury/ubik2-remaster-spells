﻿using Dawnsbury.Core.CharacterBuilder.Feats;
using Dawnsbury.Core.CharacterBuilder.FeatsDb;
using Dawnsbury.Core.Mechanics.Enumerations;
using Dawnsbury.Modding;
using Dawnsbury.Mods.Remaster.FeatsDb.TrueFeatsDb;
using System.Collections.Generic;

namespace Dawnsbury.Mods.Remaster.FeatsDb
{

    public class RemasterFeats
    {
        public static Trait RemasterTrait = ModManager.RegisterTrait("Remaster");

        [DawnsburyDaysModMainMethod]
        public static void LoadMod()
        {
            AddOrReplaceFeats(ClericClassFeatures.LoadFonts());
            AddOrReplaceFeats(Fighter.LoadAll());
        }

        public static void AddOrReplaceFeats(IEnumerable<Feat> feats)
        {
            foreach (var feat in feats)
            {
                // Remove any feats that have the same name as one of our new feats
                AllFeats.All.RemoveAll((existingFeat) => existingFeat.Name == feat.Name);
                if (!feat.HasTrait(RemasterTrait))
                {
                    feat.Traits.Add(RemasterTrait);
                }
                ModManager.AddFeat(feat);
            }

        }
    }
}
