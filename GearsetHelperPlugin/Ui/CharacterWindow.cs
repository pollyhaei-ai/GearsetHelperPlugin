using Dalamud;

using Dalamud.Game.ClientState.Objects.SubKinds;

using FFXIVClientStructs.FFXIV.Client.Game;

namespace GearsetHelperPlugin.Ui;

internal class CharacterWindow : BaseWindow {

	protected override string Name => Localization.Localize("gui.character", "Character");

	internal CharacterWindow(PluginUI ui) : base(ui) {
		Visible = Ui.Plugin.Config.CharacterOpen;
	}

	public override void Dispose(bool disposing) {

	}

	protected override void OnVisibleChange() {
		Ui.Plugin.Config.CharacterOpen = Visible;
		Ui.Plugin.Config.Save();

		if (Visible && Ui.Plugin.Config.CharacterAutoFood && CachedSet is not null)
			UpdateFoodData();
	}

	internal void Draw() {
		if (!Ui.Plugin.Config.DisplayWithCharacter) {
			CachedSet = null;
			return;
		}

		var charAddon = Ui.Plugin.GameGui.GetAddonByName("Character", 1);
		if (charAddon.IsNull || !charAddon.IsVisible) {
			SelectedFood = null;
			SelectedMedicine = null;
			SelectedGroupBonus = 0;
			CachedSet = null;
			return;
		}

		DrawWindow(
			Ui.Plugin.Config.AttachToCharacter,
			Ui.Plugin.Config.AttachSideCharacter,
			charAddon.X,
			charAddon.Y,
			(ushort) charAddon.ScaledWidth
		);
	}

	protected override unsafe InventoryContainer* GetInventoryContainer() {
		return InventoryManager.Instance()->GetInventoryContainer(InventoryType.EquippedItems);
	}

	protected override bool HasEquipment() {
		return true;
	}

	protected override unsafe IPlayerCharacter? GetActor() {
		// The local player is easy to deal with.
		return Ui.Plugin.ObjectTable.LocalPlayer;
	}

}
