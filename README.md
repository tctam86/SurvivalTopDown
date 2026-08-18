# Survival Top-down

Game survival góc nhìn từ trên xuống (top-down): nhân vật di chuyển, bắn quái theo từng wave, lên cấp và nâng chỉ số.

## Unity version

- Unity **6000.3.22f1** (Unity 6)
- Template: 3D (Universal Render Pipeline)

## Cách mở và chạy

1. Mở project bằng Unity Hub (bản 6000.3.22f1 trở lên).
2. Mở scene: `Assets/Scenes/SampleScene.unity`.
3. Nhấn **Play** — wave đầu sẽ tự spawn quanh người chơi.

> Scene mặc định hiện tại là `SampleScene.unity`, có thể chạy ngay không cần cấu hình thêm.
> Nếu scene không phải scene chính, mở `SampleScene` là đủ.

## Điều khiển

| Thao tác | Mô tả |
|---|---|
| **Joystick ảo** (trái màn hình) | Di chuyển nhân vật |
| **Nút Shoot** (phải, dưới) | Bắn 3 viên hình nón (±15°), tốc hồi charge 3 giây, cách phát 0.5s, tối đa 3 charge |
| **Nút Bomb** | Đặt bom, 2 giây sau nổ 50 dmg bán kính 5, cooldown 12s |
| **Nút Dash** | Lướt về phía trước 3 unit trong 0.5s, cuối lướt nổ 15 dmg bán kính 3, cooldown 6s |
| (PC test) WASD / tay cầm | Di chuyển tương đương joystick (optional) |

Sẽ quái đuổi theo người chơi, tấn công khi vào tầm. Bắn, bom, dash để tiêu diệt.

## Cơ chế chính

- **Sát thương:** nhân vật nhận `rawDamage - armor` (tối thiểu 0). Đạn/bom gây `rawDamage * (1 + dmgMultiplier)`.
- **Charge bắn:** mỗi phát 3 viên, mỗi viên 10 dmg; hồi +1 charge mỗi 3 giây; chống spam 0.5s.
- **Quái đánh gần:** 220 HP, tốc 3, tấn công nón 50° tầm 1.3, 30 dmg mỗi đòn, đứng im 1 giây giữa 2 đòn.
- **Quái đánh xa:** 180 HP, tốc 2.7, dừng cách người chơi 3 unit để bắn đạn độc (tốc 10, bay tối đa 5 unit). Độc: 30 dmg/giây, tick ngay lúc trúng và mỗi giây trong 3 giây (tổng 4 tick). Dính lại khi đang độc thì reset thời gian, không stack.
- **Wave:** mỗi wave spawn ngẫu nhiên 3–4 quái đánh gần + 1–2 quái đánh xa. Wave kế chỉ spawn khi đã tiêu diệt toàn bộ quái wave hiện tại.
- **EXP & lên cấp:** giết 1 quái +30 EXP. Đủ 100 EXP lên 1 cấp (EXP dư giữ lại). Mỗi cấp: +40 HP hiện tại & tối đa, +2 giáp, +0.1 Damage Multiplier.
- **UI:** thanh máu người chơi và quái (trên đầu), level, joystick ảo, 3 nút kỹ năng kèm hiển thị cooldown.

## Cấu hình chỉ số

Toàn bộ chỉ số tập trung trong các ScriptableObject, dễ chỉnh khi không cần sửa code:

- `Assets/Scripts/Player/PlayerConfig.asset` — HP, tốc độ, sát thương skill, cooldown, charge.
- `Assets/Scripts/Enemy/MeleeEnemyConfig.asset` — chỉ số quái đánh gần.
- `Assets/Scripts/Enemy/RangedEnemyConfig.asset` — chỉ số quái đánh xa.

Việc chỉnh số chỉ giới hạn ở các asset trên, không cần đụng code.

## Cấu trúc thư mục

```
Assets/
├── Scripts/
│   ├── Player/      PlayerConfig, PlayerMovement, PlayerHealth, ShootingSkill, BombSkill, DashSkill, ExperienceSystem, PoisonEffect, CameraFollow, PlayerInputHandler
│   ├── Enemy/       EnemyBase, MeleeEnemy, RangedEnemy, EnemyHealth, EnemyConfig
│   ├── Skills/      Bullet, PoisonBullet, Bomb
│   ├── Systems/     WaveManager
│   └── UI/          VirtualJoystick, HealthBarUI, EnemyHealthBarUI, LevelUI, SkillButtonUI(mỗi skill), Billboard
├── Prefabs/         Player, EnemyMelee, EnemyRanged, Bullet, PoisonBullet, Bomb
└── Scenes/          SampleScene
```

## Danh sách đã làm / chưa làm

### Đã làm

- [x] Nhân vật di chuyển bằng joystick ảo, xoay 180°/giây, camera follow.
- [x] Công thức sát thương (giáp giảm, dmg multiplier tăng).
- [x] Bắn 3 viên hình nón + hệ thống charge.
- [x] Đặt bom (2s nổ, AoE 5) + dash rồi nổ (AoE 3).
- [x] Quái đánh gần (nón 50°, tầm 1.3) + quái đánh xa (đạn độc, 4 tick, refresh không stack).
- [x] Hệ thống wave (3–4 gần + 1–2 xa), chỉ spawn wave kế sau khi clear.
- [x] EXP + lên cấp (+40 HP, +2 giáp, +0.1 dmg).
- [x] UI: thanh máu player/quái, level, joystick, nút kỹ năng + cooldown.
- [x] Chỉ số tập trung trong ScriptableObject config, reset mỗi lần Play mới.

### Chưa làm

- [ ] Camera shake.
- [ ] VFX/âm thanh.
- [ ] Object pooling đạn

## Build
**Build Windows:** File → Build Settings → Platform: Windows (x86_64) → Build.
