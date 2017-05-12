// This is the main DLL file.

#include "stdafx.h"
#include "dllmain.h"
#include "CQILBridge.h"

using namespace CQILBridge::Framework;

namespace CQILBridge {

	public class ILAdapter {
	public:
		ILAdapter() {}
		~ILAdapter() {}
		int32_t Initialize(int32_t authCode) {
			CQ::SetAuthCode(authCode);
			CQPluginInstance::BridgeName = gcnew String(CQAPPID);
			return CQPluginInstance::GetInstance()->Initialize();
		}
		int32_t Exit() { return CQPluginInstance::GetInstance()->Exit(); }
		int32_t Enabled() { return CQPluginInstance::GetInstance()->Enabled(); }
		int32_t Disabled() { return CQPluginInstance::GetInstance()->Disabled(); }
		int32_t PrivateMessageEvent(int32_t subType, int32_t sendTime, int64_t fromQQ, const char *msg, int32_t font) {
			return (int)CQPluginInstance::GetInstance()->PrivateMessage(subType, sendTime, fromQQ, gcnew String(msg), font);
		}
		int32_t GroupMessageEvent(int32_t subType, int32_t sendTime, int64_t fromGroup, int64_t fromQQ, const char *fromAnonymous, const char *msg, int32_t font) {
			return (int)CQPluginInstance::GetInstance()->GroupMessage(subType, sendTime, fromGroup, fromQQ, gcnew String(fromAnonymous), gcnew String(msg), font);
		}
		int32_t DiscussMessageEvent(int32_t subType, int32_t sendTime, int64_t fromDiscuss, int64_t fromQQ, const char *msg, int32_t font) {
			return (int)CQPluginInstance::GetInstance()->DiscussMessage(subType, sendTime, fromDiscuss, fromQQ, gcnew String(msg), font);
		}
		int32_t GroupAdminEvent(int32_t subType, int32_t sendTime, int64_t fromGroup, int64_t beingOperateQQ) {
			return (int)CQPluginInstance::GetInstance()->GroupAdmin(subType, sendTime, fromGroup, beingOperateQQ);
		}
		int32_t GroupMemberIncreaseEvent(int32_t subType, int32_t sendTime, int64_t fromGroup, int64_t fromQQ, int64_t beingOperateQQ) {
			return (int)CQPluginInstance::GetInstance()->GroupMemberIncrease(subType, sendTime, fromGroup, fromQQ, beingOperateQQ);
		}
		int32_t GroupMemberDecreaseEvent(int32_t subType, int32_t sendTime, int64_t fromGroup, int64_t fromQQ, int64_t beingOperateQQ) {
			return (int)CQPluginInstance::GetInstance()->GroupMemberDecrease(subType, sendTime, fromGroup, fromQQ, beingOperateQQ);
		}
		int32_t FriendAddEvent(int32_t subType, int32_t sendTime, int64_t fromQQ) {
			return (int)CQPluginInstance::GetInstance()->FriendAdded(subType, sendTime, fromQQ);
		}
		int32_t RequestAddFriendEvent(int32_t subType, int32_t sendTime, int64_t fromQQ, const char *msg, const char *responseFlag) {
			return (int)CQPluginInstance::GetInstance()->RequestAddFriend(subType, sendTime, fromQQ, gcnew String(msg), gcnew String(responseFlag));
		}
		int32_t RequestAddGroupEvent(int32_t subType, int32_t sendTime, int64_t fromGroup, int64_t fromQQ, const char *msg, const char *responseFlag) {
			return (int)CQPluginInstance::GetInstance()->RequestAddGroup(subType, sendTime, fromGroup, fromQQ, gcnew String(msg), gcnew String(responseFlag));
		}
		int32_t GroupUploadEvent(int32_t subType, int32_t sendTime, int64_t fromGroup, int64_t fromQQ, const char *file) {
			return (int)CQPluginInstance::GetInstance()->GroupUpload(subType, sendTime, fromGroup, fromQQ, gcnew String(file));
		}
		void SettingPanelEvent() { CQPluginInstance::GetInstance()->OpenSettingPanel(); }

	};

	ILBridge::ILBridge() {
		m_adapter = new ILAdapter();
	}

	ILBridge::~ILBridge() {
		delete m_adapter;
	}

	int32_t ILBridge::Initialize(int32_t authCode) { return m_adapter->Initialize(authCode); }

	int32_t ILBridge::Exit() { return m_adapter->Exit(); }

	int32_t ILBridge::Enabled() { return m_adapter->Enabled(); }

	int32_t ILBridge::Disabled() { return m_adapter->Disabled(); }

	int32_t ILBridge::PrivateMessageEvent(int32_t subType, int32_t sendTime, int64_t fromQQ, const char *msg, int32_t font) {
		return m_adapter->PrivateMessageEvent(subType, sendTime, fromQQ, msg, font);
	}

	int32_t ILBridge::GroupMessageEvent(int32_t subType, int32_t sendTime, int64_t fromGroup, int64_t fromQQ, const char *fromAnonymous, const char *msg, int32_t font) {
		return m_adapter->GroupMessageEvent(subType, sendTime, fromGroup, fromQQ, fromAnonymous, msg, font);
	}

	int32_t ILBridge::DiscussMessageEvent(int32_t subType, int32_t sendTime, int64_t fromDiscuss, int64_t fromQQ, const char *msg, int32_t font) {
		return m_adapter->DiscussMessageEvent(subType, sendTime, fromDiscuss, fromQQ, msg, font);
	}

	int32_t ILBridge::GroupAdminEvent(int32_t subType, int32_t sendTime, int64_t fromGroup, int64_t beingOperateQQ) {
		return m_adapter->GroupAdminEvent(subType, sendTime, fromGroup, beingOperateQQ);
	}

	int32_t ILBridge::GroupMemberIncreaseEvent(int32_t subType, int32_t sendTime, int64_t fromGroup, int64_t fromQQ, int64_t beingOperateQQ) {
		return m_adapter->GroupMemberIncreaseEvent(subType, sendTime, fromGroup, fromQQ, beingOperateQQ);
	}

	int32_t ILBridge::GroupMemberDecreaseEvent(int32_t subType, int32_t sendTime, int64_t fromGroup, int64_t fromQQ, int64_t beingOperateQQ) {
		return m_adapter->GroupMemberDecreaseEvent(subType, sendTime, fromGroup, fromQQ, beingOperateQQ);
	}

	int32_t ILBridge::FriendAddEvent(int32_t subType, int32_t sendTime, int64_t fromQQ) {
		return m_adapter->FriendAddEvent(subType, sendTime, fromQQ);
	}

	int32_t ILBridge::RequestAddFriendEvent(int32_t subType, int32_t sendTime, int64_t fromQQ, const char *msg, const char *responseFlag) {
		return m_adapter->RequestAddFriendEvent(subType, sendTime, fromQQ, msg, responseFlag);
	}

	int32_t ILBridge::RequestAddGroupEvent(int32_t subType, int32_t sendTime, int64_t fromGroup, int64_t fromQQ, const char *msg, const char *responseFlag) {
		return m_adapter->RequestAddGroupEvent(subType, sendTime, fromGroup, fromQQ, msg, responseFlag);
	}

	int32_t ILBridge::GroupUploadEvent(int32_t subType, int32_t sendTime, int64_t fromGroup, int64_t fromQQ, const char *file) {
		return m_adapter->GroupUploadEvent(subType, sendTime, fromGroup, fromQQ, file);
	}

	int32_t ILBridge::SettingPanelEvent() {
		m_adapter->SettingPanelEvent();
		return 0;
	}

}