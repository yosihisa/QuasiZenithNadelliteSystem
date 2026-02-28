cmake_minimum_required(VERSION 3.30)

project(NadelliteDriver LANGUAGES CXX)

set(CMAKE_CXX_STANDARD 17)
set(CMAKE_CXX_STANDARD_REQUIRED ON)
set(CMAKE_CXX_EXTENSIONS OFF)

add_library(NadelliteDriver SHARED
    src/driver_main.cpp
    src/DriverProvider.cpp
    src/VirtualTrackerDevice.cpp
    src/UdpPoseReceiver.cpp
)

target_include_directories(NadelliteDriver PRIVATE
    third_party/openvr/headers
)

target_link_libraries(NadelliteDriver PRIVATE ws2_32)

target_compile_definitions(NadelliteDriver PRIVATE
    WIN32_LEAN_AND_MEAN
    NOMINMAX
    _CRT_SECURE_NO_WARNINGS
)

if (MSVC)
    target_compile_options(NadelliteDriver PRIVATE /utf-8)
endif()

set_target_properties(NadelliteDriver PROPERTIES
    OUTPUT_NAME "driver_Nadellite"
)
