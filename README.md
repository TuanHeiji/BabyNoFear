# Tên Dự Án
Tên dự án: "Game 2D pixel BabyNoFear"


## Level 1
<p align="center">
  <img src="images/Level1Pic1.jpg" width="800"/>
</p>
<p align="center">
  <img src="images/Level1Pic2.jpg" width="800"/>
</p>
<p align="center">
  <img src="images/Level1Pic3.jpg" width="800"/>
</p>

## Level 2
<p align="center">
  <img src="images/Level2Pic1.jpg" width="800"/>
</p>
<p align="center">
  <img src="images/Level2Pic2.jpg" width="800"/>
</p>
<p align="center">
  <img src="images/Level2Pic3.jpg" width="800"/>
</p>


## Công Nghệ Sử Dụng
- C#
- Unity hub 
- Unity 6 (version 6000.0.55f1) 
- Visual studio 2022

## Cấu Trúc Dự Án
```
GreenNightmare/
│
├── Assets/                         # Chứa mã nguồn, ảnh, scene, script, v.v.
│   │ 
│   ├── Sprites                     # Chứa tài nguyên game
│   ├── Scripts                     # Chứa mã nguồn C# điều khiển logic game
│   ├── Scenes                      # Chứa các màn chơi và giao diện
│   ├── TextMesh Pro                # Chứa tài nguyên và cài đặt của plugin TextMesh Pro dùng để hiển thị text đẹp
│   ├── Physric2d                   # Các tài nguyên vật lý: collider, layer (tránh nhân vật dính vào map)
│   ├── Tile                        # Chứa tilemap, tile palette, dữ liệu map lưới 2D
│   ├── Animations                  # Chứa file animation (*.anim) dùng để tạo chuyển động
│   ├── Audio                       # Chứa âm thanh: nhạc nền, hiệu ứng âm thanh
│   ├── Fonts                       # Chứa font chữ (dùng cho UI, TextMesh Pro...)
│   ├── Prefabs                     # Các đối tượng được đóng gói sẵn (nhân vật, quái vật, item,...)
│   ├── Images                      # Chứa ảnh demo game
│   └── Settings                    # Chứa các ScriptableObject, config game
│   
├── Packages/                       # Chứa thông tin các gói đang dùng (manifest, lock)
├── ProjectSettings                 # Chứa các cài đặt dự án Unity (build, input, tag...)
├── GreenNightmare.sln              # Cấu trúc giải pháp, liên quan đến IDE, nếu bạn dùng VS/C#
├── Assembly-CSharp.csproj          # Cấu trúc giải pháp, liên quan đến IDE 
└── README.md                       # File mô tả dự án
```
## Cách Chạy Dự Án

1. Clone project frontend:
- git clone https://github.com/TuanHeiji/BabyNoFear.git

2. Cài Unity hub và chọn editor version: 6000.0.55f1

3. Import vào unity


## Tác Giả

Tuấn Heiji