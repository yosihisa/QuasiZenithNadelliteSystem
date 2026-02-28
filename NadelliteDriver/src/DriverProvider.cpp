#include "DriverProvider.h"
#include <windows.h>

static void DebugPrint(const char* s)
{
    OutputDebugStringA(s);
}

vr::EVRInitError DriverProvider::Init(vr::IVRDriverContext* pDriverContext)
{
    vr::EVRInitError err = vr::InitServerDriverContext(pDriverContext);
    if (err != vr::VRInitError_None) {
        DebugPrint("DriverProvider::Init InitServerDriverContext failed\n");
        return err;
    }

    DebugPrint("DriverProvider::Init ok\n");

    rx_.Start(39570);
    
    DebugPrint("UdpPoseReceiver::Start called\n");

    tracker_ = std::make_unique<VirtualTrackerDevice>(
        "QZSS_TRACKER_001",
        "handL",
        &rx_
    );

    vr::VRServerDriverHost()->TrackedDeviceAdded(
        tracker_->GetSerial().c_str(),
        //vr::TrackedDeviceClass_GenericTracker,
        vr::TrackedDeviceClass_Controller,
        tracker_.get()
    );

    DebugPrint("TrackedDeviceAdded QZSS_TRACKER_001\n");
    return vr::VRInitError_None;
}

void DriverProvider::RunFrame()
{
    if (tracker_) tracker_->RunFrame();
}

void DriverProvider::Cleanup()
{
    DebugPrint("DriverProvider::Cleanup\n");
    tracker_.reset();
    rx_.Stop();

    VR_CLEANUP_SERVER_DRIVER_CONTEXT();
}
