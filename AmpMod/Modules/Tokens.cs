﻿using R2API;
using System;

namespace AmpMod.Modules
{//need to fix the charactername and description not showing up
    internal static class Tokens
    {
        internal static void AddTokens()
        {
            #region Amp
            string prefix = AmpPlugin.developerPrefix + "_AMP_BODY_";
            string chargedPrefix = "<color=#0091ff>Charged. </color>"; 

            #region Skins
            LanguageAPI.Add(prefix + "DEFAULT_SKIN_NAME", "Default");
            LanguageAPI.Add(prefix + "MASTERY_SKIN_NAME", "Red Sprite");
            LanguageAPI.Add(prefix + "GOLEM_SKIN_NAME", "Reformation");
            #endregion

            #region Descriptions
            LanguageAPI.Add(prefix + "NAME", Modules.StaticValues.characterName);
            LanguageAPI.Add(prefix + "SUBTITLE", Modules.StaticValues.characterSubtitle);
            LanguageAPI.Add(prefix + "DESCRIPTION", Modules.StaticValues.descriptionText);
            LanguageAPI.Add(prefix + "OUTRO_FLAVOR", Modules.StaticValues.characterOutro);
            LanguageAPI.Add(prefix + "LORE", Modules.StaticValues.characterLore);
            LanguageAPI.Add(prefix + "OUTRO_FAILURE", Modules.StaticValues.characterOutroFailure);
            LanguageAPI.Add(prefix + "KEYWORD_CHARGE", StaticValues.chargeDesc);
            LanguageAPI.Add(prefix + "KEYWORD_DOUBLECHARGE", StaticValues.doubleChargeDesc);
            #endregion

            #region Passive
            LanguageAPI.Add(prefix + "PASSIVE_NAME", "Charge");
            LanguageAPI.Add(prefix + "PASSIVE_DESCRIPTION", $"Attacks have a varying chance of applying <color=#0091ff>charge</color> on enemies.");
            #endregion

            #region Primary
            LanguageAPI.Add(prefix + "PRIMARY_SLASH_NAME", "Modified Shockblade");
            LanguageAPI.Add(prefix + "PRIMARY_SLASH_DESCRIPTION", Helpers.agilePrefix + chargedPrefix +  $"Slash continuously with your electrified sword for <style=cIsDamage>{100f * StaticValues.stormbladeDamageCoefficient}% damage</style>.");
            #endregion

            #region Secondary
            LanguageAPI.Add(prefix + "SECONDARY_FERROSHOT_NAME", "Lorentz Cannon");
            LanguageAPI.Add(prefix + "SECONDARY_FERROSHOT_DESCRIPTION", Helpers.agilePrefix + $"Use electromagnetic fields to fire an array of <style=cIsDamage>6</style> iron sand bullets, each dealing <style=cIsDamage>{100f * StaticValues.ferroshotDamageCoefficient}% damage</style>. Bullets <style=cIsUtility>home</style> onto <color=#0091ff>charged</color> & <color=#4cceff>electrified</color> enemies.");
            #endregion

            #region Secondary2
            LanguageAPI.Add(prefix + "SECONDARY_VORTEX_NAME", "Magnetic Vortex");
            LanguageAPI.Add(prefix + "SECONDARY_VORTEX_DESCRIPTION", Helpers.agilePrefix + $"Launch a magnetic singularity that <style=cIsUtility>pulls enemies into it</style> for <style=cIsDamage>{100f * StaticValues.vortexDamageCoefficient}% damage</style> per second, and explodes for <style=cIsDamage>{100f * StaticValues.vortexExplosionCoefficient}% damage</style>.");
            #endregion

            #region Secondary3
            LanguageAPI.Add(prefix + "SECONDARY_PLASMASLASH_NAME", "Plasma Slash");
            LanguageAPI.Add(prefix + "SECONDARY_PLASMASLASH_DESCRIPTION",  $"Perform a sweeping slash with your sword for <style=cIsDamage>{100f * StaticValues.spinSlashDamageCoefficient}%</style> damage, <style=cIsDamage>burning</style> enemies. If in the air, launch a <style=cIsDamage>burning</style> wave of plasma for <style=cIsDamage>{100f * StaticValues.fireBeamDamageCoefficient}%</style> damage. <color=#0091ff>Charged</color> & <color=#4cceff>electrified</color> enemies <style=cIsDamage>burn stronger</style>.");

            #endregion

            #region Utility
            LanguageAPI.Add(prefix + "UTILITY_DASH_NAME", "Surge");
            LanguageAPI.Add(prefix + "UTILITY_DASH_DESCRIPTION", chargedPrefix + $"Transform into lightning, becoming <style=cIsUtility>invulnerable</style>. Deal <style=cIsDamage>{100f * StaticValues.boltOverlapDamageCoefficient}%</style> damage on contact. Explode on exit for <style=cIsDamage>{100f * StaticValues.boltBlastDamageCoefficient}% damage</style>.");
            LanguageAPI.Add(prefix + "SPECIAL_CANCELDASH_NAME", "Cancel Surge");
            LanguageAPI.Add(prefix + "SPECIAL_CANCELDASH_DESCRIPTION", "Exit Surge early.");
            #endregion

            #region Utility2
            LanguageAPI.Add(prefix + "UTILITY_BOOST_NAME", "Pulse Leap");
            LanguageAPI.Add(prefix + "UTILITY_BOOST_DESCRIPTION", $"Magnetically <style=cIsUtility>boost</style> yourself forward, creating a <color=#0091ff>charged</color> explosion that deals <style=cIsDamage>{100f * StaticValues.boostDamageCoefficient}% damage</style>. Can boost up to <style=cIsUtility>3 times</style>.");
            #endregion

            #region Special
            LanguageAPI.Add(prefix + "SPECIAL_CHAIN_NAME", "Fulmination");
            LanguageAPI.Add(prefix + "SPECIAL_CHAIN_DESCRIPTION", Helpers.agilePrefix + $"Fire a <style=cIsUtility>chaining</style> stream of electricity that deals <style=cIsDamage>{100f * StaticValues.fulminationTotalDamageCoefficient}% damage</style> and has a <style=cIsDamage>{StaticValues.fulminationChargeProcCoefficient}%</style> chance of being <color=#0091ff>charged</color>.");
            LanguageAPI.Add(prefix + "SPECIAL_CANCELCHAIN_NAME", "Cancel Fulmination");
            LanguageAPI.Add(prefix + "SPECIAL_CANCELCHAIN_DESCRIPTION", "Exit Fulmination early.");
            #endregion

            #region Special2
            LanguageAPI.Add(prefix + "SPECIAL_LIGHTNING_NAME", "Voltaic Bombardment");
            LanguageAPI.Add(prefix + "SPECIAL_LIGHTNING_DESCRIPTION", Helpers.agilePrefix + $"<color=#0091ff>Double Charged</color>. Summon a lightning bolt for <style=cIsDamage>{100f * StaticValues.lightningStrikeCoefficient}% damage</style>. Hit yourself or allies with the bolt to become <style=cIsUtility>overcharged</style>, boosting attack and movement speed.");
            #endregion

            #region Special3
            LanguageAPI.Add(prefix + "SPECIAL_WORM_NAME", "Bulwark of Storms");
            LanguageAPI.Add(prefix + "SPECIAL_WORM_DISPLAY_NAME", "Melvin");
            LanguageAPI.Add(prefix + "SPECIAL_WORM_DESCRIPTION",  $"<style=cIsUtility>Channel</style> for 3 seconds, then summon an <style=cIsDamage>Overloading Worm</style> for <style=cIsUtility>30 seconds</style> that has <style=cIsHealing>300% your health</style> and inherits ALL your items.");
            LanguageAPI.Add(prefix + "SPECIAL_WORMCANCEL_NAME", "Return");
            LanguageAPI.Add(prefix + "SPECIAL_WORMCANCEL_DESCRIPTION", "Return Melvin to the depths.");
            #endregion

            #region Achievements
            LanguageAPI.Add("ACHIEVEMENT_AMPMASTERYUNLOCK_NAME", "Amp: Mastery");
            LanguageAPI.Add("ACHIEVEMENT_AMPMASTERYUNLOCK_DESCRIPTION", "As Amp, beat the game or obliterate on Monsoon.");
            LanguageAPI.Add(AmpPlugin.developerPrefix + "_AMP_BODY_MASTERY", "Amp: Mastery");

            LanguageAPI.Add("ACHIEVEMENT_AMPPLASMAUNLOCK_NAME", "Amp: Electric Burns");
            LanguageAPI.Add("ACHIEVEMENT_AMPPLASMAUNLOCK_DESCRIPTION", "As Amp, kill 100 burning enemies.");
            LanguageAPI.Add(AmpPlugin.developerPrefix + "_AMP_BODY_PLASMA", "Amp: Electric Burns");

            LanguageAPI.Add("ACHIEVEMENT_AMPWORMUNLOCK_NAME", "Amp: Usurper");
            LanguageAPI.Add("ACHIEVEMENT_AMPWORMUNLOCK_DESCRIPTION", "As Amp, beat an Overloading Worm at its own game.");
            LanguageAPI.Add(AmpPlugin.developerPrefix + "_AMP_BODY_USURPER", "Amp: Usurper");

            LanguageAPI.Add("ACHIEVEMENT_AMPGRANDMASTERYUNLOCK_NAME", "Amp: Grand Mastery");
            LanguageAPI.Add("ACHIEVEMENT_AMPGRANDMASTERYUNLOCK_DESCRIPTION", "As Amp, beat the game or obliterate on Typhoon.");
            LanguageAPI.Add(AmpPlugin.developerPrefix + "_AMP_BODY_GRANDMASTERY", "Amp: Grand Mastery");
            #endregion
            #endregion

            #region NemAmp

            string nemPrefix = AmpPlugin.developerPrefix + "_NEMESISAMP_BODY_";

            #region Skins
            LanguageAPI.Add(nemPrefix + "DEFAULT_SKIN_NAME", "Default");
            #endregion

            #region Descriptions
            LanguageAPI.Add(nemPrefix + "NAME", Modules.StaticValues.nemCharacterName);
            LanguageAPI.Add(nemPrefix + "SUBTITLE", Modules.StaticValues.nemCharacterSubtitle);
            LanguageAPI.Add(nemPrefix + "DESCRIPTION", Modules.StaticValues.nemDescriptionText);
            LanguageAPI.Add(nemPrefix + "OUTRO_FLAVOR", Modules.StaticValues.nemCharacterOutro);
            //LanguageAPI.Add(nemPrefix + "LORE", Modules.StaticValues.nemCharacterLore);
            LanguageAPI.Add(nemPrefix + "OUTRO_FAILURE", Modules.StaticValues.nemCharacterOutroFailure);
            #endregion

            #region Passive
            LanguageAPI.Add(nemPrefix + "PASSIVE_NAME", "Blessing of Lightning");
            LanguageAPI.Add(nemPrefix + "PASSIVE_DESCRIPTION", $"Using a skill <style=cIsUtility>immediately</style> after using a different skill will <style=cIsDamage>increase its damage by {100f * StaticValues.growthDamageCoefficient}%</style>, with a maximum bonus of <style=cIsDamage>{100f * StaticValues.maxGrowthDamageCoefficient}%</style>. The bonus is maintained as long as you are dealing damage.");
            #endregion

            #region Primary
            LanguageAPI.Add(nemPrefix + "PRIMARY_LIGHTNING_NAME", "Fulmination");
            LanguageAPI.Add(nemPrefix + "PRIMARY_LIGHTNING_DESCRIPTION", $"Lock on to an enemy with a continuous stream of electricity that deals 150% damage per second.");
            #endregion

            #region Primary2
            LanguageAPI.Add(nemPrefix + "PRIMARY_BLADES_NAME", "Flux Blades");
            LanguageAPI.Add(nemPrefix + "PRIMARY_BLADES_DESCRIPTION", $"Fire an iron sand dagger, dealing <style=cIsDamage>{100f * StaticValues.bladeDamageCoefficient}% damage</style> damage on hit.");
            #endregion

            #region Secondary
            LanguageAPI.Add(nemPrefix + "SECONDARY_CHARGEBEAM_NAME", "Howitzer Spark");
            LanguageAPI.Add(nemPrefix + "SECONDARY_CHARGEBEAM_DESCRIPTION", $"Charge a <style=cIsUtility>piercing</style> beam of electricity that deals <style=cIsDamage>{100f * StaticValues.chargeBeamMinDamageCoefficient}%-{100f * StaticValues.chargeBeamMaxDamageCoefficient}% damage</style>. For every enemy pierced, the beam does {100f * StaticValues.additionalPierceDamageCoefficient}% extra damage</style> to the next enemy hit.");
            #endregion

            #region Utility
            LanguageAPI.Add(nemPrefix + "UTILITY_FIELD_NAME", "Static Field");
            LanguageAPI.Add(nemPrefix + "UTILITY_FIELD_DESCRIPTION", $"<style=cIsUtility>Electrify</style> an area, <style=cIsUtility>weakening and slowing</style> enemies inside, and dealing <style=cIsDamage>200% damage</style>. Being in the field <style=cIsUtility>increase</style> your attack speed.");
            #endregion

            #region Utility2
            LanguageAPI.Add(nemPrefix + "UTILITY_TELEPORT_NAME", "Shocking Teleport");
            LanguageAPI.Add(nemPrefix + "UTILITY_TELEPORT_DESCRIPTION", $"Teleport to any destination within your line of sight, dealing <style=cIsDamage>{100f * StaticValues.teleportBlastDamageCoefficient}% damage</style> damage upon arrival.");
            #endregion

            #region Special
            LanguageAPI.Add(nemPrefix + "SPECIAL_SUMMONSTORM_NAME", "Electron Crash");
            LanguageAPI.Add(nemPrefix + "SPECIAL_SUMMONSTORM_DESCRIPTION", $"Dealing damage adds stacks of <color=#0091ff>Controlled Charge</color>. Activate this ability to summon a lightning bolt onto every enemy within a large radius; the damage of the lightning bolt deals <style=cIsDamage>{100f * StaticValues.baseBoltDamageCoefficient}% base damage</style> with an extra <style=cIsDamage>{100f * StaticValues.additionalBoltDamageCoefficient}% damage for every stack of Controlled Charge</style>. ");
            #endregion

            #endregion

            #region Mithrix Quotes
            LanguageAPI.Add("MITHRIX_SEE_AMP_1", "You wield stolen power. Relinquish it through death.");
            LanguageAPI.Add("MITHRIX_SEE_AMP_2", "Watch, brother. I will prove the fragility of your constructs.");
            LanguageAPI.Add("MITHRIX_SEE_AMP_3", "The power of a wurm? Does brother wish to mock me?");

            LanguageAPI.Add("MITHRIX_KILL_AMP_1", "A pity. You may have been a useful servant.");
            LanguageAPI.Add("MITHRIX_KILL_AMP_2", "Frail sparks.");
            #endregion

        }
    }
}

