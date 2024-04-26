using Dawnsbury.Core.CharacterBuilder.FeatsDb.Spellbook;
using Dawnsbury.Core.CharacterBuilder.Spellcasting;
using Dawnsbury.Core.CombatActions;
using Dawnsbury.Core.Creatures;
using Dawnsbury.Core.Mechanics;
using Dawnsbury.Core.Mechanics.Enumerations;
using Dawnsbury.Modding;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dawnsbury.Mods.Remaster.HideLegacySpells
{
    public class HideLegacySpells
    {
        [DawnsburyDaysModMainMethod]
        public static void LoadMod()
        {
            // A list of legacy spell ids for each level (starting at 0)
            SpellId[][] legacySpells = new[] {
                new[] { SpellId.AcidSplash, SpellId.RayOfFrost, SpellId.ProduceFlame, SpellId.DisruptUndead, SpellId.ChillTouch },
                new[] { SpellId.BurningHands, SpellId.ColorSpray, SpellId.MagicMissile, SpellId.MageArmor, SpellId.MagicWeapon, SpellId.TrueStrike, SpellId.ShockingGrasp },
                new[] { SpellId.AcidArrow, SpellId.CalmEmotions, SpellId.FlamingSphere, SpellId.HideousLaughter, SpellId.ObscuringMist, SpellId.SoundBurst, SpellId.Barkskin, SpellId.SpiritualWeapon, SpellId.TouchOfIdiocy }
            };
            ModManager.RegisterActionOnEachSpell(spell =>
            {
                foreach (var legacySpellList in legacySpells)
                {
                    if (legacySpellList.Contains(spell.SpellId))
                    {
                        spell.Traits.Add(Trait.SpellCannotBeChosenInCharacterBuilder);
                    }
                }
            });
        }
    }
}
