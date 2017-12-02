using System;
using System.Dynamic;

namespace DiscordRest.Data
{
    public class Permissions
    {
        private ulong _rawValue { get; set; }
        private PermissionType _flags
        {
            get => (PermissionType) _rawValue;
            set { _rawValue = (ulong)value; }
        }

        public Permissions(ulong rawPermissions)
        {
            _rawValue = rawPermissions;
        }

        public ulong RawValue => _rawValue;

        public bool IsAdmin
        {
            get => _flags.HasFlag(PermissionType.Administrator);
            set => _setFlag(PermissionType.Administrator, value);
        }

        public bool IsManager
        {
            get => _flags.HasFlag(PermissionType.ManageGuild);
            set => _setFlag(PermissionType.ManageGuild, value);
        }

        public bool CanConnect  
        {
            get => _flags.HasFlag(PermissionType.Connect);
            set => _setFlag(PermissionType.Connect, value);
        }

        public bool CanAddReactions
        {
            get => _flags.HasFlag(PermissionType.AddReactions);
            set => _setFlag(PermissionType.AddReactions, value);
        }

        public bool CanAttachFiles
        {
            get => _flags.HasFlag(PermissionType.AttachFiles);
            set => _setFlag(PermissionType.AttachFiles, value);
        }

        public bool CanBanMembers   
        {
            get => _flags.HasFlag(PermissionType.BanMembers);
            set => _setFlag(PermissionType.BanMembers, value);
        }

        public bool CanChangeNickname
        {   
            get => _flags.HasFlag(PermissionType.ChangeNickname);
            set => _setFlag(PermissionType.ChangeNickname, value);
        }

        public bool CanCreateInstantInvite
        {
            get => _flags.HasFlag(PermissionType.CreateInstantInvite);
            set => _setFlag(PermissionType.CreateInstantInvite, value);
        }

        public bool CanDeafenMembers
        {
            get => _flags.HasFlag(PermissionType.DeafenMembers);
            set => _setFlag(PermissionType.DeafenMembers, value);
        }

        public bool CanEmbedLinks
        {
            get => _flags.HasFlag(PermissionType.EmbedLinks);
            set => _setFlag(PermissionType.EmbedLinks, value);
        }

        public bool CanKickMembers
        {
            get => _flags.HasFlag(PermissionType.KickMembers);
            set => _setFlag(PermissionType.KickMembers, value);
        }

        public bool CanManageChannels
        {
            get => _flags.HasFlag(PermissionType.ManageChannels);
            set => _setFlag(PermissionType.ManageChannels, value);
        }

        public bool CanManageEmojis
        {
            get => _flags.HasFlag(PermissionType.ManageEmojis);
            set => _setFlag(PermissionType.ManageEmojis, value);
        }

        public bool CanManageMessages
        {
            get => _flags.HasFlag(PermissionType.ManageMessages);
            set => _setFlag(PermissionType.ManageMessages, value);
        }

        public bool CanManageRoles
        {
            get => _flags.HasFlag(PermissionType.ManageRoles);
            set => _setFlag(PermissionType.ManageRoles, value);
        }

        public bool CanManageWebhooks
        {
            get => _flags.HasFlag(PermissionType.ManageWebhooks);
            set => _setFlag(PermissionType.ManageWebhooks, value);
        }

        public bool CanMentionEveryone
        {
            get => _flags.HasFlag(PermissionType.MentionEveryone);
            set => _setFlag(PermissionType.MentionEveryone, value);
        }

        public bool CanMoveMembers
        {
            get => _flags.HasFlag(PermissionType.MoveMembers);
            set => _setFlag(PermissionType.MoveMembers, value);
        }

        public bool CanReadMessageHistory
        {
            get => _flags.HasFlag(PermissionType.ReadMessageHistory);
            set => _setFlag(PermissionType.ReadMessageHistory, value);
        }

        public bool CanReadMessages
        {
            get => _flags.HasFlag(PermissionType.ReadMessages);
            set => _setFlag(PermissionType.ReadMessages, value);
        }

        public bool CanMuteMembers
        {
            get => _flags.HasFlag(PermissionType.MuteMembers);
            set => _setFlag(PermissionType.MuteMembers, value);
        }

        public bool CanSendMessages
        {
            get => _flags.HasFlag(PermissionType.SendMessages);
            set => _setFlag(PermissionType.SendMessages, value);
        }

        public bool CanSendTTSMessages
        {
            get => _flags.HasFlag(PermissionType.SendTTSMessages);
            set => _setFlag(PermissionType.SendTTSMessages, value);
        }

        public bool CanSpeak
        {
            get => _flags.HasFlag(PermissionType.Speak);
            set => _setFlag(PermissionType.Speak, value);
        }

        public bool CanUseExternalEmojis
        {
            get => _flags.HasFlag(PermissionType.UseExternalEmojis);
            set => _setFlag(PermissionType.UseExternalEmojis, value);
        }

        public bool CanUseVAD
        {
            get => _flags.HasFlag(PermissionType.UseVAD);
            set => _setFlag(PermissionType.UseVAD, value);
        }

        private void _setFlag(PermissionType permission, bool hasPermission)
        {
            if (hasPermission)
            {
                _flags = _flags | permission;
            }
            else
            {
                _flags = _flags & ~permission;
            }
        }
    }
}   