#include "UdpPoseReceiver.h"
#include <winsock2.h>
#include <ws2tcpip.h>
#include <cstdio>
#include <cstring>


#pragma comment(lib, "Ws2_32.lib")

static void DebugPrint(const char* s)
{
    OutputDebugStringA(s);
}

static DWORD WINAPI ThreadProc(LPVOID p)
{
    UdpPoseReceiver* self = (UdpPoseReceiver*)p;
    self->ThreadMain(39570);
    return 0;
}

bool UdpPoseReceiver::Start(unsigned short)
{
    running_ = true;
    thread_ = CreateThread(NULL, 0, ThreadProc, this, 0, NULL);
    if (thread_ == NULL) {
        DebugPrint("UdpPoseReceiver::Start CreateThread failed\n");
        return false;
    }
    DebugPrint("UdpPoseReceiver::Start ok\n");
    return true;
}

void UdpPoseReceiver::Stop()
{
    running_ = false;
    if (thread_) {
        WaitForSingleObject(thread_, 1000);
        CloseHandle(thread_);
        thread_ = NULL;
    }
    DebugPrint("UdpPoseReceiver::Stop\n");
}

bool UdpPoseReceiver::TryGetLatestForId(const char*, PosePacket& out)
{

    std::lock_guard<std::mutex> lock(mtx_);
    if (!latest_.valid)
        return false;

    out.x_mm  = latest_.x_mm;
    out.y_mm  = latest_.y_mm;
    out.z_mm  = latest_.z_mm;
    out.w_ro  = latest_.w_ro;
    out.x_ro  = latest_.x_ro;
    out.y_ro  = latest_.y_ro;
    out.z_ro  = latest_.z_ro;

    out.valid = latest_.valid;
    return true;
}

void UdpPoseReceiver::ThreadMain(unsigned short port)
{
    WSADATA wsa;
    if (WSAStartup(MAKEWORD(2, 2), &wsa) != 0) {
        DebugPrint("UdpPoseReceiver WSAStartup failed\n");
        return;
    }

    SOCKET s = socket(AF_INET, SOCK_DGRAM, IPPROTO_UDP);
    if (s == INVALID_SOCKET) {
        DebugPrint("UdpPoseReceiver socket failed\n");
        WSACleanup();
        return;
    }

    sockaddr_in addr;
    std::memset(&addr, 0, sizeof(addr));
    addr.sin_family = AF_INET;
    addr.sin_addr.s_addr = htonl(INADDR_ANY);
    addr.sin_port = htons(port);

    if (bind(s, (sockaddr*)&addr, sizeof(addr)) != 0) {
        DebugPrint("UdpPoseReceiver bind failed\n");
        closesocket(s);
        WSACleanup();
        return;
    }

    DebugPrint("UdpPoseReceiver bind ok\n");

    DWORD timeout = 50;
    setsockopt(s, SOL_SOCKET, SO_RCVTIMEO, (const char*)&timeout, sizeof(timeout));

    char buf[256];

    // Log throttling: at most 10 logs/sec
    ULONGLONG lastLogMs = 0;

    while (running_) {
        int len = recv(s, buf, (int)sizeof(buf) - 1, 0);
        if (len <= 0)
            continue;

        buf[len] = '\0';
        
        
        // ---- Y button commands (one-shot pulse) ----
        if (std::strstr(buf, "btn=Y click") != nullptr) { y_pulse_ = 1; continue; }
        if (std::strstr(buf, "btn=Y long")  != nullptr) { y_pulse_ = 2; continue; }
        
        
        
        
        double x = 0.0;
        double y = 0.0;
        double z = 0.0;

        double wr = 0.0;
        double xr = 0.0;
        double yr = 0.0;
        double zr = 0.0;
        
 
        int n = std::sscanf(buf, "x_mm=%lf y_mm=%lf z_mm=%lf w_ro=%lf x_ro=%lf y_ro=%lf z_ro=%lf", &x, &y, &z, &wr, &xr, &yr, &zr);
        if (n >= 1) {
            {
                std::lock_guard<std::mutex> lock(mtx_);
                latest_.x_mm = x;
                latest_.y_mm = (n >= 2) ? y : 0.0;
                latest_.z_mm = (n >= 3) ? z : 0.0;
                latest_.w_ro = (n >= 4) ? wr : 1.0;
                latest_.x_ro = (n >= 5) ? xr : 0.0;
                latest_.y_ro = (n >= 6) ? yr : 0.0;
                latest_.z_ro = (n >= 7) ? zr : 0.0;
                latest_.valid = true;
            }

            ULONGLONG now = GetTickCount64();
            if (now - lastLogMs >= 100) {
                char msg[256];
                std::snprintf(msg, sizeof(msg),
                              "UDP RX: x=%.3f y=%.3f z=%.3f wr=%.3f xr=%.3f yr=%.3f zr=%.3f\n",
                              x, (n >= 2) ? y : 0.0, (n >= 3) ? z : 0.0, (n >= 4) ? wr : 1.0, (n >= 5) ? xr : 0.0, (n >= 6) ? yr : 0.0, (n >= 7) ? zr : 0.0);
                DebugPrint(msg);
                lastLogMs = now;
            }
        } else {
            ULONGLONG now = GetTickCount64();
            if (now - lastLogMs >= 250) {
                DebugPrint("UDP RX: parse failed\n");
                lastLogMs = now;
            }
        }
    }

    closesocket(s);
    WSACleanup();
}
