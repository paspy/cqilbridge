// This is the main DLL file.

#include "stdafx.h"
#include "CQILBridge.h"

#include <msclr/auto_gcroot.h>
using msclr::auto_gcroot;
#using <System.dll>
using namespace System;

namespace CQILBridge {

	public class ILAdapter {
	private:
		Object^ CQApp;
	public:
		ILAdapter() {
			CQApp = Activator::CreateInstance(CQILBridge::Framework::CQAppAbstract);
		}

		int32_t Initialize(int32_t authCode) { return CQApp->Initialize(authCode); }
		int32_t Exit() { return CQApp->CoolQExited(); }

		int32_t Enabled() { return CQApp->Enabled(); }

		int32_t Disabled() { return CQApp->Disabled(); }
		int32_t ProcessPrivateMessage(int32_t subType, int32_t sendTime, int64_t fromQQ, const char *msg, int32_t font) {
			return CQApp->ProcessPrivateMessage(subType, sendTime, fromQQ, gcnew String(msg), font);
		}

	};
	
	ILBridge::ILBridge() {

	}

	ILBridge::~ILBridge() {

	}

	int32_t ILBridge::Initialize(int32_t authCode) {

		return 0;
	}

	void ILBridge::Exit() {

	}

	int32_t ILBridge::Enabled() {

		return 0;
	}

	int32_t ILBridge::Disabled() {

		return 0;
	}

	int32_t ILBridge::ProcessPrivateMessageEvent(int32_t subType, int32_t sendTime, int64_t fromQQ, const char *msg, int32_t font) {

		return 0;
	}

	int32_t ILBridge::ProcessGroupMessageEvent(int32_t subType, int32_t sendTime, int64_t fromGroup, int64_t fromQQ, const char *fromAnonymous, const char *msg, int32_t font) {

		return 0;
	}

	int32_t ILBridge::ProcessDiscussMessageEvent(int32_t subType, int32_t sendTime, int64_t fromDiscuss, int64_t fromQQ, const char *msg, int32_t font) {

		return 0;
	}

	int32_t ILBridge::ProcessGroupAdminEvent(int32_t subType, int32_t sendTime, int64_t fromGroup, int64_t beingOperateQQ) {

		return 0;
	}

	int32_t ILBridge::ProcessGroupMemberIncreaseEvent(int32_t subType, int32_t sendTime, int64_t fromGroup, int64_t fromQQ, int64_t beingOperateQQ) {

		return 0;
	}

	int32_t ILBridge::ProcessGroupMemberDecreaseEvent(int32_t subType, int32_t sendTime, int64_t fromGroup, int64_t fromQQ, int64_t beingOperateQQ) {

		return 0;
	}

	int32_t ILBridge::ProcessFriendAddEvent(int32_t subType, int32_t sendTime, int64_t fromQQ) {

		return 0;
	}

	int32_t ILBridge::ProcessRequestAddFriendEvent(int32_t subType, int32_t sendTime, int64_t fromQQ, const char *msg, const char *responseFlag) {

		return 0;
	}

	int32_t ILBridge::ProcessRequestAddGroupEvent(int32_t subType, int32_t sendTime, int64_t fromGroup, int64_t fromQQ, const char *msg, const char *responseFlag) {

		return 0;
	}

	int32_t ILBridge::ProcessGroupUploadEvent(int32_t subType, int32_t sendTime, int64_t fromGroup, int64_t fromQQ, const char *file) {

		return 0;
	}

	int32_t ILBridge::ProcessPanelEvent() {

		return 0;
	}

}