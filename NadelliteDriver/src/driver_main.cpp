#include <cstring>
#include "openvr_driver.h"
#include "DriverProvider.h"

static DriverProvider g_provider;

extern "C" __declspec(dllexport)
void* HmdDriverFactory(const char* pInterfaceName, int* pReturnCode)
{
    if (pReturnCode) *pReturnCode = 0;

    if (pInterfaceName &&
        std::strcmp(pInterfaceName, vr::IServerTrackedDeviceProvider_Version) == 0)
        return &g_provider;

    if (pReturnCode)
        *pReturnCode = vr::VRInitError_Init_InterfaceNotFound;
    return nullptr;
}
