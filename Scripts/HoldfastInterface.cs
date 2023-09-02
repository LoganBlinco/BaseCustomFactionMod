using HoldfastSharedMethods;
using UnityEngine;
using Assets.Assets.BaseCustomFactions.HoldfastCustomFactions_main.Scripts.Config;
using BaseCustomFactions.Core;

namespace BaseCustomFactions
{
    public class HoldfastInterface : IHoldfastSharedMethods
    {
        private bool _isServer = false;
        private int _clientsID = 0;
        private ulong _clientsSteamID = 0;

        private CustomFactionReplacementOverload _customFactionReplacementOverload;

        private Configuration _config;
        

        public void OnIsServer(bool server)
        {
            _isServer = server;
            if (server) { return; }

            _customFactionReplacementOverload = GameObject.FindObjectOfType<CustomFactionReplacementOverload>();
        }

		public void PassConfigVariables(string[] value)
		{
            _config = new Configuration();
            ConfigVariableManager.PassConfigVariables(value, _config);
		}


		public void OnRoundDetails(int roundId, string serverName, string mapName, FactionCountry attackingFaction,
            FactionCountry defendingFaction, GameplayMode gameplayMode, GameType gameType)
        {
            if (_isServer) { return; }

            _customFactionReplacementOverload?.RoundDetailsAsync(attackingFaction, defendingFaction, _config);
        }

        public void OnTextMessage(int playerId, TextChatChannel channel, string text)
        {
            //WeaponSwapTest script = GameObject.FindObjectOfType<WeaponSwapTest>();
            //script.SwapThem();
        }

        public void OnIsClient(bool client, ulong steamId)
        {
            _clientsSteamID = steamId;
        }

        public void OnPlayerJoined(int playerId, ulong steamId, string name, string regimentTag, bool isBot)
        {
            if (_isServer) { return; }

            if (steamId == _clientsSteamID)
            {
                _clientsID = playerId;
            }
        }

        public void OnPlayerSpawned(int playerId, int spawnSectionId, FactionCountry playerFaction,
            PlayerClass playerClass,
            int uniformId, GameObject playerObject)
        {
            if (_isServer) { return; }
            
            if (playerId == _clientsID)
            {
                _customFactionReplacementOverload?.OnPlayerSpawnedAsync(playerFaction);
            }
        }

        public void OnRoundEndFactionWinner(FactionCountry factionCountry, FactionRoundWinnerReason reason)
        {
            if (_isServer) { return; }

            _customFactionReplacementOverload?.OnRoundEndFactionWinnerAsync(factionCountry, reason);
        }
        
        public void OnEmplacementPlaced(int itemId, GameObject objectBuilt, EmplacementType emplacementType)
        {
            //parant is an object in scane. probably root node.
        }

        public void OnEmplacementConstructed(int itemId)
        {
        }
        


        public void OnSyncValueState(int value)
        {
        }

        public void OnUpdateSyncedTime(double time)
        {
        }

        public void OnUpdateElapsedTime(float time)
        {
        }

        public void OnUpdateTimeRemaining(float time)
        {
        }




        public void OnPlayerLeft(int playerId)
        {
        }

        public void OnPlayerHurt(int playerId, byte oldHp, byte newHp, EntityHealthChangedReason reason)
        {
        }

        public void OnPlayerKilledPlayer(int killerPlayerId, int victimPlayerId, EntityHealthChangedReason reason,
            string details)
        {
        }

        public void OnScorableAction(int playerId, int score, ScorableActionType reason)
        {
        }

        public void OnPlayerShoot(int playerId, bool dryShot)
        {
        }

        public void OnShotInfo(int playerId, int shotCount, Vector3[][] shotsPointsPositions,
            float[] trajectileDistances,
            float[] distanceFromFiringPositions, float[] horizontalDeviationAngles,
            float[] maxHorizontalDeviationAngles,
            float[] muzzleVelocities, float[] gravities, float[] damageHitBaseDamages, float[] damageRangeUnitValues,
            float[] damagePostTraitAndBuffValues, float[] totalDamages, Vector3[] hitPositions, Vector3[] hitDirections,
            int[] hitPlayerIds, int[] hitDamageableObjectIds, int[] hitShipIds, int[] hitVehicleIds)
        {
        }

        public void OnPlayerBlock(int attackingPlayerId, int defendingPlayerId)
        {
        }

        public void OnPlayerMeleeStartSecondaryAttack(int playerId)
        {
        }

        public void OnPlayerWeaponSwitch(int playerId, string weapon)
        {
        }

        public void OnPlayerStartCarry(int playerId, CarryableObjectType carryableObject)
        {
        }

        public void OnPlayerEndCarry(int playerId)
        {
        }

        public void OnPlayerShout(int playerId, CharacterVoicePhrase voicePhrase)
        {
        }

        public void OnConsoleCommand(string input, string output, bool success)
        {
        }

        public void OnRCLogin(int playerId, string inputPassword, bool isLoggedIn)
        {
        }

        public void OnRCCommand(int playerId, string input, string output, bool success)
        {
        }

        public void OnAdminPlayerAction(int playerId, int adminId, ServerAdminAction action, string reason)
        {
        }

        public void OnDamageableObjectDamaged(GameObject damageableObject, int damageableObjectId, int shipId,
            int oldHp, int newHp)
        {
            Debug.Log($"object damaged {damageableObject.name}");
        }

        public void OnInteractableObjectInteraction(int playerId, int interactableObjectId,
            GameObject interactableObject,
            InteractionActivationType interactionActivationType, int nextActivationStateTransitionIndex)
        {
        }



        public void OnCapturePointCaptured(int capturePoint)
        {
        }

        public void OnCapturePointOwnerChanged(int capturePoint, FactionCountry factionCountry)
        {
        }

        public void OnCapturePointDataUpdated(int capturePoint, int defendingPlayerCount, int attackingPlayerCount)
        {
        }

        public void OnBuffStart(int playerId, BuffType buff)
        {
        }

        public void OnBuffStop(int playerId, BuffType buff)
        {
        }


        public void OnRoundEndPlayerWinner(int playerId)
        {
        }

        public void OnVehicleSpawned(int vehicleId, FactionCountry vehicleFaction, PlayerClass vehicleClass,
            GameObject vehicleObject,
            int ownerPlayerId)
        {
        }

        public void OnVehicleHurt(int vehicleId, byte oldHp, byte newHp, EntityHealthChangedReason reason)
        {
        }

        public void OnPlayerKilledVehicle(int killerPlayerId, int victimVehicleId, EntityHealthChangedReason reason,
            string details)
        {
        }

        public void OnShipSpawned(int shipId, GameObject shipObject, FactionCountry shipfaction, ShipType shipType,
            int shipName)
        {
        }

        public void OnShipDamaged(int shipId, int oldHp, int newHp)
        {
        }
    }
}