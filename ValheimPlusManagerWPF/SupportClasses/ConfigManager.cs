﻿using IniParser;
using IniParser.Model;
using IniParser.Model.Configuration;
using System;
using System.Globalization;
using ValheimPlusManager.Data;
using ValheimPlusManager.Models;

namespace ValheimPlusManager.SupportClasses
{
    public sealed class ConfigManager
    {
        public static ValheimPlusConf ReadConfigFile(bool manageClient)
        {
            ValheimPlusConf valheimPlusConfiguration = new ValheimPlusConf();
            Settings settings = SettingsDAL.GetSettings();
            IniData data;

            // Settings to make sure floats are using dots as separators and not commas
            CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            ci.NumberFormat.CurrencyDecimalSeparator = ".";

            var parser = new FileIniDataParser();
            if (manageClient)
            {
                data = parser.ReadFile(string.Format("{0}BepInEx/config/valheim_plus.cfg", settings.ClientInstallationPath));
            }
            else
            {
                data = parser.ReadFile(string.Format("{0}BepInEx/config/valheim_plus.cfg", settings.ServerInstallationPath));
            }

            #region Advanced building mode
            if (bool.TryParse(data["AdvancedBuildingMode"]["enabled"], out bool advancedBuildingModeEnabled))
            {
                valheimPlusConfiguration.advancedBuildingModeEnabled = advancedBuildingModeEnabled;
            }
            if (data["AdvancedBuildingMode"]["enterAdvancedBuildingMode"] != null)
            {
                valheimPlusConfiguration.enterAdvancedBuildingMode = data["AdvancedBuildingMode"]["enterAdvancedBuildingMode"];
            }
            if (data["AdvancedBuildingMode"]["exitAdvancedBuildingMode"] != null)
            {
                valheimPlusConfiguration.exitAdvancedBuildingMode = data["AdvancedBuildingMode"]["exitAdvancedBuildingMode"];
            }
            if (data["AdvancedBuildingMode"]["copyObjectRotation"] != null)
            {
                valheimPlusConfiguration.copyObjectRotation = data["AdvancedBuildingMode"]["copyObjectRotation"];
            }
            if (data["AdvancedBuildingMode"]["pasteObjectRotation"] != null)
            {
                valheimPlusConfiguration.pasteObjectRotation = data["AdvancedBuildingMode"]["pasteObjectRotation"];
            }

            #endregion Advanced building mode

            #region Advanced editing mode
            if (bool.TryParse(data["AdvancedEditingMode"]["enabled"], out bool advancedEditingModeEnabled))
            {
                valheimPlusConfiguration.advancedEditingModeEnabled = advancedEditingModeEnabled;
            }
            if (data["AdvancedEditingMode"]["enterAdvancedEditingMode"] != null)
            {
                valheimPlusConfiguration.enterAdvancedEditingMode = data["AdvancedEditingMode"]["enterAdvancedEditingMode"];
            }
            if (data["AdvancedEditingMode"]["resetAdvancedEditingMode"] != null)
            {
                valheimPlusConfiguration.resetAdvancedEditingMode = data["AdvancedEditingMode"]["resetAdvancedEditingMode"];
            }
            if (data["AdvancedEditingMode"]["abortAndExitAdvancedEditingMode"] != null)
            {
                valheimPlusConfiguration.abortAndExitAdvancedEditingMode = data["AdvancedEditingMode"]["abortAndExitAdvancedEditingMode"];
            }
            if (data["AdvancedEditingMode"]["confirmPlacementOfAdvancedEditingMode"] != null)
            {
                valheimPlusConfiguration.confirmPlacementOfAdvancedEditingMode = data["AdvancedEditingMode"]["confirmPlacementOfAdvancedEditingMode"];
            }
            if (data["AdvancedEditingMode"]["copyObjectRotation"] != null)
            {
                valheimPlusConfiguration.copyObjectRotationAEM = data["AdvancedEditingMode"]["copyObjectRotation"];
            }
            if (data["AdvancedEditingMode"]["pasteObjectRotation"] != null)
            {
                valheimPlusConfiguration.pasteObjectRotationAEM = data["AdvancedEditingMode"]["pasteObjectRotation"];
            }
            #endregion Advanced editing mode

            #region Armor
            if (bool.TryParse(data["Armor"]["enabled"], out bool armorSettingsEnabled))
            {
                valheimPlusConfiguration.armorSettingsEnabled = armorSettingsEnabled;
            }
            if (float.TryParse(data["Armor"]["helmets"], NumberStyles.Any, ci, out float helmetsArmor))
            {
                valheimPlusConfiguration.helmetsArmor = helmetsArmor;
            }
            if (float.TryParse(data["Armor"]["chests"], NumberStyles.Any, ci, out float chestsArmor))
            {
                valheimPlusConfiguration.chestsArmor = chestsArmor;
            }
            if (float.TryParse(data["Armor"]["legs"], NumberStyles.Any, ci, out float legsArmor))
            {
                valheimPlusConfiguration.legsArmor = legsArmor;
            }
            if (float.TryParse(data["Armor"]["capes"], NumberStyles.Any, ci, out float capesArmor))
            {
                valheimPlusConfiguration.capesArmor = capesArmor;
            }
            #endregion Armor

            #region Beehive
            if (bool.TryParse(data["Beehive"]["enabled"], out bool beehiveSettingsEnabled))
            {
                valheimPlusConfiguration.beehiveSettingsEnabled = beehiveSettingsEnabled;
            }
            if (float.TryParse(data["Beehive"]["honeyProductionSpeed"], NumberStyles.Any, ci, out float honeyProductionSpeed))
            {
                valheimPlusConfiguration.honeyProductionSpeed = honeyProductionSpeed;
            }
            if (int.TryParse(data["Beehive"]["maximumHoneyPerBeehive"], out int maximumHoneyPerBeehive))
            {
                valheimPlusConfiguration.maximumHoneyPerBeehive = maximumHoneyPerBeehive;
            }
            #endregion Beehive

            #region Building
            if (bool.TryParse(data["Building"]["enabled"], out bool buildingSettingsEnabled))
            {
                valheimPlusConfiguration.buildingSettingsEnabled = buildingSettingsEnabled;
            }
            if (bool.TryParse(data["Building"]["noInvalidPlacementRestriction"], out bool noInvalidPlacementRestriction))
            {
                valheimPlusConfiguration.noInvalidPlacementRestriction = noInvalidPlacementRestriction;
            }
            if (bool.TryParse(data["Building"]["noWeatherDamage"], out bool noWeatherDamage))
            {
                valheimPlusConfiguration.noWeatherDamage = noWeatherDamage;
            }
            if (float.TryParse(data["Building"]["maximumPlacementDistance"], NumberStyles.Any, ci, out float maximumPlacementDistance))
            {
                valheimPlusConfiguration.maximumPlacementDistance = maximumPlacementDistance;
            }
            #endregion Building

            #region Durability
            if (bool.TryParse(data["Durability"]["enabled"], out bool durabilitySettingsEnabled))
            {
                valheimPlusConfiguration.durabilitySettingsEnabled = durabilitySettingsEnabled;
            }
            if (float.TryParse(data["Durability"]["axes"], NumberStyles.Any, ci, out float axesDurability))
            {
                valheimPlusConfiguration.axesDurability = axesDurability;
            }
            if (float.TryParse(data["Durability"]["pickaxes"], NumberStyles.Any, ci, out float pickaxesDurability))
            {
                valheimPlusConfiguration.pickaxesDurability = pickaxesDurability;
            }
            if (float.TryParse(data["Durability"]["hammer"], NumberStyles.Any, ci, out float hammerDurability))
            {
                valheimPlusConfiguration.hammerDurability = hammerDurability;
            }
            if (float.TryParse(data["Durability"]["cultivator"], NumberStyles.Any, ci, out float cultivatorDurability))
            {
                valheimPlusConfiguration.cultivatorDurability = cultivatorDurability;
            }
            if (float.TryParse(data["Durability"]["hoe"], NumberStyles.Any, ci, out float hoeDurability))
            {
                valheimPlusConfiguration.hoeDurability = hoeDurability;
            }
            if (float.TryParse(data["Durability"]["weapons"], NumberStyles.Any, ci, out float weaponsDurability))
            {
                valheimPlusConfiguration.weaponsDurability = weaponsDurability;
            }
            if (float.TryParse(data["Durability"]["armor"], NumberStyles.Any, ci, out float armorDurability))
            {
                valheimPlusConfiguration.armorDurability = armorDurability;
            }
            if (float.TryParse(data["Durability"]["bows"], NumberStyles.Any, ci, out float bowsDurability))
            {
                valheimPlusConfiguration.bowsDurability = bowsDurability;
            }
            if (float.TryParse(data["Durability"]["shields"], NumberStyles.Any, ci, out float shieldsDurability))
            {
                valheimPlusConfiguration.shieldsDurability = shieldsDurability;
            }
            #endregion Durability

            #region Inventory
            if (bool.TryParse(data["Inventory"]["enabled"], out bool inventorySettingsEnabled))
            {
                valheimPlusConfiguration.inventorySettingsEnabled = inventorySettingsEnabled;
            }
            if (bool.TryParse(data["Inventory"]["inventoryFillTopToBottom"], out bool inventoryFillTopToBottom))
            {
                valheimPlusConfiguration.inventoryFillTopToBottom = inventoryFillTopToBottom;
            }
            if (int.TryParse(data["Inventory"]["playerInventoryRows"], out int playerInventoryRows))
            {
                valheimPlusConfiguration.playerInventoryRows = playerInventoryRows;
            }
            if (int.TryParse(data["Inventory"]["woodChestColumns"], out int woodChestColumns))
            {
                valheimPlusConfiguration.woodChestColumns = woodChestColumns;
            }
            if (int.TryParse(data["Inventory"]["woodChestRows"], out int woodChestRows))
            {
                valheimPlusConfiguration.woodChestRows = woodChestRows;
            }
            if (int.TryParse(data["Inventory"]["ironChestColumns"], out int ironChestColumns))
            {
                valheimPlusConfiguration.ironChestColumns = ironChestColumns;
            }
            if (int.TryParse(data["Inventory"]["ironChestRows"], out int ironChestRows))
            {
                valheimPlusConfiguration.ironChestRows = ironChestRows;
            }
            #endregion Inventory

            #region Items
            if (bool.TryParse(data["Items"]["enabled"], out bool itemsSettingsEnabled))
            {
                valheimPlusConfiguration.itemsSettingsEnabled = itemsSettingsEnabled;
            }
            if (bool.TryParse(data["Items"]["noTeleportPrevention"], out bool noTeleportPrevention))
            {
                valheimPlusConfiguration.noTeleportPrevention = noTeleportPrevention;
            }
            if (float.TryParse(data["Items"]["baseItemWeightReduction"], NumberStyles.Any, ci, out float baseItemWeightReduction))
            {
                valheimPlusConfiguration.baseItemWeightReduction = baseItemWeightReduction;
            }
            if (float.TryParse(data["Items"]["itemStackMultiplier"], NumberStyles.Any, ci, out float itemStackMultiplier))
            {
                valheimPlusConfiguration.itemStackMultiplier = itemStackMultiplier;
            }
            if (int.TryParse(data["Items"]["droppedItemOnGroundDurationInSeconds"], out int droppedItemOnGroundDurationInSeconds))
            {
                valheimPlusConfiguration.droppedItemOnGroundDurationInSeconds = droppedItemOnGroundDurationInSeconds;
            }
            #endregion Items

            #region Fermenter
            if (bool.TryParse(data["Fermenter"]["enabled"], out bool fermenterSettingsEnabled))
            {
                valheimPlusConfiguration.fermenterSettingsEnabled = fermenterSettingsEnabled;
            }
            if (float.TryParse(data["Fermenter"]["fermenterDuration"], NumberStyles.Any, ci, out float fermenterDuration))
            {
                valheimPlusConfiguration.fermenterDuration = fermenterDuration;
            }
            if (int.TryParse(data["Fermenter"]["fermenterItemsProduced"], out int fermenterItemsProduced))
            {
                valheimPlusConfiguration.fermenterItemsProduced = fermenterItemsProduced;
            }
            if (bool.TryParse(data["Fermenter"]["showFermenterDuration"], out bool showFermenterDuration))
            {
                valheimPlusConfiguration.showFermenterDuration = showFermenterDuration;
            }
            #endregion Fermenter

            #region Fireplace
            if (bool.TryParse(data["Fireplace"]["enabled"], out bool fireplaceSettingsEnabled))
            {
                valheimPlusConfiguration.fireplaceSettingsEnabled = fireplaceSettingsEnabled;
            }
            if (bool.TryParse(data["Fireplace"]["onlyTorches"], out bool onlyTorches))
            {
                valheimPlusConfiguration.onlyTorches = onlyTorches;
            }
            #endregion Fireplace

            #region Food
            if (bool.TryParse(data["Food"]["enabled"], out bool foodSettingsEnabled))
            {
                valheimPlusConfiguration.foodSettingsEnabled = foodSettingsEnabled;
            }
            if (float.TryParse(data["Food"]["foodDurationMultiplier"], NumberStyles.Any, ci, out float foodDurationMultiplier))
            {
                valheimPlusConfiguration.foodDurationMultiplier = foodDurationMultiplier;
            }
            #endregion Food

            #region Furnace
            if (bool.TryParse(data["Furnace"]["enabled"], out bool furnaceSettingsEnabled))
            {
                valheimPlusConfiguration.furnaceSettingsEnabled = furnaceSettingsEnabled;
            }
            if (int.TryParse(data["Furnace"]["maximumOre"], out int maximumOre))
            {
                valheimPlusConfiguration.maximumOre = maximumOre;
            }
            if (int.TryParse(data["Furnace"]["maximumCoal"], out int maximumCoal))
            {
                valheimPlusConfiguration.maximumCoal = maximumCoal;
            }
            if (int.TryParse(data["Furnace"]["coalUsedPerProduct"], out int coalUsedPerProduct))
            {
                valheimPlusConfiguration.coalUsedPerProduct = coalUsedPerProduct;
            }
            if (int.TryParse(data["Furnace"]["productionSpeed"], out int furnaceProductionSpeed))
            {
                valheimPlusConfiguration.furnaceProductionSpeed = furnaceProductionSpeed;
            }
            if (float.TryParse(data["Furnace"]["autoDepositRange"], NumberStyles.Any, ci, out float autoDepositRangeFurnace))
            {
                valheimPlusConfiguration.autoDepositRangeFurnace = autoDepositRangeFurnace;
            }
            if (bool.TryParse(data["Furnace"]["autoDeposit"], out bool autoDepositFurnace))
            {
                valheimPlusConfiguration.autoDepositFurnace = autoDepositFurnace;
            }
            #endregion Furnace

            #region Game
            if (bool.TryParse(data["Game"]["enabled"], out bool gameSettingsEnabled))
            {
                valheimPlusConfiguration.gameSettingsEnabled = gameSettingsEnabled;
            }
            if (float.TryParse(data["Game"]["gameDifficultyDamageScale"], NumberStyles.Any, ci, out float gameDifficultyDamageScale))
            {
                valheimPlusConfiguration.gameDifficultyDamageScale = gameDifficultyDamageScale;
            }
            if (float.TryParse(data["Game"]["gameDifficultyHealthScale"], NumberStyles.Any, ci, out float gameDifficultyHealthScale))
            {
                valheimPlusConfiguration.gameDifficultyHealthScale = gameDifficultyHealthScale;
            }
            if (int.TryParse(data["Game"]["extraPlayerCountNearby"], out int extraPlayerCountNearby))
            {
                valheimPlusConfiguration.extraPlayerCountNearby = extraPlayerCountNearby;
            }
            if (int.TryParse(data["Game"]["setFixedPlayerCountTo"], out int setFixedPlayerCountTo))
            {
                valheimPlusConfiguration.setFixedPlayerCountTo = setFixedPlayerCountTo;
            }
            if (int.TryParse(data["Game"]["difficultyScaleRange"], out int difficultyScaleRange))
            {
                valheimPlusConfiguration.difficultyScaleRange = difficultyScaleRange;
            }
            if (bool.TryParse(data["Game"]["disablePortals"], out bool disablePortals))
            {
                valheimPlusConfiguration.disablePortals = disablePortals;
            }
            #endregion Game

            #region Gathering
            if (bool.TryParse(data["Gathering"]["enabled"], out bool gatheringSettingsEnabled))
            {
                valheimPlusConfiguration.gatheringSettingsEnabled = gatheringSettingsEnabled;
            }
            if (float.TryParse(data["Gathering"]["wood"], NumberStyles.Any, ci, out float woodGathering))
            {
                valheimPlusConfiguration.woodGathering = woodGathering;
            }
            if (float.TryParse(data["Gathering"]["stone"], NumberStyles.Any, ci, out float stoneGathering))
            {
                valheimPlusConfiguration.stoneGathering = stoneGathering;
            }
            if (float.TryParse(data["Gathering"]["fineWood"], NumberStyles.Any, ci, out float fineWoodGathering))
            {
                valheimPlusConfiguration.fineWoodGathering = fineWoodGathering;
            }
            if (float.TryParse(data["Gathering"]["coreWood"], NumberStyles.Any, ci, out float coreWoodGathering))
            {
                valheimPlusConfiguration.coreWoodGathering = coreWoodGathering;
            }
            if (float.TryParse(data["Gathering"]["elderBark"], NumberStyles.Any, ci, out float elderBarkGathering))
            {
                valheimPlusConfiguration.elderBarkGathering = elderBarkGathering;
            }
            if (float.TryParse(data["Gathering"]["ironScrap"], NumberStyles.Any, ci, out float ironScrapGathering))
            {
                valheimPlusConfiguration.ironScrapGathering = ironScrapGathering;
            }
            if (float.TryParse(data["Gathering"]["tinOre"], NumberStyles.Any, ci, out float tinOreGathering))
            {
                valheimPlusConfiguration.tinOreGathering = tinOreGathering;
            }
            if (float.TryParse(data["Gathering"]["copperOre"], NumberStyles.Any, ci, out float copperOreGathering))
            {
                valheimPlusConfiguration.copperOreGathering = copperOreGathering;
            }
            if (float.TryParse(data["Gathering"]["silverOre"], NumberStyles.Any, ci, out float silverOreGathering))
            {
                valheimPlusConfiguration.silverOreGathering = silverOreGathering;
            }
            if (float.TryParse(data["Gathering"]["chitin"], NumberStyles.Any, ci, out float chitinGathering))
            {
                valheimPlusConfiguration.chitinGathering = chitinGathering;
            }
            if (float.TryParse(data["Gathering"]["dropChance"], NumberStyles.Any, ci, out float dropChanceGathering))
            {
                valheimPlusConfiguration.dropChanceGathering = dropChanceGathering;
            }
            #endregion Gathering

            #region Hotkeys
            if (bool.TryParse(data["Hotkeys"]["enabled"], out bool hotkeysSettingsEnabled))
            {
                valheimPlusConfiguration.hotkeysSettingsEnabled = hotkeysSettingsEnabled;
            }
            if (data["Hotkeys"]["rollForwards"] != null)
            {
                valheimPlusConfiguration.rollForwards = data["Hotkeys"]["rollForwards"];
            }
            if (data["Hotkeys"]["rollBackwards"] != null)
            {
                valheimPlusConfiguration.rollBackwards = data["Hotkeys"]["rollBackwards"];
            }
            #endregion Hotkeys

            #region HUD
            if (bool.TryParse(data["Hud"]["enabled"], out bool hudSettingsEnabled))
            {
                valheimPlusConfiguration.hudSettingsEnabled = hudSettingsEnabled;
            }
            if (bool.TryParse(data["Hud"]["showRequiredItems"], out bool showRequiredItems))
            {
                valheimPlusConfiguration.showRequiredItems = showRequiredItems;
            }
            if (bool.TryParse(data["Hud"]["experienceGainedNotifications"], out bool experienceGainedNotifications))
            {
                valheimPlusConfiguration.experienceGainedNotifications = experienceGainedNotifications;
            }
            if (bool.TryParse(data["Hud"]["displayStaminaValue"], out bool displayStaminaValue))
            {
                valheimPlusConfiguration.displayStaminaValue = displayStaminaValue;
            }
            if (bool.TryParse(data["Hud"]["removeDamageFlash"], out bool removeDamageFlash))
            {
                valheimPlusConfiguration.removeDamageFlash = removeDamageFlash;
            }
            #endregion HUD

            #region Kiln
            if (bool.TryParse(data["Kiln"]["enabled"], out bool kilnSettingsEnabled))
            {
                valheimPlusConfiguration.kilnSettingsEnabled = kilnSettingsEnabled;
            }
            if (int.TryParse(data["Kiln"]["maximumWood"], out int maximumWood))
            {
                valheimPlusConfiguration.maximumWood = maximumWood;
            }
            if (int.TryParse(data["Kiln"]["productionSpeed"], out int kilnProductionSpeed))
            {
                valheimPlusConfiguration.kilnProductionSpeed = kilnProductionSpeed;
            }
            if (float.TryParse(data["Kiln"]["autoDepositRange"], NumberStyles.Any, ci, out float autoDepositRangeKiln))
            {
                valheimPlusConfiguration.autoDepositRangeKiln = autoDepositRangeKiln;
            }
            if (bool.TryParse(data["Kiln"]["autoDeposit"], out bool autoDepositKiln))
            {
                valheimPlusConfiguration.autoDepositKiln = autoDepositKiln;
            }
            #endregion Kiln

            #region Map
            if (bool.TryParse(data["Map"]["enabled"], out bool mapSettingsEnabled))
            {
                valheimPlusConfiguration.mapSettingsEnabled = mapSettingsEnabled;
            }
            if (bool.TryParse(data["Map"]["shareMapProgression"], out bool shareMapProgression))
            {
                valheimPlusConfiguration.shareMapProgression = shareMapProgression;
            }
            if (int.TryParse(data["Map"]["exploreRadius"], out int exploreRadius))
            {
                valheimPlusConfiguration.exploreRadius = exploreRadius;
            }
            if (bool.TryParse(data["Map"]["playerPositionPublicOnJoin"], out bool playerPositionPublicOnJoin))
            {
                valheimPlusConfiguration.playerPositionPublicOnJoin = playerPositionPublicOnJoin;
            }
            if (bool.TryParse(data["Map"]["preventPlayerFromTurningOffPublicPosition"], out bool preventPlayerFromTurningOffPublicPosition))
            {
                valheimPlusConfiguration.preventPlayerFromTurningOffPublicPosition = preventPlayerFromTurningOffPublicPosition;
            }
            if (bool.TryParse(data["Map"]["removeDeathPinOnTombstoneEmpty"], out bool removeDeathPinOnTombstoneEmpty))
            {
                valheimPlusConfiguration.removeDeathPinOnTombstoneEmpty = removeDeathPinOnTombstoneEmpty;
            }
            #endregion Map

            #region Player
            if (bool.TryParse(data["Player"]["enabled"], out bool playerSettingsEnabled))
            {
                valheimPlusConfiguration.playerSettingsEnabled = playerSettingsEnabled;
            }
            if (int.TryParse(data["Player"]["baseMaximumWeight"], out int baseMaximumWeight))
            {
                valheimPlusConfiguration.baseMaximumWeight = baseMaximumWeight;
            }
            if (int.TryParse(data["Player"]["baseMegingjordBuff"], out int baseMegingjordBuff))
            {
                valheimPlusConfiguration.baseMegingjordBuff = baseMegingjordBuff;
            }
            if (int.TryParse(data["Player"]["baseAutoPickUpRange"], out int baseAutoPickUpRange))
            {
                valheimPlusConfiguration.baseAutoPickUpRange = baseAutoPickUpRange;
            }
            if (bool.TryParse(data["Player"]["disableCameraShake"], out bool disableCameraShake))
            {
                valheimPlusConfiguration.disableCameraShake = disableCameraShake;
            }
            if (float.TryParse(data["Player"]["baseUnarmedDamage"], NumberStyles.Any, ci, out float baseUnarmedDamage))
            {
                valheimPlusConfiguration.baseUnarmedDamage = baseUnarmedDamage;
            }
            if (bool.TryParse(data["Player"]["cropNotifier"], out bool cropNotifier))
            {
                valheimPlusConfiguration.cropNotifier = cropNotifier;
            }
            #endregion Player

            #region Server
            if (bool.TryParse(data["Server"]["enabled"], out bool serverSettingsEnabled))
            {
                valheimPlusConfiguration.serverSettingsEnabled = serverSettingsEnabled;
            }
            if (int.TryParse(data["Server"]["maxPlayers"], out int maxPlayers))
            {
                valheimPlusConfiguration.maxPlayers = maxPlayers;
            }
            if (bool.TryParse(data["Server"]["disableServerPassword"], out bool disableServerPassword))
            {
                valheimPlusConfiguration.disableServerPassword = disableServerPassword;
            }
            //valheimPlusConfiguration.enforceConfiguration = bool.Parse(data["Server"]["enforceConfiguration"]); // Won't add backwards compatibility
            if (bool.TryParse(data["Server"]["enforceMod"], out bool enforceMod))
            {
                valheimPlusConfiguration.enforceMod = enforceMod;
            }
            if (int.TryParse(data["Server"]["dataRate"], out int dataRate))
            {
                valheimPlusConfiguration.dataRate = dataRate;
            }
            //if (int.TryParse(data["Server"]["autoSaveInterval"], out int autoSaveInterval))
            //{
            //    valheimPlusConfiguration.autoSaveInterval = autoSaveInterval;
            //}
            #endregion Server

            #region Stamina
            if (bool.TryParse(data["Stamina"]["enabled"], out bool staminaSettingsEnabled))
            {
                valheimPlusConfiguration.staminaSettingsEnabled = staminaSettingsEnabled;
            }
            if (int.TryParse(data["Stamina"]["dodgeStaminaUsage"], out int dodgeStaminaUsage))
            {
                valheimPlusConfiguration.dodgeStaminaUsage = dodgeStaminaUsage;
            }
            if (int.TryParse(data["Stamina"]["encumberedStaminaDrain"], out int encumberedStaminaDrain))
            {
                valheimPlusConfiguration.encumberedStaminaDrain = encumberedStaminaDrain;
            }
            if (int.TryParse(data["Stamina"]["jumpStaminaDrain"], out int jumpStaminaDrain))
            {
                valheimPlusConfiguration.jumpStaminaDrain = jumpStaminaDrain;
            }
            if (int.TryParse(data["Stamina"]["runStaminaDrain"], out int runStaminaDrain))
            {
                valheimPlusConfiguration.runStaminaDrain = runStaminaDrain;
            }
            if (int.TryParse(data["Stamina"]["sneakStaminaDrain"], out int sneakStaminaDrain))
            {
                valheimPlusConfiguration.sneakStaminaDrain = sneakStaminaDrain;
            }
            if (int.TryParse(data["Stamina"]["staminaRegen"], out int staminaRegen))
            {
                valheimPlusConfiguration.staminaRegen = staminaRegen;
            }
            if (float.TryParse(data["Stamina"]["staminaRegenDelay"], NumberStyles.Any, ci, out float staminaRegenDelay))
            {
                valheimPlusConfiguration.staminaRegenDelay = staminaRegenDelay;
            }
            if (int.TryParse(data["Stamina"]["swimStaminaDrain"], out int swimStaminaDrain))
            {
                valheimPlusConfiguration.swimStaminaDrain = swimStaminaDrain;
            }
            #endregion Stamina

            #region StaminaUsage
            if (bool.TryParse(data["StaminaUsage"]["enabled"], out bool staminaUsageSettingsEnabled))
            {
                valheimPlusConfiguration.staminaUsageSettingsEnabled = staminaUsageSettingsEnabled;
            }
            if (int.TryParse(data["StaminaUsage"]["axes"], out int axes))
            {
                valheimPlusConfiguration.axes = axes;
            }
            if (int.TryParse(data["StaminaUsage"]["bows"], out int bows))
            {
                valheimPlusConfiguration.bows = bows;
            }
            if (int.TryParse(data["StaminaUsage"]["clubs"], out int clubs))
            {
                valheimPlusConfiguration.clubs = clubs;
            }
            if (int.TryParse(data["StaminaUsage"]["knives"], out int knives))
            {
                valheimPlusConfiguration.knives = knives;
            }
            if (int.TryParse(data["StaminaUsage"]["pickaxes"], out int pickaxes))
            {
                valheimPlusConfiguration.pickaxes = pickaxes;
            }
            if (int.TryParse(data["StaminaUsage"]["polearms"], out int polearms))
            {
                valheimPlusConfiguration.polearms = polearms;
            }
            if (int.TryParse(data["StaminaUsage"]["spears"], out int spears))
            {
                valheimPlusConfiguration.spears = spears;
            }
            if (int.TryParse(data["StaminaUsage"]["swords"], out int swords))
            {
                valheimPlusConfiguration.swords = swords;
            }
            if (int.TryParse(data["StaminaUsage"]["unarmed"], out int unarmed))
            {
                valheimPlusConfiguration.unarmed = unarmed;
            }
            if (int.TryParse(data["StaminaUsage"]["hammer"], out int hammer))
            {
                valheimPlusConfiguration.hammer = hammer;
            }
            if (int.TryParse(data["StaminaUsage"]["hoe"], out int hoe))
            {
                valheimPlusConfiguration.hoe = hoe;
            }
            if (int.TryParse(data["StaminaUsage"]["cultivator"], out int cultivator))
            {
                valheimPlusConfiguration.cultivator = cultivator;
            }
            #endregion StaminaUsage

            #region Workbench
            if (bool.TryParse(data["Workbench"]["enabled"], out bool workbenchSettingsEnabled))
            {
                valheimPlusConfiguration.workbenchSettingsEnabled = workbenchSettingsEnabled;
            }
            if (int.TryParse(data["Workbench"]["workbenchRange"], out int workbenchRange))
            {
                valheimPlusConfiguration.workbenchRange = workbenchRange;
            }
            if (bool.TryParse(data["Workbench"]["disableRoofCheck"], out bool disableRoofCheck))
            {
                valheimPlusConfiguration.disableRoofCheck = disableRoofCheck;
            }
            #endregion Workbench

            #region Time
            //if (bool.TryParse(data["Time"]["enabled"], out bool timeSettingsEnabled))
            //{
            //    valheimPlusConfiguration.timeSettingsEnabled = timeSettingsEnabled;
            //}
            //if (int.TryParse(data["Time"]["totalDayTimeInSeconds"], out int totalDayTimeInSeconds))
            //{
            //    valheimPlusConfiguration.totalDayTimeInSeconds = totalDayTimeInSeconds;
            //}
            //if (int.TryParse(data["Time"]["nightTimeSpeedMultiplier"], out int nightTimeSpeedMultiplier))
            //{
            //    valheimPlusConfiguration.nightTimeSpeedMultiplier = nightTimeSpeedMultiplier;
            //}
            #endregion Time

            #region Ward
            if (bool.TryParse(data["Ward"]["enabled"], out bool wardSettingsEnabled))
            {
                valheimPlusConfiguration.wardSettingsEnabled = wardSettingsEnabled;
            }
            if (int.TryParse(data["Ward"]["wardRange"], out int wardRange))
            {
                valheimPlusConfiguration.wardRange = wardRange;
            }
            #endregion Ward

            #region StructuralIntegrity
            if (bool.TryParse(data["StructuralIntegrity"]["enabled"], out bool structuralIntegritySettingsEnabled))
            {
                valheimPlusConfiguration.structuralIntegritySettingsEnabled = structuralIntegritySettingsEnabled;
            }
            if (bool.TryParse(data["StructuralIntegrity"]["disableStructuralIntegrity"], out bool disableStructuralIntegrity))
            {
                valheimPlusConfiguration.disableStructuralIntegrity = disableStructuralIntegrity;
            }
            if (int.TryParse(data["StructuralIntegrity"]["wood"], out int wood))
            {
                valheimPlusConfiguration.wood = wood;
            }
            if (int.TryParse(data["StructuralIntegrity"]["stone"], out int stone))
            {
                valheimPlusConfiguration.stone = stone;
            }
            if (int.TryParse(data["StructuralIntegrity"]["iron"], out int iron))
            {
                valheimPlusConfiguration.iron = iron;
            }
            if (int.TryParse(data["StructuralIntegrity"]["hardWood"], out int hardWood))
            {
                valheimPlusConfiguration.hardWood = hardWood;
            }
            if (bool.TryParse(data["StructuralIntegrity"]["disableDamageToPlayerStructures"], out bool disableDamageToPlayerStructures))
            {
                valheimPlusConfiguration.disableDamageToPlayerStructures = disableDamageToPlayerStructures;
            }
            #endregion StructuralIntegrity

            #region Experience
            if (bool.TryParse(data["Experience"]["enabled"], out bool experienceSettingsEnabled))
            {
                valheimPlusConfiguration.experienceSettingsEnabled = experienceSettingsEnabled;
            }
            if (int.TryParse(data["Experience"]["swords"], out int experienceSwords))
            {
                valheimPlusConfiguration.experienceSwords = experienceSwords;
            }
            if (int.TryParse(data["Experience"]["knives"], out int experienceKnives))
            {
                valheimPlusConfiguration.experienceKnives = experienceKnives;
            }
            if (int.TryParse(data["Experience"]["clubs"], out int experienceClubs))
            {
                valheimPlusConfiguration.experienceClubs = experienceClubs;
            }
            if (int.TryParse(data["Experience"]["polearms"], out int experiencePolearms))
            {
                valheimPlusConfiguration.experiencePolearms = experiencePolearms;
            }
            if (int.TryParse(data["Experience"]["spears"], out int experienceSpears))
            {
                valheimPlusConfiguration.experienceSpears = experienceSpears;
            }
            if (int.TryParse(data["Experience"]["blocking"], out int experienceBlocking))
            {
                valheimPlusConfiguration.experienceBlocking = experienceBlocking;
            }
            if (int.TryParse(data["Experience"]["axes"], out int experienceAxes))
            {
                valheimPlusConfiguration.experienceAxes = experienceAxes;
            }
            if (int.TryParse(data["Experience"]["bows"], out int experienceBows))
            {
                valheimPlusConfiguration.experienceBows = experienceBows;
            }
            if (int.TryParse(data["Experience"]["fireMagic"], out int experienceFireMagic))
            {
                valheimPlusConfiguration.experienceFireMagic = experienceFireMagic;
            }
            if (int.TryParse(data["Experience"]["frostMagic"], out int experienceFrostMagic))
            {
                valheimPlusConfiguration.experienceFrostMagic = experienceFrostMagic;
            }
            if (int.TryParse(data["Experience"]["unarmed"], out int experienceUnarmed))
            {
                valheimPlusConfiguration.experienceUnarmed = experienceUnarmed;
            }
            if (int.TryParse(data["Experience"]["pickaxes"], out int experiencePickaxes))
            {
                valheimPlusConfiguration.experiencePickaxes = experiencePickaxes;
            }
            if (int.TryParse(data["Experience"]["woodCutting"], out int experienceWoodCutting))
            {
                valheimPlusConfiguration.experienceWoodCutting = experienceWoodCutting;
            }
            if (int.TryParse(data["Experience"]["jump"], out int experienceJump))
            {
                valheimPlusConfiguration.experienceJump = experienceJump;
            }
            if (int.TryParse(data["Experience"]["sneak"], out int experienceSneak))
            {
                valheimPlusConfiguration.experienceSneak = experienceSneak;
            }
            if (int.TryParse(data["Experience"]["run"], out int experienceRun))
            {
                valheimPlusConfiguration.experienceRun = experienceRun;
            }
            if (int.TryParse(data["Experience"]["swim"], out int experienceSwim))
            {
                valheimPlusConfiguration.experienceSwim = experienceSwim;
            }
            if (Int32.TryParse(data["Experience"]["hammer"], out int experienceHammer)) // Added in case Iron Gate adds XP for hammers
            {
                valheimPlusConfiguration.experienceHammer = experienceHammer;
            }
            if (Int32.TryParse(data["Experience"]["hoe"], out int experienceHoe)) // Added in case Iron Gate adds XP for hoes
            {
                valheimPlusConfiguration.experienceHoe = experienceHoe;
            }
            #endregion Experience

            #region Camera
            if (bool.TryParse(data["Camera"]["enabled"], out bool cameraSettingsEnabled))
            {
                valheimPlusConfiguration.cameraSettingsEnabled = cameraSettingsEnabled;
            }
            if (Int32.TryParse(data["Camera"]["cameraMaximumZoomDistance"], out int cameraMaximumZoomDistance)) // Added in case Iron Gate adds XP for hoes
            {
                valheimPlusConfiguration.cameraMaximumZoomDistance = cameraMaximumZoomDistance;
            }
            if (Int32.TryParse(data["Camera"]["cameraBoatMaximumZoomDistance"], out int cameraBoatMaximumZoomDistance)) // Added in case Iron Gate adds XP for hoes
            {
                valheimPlusConfiguration.cameraBoatMaximumZoomDistance = cameraBoatMaximumZoomDistance;
            }
            if (Int32.TryParse(data["Camera"]["cameraFOV"], out int cameraFOV)) // Added in case Iron Gate adds XP for hoes
            {
                valheimPlusConfiguration.cameraFOV = cameraFOV;
            }
            #endregion Camera

            #region Wagon
            if (bool.TryParse(data["Wagon"]["enabled"], out bool wagonSettingsEnabled))
            {
                valheimPlusConfiguration.wagonSettingsEnabled = wagonSettingsEnabled;
            }
            if (Int32.TryParse(data["Wagon"]["wagonBaseMass"], out int wagonBaseMass))
            {
                valheimPlusConfiguration.wagonBaseMass = wagonBaseMass;
            }
            if (Int32.TryParse(data["Wagon"]["wagonExtraMassFromItems"], out int wagonExtraMassFromItems))
            {
                valheimPlusConfiguration.wagonExtraMassFromItems = wagonExtraMassFromItems;
            }
            #endregion Wagon

            return valheimPlusConfiguration;
        }

