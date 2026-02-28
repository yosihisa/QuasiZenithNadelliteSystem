#pragma once
#include <memory>
#include "openvr_driver.h"
#include "VirtualTrackerDevice.h"
#include "UdpPoseReceiver.h"

class DriverProvider : public vr::IServerTrackedDeviceProvider
{
public:
    vr::EVRInitError Init(vr::IVRDriverContext* pDriverContext) override;
    void Cleanup() override;
    const char* const* GetInterfaceVersions() override { return vr::k_InterfaceVersions; }
    void RunFrame() override;
    bool ShouldBlockStandbyMode() override { return false; }
    void EnterStandby() override {}
    void LeaveStandby() override {}

private:
    UdpPoseReceiver rx_;
    std::unique_ptr<VirtualTrackerDevice> tracker_;
};
