#pragma once
#define CQAPPID "org.paspy.ilbridge" //���޸�AppID������� http://d.cqp.me/Pro/����/������Ϣ
#define CQAPPINFO CQAPIVERTEXT "," CQAPPID

#define CQAPIVER 9
#define CQAPIVERTEXT "9"

#define CQEVENT(ReturnType, Name, Size) __pragma(comment(linker, "/EXPORT:" #Name "=_" #Name "@" #Size))\
 extern "C" __declspec(dllexport) ReturnType __stdcall Name
