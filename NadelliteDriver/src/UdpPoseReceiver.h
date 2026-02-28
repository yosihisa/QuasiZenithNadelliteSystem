#pragma once
#include <mutex>
#include <atomic>
#include <windows.h>
#include <functional>

struct PosePacket
{
    double x_mm{0};
    double y_mm{0};
    double z_mm{0};
    double w_ro{0};
    double x_ro{0};
    double y_ro{0};
    double z_ro{0};
    bool valid{false};
};

class UdpPoseReceiver
{
public:
    std::function<void(bool)> onMode;
    bool Start(unsigned short port);
    void Stop();
    bool TryGetLatestForId(const char*, PosePacket& out);
    int ConsumeYPulse() { return y_pulse_.exchange(0); }

    void ThreadMain(unsigned short port);

private:
    PosePacket latest_;
    std::mutex mtx_;
    std::atomic<bool> running_{ false };
    HANDLE thread_{ NULL };
    
    // 0=none, 1=menu 2=udon
    std::atomic<int> y_pulse_{0};
};
