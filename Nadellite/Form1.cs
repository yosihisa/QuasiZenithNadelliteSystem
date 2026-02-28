using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Nadellite
{
    public partial class Form1 : Form
    {

        // --- OpenVR連携用変数 (UDP送信) ---
        private UdpClient udp_;
        private IPEndPoint remoteEp_;
        private bool connected_ = false;

        // 仮想トラッカーのオフセット位置 (mm)
        private int x_mm_ = 0;
        private int y_mm_ = 0;
        private int z_mm_ = 0;

        // 仮想トラッカーの回転 (クォータニオン)
        private double w_ro_ = 1.0;
        private double x_ro_ = 0.0;
        private double y_ro_ = 0.0;
        private double z_ro_ = 0.0;

        // --- GNSS/QZSS 受信データ ---
        private double lat = 0.0;   // 緯度
        private double lon = 0.0;   // 経度
        private double alt = 0.0;   // 高度
        private double hacc = 0.0;  // 水平精度
        private double vacc = 0.0;  // 垂直精度

        // --- キャリブレーション基準点 ---
        // 左側基準点
        private double L_lat = 0.0;
        private double L_lon = 0.0;
        private double L_alt = 0.0;

        // 右側基準点
        private double R_lat = 0.0;
        private double R_lon = 0.0;
        private double R_alt = 0.0;

        // --- 計算されたローカル座標位置 ---
        private double qzssX = 0.0;
        private double qzssY = 0.0;
        private double qzssZ = 0.0;

        // 受信バッファ
        private List<byte> ubxBuffer = new List<byte>();

        public Form1()
        {
            InitializeComponent();
            w_ro_ = 1.0; x_ro_ = 0.0; y_ro_ = 0.0; z_ro_ = 0.0;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (connected_)
                return;

            // 接続先設定 (デフォルト: localhost:39570)
            string targetIp = "127.0.0.1";
            int targetPort = 39570;

            udp_ = new UdpClient();
            remoteEp_ = new IPEndPoint(IPAddress.Parse(targetIp), targetPort);

            connected_ = true;

            btnConnect.Enabled = false;
            btnDisconnect.Enabled = true;

            SendCurrentPosition();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (!connected_)
                return;

            udp_.Close();
            udp_ = null;

            connected_ = false;

            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
        }

        /// <summary>
        /// 現在の位置・回転情報をUDPで送信します。
        /// </summary>
        private void SendCurrentPosition()
        {
            if (!connected_ || udp_ == null)
                return;

            int x, y, z;
            if (vr_connect.Checked== true)
            {
                x = x_mm_ + (int)(qzssX * 1000);
                y = y_mm_ + (int)(qzssY * 1000);
                z = z_mm_ + (int)(qzssZ * 1000);
            }
            else
            {
                x = x_mm_;
                y = y_mm_;
                z = z_mm_;
            }
            string message = $"x_mm={x} y_mm={y} z_mm={z} w_ro={w_ro_} x_ro={x_ro_} y_ro={y_ro_} z_ro={z_ro_}\n";
            byte[] data = Encoding.ASCII.GetBytes(message);
            udp_.Send(data, data.Length, remoteEp_);
            UpdatePositionText();
        }

        private void btnXP_Click(object sender, EventArgs e)
        {
            if (!connected_ || udp_ == null)
                return;
            x_mm_ += 100;
            SendCurrentPosition();
        }

        private void btnXM_Click(object sender, EventArgs e)
        {
            if (!connected_ || udp_ == null)
                return;
            x_mm_ -= 100;
            SendCurrentPosition();
        }

        private void btnXPP_Click(object sender, EventArgs e)
        {
            if (!connected_ || udp_ == null)
                return;
            x_mm_ += 500;
            SendCurrentPosition();

        }

        private void btnXMM_Click(object sender, EventArgs e)
        {
            if (!connected_ || udp_ == null)
                return;
            x_mm_ -= 500;
            SendCurrentPosition();
        }


        private void btnYP_Click(object sender, EventArgs e)
        {
            if (!connected_ || udp_ == null)
                return;
            y_mm_ += 100;
            SendCurrentPosition();

        }

        private void btnYM_Click(object sender, EventArgs e)
        {
            if (!connected_ || udp_ == null)
                return;
            y_mm_ -= 100;
            SendCurrentPosition();

        }

        private void btnYPP_Click(object sender, EventArgs e)
        {
            if (!connected_ || udp_ == null)
                return;
            y_mm_ += 500;
            SendCurrentPosition();

        }

        private void btnYMM_Click(object sender, EventArgs e)
        {
            if (!connected_ || udp_ == null)
                return;
            y_mm_ -= 500;
            SendCurrentPosition();

        }



        private void btnZP_Click(object sender, EventArgs e)
        {
            if (!connected_ || udp_ == null)
                return;
            z_mm_ += 100;
            SendCurrentPosition();

        }

        private void btnZM_Click(object sender, EventArgs e)
        {
            if (!connected_ || udp_ == null)
                return;
            z_mm_ -= 100;
            SendCurrentPosition();

        }
        private void btnZPP_Click(object sender, EventArgs e)
        {
            if (!connected_ || udp_ == null)
                return;
            z_mm_ += 500;
            SendCurrentPosition();

        }

        private void btnZMM_Click(object sender, EventArgs e)
        {
            if (!connected_ || udp_ == null)
                return;
            z_mm_ -= 500;
            SendCurrentPosition();
        }

        private void UpdatePositionText()
        {
            txtXPos.Text = x_mm_.ToString();
            txtYPos.Text = y_mm_.ToString();
            txtZPos.Text = z_mm_.ToString();
        }

        private void SavePositionToSettings()
        {
            Properties.Settings.Default.LastXmm = x_mm_;
            Properties.Settings.Default.LastYmm = y_mm_;
            Properties.Settings.Default.LastZmm = z_mm_;
            Properties.Settings.Default.LastWro = w_ro_;
            Properties.Settings.Default.LastXro = x_ro_;
            Properties.Settings.Default.LastYro = y_ro_;
            Properties.Settings.Default.LastZro = z_ro_;

            Properties.Settings.Default.Save(); // ここで永続化
        }

        private void LoadPositionFromSettings()
        {
            x_mm_ = Properties.Settings.Default.LastXmm;
            y_mm_ = Properties.Settings.Default.LastYmm;
            z_mm_ = Properties.Settings.Default.LastZmm;
            w_ro_ = Properties.Settings.Default.LastWro;
            x_ro_ = Properties.Settings.Default.LastXro;
            y_ro_ = Properties.Settings.Default.LastYro;
            z_ro_ = Properties.Settings.Default.LastZro;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadPositionFromSettings();
            UpdatePositionText();
            
            comboBoxPorts.Items.Clear();
            comboBoxPorts.Items.AddRange(SerialPort.GetPortNames());
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            SavePositionToSettings();

            if (!connected_ || udp_ == null)
                return;
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (!connected_ || udp_ == null)
                return;

            string message = $"btn=Y click\n";
            byte[] data = Encoding.ASCII.GetBytes(message);
            udp_.Send(data, data.Length, remoteEp_);
        }

        private void btnUdonMenu_Click(object sender, EventArgs e)
        {
            if (!connected_ || udp_ == null)
                return;
            string message = $"btn=Y long\n";
            byte[] data = Encoding.ASCII.GetBytes(message);
            udp_.Send(data, data.Length, remoteEp_);
        }

        /// <summary>
        /// 指定した軸で正弦波状に位置を揺らします（デバッグ・動作確認用）。
        /// </summary>
        /// <param name="axis">軸 (0:X, 1:Y, 2:Z)</param>
        /// <param name="amplitudeMm">振幅 (mm)</param>
        /// <param name="roundTrips">往復回数</param>
        /// <param name="secondsPerRoundTrip">1往復にかかる時間(秒)</param>
        /// <param name="intervalMs">更新間隔(ms)</param>
        void OscillateXBySin(
            int axis = 0,
            double amplitudeMm = 100.0,
            int roundTrips = 10,
            double secondsPerRoundTrip = 2.0,
            int intervalMs = 20
    )
        {

            double omega = 2.0 * Math.PI / secondsPerRoundTrip;
            double totalTime = roundTrips * secondsPerRoundTrip;

            var sw = System.Diagnostics.Stopwatch.StartNew();

            if (axis == 0)
            {
                double baseX = x_mm_; // 現在位置を基準にする
                while (true)
                {
                    double t = sw.Elapsed.TotalSeconds;
                    if (t > totalTime)
                        break;

                    x_mm_ = (int)(baseX + amplitudeMm * Math.Sin(omega * t));
                    SendCurrentPosition();

                    Thread.Sleep(intervalMs);
                }

                // 最後に元の位置へ戻す（推奨）
                x_mm_ = (int)baseX;
                SendCurrentPosition();
            }
            if (axis == 1)
            {
                double baseY = y_mm_; // 現在位置を基準にする
                while (true)
                {
                    double t = sw.Elapsed.TotalSeconds;
                    if (t > totalTime)
                        break;

                    y_mm_ = (int)(baseY + amplitudeMm * Math.Sin(omega * t));
                    SendCurrentPosition();

                    Thread.Sleep(intervalMs);
                }

                // 最後に元の位置へ戻す（推奨）
                y_mm_ = (int)baseY;
                SendCurrentPosition();
            }
            if (axis == 2)
            {
                double baseZ = z_mm_; // 現在位置を基準にする
                while (true)
                {
                    double t = sw.Elapsed.TotalSeconds;
                    if (t > totalTime)
                        break;

                    z_mm_ = (int)(baseZ + amplitudeMm * Math.Sin(omega * t));
                    SendCurrentPosition();

                    Thread.Sleep(intervalMs);
                }

                // 最後に元の位置へ戻す（推奨）
                z_mm_ = (int)baseZ;
                SendCurrentPosition();
            }

        }

        private void btnNade_Click(object sender, EventArgs e)
        {
            if (!connected_ || udp_ == null)
                return;
            OscillateXBySin(0);
        }

        private void btnNadeY_Click(object sender, EventArgs e)
        {
            if (!connected_ || udp_ == null)
                return;
            OscillateXBySin(1);

        }

        private void btnNadeZ_Click(object sender, EventArgs e)
        {
            if (!connected_ || udp_ == null)
                return;
            OscillateXBySin(2);

        }


        /// <summary>
        /// 現在の回転クォータニオンに、指定した軸・角度の回転を左から乗算します。
        /// </summary>
        /// <param name="deg">回転角度 (度)</param>
        /// <param name="ax">回転軸 X成分</param>
        /// <param name="ay">回転軸 Y成分</param>
        /// <param name="az">回転軸 Z成分</param>
        private void ApplyAxisAngleDeg(double deg, double ax, double ay, double az)
        {
            double rad = deg * Math.PI / 180.0;
            double half = rad * 0.5;

            // 念のため軸を正規化
            double len = Math.Sqrt(ax * ax + ay * ay + az * az);
            if (len <= 0.0) return;
            ax /= len; ay /= len; az /= len;

            // 軸角→クォータニオン（wxyz）
            double s = Math.Sin(half);
            double qW = Math.Cos(half);
            double qX = ax * s;
            double qY = ay * s;
            double qZ = az * s;

            // q = qDelta ⊗ q（左掛けで積み上げ）
            MultiplyLeft(qW, qX, qY, qZ);

            // 数値誤差対策
            Normalize();
        }

        /// <summary>
        /// 現在の (w_ro,x_ro,y_ro,z_ro) に対し、左から a を掛ける： q ← a ⊗ q
        /// </summary>
        private void MultiplyLeft(double aW, double aX, double aY, double aZ)
        {
            double w = w_ro_, x = x_ro_, y = y_ro_, z = z_ro_;

            w_ro_ = aW * w - aX * x - aY * y - aZ * z;
            x_ro_ = aW * x + aX * w + aY * z - aZ * y;
            y_ro_ = aW * y - aX * z + aY * w + aZ * x;
            z_ro_ = aW * z + aX * y - aY * x + aZ * w;
        }

        private void Normalize()
        {
            double n = Math.Sqrt(w_ro_ * w_ro_ + x_ro_ * x_ro_ + y_ro_ * y_ro_ + z_ro_ * z_ro_);
            if (n <= 0.0)
            {
                w_ro_ = 1.0; x_ro_ = 0.0; y_ro_ = 0.0; z_ro_ = 0.0;
                return;
            }
            w_ro_ /= n; x_ro_ /= n; y_ro_ /= n; z_ro_ /= n;
        }

        private void btnXRP_Click(object sender, EventArgs e)
        {
            if (!connected_ || udp_ == null)
                return;
            ApplyAxisAngleDeg(5, 1.0, 0.0, 0.0);
            SendCurrentPosition();
        }

        private void btnXRM_Click_1(object sender, EventArgs e)
        {
            if (!connected_ || udp_ == null)
                return;
            ApplyAxisAngleDeg(-5, 1.0, 0.0, 0.0);
            SendCurrentPosition();

        }

        private void btnYRP_Click(object sender, EventArgs e)
        {
            if (!connected_ || udp_ == null)
                return;
            ApplyAxisAngleDeg(5, 0.0, 1.0, 0.0);
            SendCurrentPosition();

        }

        private void btnYRM_Click_1(object sender, EventArgs e)
        {
            if (!connected_ || udp_ == null)
                return;
            ApplyAxisAngleDeg(-5, 0.0, 1.0, 0.0);
            SendCurrentPosition();

        }

        private void btnZRP_Click(object sender, EventArgs e)
        {
            if (!connected_ || udp_ == null)
                return;
            ApplyAxisAngleDeg(5, 0.0, 0.0, 1.0);
            SendCurrentPosition();

        }

        private void btnZRM_Click_1(object sender, EventArgs e)
        {
            if (!connected_ || udp_ == null)
                return;
            ApplyAxisAngleDeg(-5, 0.0, 0.0, 1.0);
            SendCurrentPosition();
        }

        private void btnPosReset_Click(object sender, EventArgs e)
        {
            if (!connected_ || udp_ == null)
                return;
            x_mm_ = 0;
            y_mm_ = 0;
            z_mm_ = 0;
            SendCurrentPosition();

        }

        private void btnRotReset_Click(object sender, EventArgs e)
        {
            if (!connected_ || udp_ == null)
                return;
            w_ro_ = 1.0;
            x_ro_ = 0.0;
            y_ro_ = 0.0;
            z_ro_ = 0.0;
            SendCurrentPosition();
        }

        private void txtXPos_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtYPos_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtZPos_TextChanged(object sender, EventArgs e)
        {

        }

        private void qzss_connect_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen)
            {
                serialPort.PortName = comboBoxPorts.SelectedItem.ToString();
                serialPort.Open();
                qzss_connect.Text = "切断";
            }
            else
            {
                serialPort.Close();
                qzss_connect.Text = "接続";
            }
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int bytes = serialPort.BytesToRead;
            byte[] buffer = new byte[bytes];
            serialPort.Read(buffer, 0, bytes);

            ubxBuffer.AddRange(buffer);
            ParseUbxMessages();

        }

        /// <summary>
        /// 受信バッファからUBXメッセージを抽出し、解析メソッドを呼び出します。
        /// </summary>
        private void ParseUbxMessages()
        {
            while (ubxBuffer.Count >= 8) // 最低ヘッダ長
            {
                // UBXヘッダ検索
                int start = ubxBuffer.IndexOf(0xB5);
                if (start < 0 || start + 1 >= ubxBuffer.Count || ubxBuffer[start + 1] != 0x62)
                {
                    ubxBuffer.Clear();
                    return;
                }

                if (start > 0)
                    ubxBuffer.RemoveRange(0, start);

                if (ubxBuffer.Count < 6)
                    return;

                byte cls = ubxBuffer[2];
                byte id = ubxBuffer[3];
                int len = ubxBuffer[4] | (ubxBuffer[5] << 8);

                if (ubxBuffer.Count < 6 + len + 2)
                    return; // フレーム未完成

                byte[] payload = ubxBuffer.Skip(6).Take(len).ToArray();

                // NAV-HPPOSLLH の場合
                if (cls == 0x01 && id == 0x14)
                {
                    ParseNavHpposllh(payload);
                    UpdatePosition();
                    SendCurrentPosition();
                }

                // NAV-PVT の場合
                if (cls == 0x01 && id == 0x07)
                {
                    ParseNavPvt(payload);
                }

                // フレーム削除
                ubxBuffer.RemoveRange(0, 6 + len + 2);
            }
        }

        /// <summary>
        /// UBX-NAV-HPPOSLLH (高精度測位解) メッセージの解析
        /// </summary>
        private void ParseNavHpposllh(byte[] p)
        {
            // 32bit整数部
            int lat32 = BitConverter.ToInt32(p, 8);
            int lon32 = BitConverter.ToInt32(p, 12);
            int height32 = BitConverter.ToInt32(p, 16); // 楕円体高

            // 高精度成分 (8bit符号付き)
            sbyte lonHp = (sbyte)p[24];
            sbyte latHp = (sbyte)p[25];
            sbyte heightHp = (sbyte)p[26];

            // 精度情報 (mm単位)
            uint hAccmm = BitConverter.ToUInt32(p, 28);
            uint vAccmm = BitConverter.ToUInt32(p, 32);

            // 実際の値に変換
            lon = (lon32 * 1e-7) + (lonHp * 1e-9);
            lat = (lat32 * 1e-7) + (latHp * 1e-9);
            alt = (height32 + (heightHp * 0.1)) / 1000.0;

            hacc = hAccmm / 10000.0;
            vacc = vAccmm / 10000.0;

            // UI へ反映（Invoke 必須）
            this.Invoke(new Action(() =>
            {
                txtLat.Text = lat.ToString("F9");
                txtLon.Text = lon.ToString("F9");
                txtAlt.Text = alt.ToString("F3");
                txthacc.Text = hacc.ToString("F3");
                txtvacc.Text = vacc.ToString("F3");
            }));
        }

        /// <summary>
        /// UBX-NAV-PVT (測位解と時刻) メッセージの解析
        /// </summary>
        private void ParseNavPvt(byte[] p)
        {
            if (p.Length < 30) return; // 念のため

            byte fixType = p[20];
            byte flags = p[21];

            int carrSoln = (flags >> 6) & 0x03;

            // 測位状態をUIに表示
            this.Invoke(new Action(() =>
            {
                switch (fixType)
                {
                    case 0:
                        txtfix_mode.Text = "No Fix";
                        txtfix_mode.BackColor = Color.MistyRose;
                        break;
                    case 1:
                        txtfix_mode.Text = "Dead Reckoning only";
                        txtfix_mode.BackColor = Color.LightGray;
                        break;
                    case 2:
                        txtfix_mode.Text = "2D";
                        txtfix_mode.BackColor = Color.LemonChiffon;
                        break;
                    case 3:
                        switch (carrSoln)
                        {
                            case 0:
                                txtfix_mode.Text = "3D";
                                txtfix_mode.BackColor = Color.LemonChiffon;
                                break;
                            case 1:
                                txtfix_mode.Text = "CLAS Float";
                                txtfix_mode.BackColor = Color.PaleGreen;
                                break;
                            case 2:
                                txtfix_mode.Text = "CLAS Fix";
                                txtfix_mode.BackColor = Color.MediumSpringGreen;
                                break;
                            default:
                                txtfix_mode.Text = "Unknown";
                                txtfix_mode.BackColor = Color.LightGray;
                                break;
                        }
                        break;

                    default:
                        txtfix_mode.Text = "Unknown";
                        txtfix_mode.BackColor = Color.LightGray;
                        break;
                }
            }));
        }


        private void Calibration_L_Click(object sender, EventArgs e)
        {
            L_lat = lat;
            L_lon = lon;
            L_alt = alt;
            txt_L_Lat.Text = L_lat.ToString("F9");
            txt_L_Lon.Text = L_lon.ToString("F9");
        }

        private void Calibration_R_Click(object sender, EventArgs e)
        {
            R_lat = lat;
            R_lon = lon;
            R_alt = alt;
            txt_R_Lat.Text = R_lat.ToString("F9");
            txt_R_Lon.Text = R_lon.ToString("F9");
        }


        /// <summary>
        /// 取得したGNSS座標(LLH)を、キャリブレーション基準点を用いてローカル座標(ENUベース)に変換します。
        /// </summary>
        private void UpdatePosition()
        {
            // キャリブレーション未実施の場合は処理しない
            if (L_lat == 0.0 || R_lat == 0.0)
            {
                qzssX = 0.0;
                qzssY = 0.0;
                qzssZ = 0.0;
                return;
            }

            // 1. 原点計算 (左右のキャリブレーションポイントの中点を原点とします)
            double lat0 = (L_lat + R_lat) / 2.0;
            double lon0 = (L_lon + R_lon) / 2.0;
            double alt0 = (L_alt + R_alt) / 2.0;

            // 2. 緯度経度をメートルに換算する係数を計算 (WGS84楕円体近似)
            // 原点付近での1度あたりの距離(m)を算出します
            double lat0Rad = lat0 * Math.PI / 180.0;
            double a = 6378137.0; // 赤道半径
            double f = 1.0 / 298.257223563; // 扁平率
            double e2 = f * (2.0 - f); // 第一離心率の2乗

            double sinLat = Math.Sin(lat0Rad);
            double cosLat = Math.Cos(lat0Rad);
            double W = Math.Sqrt(1.0 - e2 * sinLat * sinLat);

            double M = a * (1.0 - e2) / (W * W * W); // 子午線曲率半径 (南北)
            double N = a / W;                        // 卯酉線曲率半径 (東西)

            // 1度あたりのメートル数
            double mPerLat = M * (Math.PI / 180.0);
            double mPerLon = N * cosLat * (Math.PI / 180.0);

            // 3. 左右方向(基準)ベクトルの計算
            // L->R のベクトルをENU(East, North)平面上のメートル単位で計算
            double vecLR_East = (R_lon - L_lon) * mPerLon;
            double vecLR_North = (R_lat - L_lat) * mPerLat;

            // ベクトルの長さ（LとRの間の距離）
            double baselineLength = Math.Sqrt(vecLR_East * vecLR_East + vecLR_North * vecLR_North);

            // 安全対策：距離が近すぎる場合はゼロ除算を防ぐ
            if (baselineLength < 0.001) return;

            // 単位ベクトル化 (これがローカル座標系のX軸方向になります)
            // cosTheta, sinTheta に相当
            double uX = vecLR_East / baselineLength;
            double uY = vecLR_North / baselineLength;

            // 4. 現在位置の原点からのオフセットを計算 (メートル単位)
            // 現在の受信座標(lat, lon, alt)を使用
            double dEast = (lon - lon0) * mPerLon;
            double dNorth =(lat - lat0) * mPerLat;
            double dUp = alt - alt0;

            // 5. LLH座標系からローカル座標系(OpenVR HMD座標系)へ変換
            // 原点を(lat0,lon0,alt0)
            // +X軸　右方向 (L->Rベクトルの方向)
            // +Y軸　上方向 (高さ方向)
            // +Z軸　後ろ方向 

            // 回転行列の適用
            // X (Right): 東西南北ベクトルと基準ベクトルの内積 (射影)
            qzssX = dEast * uX + dNorth * uY;

            // Y (Up): 単純な高さの差分
            qzssY = dUp;

            // Z (Back): X軸と直交する成分
            qzssZ = +dEast * uY - dNorth * uX;


            this.Invoke(new Action(() =>
            {
                pos_X.Text = qzssX.ToString("F3");
                pos_Y.Text = qzssY.ToString("F3");
                pos_Z.Text = qzssZ.ToString("F3");
            }));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                try
                {
                    serialPort.Dispose();
                    serialPort.Close();
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
}
