# Quasi Zenith Nadellite System (QZNS)

**Quasi Zenith Nadellite System** は、準天頂衛星「みちびき」(QZSS) の信号を利用してアンテナ（手）の位置を高精度に測位し、その動きを VR 空間上のトラッカーとして反映させるソフトウェアです。

GNSS (CLAS) によるセンチメートル級の測位結果を SteamVR のトラッカーとして扱うことで、VRChat などの VR アプリケーション上で、現実空間での位置や手の動きを再現できます。


## 必要なデバイス

以下の u-blox 社製デバイスが必要です。

- **u-blox ZED-F9P** (GNSS 受信機)
- **u-blox NEO-D9C** (L6 帯受信機 / 補正データ用)

## デバイス設定

u-blox の設定ツール **u-center** を使用して、同梱の設定ファイルをデバイスに送信します。

1. **u-center** を起動し、デバイスを接続します。
2. メニューバーから `Tools` -> `Receiver configuration...` を選択します。
3. `configuration file` 欄の右側にある `...` ボタンを押し、デバイスに対応した設定ファイル（**QZNS_F9P.txt** または **QZNS_D9C.txt**）を選択します。
4. `Transfer file -> GNSS` ボタンを押して設定を送信します。
5. 設定完了後、メニューバーから `Receiver` -> `Action` -> `Save Config` を押し、設定を保存します。

## インストール方法

### 1. SteamVR ドライバの配置

`driver_Nadellite.dll` と `driver.vrdrivermanifest` を SteamVR のドライバフォルダに配置します。

まず、以下のフォルダ階層を作成し、driver_Nadellite.dllを配置してください。

```
C:\Program Files (x86)\Steam\steamapps\common\SteamVR\drivers\Nadellite\bin\win64\
```

driver.vrdrivermanifestを以下のフォルダにコピーしてください。

```
C:\Program Files (x86)\Steam\steamapps\common\SteamVR\drivers\Nadellite\
```

以下のような構成になればOKです。
```
C:\Program Files (x86)\Steam\steamapps\common\SteamVR\drivers\
 └─Nadellite\
   ├─ driver.vrdrivermanifest
   └─ bin\
       └─ win64\
          └─ driver_Nadellite.dll
```

### SteamVR 設定

以下のファイルを開きます。

```
C:\Program Files (x86)\Steam\config\steamvr.vrsettings
```

`steamvr` セクション内で、次の設定が `true` になっていることを確認してください（通常はデフォルトで有効です）。

```json
"steamvr" : {
    "haveStartedTutorialForNativeChaperoneDriver" : true
}
```

次に、同じ `steamvr` セクションの直下に以下を追加します。(カンマ`,`の位置に注意してください。)

```json
"trackers" : {
    "/devices/Nadellite/QZSS_TRACKER_001" :
        "TrackerRole_Handed,TrackedControllerRole_LeftHand"
}
```
  
以下のようになるはずです。
```json
   "steamvr" : {
      中略
   }, ←ここにカンマ追加
   "trackers" : {
    "/devices/Nadellite/QZSS_TRACKER_001" :
        "TrackerRole_Handed,TrackedControllerRole_LeftHand"
   } ←最後のセクションの場合はカンマ不要
}
```

## 使い方

### QZSS 測位準備

1. F9P を USB ケーブルで PC に接続
2. `Nadellite.exe` を起動
3. シリアルポートを選択し「接続」を押す
4. 測位状態が **CLAS Float** または **CLAS Fix**（緑表示）になるまで待つ
5. 左腕を伸ばした状態で手に持ち、「キャリブレーション 左」を押す
6. 右腕を伸ばした状態で手に持ち、「キャリブレーション 右」を押す


### VR 連携

1. Quest を起動し、Virtual Desktop または Air Link で PC と接続
2. SteamVR を起動  
   - ドライバが正しくロードされている場合、  
     **SteamVR 設定 → トラッカーの管理** に  
     `QZSS_TRACKER_001` が表示されます
   - トラッカーの役割を **ハンドベルト / 左手** に設定
3. SteamVR のみを起動した状態で HMD を装着し、周囲を見渡すとゲームパッドが表示されます
4. `Nadellite.exe` 右側の「接続」を押す
5. 位置・回転調整ボタンを使用し、ゲームパッドが HMD 正面付近に来るよう調整
6. VRChat を起動

### 注意事項

- 左手は Nadellite によって制御されるため、Quest 付属の左手コントローラは使用できません
- 移動はキーボード（WASD キーなど）で行えます

## ビルド方法

### 必要な環境

- **Visual Studio Community 2022 / 2026**
- **C++ によるデスクトップ開発**


### Nadellite.exe

1. `Nadellite.sln` を開く
2. 通常通りビルド


### NadelliteDriver.dll

1. **Visual Studio x86 Native Tools Command Prompt for VS** を起動
2. `NadelliteDriver` ディレクトリへ移動

```sh
cd NadelliteDriver
```

#### CMake 設定 / ビルド

**Visual Studio 2022の場合**
```sh
cmake -S . -B build -G "Visual Studio 17 2022" -A x64
cmake --build build --config Debug
```

**Visual Studio 2026の場合**
```sh
cmake -S . -B build -G "Visual Studio 18 2026" -A x64
cmake --build build --config Debug
```

2回目以降は
```sh
cmake --build build --config Debug
```
のみでOK


ビルドが成功すると、以下の DLL が生成されます。

```
NadelliteDriver\build\Debug\driver_Nadellite.dll
```

[debugview](https://learn.microsoft.com/ja-jp/sysinternals/downloads/debugview)を用いるとデバッグメッセージを表示できます。  
