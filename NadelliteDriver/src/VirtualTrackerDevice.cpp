
#include "VirtualTrackerDevice.h"
#include <windows.h>
#include <cstdio>
#include <cstring> // std::memset

static void DebugPrint(const char* s)
{
    OutputDebugStringA(s);
}

VirtualTrackerDevice::VirtualTrackerDevice(std::string serial, std::string id, UdpPoseReceiver* rx)
    : serial_(std::move(serial)), id_(std::move(id)), rx_(rx)
{
    std::memset(&pose_, 0, sizeof(pose_));

    pose_.qRotation.w = 1.0;
    pose_.qRotation.x = 0.0;
    pose_.qRotation.y = 0.0;
    pose_.qRotation.z = 0.0;

    // 重要：未初期化だと姿勢合成が壊れることがある
    pose_.qWorldFromDriverRotation.w = 1.0;
    pose_.qDriverFromHeadRotation.w  = 1.0;

    // translationもゼロ（memsetで0になっているが明示してもOK）
    pose_.vecWorldFromDriverTranslation[0] = 0.0;
    pose_.vecWorldFromDriverTranslation[1] = 0.0;
    pose_.vecWorldFromDriverTranslation[2] = 0.0;

    pose_.vecDriverFromHeadTranslation[0] = 0.0;
    pose_.vecDriverFromHeadTranslation[1] = 0.0;
    pose_.vecDriverFromHeadTranslation[2] = 0.0;
}

vr::EVRInitError VirtualTrackerDevice::Activate(vr::TrackedDeviceIndex_t unObjectId)
{
    objectId_ = unObjectId;

    auto props = vr::VRProperties()->TrackedDeviceToPropertyContainer(objectId_);
    
    vr::VRDriverInput()->CreateBooleanComponent(props, "/input/y/click", &h_action_);

    //lefthand
    vr::VRProperties()->SetInt32Property(
        props,
        vr::Prop_ControllerRoleHint_Int32,
        vr::TrackedControllerRole_LeftHand
    );

    vr::VRProperties()->SetBoolProperty(
        props,
        vr::Prop_HasControllerComponent_Bool,
        true
    );
    
    vr::VRProperties()->SetStringProperty(props, vr::Prop_SerialNumber_String, serial_.c_str());
    vr::VRProperties()->SetStringProperty(props, vr::Prop_ModelNumber_String, "UDP Virtual Tracker");
    vr::VRProperties()->SetStringProperty(props, vr::Prop_ControllerType_String, "oculus_touch");

    vr::EVRInputError err = vr::VRDriverInput()->CreateBooleanComponent(
        props, "/input/y/click", &h_action_);
    
    if (err != vr::VRInputError_None) {
        DebugPrint("CreateBooleanComponent(/input/y/click) FAILED\n");
    } else {
        DebugPrint("CreateBooleanComponent(/input/y/click) OK\n");
    }


    pose_.poseIsValid = true;
    pose_.deviceIsConnected = true;
    pose_.result = vr::TrackingResult_Running_OK;

    DebugPrint("VirtualTrackerDevice::Activate ok\n");
    return vr::VRInitError_None;
}

void VirtualTrackerDevice::Deactivate()
{
    objectId_ = vr::k_unTrackedDeviceIndexInvalid;
    DebugPrint("VirtualTrackerDevice::Deactivate\n");
}


void VirtualTrackerDevice::RunFrame()
{

    PosePacket pkt;
    bool hasData = false;

    int yp = 0;
    if (rx_) {
        hasData = rx_->TryGetLatestForId(id_.c_str(), pkt);
        yp = rx_->ConsumeYPulse();

        if (yp == 1) actionHoldFrames_ = 2;
        if (yp == 2) actionHoldFrames_ = 30;

        if (yp) OutputDebugStringA(yp==1 ? "Y CLICK\n" : "Y LONG\n");
    }
    
    
        // ---- Y button update ----
    if (h_action_ != vr::k_ulInvalidInputComponentHandle) {
        bool down = (actionHoldFrames_ > 0);
        vr::VRDriverInput()->UpdateBooleanComponent(h_action_, down, 0);
        if (actionHoldFrames_ > 0) actionHoldFrames_--;
    }

    static double lastX = 0.0;
    static double lastY = 0.0;
    static double lastZ = 0.0;
    static double lastWR = 0.0;
    static double lastXR = 0.0;
    static double lastYR = 0.0;
    static double lastZR = 0.0;


    if (hasData) {
        pose_.vecPosition[0] = pkt.x_mm * 0.001;
        pose_.vecPosition[1] = pkt.y_mm * 0.001;
        pose_.vecPosition[2] = pkt.z_mm * 0.001;

        pose_.qRotation.w = pkt.w_ro;  //1;
        pose_.qRotation.x = pkt.x_ro;  //0.0;
        pose_.qRotation.y = pkt.y_ro;    //0.0;
        pose_.qRotation.z = pkt.z_ro;

        // 正規化（超重要）
        double nrm = std::sqrt(
            pose_.qRotation.w * pose_.qRotation.w +
            pose_.qRotation.x * pose_.qRotation.x +
            pose_.qRotation.y * pose_.qRotation.y +
            pose_.qRotation.z * pose_.qRotation.z);

        if (nrm > 0.0) {
            pose_.qRotation.w /= nrm;
            pose_.qRotation.x /= nrm;
            pose_.qRotation.y /= nrm;
            pose_.qRotation.z /= nrm;
        } else {
            pose_.qRotation.w = 1.0;
            pose_.qRotation.x = 0.0;
            pose_.qRotation.y = 0.0;
            pose_.qRotation.z = 0.0;
        }


        lastX = pkt.x_mm;
        lastY = pkt.y_mm;
        lastZ = pkt.z_mm;
        lastWR = pkt.w_ro;
        lastXR = pkt.x_ro;
        lastYR = pkt.y_ro;
        lastZR = pkt.z_ro;
    }

    pose_.poseIsValid = true;
    pose_.deviceIsConnected = true;
    pose_.result = vr::TrackingResult_Running_OK;


    vr::VRServerDriverHost()->TrackedDevicePoseUpdated(
        objectId_,
        pose_,
        sizeof(vr::DriverPose_t)
    );

    static ULONGLONG lastLogMs = 0;
    ULONGLONG now = GetTickCount64();
    if (now - lastLogMs >= 2000) {
        char msg[256];
        std::snprintf(msg, sizeof(msg),
                      "POSE ALIVE: x=%.3f y=%.3f z=%.3f wr=%.3f xr=%.3f yr=%.3f zr=%.3f\n ",
                      lastX, lastY, lastZ, lastWR, lastXR, lastYR, lastZR);
        OutputDebugStringA(msg);
        lastLogMs = now;
    }
}