        public static bool WriteConfigFile(ValheimPlusConf valheimPlusConfiguration, bool manageClient)
        {
            Settings settings = SettingsDAL.GetSettings();
            IniData data;

            var parser = new FileIniDataParser();
            IniParserConfiguration iniParserConfiguration = parser.Parser.Configuration;
            iniParserConfiguration.AllowCreateSectionsOnFly = true;

            // Reading the current configuration file
            if (manageClient)
            {
                data = parser.ReadFile(string.Format("{0}BepInEx/config/valheim_plus.cfg", settings.ClientInstallationPath));
            }
            else
            {
                data = parser.ReadFile(string.Format("{0}BepInEx/config/valheim_plus.cfg", settings.ServerInstallationPath));
            }

            // Advanced building mode settings
            data["AdvancedBuildingMode"]["enabled"] = valheimPlusConfiguration.advancedBuildingModeEnabled.ToString().ToLower();
            data["AdvancedBuildingMode"]["enterAdvancedBuildingMode"] = valheimPlusConfiguration.enterAdvancedBuildingMode.ToString();
            data["AdvancedBuildingMode"]["exitAdvancedBuildingMode"] = valheimPlusConfiguration.exitAdvancedBuildingMode.ToString();
            data["AdvancedBuildingMode"]["copyObjectRotation"] = valheimPlusConfiguration.copyObjectRotation.ToString();
            data["AdvancedBuildingMode"]["pasteObjectRotation"] = valheimPlusConfiguration.pasteObjectRotation.ToString();

            // Advanced editing mode settings
            data["AdvancedEditingMode"]["enabled"] = valheimPlusConfiguration.advancedEditingModeEnabled.ToString().ToLower();
            data["AdvancedEditingMode"]["enterAdvancedEditingMode"] = valheimPlusConfiguration.enterAdvancedEditingMode.ToString();
            data["AdvancedEditingMode"]["resetAdvancedEditingMode"] = valheimPlusConfiguration.resetAdvancedEditingMode.ToString();
            data["AdvancedEditingMode"]["abortAndExitAdvancedEditingMode"] = valheimPlusConfiguration.abortAndExitAdvancedEditingMode.ToString();
            data["AdvancedEditingMode"]["confirmPlacementOfAdvancedEditingMode"] = valheimPlusConfiguration.confirmPlacementOfAdvancedEditingMode.ToString();
            data["AdvancedEditingMode"]["copyObjectRotation"] = valheimPlusConfiguration.copyObjectRotationAEM.ToString();
            data["AdvancedEditingMode"]["pasteObjectRotation"] = valheimPlusConfiguration.pasteObjectRotationAEM.ToString();

            // Armor
            data["Armor"]["enabled"] = valheimPlusConfiguration.armorSettingsEnabled.ToString().ToLower();
            data["Armor"]["helmets"] = valheimPlusConfiguration.helmetsArmor.ToString();
            data["Armor"]["chests"] = valheimPlusConfiguration.chestsArmor.ToString();
            data["Armor"]["legs"] = valheimPlusConfiguration.legsArmor.ToString();
            data["Armor"]["capes"] = valheimPlusConfiguration.capesArmor.ToString();

            // Beehive
            data["Beehive"]["enabled"] = valheimPlusConfiguration.beehiveSettingsEnabled.ToString().ToLower();
            data["Beehive"]["honeyProductionSpeed"] = valheimPlusConfiguration.honeyProductionSpeed.ToString();
            data["Beehive"]["maximumHoneyPerBeehive"] = valheimPlusConfiguration.maximumHoneyPerBeehive.ToString();

            // Building
            data["Building"]["enabled"] = valheimPlusConfiguration.buildingSettingsEnabled.ToString().ToLower();
            data["Building"]["maximumPlacementDistance"] = valheimPlusConfiguration.maximumPlacementDistance.ToString().ToLower();
            data["Building"]["noWeatherDamage"] = valheimPlusConfiguration.noWeatherDamage.ToString();
            data["Building"]["noInvalidPlacementRestriction"] = valheimPlusConfiguration.noInvalidPlacementRestriction.ToString();

            // Durability
            data["Durability"]["enabled"] = valheimPlusConfiguration.durabilitySettingsEnabled.ToString().ToLower();
            data["Durability"]["axes"] = valheimPlusConfiguration.axesDurability.ToString();
            data["Durability"]["pickaxes"] = valheimPlusConfiguration.pickaxesDurability.ToString();
            data["Durability"]["hammer"] = valheimPlusConfiguration.hammerDurability.ToString();
            data["Durability"]["cultivator"] = valheimPlusConfiguration.cultivatorDurability.ToString();
            data["Durability"]["hoe"] = valheimPlusConfiguration.hoeDurability.ToString();
            data["Durability"]["weapons"] = valheimPlusConfiguration.weaponsDurability.ToString();
            data["Durability"]["armor"] = valheimPlusConfiguration.armorDurability.ToString();
            data["Durability"]["bows"] = valheimPlusConfiguration.bowsDurability.ToString();
            data["Durability"]["shields"] = valheimPlusConfiguration.shieldsDurability.ToString();

            // Inventory
            data["Inventory"]["enabled"] = valheimPlusConfiguration.inventorySettingsEnabled.ToString().ToLower();
            data["Inventory"]["inventoryFillTopToBottom"] = valheimPlusConfiguration.inventoryFillTopToBottom.ToString().ToLower();
            data["Inventory"]["playerInventoryRows"] = valheimPlusConfiguration.playerInventoryRows.ToString();
            data["Inventory"]["woodChestColumns"] = valheimPlusConfiguration.woodChestColumns.ToString();
            data["Inventory"]["woodChestRows"] = valheimPlusConfiguration.woodChestRows.ToString();
            data["Inventory"]["ironChestColumns"] = valheimPlusConfiguration.ironChestColumns.ToString();
            data["Inventory"]["ironChestRows"] = valheimPlusConfiguration.ironChestRows.ToString();

            // Items
            data["Items"]["enabled"] = valheimPlusConfiguration.itemsSettingsEnabled.ToString().ToLower();
            data["Items"]["noTeleportPrevention"] = valheimPlusConfiguration.noTeleportPrevention.ToString().ToLower();
            data["Items"]["baseItemWeightReduction"] = valheimPlusConfiguration.baseItemWeightReduction.ToString();
            data["Items"]["itemStackMultiplier"] = valheimPlusConfiguration.itemStackMultiplier.ToString();
            data["Items"]["droppedItemOnGroundDurationInSeconds"] = valheimPlusConfiguration.droppedItemOnGroundDurationInSeconds.ToString();

            // Fermenter
            data["Fermenter"]["enabled"] = valheimPlusConfiguration.fermenterSettingsEnabled.ToString().ToLower();
            data["Fermenter"]["fermenterDuration"] = valheimPlusConfiguration.fermenterDuration.ToString();
            data["Fermenter"]["fermenterItemsProduced"] = valheimPlusConfiguration.fermenterItemsProduced.ToString();
            data["Fermenter"]["showFermenterDuration"] = valheimPlusConfiguration.showFermenterDuration.ToString().ToLower();

            // Fireplace
            data["Fireplace"]["enabled"] = valheimPlusConfiguration.fireplaceSettingsEnabled.ToString().ToLower();
            data["Fireplace"]["onlyTorches"] = valheimPlusConfiguration.onlyTorches.ToString().ToLower();

            // Food
            data["Food"]["enabled"] = valheimPlusConfiguration.foodSettingsEnabled.ToString().ToLower();
            data["Food"]["foodDurationMultiplier"] = valheimPlusConfiguration.foodDurationMultiplier.ToString();

            // Furnace
            data["Furnace"]["enabled"] = valheimPlusConfiguration.furnaceSettingsEnabled.ToString().ToLower();
            data["Furnace"]["maximumOre"] = valheimPlusConfiguration.maximumOre.ToString();
            data["Furnace"]["maximumCoal"] = valheimPlusConfiguration.maximumCoal.ToString();
            data["Furnace"]["coalUsedPerProduct"] = valheimPlusConfiguration.coalUsedPerProduct.ToString();
            data["Furnace"]["productionSpeed"] = valheimPlusConfiguration.furnaceProductionSpeed.ToString();
            data["Furnace"]["autoDeposit"] = valheimPlusConfiguration.autoDepositFurnace.ToString().ToLower();
            data["Furnace"]["autoDepositRange"] = valheimPlusConfiguration.autoDepositRangeFurnace.ToString();

            #region Game
            data["Game"]["enabled"] = valheimPlusConfiguration.gameSettingsEnabled.ToString().ToLower();
            data["Game"]["gameDifficultyDamageScale"] = valheimPlusConfiguration.gameDifficultyDamageScale.ToString();
            data["Game"]["gameDifficultyHealthScale"] = valheimPlusConfiguration.gameDifficultyHealthScale.ToString();
            data["Game"]["extraPlayerCountNearby"] = valheimPlusConfiguration.extraPlayerCountNearby.ToString();
            data["Game"]["setFixedPlayerCountTo"] = valheimPlusConfiguration.setFixedPlayerCountTo.ToString();
            data["Game"]["difficultyScaleRange"] = valheimPlusConfiguration.difficultyScaleRange.ToString();
            data["Game"]["disablePortals"] = valheimPlusConfiguration.disablePortals.ToString().ToLower();
            #endregion Game

            #region Gathering
            data["Gathering"]["enabled"] = valheimPlusConfiguration.gatheringSettingsEnabled.ToString().ToLower();
            data["Gathering"]["wood"] = valheimPlusConfiguration.woodGathering.ToString();
            data["Gathering"]["stone"] = valheimPlusConfiguration.stoneGathering.ToString();
            data["Gathering"]["fineWood"] = valheimPlusConfiguration.fineWoodGathering.ToString();
            data["Gathering"]["coreWood"] = valheimPlusConfiguration.coreWoodGathering.ToString();
            data["Gathering"]["elderBark"] = valheimPlusConfiguration.elderBarkGathering.ToString();
            data["Gathering"]["ironScrap"] = valheimPlusConfiguration.ironScrapGathering.ToString();
            data["Gathering"]["tinOre"] = valheimPlusConfiguration.tinOreGathering.ToString();
            data["Gathering"]["copperOre"] = valheimPlusConfiguration.copperOreGathering.ToString();
            data["Gathering"]["silverOre"] = valheimPlusConfiguration.silverOreGathering.ToString();
            data["Gathering"]["chitin"] = valheimPlusConfiguration.chitinGathering.ToString();
            data["Gathering"]["dropChance"] = valheimPlusConfiguration.dropChanceGathering.ToString();
            #endregion Gathering

            // Hotkeys
            data["Hotkeys"]["enabled"] = valheimPlusConfiguration.hotkeysSettingsEnabled.ToString().ToLower();
            data["Hotkeys"]["rollForwards"] = valheimPlusConfiguration.rollForwards.ToString();
            data["Hotkeys"]["rollBackwards"] = valheimPlusConfiguration.rollBackwards.ToString();

            // Hud
            data["Hud"]["enabled"] = valheimPlusConfiguration.hudSettingsEnabled.ToString().ToLower();
            data["Hud"]["showRequiredItems"] = valheimPlusConfiguration.showRequiredItems.ToString().ToLower();
            data["Hud"]["experienceGainedNotifications"] = valheimPlusConfiguration.experienceGainedNotifications.ToString().ToLower();
            data["Hud"]["displayStaminaValue"] = valheimPlusConfiguration.displayStaminaValue.ToString().ToLower();
            data["Hud"]["removeDamageFlash"] = valheimPlusConfiguration.removeDamageFlash.ToString().ToLower();

            // Kiln
            data["Kiln"]["enabled"] = valheimPlusConfiguration.kilnSettingsEnabled.ToString().ToLower();
            data["Kiln"]["maximumWood"] = valheimPlusConfiguration.maximumWood.ToString();
            data["Kiln"]["productionSpeed"] = valheimPlusConfiguration.kilnProductionSpeed.ToString();
            data["Kiln"]["autoDeposit"] = valheimPlusConfiguration.autoDepositKiln.ToString().ToLower();
            data["Kiln"]["autoDepositRange"] = valheimPlusConfiguration.autoDepositRangeKiln.ToString();

            // Map
            data["Map"]["enabled"] = valheimPlusConfiguration.mapSettingsEnabled.ToString().ToLower();
            data["Map"]["shareMapProgression"] = valheimPlusConfiguration.shareMapProgression.ToString().ToLower();
            data["Map"]["exploreRadius"] = valheimPlusConfiguration.exploreRadius.ToString();
            data["Map"]["playerPositionPublicOnJoin"] = valheimPlusConfiguration.playerPositionPublicOnJoin.ToString().ToLower();
            data["Map"]["preventPlayerFromTurningOffPublicPosition"] = valheimPlusConfiguration.preventPlayerFromTurningOffPublicPosition.ToString().ToLower();
            data["Map"]["removeDeathPinOnTombstoneEmpty"] = valheimPlusConfiguration.removeDeathPinOnTombstoneEmpty.ToString().ToLower();

            #region Player
            data["Player"]["enabled"] = valheimPlusConfiguration.playerSettingsEnabled.ToString().ToLower();
            data["Player"]["baseMaximumWeight"] = valheimPlusConfiguration.baseMaximumWeight.ToString();
            data["Player"]["baseMegingjordBuff"] = valheimPlusConfiguration.baseMegingjordBuff.ToString();
            data["Player"]["baseAutoPickUpRange"] = valheimPlusConfiguration.baseAutoPickUpRange.ToString();
            data["Player"]["disableCameraShake"] = valheimPlusConfiguration.disableCameraShake.ToString().ToLower();
            data["Player"]["baseUnarmedDamage"] = valheimPlusConfiguration.baseUnarmedDamage.ToString();
            data["Player"]["cropNotifier"] = valheimPlusConfiguration.cropNotifier.ToString().ToLower();
            #endregion Player

            // Server
            data["Server"]["enabled"] = valheimPlusConfiguration.serverSettingsEnabled.ToString().ToLower();
            data["Server"]["maxPlayers"] = valheimPlusConfiguration.maxPlayers.ToString();
            data["Server"]["disableServerPassword"] = valheimPlusConfiguration.disableServerPassword.ToString().ToLower();
            data["Server"]["enforceMod"] = valheimPlusConfiguration.enforceMod.ToString().ToLower();
            data["Server"]["dataRate"] = valheimPlusConfiguration.dataRate.ToString();
            //data["Server"]["autoSaveInterval"] = valheimPlusConfiguration.autoSaveInterval.ToString();

            // Stamina
            data["Stamina"]["enabled"] = valheimPlusConfiguration.staminaSettingsEnabled.ToString().ToLower();
            data["Stamina"]["dodgeStaminaUsage"] = valheimPlusConfiguration.dodgeStaminaUsage.ToString();
            data["Stamina"]["encumberedStaminaDrain"] = valheimPlusConfiguration.encumberedStaminaDrain.ToString();
            data["Stamina"]["jumpStaminaDrain"] = valheimPlusConfiguration.jumpStaminaDrain.ToString();
            data["Stamina"]["runStaminaDrain"] = valheimPlusConfiguration.runStaminaDrain.ToString();
            data["Stamina"]["sneakStaminaDrain"] = valheimPlusConfiguration.sneakStaminaDrain.ToString();
            data["Stamina"]["staminaRegen"] = valheimPlusConfiguration.staminaRegen.ToString();
            data["Stamina"]["staminaRegenDelay"] = valheimPlusConfiguration.staminaRegenDelay.ToString();
            data["Stamina"]["swimStaminaDrain"] = valheimPlusConfiguration.swimStaminaDrain.ToString();

            // StaminaUsage
            data["StaminaUsage"]["enabled"] = valheimPlusConfiguration.staminaUsageSettingsEnabled.ToString().ToLower();
            data["StaminaUsage"]["axes"] = valheimPlusConfiguration.axes.ToString();
            data["StaminaUsage"]["bows"] = valheimPlusConfiguration.bows.ToString();
            data["StaminaUsage"]["clubs"] = valheimPlusConfiguration.clubs.ToString();
            data["StaminaUsage"]["knives"] = valheimPlusConfiguration.knives.ToString();
            data["StaminaUsage"]["pickaxes"] = valheimPlusConfiguration.pickaxes.ToString();
            data["StaminaUsage"]["polearms"] = valheimPlusConfiguration.polearms.ToString();
            data["StaminaUsage"]["spears"] = valheimPlusConfiguration.spears.ToString();
            data["StaminaUsage"]["swords"] = valheimPlusConfiguration.swords.ToString();
            data["StaminaUsage"]["unarmed"] = valheimPlusConfiguration.unarmed.ToString();
            data["StaminaUsage"]["hammer"] = valheimPlusConfiguration.hammer.ToString();
            data["StaminaUsage"]["hoe"] = valheimPlusConfiguration.hoe.ToString();
            data["StaminaUsage"]["cultivator"] = valheimPlusConfiguration.cultivator.ToString();

            // Workbench
            data["Workbench"]["enabled"] = valheimPlusConfiguration.workbenchSettingsEnabled.ToString().ToLower();
            data["Workbench"]["workbenchRange"] = valheimPlusConfiguration.workbenchRange.ToString();
            data["Workbench"]["disableRoofCheck"] = valheimPlusConfiguration.disableRoofCheck.ToString().ToLower();

            // Time
            //data["Time"]["enabled"] = valheimPlusConfiguration.timeSettingsEnabled.ToString().ToLower();
            //data["Time"]["totalDayTimeInSeconds"] = valheimPlusConfiguration.totalDayTimeInSeconds.ToString();
            //data["Time"]["nightTimeSpeedMultiplier"] = valheimPlusConfiguration.nightTimeSpeedMultiplier.ToString();

            // Ward
            data["Ward"]["enabled"] = valheimPlusConfiguration.wardSettingsEnabled.ToString().ToLower();
            data["Ward"]["wardRange"] = valheimPlusConfiguration.wardRange.ToString().ToLower();

            #region StructuralIntegrity
            data["StructuralIntegrity"]["enabled"] = valheimPlusConfiguration.structuralIntegritySettingsEnabled.ToString().ToLower();
            data["StructuralIntegrity"]["wood"] = valheimPlusConfiguration.wood.ToString();
            data["StructuralIntegrity"]["stone"] = valheimPlusConfiguration.stone.ToString();
            data["StructuralIntegrity"]["iron"] = valheimPlusConfiguration.iron.ToString();
            data["StructuralIntegrity"]["hardWood"] = valheimPlusConfiguration.hardWood.ToString();
            data["StructuralIntegrity"]["disableStructuralIntegrity"] = valheimPlusConfiguration.disableStructuralIntegrity.ToString().ToLower();
            data["StructuralIntegrity"]["disableDamageToPlayerStructures"] = valheimPlusConfiguration.disableDamageToPlayerStructures.ToString().ToLower();
            #endregion StructuralIntegrity

            // Experience
            data["Experience"]["enabled"] = valheimPlusConfiguration.experienceSettingsEnabled.ToString().ToLower();
            data["Experience"]["swords"] = valheimPlusConfiguration.experienceSwords.ToString();
            data["Experience"]["knives"] = valheimPlusConfiguration.experienceKnives.ToString();
            data["Experience"]["clubs"] = valheimPlusConfiguration.experienceClubs.ToString();
            data["Experience"]["polearms"] = valheimPlusConfiguration.experiencePolearms.ToString();
            data["Experience"]["spears"] = valheimPlusConfiguration.experienceSpears.ToString();
            data["Experience"]["blocking"] = valheimPlusConfiguration.experienceBlocking.ToString();
            data["Experience"]["axes"] = valheimPlusConfiguration.experienceAxes.ToString();
            data["Experience"]["bows"] = valheimPlusConfiguration.experienceBows.ToString();
            data["Experience"]["fireMagic"] = valheimPlusConfiguration.experienceFireMagic.ToString();
            data["Experience"]["frostMagic"] = valheimPlusConfiguration.experienceFrostMagic.ToString();
            data["Experience"]["unarmed"] = valheimPlusConfiguration.experienceUnarmed.ToString();
            data["Experience"]["pickaxes"] = valheimPlusConfiguration.experiencePickaxes.ToString();
            data["Experience"]["woodCutting"] = valheimPlusConfiguration.experienceWoodCutting.ToString();
            data["Experience"]["jump"] = valheimPlusConfiguration.experienceJump.ToString();
            data["Experience"]["sneak"] = valheimPlusConfiguration.experienceSneak.ToString();
            data["Experience"]["run"] = valheimPlusConfiguration.experienceRun.ToString();
            data["Experience"]["swim"] = valheimPlusConfiguration.experienceSwim.ToString();
            data["Experience"]["hammer"] = valheimPlusConfiguration.experienceHammer.ToString();
            data["Experience"]["hoe"] = valheimPlusConfiguration.experienceHoe.ToString();

            // Camera
            data["Camera"]["enabled"] = valheimPlusConfiguration.cameraSettingsEnabled.ToString().ToLower();
            data["Camera"]["cameraMaximumZoomDistance"] = valheimPlusConfiguration.cameraMaximumZoomDistance.ToString().ToLower();
            data["Camera"]["cameraBoatMaximumZoomDistance"] = valheimPlusConfiguration.cameraBoatMaximumZoomDistance.ToString().ToLower();
            data["Camera"]["cameraFOV"] = valheimPlusConfiguration.cameraFOV.ToString().ToLower();

            // Wagon
            data["Wagon"]["enabled"] = valheimPlusConfiguration.wagonSettingsEnabled.ToString().ToLower();
            data["Wagon"]["wagonBaseMass"] = valheimPlusConfiguration.wagonBaseMass.ToString();
            data["Wagon"]["wagonExtraMassFromItems"] = valheimPlusConfiguration.wagonExtraMassFromItems.ToString();

            // Writing the new settings to configuration file
            try
            {
                if (manageClient)
                {
                    parser.WriteFile(string.Format("{0}BepInEx/config/valheim_plus.cfg", settings.ClientInstallationPath), data);
                }
                else
                {
                    parser.WriteFile(string.Format("{0}BepInEx/config/valheim_plus.cfg", settings.ServerInstallationPath), data);
                }

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        private ConfigManager()
        {
        }
        private static ConfigManager instance = null;
        public static ConfigManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConfigManager();
                }
                return instance;
            }
        }
    }
}
