#pragma once
#include <string>
#include "openvr_driver.h"
#include "UdpPoseReceiver.h"

class VirtualTrackerDevice : public vr::ITrackedDeviceServerDriver
{
public:
    VirtualTrackerDevice(std::string serial, std::string id, UdpPoseReceiver* rx);

    const std::string& GetSerial() const { return serial_; }

    vr::EVRInitError Activate(vr::TrackedDeviceIndex_t unObjectId) override;
    void Deactivate() override;
    void EnterStandby() override {}
    void* GetComponent(const char*) override { return nullptr; }
    void DebugRequest(const char*, char*, uint32_t) override {}
    vr::DriverPose_t GetPose() override { return pose_; }
    void RunFrame();

private:
    std::string serial_;
    std::string id_;
    UdpPoseReceiver* rx_;
    vr::TrackedDeviceIndex_t objectId_{ vr::k_unTrackedDeviceIndexInvalid };
    vr::DriverPose_t pose_{};
    
    vr::VRInputComponentHandle_t h_action_  = vr::k_ulInvalidInputComponentHandle;
    
    int actionHoldFrames_  = 0;
 

};


