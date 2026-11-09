![](images/icon.png)

# Gearset Helper Plugin（台服 / Dalamud API 13）

台灣版《最終幻想XIV》用的 [KhloeLeclair/GearsetHelperPlugin](https://github.com/KhloeLeclair/GearsetHelperPlugin)（作者 Khloe Leclair）。這個分支給 [cycleapple/XIVTCLauncher](https://github.com/cycleapple/XIVTCLauncher) 搭配 [yanmucorp/Dalamud](https://github.com/yanmucorp/Dalamud) **API 13 / .NET 9**。

它會在角色與查看視窗旁顯示能力值、食物、鑲嵌與降等同步的估算，並把裝備匯出到 Etro、Ariyala、XivGear 或 Teamcraft 清單。

**不要裝到官方 Dalamud API 14／15**（國際服 XIVLauncher）。這個組建只給台服。

## 下載

- 發行頁：https://github.com/pollyhaei-ai/GearsetHelperPlugin/releases/tag/api13-tw-2.6.0.1
- 壓縮檔：[GearsetHelperPlugin-api13-tw-2.6.0.1.zip](https://github.com/pollyhaei-ai/GearsetHelperPlugin/releases/download/api13-tw-2.6.0.1/GearsetHelperPlugin-api13-tw-2.6.0.1.zip)

版本 `2.6.0.1`，組建自 yanmucorp Dalamud `13.0.0.16`（`Dalamud.NET.Sdk` 13.1.0）。壓縮檔裡是一個 `GearsetHelperPlugin` 資料夾，含 `GearsetHelperPlugin.dll`、`GearsetHelperPlugin.json`（`DalamudApiLevel` 13）與 `i18n/`。

## 安裝

1. 在 XIVTCLauncher 啟用 Dalamud，進過一次遊戲讓資料夾出現，然後**關閉遊戲**。
2. 下載上面的 zip，解壓到你登入時使用的 dev plugins 資料夾。`dll` 和 `json` 要在同一層，不要再多包一層：

```text
%AppData%\FFXIVSimpleLauncher\Dalamud\Config\devPlugins\GearsetHelperPlugin\
```

帳號如果用自己的插件設定檔，改放：

```text
%AppData%\FFXIVSimpleLauncher\Profiles\<設定檔 ID>\Dalamud\devPlugins\GearsetHelperPlugin\
```

3. 進遊戲後用 `/xldev` 啟用 Gearset Helper Plugin。同一個視窗可以重新載入。主視窗與設定按鈕都開設定。

## 語言

Dalamud 的介面語言選 **繁體中文**（語言代碼 `tw`）時，會載入 `i18n/tw.json`。可在 `/xlsettings` 裡切換。遊戲裡的物品與能力名稱來自用戶端資料，本來就是台服用語；這個翻譯只涵蓋插件自己的介面。

沒有選繁體中文時，Dalamud 可能回報 `en` 或 `zh`（作業系統是繁中時，兩字母代碼常常是 `zh`）。這個組建沒有 `zh.json`，那些情況會用程式裡的英文。請在 Dalamud 設定裡明確選繁體中文。

## 使用狀況

擁有者已在台服進遊戲看過，載入與基本使用暫時沒有問題。下面幾項仍請留意：

- **品級同步 795**：等級 100 以上、又沒有另外指定品級同步時，`EquipmentSet.UpdateSync` 仍把同步品級寫死成 **795**。這是上游針對國際服寫的數字，這次沒有改。台服若已超過該品級，請在視窗裡手動填品級同步，不要只靠預設值。
- **戰鬥公式**：`Data.cs` 的 `LevelStats` 與 `COEFFICIENTS` 是黃金的遺產時期的社群公式，沒有為台服重算。介面上若出現「公式尚未針對黃金的遺產更新」是上游原文。
- **簽名掛鉤**：`GameFunctions` 裡有一條查看視窗的簽名，但 `Plugin` 沒有建立它，所以目前不會去掃那段特徵碼。

## 來源

基於 [KhloeLeclair/GearsetHelperPlugin](https://github.com/KhloeLeclair/GearsetHelperPlugin)，作者 Khloe Leclair。授權是本倉庫的 [MIT](LICENSE)。Copyright (c) 2022 Khloe Leclair。

## 自行編譯

`Dalamud.NET.Sdk` 13.1.0 對本機的 `Dalamud.dll` 編譯。把 `DALAMUD_HOME` 指到 yanmucorp Dalamud `13.0.0.16` 裡含有 `Dalamud.dll` 的目錄（[發行檔](https://github.com/yanmucorp/Dalamud/releases) 的 `latest.7z`，或 XIVTCLauncher 的 `Injector`）。沒有設定時，SDK 會去官方啟動器的 `%AppData%\XIVLauncher\addon\Hooks\dev\`。

1. 安裝 .NET 9 SDK。`global.json` 指定 `9.0.100`，並在 9.0 功能帶內向前相容。
2. 在這個目錄執行 `dotnet build -c Release -p:EnableWindowsTargeting=true`。

專案目標是 `net9.0-windows7.0`。建置會把 `GearsetHelperPlugin/i18n` 複製到輸出目錄，執行時從組件旁邊的 `i18n` 讀取。

## 截圖

以下是上游介面，這個分支的插件文字在繁體中文設定下會換成 `tw.json`。

![](images/image1.png)
![](images/image2.png)
![](images/image3.png)

## English

Fork of [KhloeLeclair/GearsetHelperPlugin](https://github.com/KhloeLeclair/GearsetHelperPlugin) by Khloe Leclair (MIT), for the Traditional Chinese client: yanmucorp Dalamud API 13 / .NET 9 and XIVTCLauncher. Do not install this on official Dalamud API 14 or 15.

Download [GearsetHelperPlugin-api13-tw-2.6.0.1.zip](https://github.com/pollyhaei-ai/GearsetHelperPlugin/releases/download/api13-tw-2.6.0.1/GearsetHelperPlugin-api13-tw-2.6.0.1.zip) and extract `GearsetHelperPlugin\` into `%AppData%\FFXIVSimpleLauncher\Dalamud\Config\devPlugins\` (or `Profiles\<id>\Dalamud\devPlugins\` when the account uses its own profile). Enable it in `/xldev`.

Set Dalamud’s UI language to Traditional Chinese (`/xlsettings`). That language code is `tw`, which loads `i18n/tw.json`. Item names still come from the game client. Leaving the language on the default can report `zh` on a Traditional Chinese Windows install and will fall back to English.

The owner checked basic load and use in-game on the Taiwan client and reported no problems for now. The level ≥100 item-level sync fallback is still the upstream value **795**. Dawntrail combat coefficients in `Data.cs` were not rewritten. The examine signature hook in `GameFunctions` is not constructed, so it does not run.
