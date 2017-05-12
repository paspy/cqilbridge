#include "stdafx.h"
#include "dllmain.h"

#include "CQILBridge.h"

using namespace std;

CQILBridge::ILBridge *g_pBridge = nullptr;

int32_t g_AuthCode = -1;

/*
* ����Ӧ�õ�ApiVer��Appid������󽫲������
*/
CQEVENT(const char*, AppInfo, 0)() {
	return CQAPPINFO;
}

CQEVENT(int32_t, Initialize, 4)(int32_t AuthCode) {
	g_AuthCode = AuthCode;
	return 0;
}


CQEVENT(int32_t, __eventStartup, 0)() {
	g_pBridge = new CQILBridge::ILBridge();
	return g_pBridge->Initialize(g_AuthCode);
}

CQEVENT(int32_t, __eventExit, 0)() {
	g_pBridge->Exit();
	delete g_pBridge;
	g_pBridge = nullptr;
	return 0;
}

CQEVENT(int32_t, __eventEnable, 0)() {
	return g_pBridge->Enabled();
}

CQEVENT(int32_t, __eventDisable, 0)() {
	return g_pBridge->Disabled();
}

CQEVENT(int32_t, __eventPrivateMsg, 24)(int32_t subType, int32_t sendTime, int64_t fromQQ, const char *msg, int32_t font) {
	return g_pBridge->ProcessPrivateMessageEvent(subType, sendTime, fromQQ, msg, font);
}

CQEVENT(int32_t, __eventGroupMsg, 36)(int32_t subType, int32_t sendTime, int64_t fromGroup, int64_t fromQQ, const char *fromAnonymous, const char *msg, int32_t font) {
	return g_pBridge->ProcessGroupMessageEvent(subType, sendTime, fromGroup, fromQQ, fromAnonymous, msg, font);
}

CQEVENT(int32_t, __eventDiscussMsg, 32)(int32_t subType, int32_t sendTime, int64_t fromDiscuss, int64_t fromQQ, const char *msg, int32_t font) {
	return g_pBridge->ProcessDiscussMessageEvent(subType, sendTime, fromDiscuss, fromQQ, msg, font);
}

CQEVENT(int32_t, __eventSystem_GroupAdmin, 24)(int32_t subType, int32_t sendTime, int64_t fromGroup, int64_t beingOperateQQ) {
	return g_pBridge->ProcessGroupAdminEvent(subType, sendTime, fromGroup, beingOperateQQ);
}

CQEVENT(int32_t, __eventSystem_GroupMemberIncrease, 32)(int32_t subType, int32_t sendTime, int64_t fromGroup, int64_t fromQQ, int64_t beingOperateQQ) {
	return g_pBridge->ProcessGroupMemberIncreaseEvent(subType, sendTime, fromGroup, fromQQ, beingOperateQQ);
}

CQEVENT(int32_t, __eventSystem_GroupMemberDecrease, 32)(int32_t subType, int32_t sendTime, int64_t fromGroup, int64_t fromQQ, int64_t beingOperateQQ) {
	return g_pBridge->ProcessGroupMemberDecreaseEvent(subType, sendTime, fromGroup, fromQQ, beingOperateQQ);
}

CQEVENT(int32_t, __eventFriend_Add, 16)(int32_t subType, int32_t sendTime, int64_t fromQQ) {
	return g_pBridge->ProcessFriendAddEvent(subType, sendTime, fromQQ);
}

CQEVENT(int32_t, __eventRequest_AddFriend, 24)(int32_t subType, int32_t sendTime, int64_t fromQQ, const char *msg, const char *responseFlag) {
	return g_pBridge->ProcessRequestAddFriendEvent(subType, sendTime, fromQQ, msg, responseFlag);
}

CQEVENT(int32_t, __eventRequest_AddGroup, 32)(int32_t subType, int32_t sendTime, int64_t fromGroup, int64_t fromQQ, const char *msg, const char *responseFlag) {
	return g_pBridge->ProcessRequestAddGroupEvent(subType, sendTime, fromGroup, fromQQ, msg, responseFlag);
}

CQEVENT(int32_t, _eventGroupUpload, 28)(int32_t subType, int32_t sendTime, int64_t fromGroup, int64_t fromQQ, const char *file) {
	return g_pBridge->ProcessGroupUploadEvent(subType, sendTime, fromGroup, fromQQ, file);
}

CQEVENT(int32_t, _settingPanel, 0)() {
	return g_pBridge->ProcessPanelEvent();
}