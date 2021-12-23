﻿using R2API;
using System;

namespace HenryMod.Modules
{//need to fix the charactername and description not showing up
    internal static class Tokens
    {
        internal static void AddTokens()
        {
            #region Henry
            string prefix = HenryPlugin.developerPrefix + "_HENRY_BODY_";

            #region Skins
            LanguageAPI.Add(prefix + "DEFAULT_SKIN_NAME", "Default");
            LanguageAPI.Add(prefix + "MASTERY_SKIN_NAME", "Alternate");
            #endregion

            #region Passive
            LanguageAPI.Add(prefix + "PASSIVE_NAME", "Charge");
            LanguageAPI.Add(prefix + "PASSIVE_DESCRIPTION", "The battlemage's electrifying attacks build up stacks of 'charge' on an enemy. When 3 stacks are reached, the electric charge accumulated on the enemy is released in a devastating burst of static electricity that damages the target and all enemies near it for <style=cIsDamage>400% damage</style>.");
            #endregion

            #region Primary
            LanguageAPI.Add(prefix + "PRIMARY_SLASH_NAME", "Stormblade");
            LanguageAPI.Add(prefix + "PRIMARY_SLASH_DESCRIPTION", Helpers.agilePrefix + $"Slash continuously with your electrified sword for <style=cIsDamage>{100f * StaticValues.swordDamageCoefficient}% damage</style>.");
            #endregion

            #region Secondary
            LanguageAPI.Add(prefix + "SECONDARY_GUN_NAME", "Gauss Cannon");
            LanguageAPI.Add(prefix + "SECONDARY_GUN_DESCRIPTION", Helpers.agilePrefix + $"Use magnetic fields to fire an array of 6 iron bullets, dealing <style=cIsDamage>{100f * StaticValues.ferroshotDamageCoefficient}% damage</style> per bullet.");
            #endregion

            #region Utility
            LanguageAPI.Add(prefix + "UTILITY_ROLL_NAME", "Bolt");
            LanguageAPI.Add(prefix + "UTILITY_ROLL_DESCRIPTION",  $"Transform into electricity, gaining invulnerability, free movement, and <style=cIsUtility>500% movement speed</style> for 1.5 seconds");
            #endregion

            #region Special
            LanguageAPI.Add(prefix + "SPECIAL_BOMB_NAME", "Fulmination");
            LanguageAPI.Add(prefix + "SPECIAL_BOMB_DESCRIPTION", $"Fire a continuous stream of electricity that deals <style=cIsDamage>{100f * StaticValues.bombDamageCoefficient}% damage</style> per second for 6 seconds.");
            #endregion

            #region Special
            LanguageAPI.Add(prefix + "SPECIAL_LIGHTNING_NAME", "Voltaic Bombardment");
            LanguageAPI.Add(prefix + "SPECIAL_LIGHTNING_DESCRIPTION", Helpers.agilePrefix + $"Summon a lightning bolt that strikes the targeted area, damaging all enemies in the vicinity for <style=cIsDamage>{100f * StaticValues.lightningStrikeCoefficient}% damage</style>.");
            #endregion

            #region Achievements
            LanguageAPI.Add(prefix + "MASTERYUNLOCKABLE_ACHIEVEMENT_NAME", "Henry: Mastery");
            LanguageAPI.Add(prefix + "MASTERYUNLOCKABLE_ACHIEVEMENT_DESC", "As Henry, beat the game or obliterate on Monsoon.");
            LanguageAPI.Add(prefix + "MASTERYUNLOCKABLE_UNLOCKABLE_NAME", "Henry: Mastery");
            #endregion
            #endregion
        }
    }
}

